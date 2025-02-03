using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica
{
    public partial class modalAgendarOrcamento : Form
    {
        private FormOrcamentos _formOrcamentos;
        private string nomeCliente;
        private string orcamentoID;
        private string valorTotal;
        public modalAgendarOrcamento(FormOrcamentos formOrcamentos, string orcamentoID, string nomeCliente, string valorTotal)
        {
            InitializeComponent();
            _formOrcamentos = formOrcamentos;
            this.nomeCliente = nomeCliente;
            this.orcamentoID = orcamentoID;  
            this.valorTotal = valorTotal;
            lblNomeCliente.Text = nomeCliente;
            lblValorTotal.Text = valorTotal;
        }
        private void CarregarHorariosDisponiveis(string dataAgendamentoFormatada)
        {

            try
            {
                // Limpa os botões existentes no FlowLayoutPanel
                flowLayoutPanelHorarios.Controls.Clear();

                // Lista de horários disponíveis (das 08:00 às 18:00)
                List<TimeSpan> horariosDisponiveis = new List<TimeSpan>
                {
                    new TimeSpan(8, 0, 0),
                    new TimeSpan(9, 0, 0),
                    new TimeSpan(10, 0, 0),
                    new TimeSpan(11, 0, 0),
                    new TimeSpan(12, 0, 0),
                    new TimeSpan(13, 0, 0),
                    new TimeSpan(14, 0, 0),
                    new TimeSpan(15, 0, 0),
                    new TimeSpan(16, 0, 0),
                    new TimeSpan(17, 0, 0),
                    new TimeSpan(18, 0, 0)
                };

                // Obter horários já agendados do banco de dados
                List<TimeSpan> horariosOcupados = ObterHorariosOcupados(dataAgendamentoFormatada);

                // Criar botões para cada horário disponível
                foreach (var horario in horariosDisponiveis)
                {
                    // Verifica se o horário está ocupado
                    bool horarioOcupado = horariosOcupados.Contains(horario);

                    // Cria o botão
                    Button btnHorario = new Button
                    {
                        Text = horario.ToString(@"hh\:mm"), // Texto do botão (horário)
                        Tag = horario, // Armazenar o horário no Tag do botão
                        Enabled = !horarioOcupado, // Desabilitar se o horário estiver ocupado
                        Width = 100, // Largura do botão
                        Height = 40, // Altura do botão
                    };

                    // Depuração: Exibe o horário disponível e se está ocupado
                    //MessageBox.Show($"Horário disponível: {horario}, Ocupado: {horarioOcupado}");

                    // Associar evento de clique
                    btnHorario.Click += BtnHorario_Click;

                    // Adicionar o botão ao FlowLayoutPanel
                    flowLayoutPanelHorarios.Controls.Add(btnHorario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar horários disponíveis: {ex.Message}");
            }
        }

        private List<TimeSpan> ObterHorariosOcupados(string dataAgendamentoFormatada)
        {
            List<TimeSpan> horariosOcupados = new List<TimeSpan>();

            // String de conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Criando as datas concatenadas com horário inicial e final
            string dataInicial = dataAgendamentoFormatada + " 00:00:00";
            string dataFinal = dataAgendamentoFormatada + " 23:59:59";

            // Query com filtro de data usando BETWEEN
            string query = @"
                SELECT DataHora FROM dbo.Agendamentos
                WHERE Status <> 'Cancelado' 
                AND DataHora BETWEEN @DataInicial AND @DataFinal";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Passando os parâmetros corretamente
                        command.Parameters.AddWithValue("@DataInicial", DateTime.Parse(dataInicial));
                        command.Parameters.AddWithValue("@DataFinal", DateTime.Parse(dataFinal));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime dataHora = (DateTime)reader["DataHora"];
                                TimeSpan horario = dataHora.TimeOfDay;
                                horariosOcupados.Add(horario);

                                Console.WriteLine($"Horário ocupado: {horario}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao consultar horários ocupados: {ex.Message}");
                }
            }

            return horariosOcupados;
        }


        private void BtnHorario_Click(object sender, EventArgs e)
        {
            Button btnHorario = sender as Button;
            if (btnHorario != null)
            {
                TimeSpan horarioSelecionado = (TimeSpan)btnHorario.Tag;
                string dataComBarras = dataAgendamento.Text;
                DateTime data = DateTime.ParseExact(dataComBarras, "dd/MM/yyyy", null);
                string dataAgendamentoFormatada = data.ToString("yyyy-MM-dd");

                // Exibir mensagem de confirmação
                DialogResult result = MessageBox.Show($"Deseja agendar o cliente {lblNomeCliente.Text} para o dia {dataAgendamentoFormatada} às {horarioSelecionado}?", "Confirmar Agendamento", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Criar o agendamento com os parâmetros corretos
                    CriarAgendamento(orcamentoID, nomeCliente, valorTotal, dataAgendamentoFormatada, horarioSelecionado);
                }
            }
        }


        private void CriarAgendamento(string orcamentoID, string nomeCliente, string valorTotal, string dataAgendamentoFormatada, TimeSpan horarioSelecionado)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 1. Obter ClienteID do Orçamento
                        int clienteID = 0;
                        string queryCliente = "SELECT ClienteID FROM Orcamentos WHERE OrcamentoID = @OrcamentoID";
                        using (SqlCommand cmd = new SqlCommand(queryCliente, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@OrcamentoID", orcamentoID);
                            object result = cmd.ExecuteScalar();
                            if (result != null) clienteID = Convert.ToInt32(result);
                        }

                        // 2. Criar DataHora do Agendamento (Data + Horário)
                        DateTime dataHoraAgendamento = DateTime.ParseExact(dataAgendamentoFormatada, "yyyy-MM-dd", null).Add(horarioSelecionado);

                        // 3. Criar Agendamento
                        string queryAgendamento = @"
                    INSERT INTO Agendamentos (ClienteID, OrcamentoID, DataHora, Status)
                    VALUES (@ClienteID, @OrcamentoID, @DataHora, 'Agendado');
                    SELECT SCOPE_IDENTITY();";

                        int novoAgendamentoID;
                        using (SqlCommand cmd = new SqlCommand(queryAgendamento, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                            cmd.Parameters.AddWithValue("@OrcamentoID", orcamentoID);
                            cmd.Parameters.AddWithValue("@DataHora", dataHoraAgendamento);
                            novoAgendamentoID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 4. Inserir os Itens do Orçamento no Agendamento_Itens
                        string queryItens = @"
                    INSERT INTO Agendamento_Itens (AgendamentoID, Tipo, IDReferencia, Quantidade, Preco)
                    SELECT @NovoAgendamentoID, Tipo, IDReferencia, Quantidade, Preco
                    FROM Orcamento_Itens
                    WHERE OrcamentoID = @OrcamentoID";

                        using (SqlCommand cmd = new SqlCommand(queryItens, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NovoAgendamentoID", novoAgendamentoID);
                            cmd.Parameters.AddWithValue("@OrcamentoID", orcamentoID);
                            cmd.ExecuteNonQuery();
                        }

                        // 5. Atualizar Estoque dos Produtos
                        string queryEstoque = @"
                    UPDATE Produtos
                    SET Estoque = Estoque - oi.Quantidade
                    FROM Produtos p
                    JOIN Orcamento_Itens oi ON p.ProdutoID = oi.IDReferencia
                    WHERE oi.OrcamentoID = @OrcamentoID";

                        using (SqlCommand cmd = new SqlCommand(queryEstoque, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@OrcamentoID", orcamentoID);
                            cmd.ExecuteNonQuery();
                        }

                        // 6. Atualizar o status do orçamento para "Concluído"
                        string updateQuery = "UPDATE dbo.Orcamentos SET Status = 'Concluido' WHERE OrcamentoID = @OrcamentoID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@OrcamentoID", orcamentoID);
                            updateCommand.ExecuteNonQuery();
                        }

                        // Commit da transação
                        transaction.Commit();
                        MessageBox.Show($"Agendamento criado com sucesso!");
                        _formOrcamentos.LoadData();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Erro ao criar agendamento: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao conectar ao banco de dados: {ex.Message}");
                }
            }
        }


        private void btnCarregarHorariosDisponiveis_Click(object sender, EventArgs e)
        {
            // Verifica se o campo de data está preenchido
            if (string.IsNullOrWhiteSpace(dataAgendamento.Text))
            {
                MessageBox.Show("Por favor, preencha a data do agendamento!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Interrompe a execução se o campo estiver vazio
            }

            try
            {
                panelDetalhes.Visible = false;

                // Converte a data para o formato correto
                string dataComBarras = dataAgendamento.Text;
                DateTime data = DateTime.ParseExact(dataComBarras, "dd/MM/yyyy", null);
                string dataAgendamentoFormatada = data.ToString("yyyy-MM-dd");

                // Chama a função para carregar os horários disponíveis
                CarregarHorariosDisponiveis(dataAgendamentoFormatada);
            }
            catch (FormatException)
            {
                MessageBox.Show("Formato de data inválido! Use o formato correto: dd/MM/yyyy", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
