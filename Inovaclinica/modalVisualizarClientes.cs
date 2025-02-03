using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Markup;

namespace Inovaclinica
{

    public partial class modalVisualizarClientes : Form
    {

        private FormClientes _formClientes;


        public modalVisualizarClientes(string clientID, FormClientes formClientes)
        {
            InitializeComponent();

            this.clientID = clientID;
            BuscarClientePeloID(clientID);
            _formClientes = formClientes;

            tabPage1.Text = "Informações";
            tabPage2.Text = "Orçamentos";
            tabPage3.Text = "Agendamentos";
            CarregarAgendamentosCliente(clientID);
            CarregarOrcamentosCliente(clientID);
            CustomizeDataGridView();
        }

        private string clientID;

        private void BuscarClientePeloID(string codigo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT ClienteID, Nome, CPF, DataNascimento, Telefone, Endereco, Ativo, DataCadastro, Email, Estado, CEP, Genero, Observacoes, Cidade FROM Clientes WHERE ClienteID = @ClienteID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClienteID", codigo); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    labelClienteID.Text = reader["ClienteID"].ToString();
                    lblNomeCliente.Text = reader["Nome"].ToString();
                    textBoxNomeCliente.Text = reader["Nome"].ToString();
                    maskTextBoxCpfCliente.Text = reader["CPF"].ToString();
                    dateTimePickerDataNascimento.Value = Convert.ToDateTime(reader["DataNascimento"]);
                    textBoxTelefone.Text = reader["Telefone"].ToString();
                    textBoxEndereco.Text = reader["Endereco"].ToString();
                    checkBoxAtivoCliente.Checked = reader.GetBoolean(reader.GetOrdinal("Ativo"));
                    DateTime dataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                    labelDataCadastro.Text = dataCadastro.ToString("dd/MM/yyyy HH:mm");
                    txtBoxEmailCliente.Text = reader["Email"].ToString();
                    visualizarEstado.Text = reader["Estado"].ToString();
                    visualizarCepCliente.Text = reader["CEP"].ToString();
                    visualizarObservacaoCliente.Text = reader["Observacoes"].ToString();
                    visualizarGeneroCliente.Text = reader["Genero"].ToString();
                    visualizarCidadeCliente.Text = reader["Cidade"].ToString();
                }
            }
        }

        public string FormatarCPF(string CPF)
        {
            // Remove caracteres não numéricos
            CPF = new string(CPF.Where(char.IsDigit).ToArray());

            // Formata o CPF
            if (CPF.Length == 11)
            {
                return string.Format("{0}.{1}.{2}-{3}",
                    CPF.Substring(0, 3),
                    CPF.Substring(3, 3),
                    CPF.Substring(6, 3),
                    CPF.Substring(9, 2));
            }
            return CPF; // Retorna sem formatação se não for válido
        }

        private void CarregarOrcamentosCliente(string clienteID)
        {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = @"
        Select 
            O.OrcamentoID as [Código], 
            O.DataCriacao [Data de Criação], 
            O.Status, 
            O.ValorTotal as [Valor Total] 
        from 
            Orcamentos as O 
        inner join 
            Clientes as C on O.ClienteID = C.ClienteID 
        where 
            C.ClienteID = @ClienteID";

            // Usa SqlConnection e SqlDataAdapter para preencher o DataGridView
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // SqlCommand para executar a consulta com parâmetros
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ClienteID", clienteID);  // Agora, o comando usa o parâmetro corretamente

                    // SqlDataAdapter para preencher os dados
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command); // Usando o command aqui para garantir que os parâmetros sejam passados

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados retornados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define a fonte de dados do DataGridView como o DataTable
                    dataGridOrcamentosCliente.DataSource = dataTable;

                    //ApplyRowColors();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }


        private void CarregarAgendamentosCliente(string clienteID)
        {
            {
                // Obtém a string de conexão a partir do App.config
                string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

                // Query SQL para buscar os dados da tabela 'Agendamentos' com filtro de data e ordenação
                string query = @"
        SELECT 
            a.AgendamentoID AS [Código],
            a.DataHora AS [Data e Hora], 
            a.Status AS [Status], 
            ISNULL((SELECT SUM(ai.Quantidade) FROM dbo.Agendamento_Itens ai WHERE ai.AgendamentoID = a.AgendamentoID AND ai.Tipo = 'Procedimento'), 0) AS [Quantidade de Procedimentos], 
            ISNULL((SELECT SUM(ai.Quantidade) FROM dbo.Agendamento_Itens ai WHERE ai.AgendamentoID = a.AgendamentoID AND ai.Tipo = 'Produto'), 0) AS [Quantidade de Produtos], 
            o.ValorTotal AS [Valor Total] 
        FROM 
            dbo.Agendamentos a 
        JOIN 
            dbo.Clientes c ON a.ClienteID = c.ClienteID 
        LEFT JOIN 
            dbo.Orcamentos o ON a.OrcamentoID = o.OrcamentoID 
        WHERE 
            c.ClienteID = @ClienteID
        ORDER BY 
            a.DataHora ASC";

                // Usa SqlConnection e SqlDataAdapter para preencher o DataGridView
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Abre a conexão
                        connection.Open();

                        // SqlCommand para executar a consulta com parâmetros
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@ClienteID", clienteID);

                        // SqlDataAdapter para preencher os dados
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        // Cria um DataTable para armazenar os dados
                        DataTable dataTable = new DataTable();

                        // Preenche o DataTable com os dados retornados da consulta
                        dataAdapter.Fill(dataTable);

                        // Define a fonte de dados do DataGridView como o DataTable
                        dataGridAgendamentosCliente.DataSource = dataTable;

                        //ApplyRowColors();
                    }
                    catch (Exception ex)
                    {
                        // Exibe uma mensagem de erro caso ocorra uma exceção
                        MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                    }
                }
            }
        }

        private void CustomizeDataGridView()
        {
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            dataGridAgendamentosCliente.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridAgendamentosCliente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridAgendamentosCliente.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridAgendamentosCliente.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridAgendamentosCliente.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridAgendamentosCliente.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridAgendamentosCliente.GridColor = gridColor;

            // Fontes
            dataGridAgendamentosCliente.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridAgendamentosCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridAgendamentosCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridAgendamentosCliente.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridAgendamentosCliente.RowHeadersVisible = false;
            dataGridAgendamentosCliente.EnableHeadersVisualStyles = false;
            dataGridAgendamentosCliente.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridAgendamentosCliente.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridAgendamentosCliente.BackgroundColor = SystemColors.Control;
            dataGridAgendamentosCliente.RowTemplate.Height = 40;

            // Impede a alteração no layout do datagrid

            dataGridAgendamentosCliente.AllowUserToAddRows = false;
            dataGridAgendamentosCliente.AllowUserToDeleteRows = false;
            dataGridAgendamentosCliente.AllowUserToOrderColumns = false;
            dataGridAgendamentosCliente.AllowUserToResizeRows = false;
            dataGridAgendamentosCliente.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridAgendamentosCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            /// DATA GRID ORCAMENTOS

            // Aplicando as cores
            dataGridOrcamentosCliente.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridOrcamentosCliente.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridOrcamentosCliente.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridOrcamentosCliente.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridOrcamentosCliente.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridOrcamentosCliente.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridOrcamentosCliente.GridColor = gridColor;

            // Fontes
            dataGridOrcamentosCliente.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridOrcamentosCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridOrcamentosCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridOrcamentosCliente.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridOrcamentosCliente.RowHeadersVisible = false;
            dataGridOrcamentosCliente.EnableHeadersVisualStyles = false;
            dataGridOrcamentosCliente.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridOrcamentosCliente.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridOrcamentosCliente.BackgroundColor = SystemColors.Control;
            dataGridOrcamentosCliente.RowTemplate.Height = 40;

            // Impede a alteração no layout do datagrid

            dataGridOrcamentosCliente.AllowUserToAddRows = false;
            dataGridOrcamentosCliente.AllowUserToDeleteRows = false;
            dataGridOrcamentosCliente.AllowUserToOrderColumns = false;
            dataGridOrcamentosCliente.AllowUserToResizeRows = false;
            dataGridOrcamentosCliente.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridOrcamentosCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarAlteracaoCliente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvarAlteracaoCliente_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"UPDATE Clientes SET Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento, Telefone = @Telefone, Ativo = @Ativo, Email = @Email, Estado = @Estado, CEP = @CEP, Observacoes = @Observacoes, Genero = @Genero, Cidade = @Cidade WHERE ClienteID = @ClientID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", textBoxNomeCliente.Text);
                command.Parameters.AddWithValue("@CPF", maskTextBoxCpfCliente.Text);
                command.Parameters.AddWithValue("@DataNascimento", dateTimePickerDataNascimento.Value);
                command.Parameters.AddWithValue("@Telefone", textBoxTelefone.Text);
                command.Parameters.AddWithValue("@ClientID", this.clientID);
                command.Parameters.AddWithValue("@Ativo", checkBoxAtivoCliente.Checked);
                command.Parameters.AddWithValue("@Email", txtBoxEmailCliente.Text);
                command.Parameters.AddWithValue("CEP", visualizarCepCliente.Text);
                command.Parameters.AddWithValue("Estado", visualizarEstado.Text);
                command.Parameters.AddWithValue("Genero", visualizarGeneroCliente.Text);
                command.Parameters.AddWithValue("Observacoes", visualizarObservacaoCliente.Text);
                command.Parameters.AddWithValue("Cidade", visualizarCidadeCliente.Text);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Executa o comando SQL

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cliente atualizado com sucesso!");
                    _formClientes.LoadData();
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi feita.");
                }
            }

        }

    }

}
