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
        public modalAgendarOrcamento()
        {
            InitializeComponent();
            
        }
        private void CarregarHorariosDisponiveis()
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
                List<TimeSpan> horariosOcupados = ObterHorariosOcupados();

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

        private List<TimeSpan> ObterHorariosOcupados()
        {
            List<TimeSpan> horariosOcupados = new List<TimeSpan>();

            // String de conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query para obter os horários agendados
            string query = "SELECT DataHora FROM dbo.Agendamentos WHERE Status <> 'Cancelado'"; // Filtra agendamentos não cancelados

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Executa a consulta
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Obtém a DataHora do agendamento
                                DateTime dataHora = (DateTime)reader["DataHora"];

                                // Extrai o horário (TimeSpan) da DataHora
                                TimeSpan horario = dataHora.TimeOfDay;

                                // Adiciona o horário à lista de horários ocupados
                                horariosOcupados.Add(horario);

                                // Depuração: Exibe o horário ocupado extraído
                                Console.WriteLine($"Horário ocupado: {horario}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Trata erros (opcional)
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

                // Exibir mensagem de confirmação
                DialogResult result = MessageBox.Show($"Deseja agendar para {horarioSelecionado}?", "Confirmar Agendamento", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Criar o agendamento no banco de dados
                    CriarAgendamento(horarioSelecionado);

                    // Atualizar a lista de horários disponíveis
                    CarregarHorariosDisponiveis();
                }
            }
        }

        private void CriarAgendamento(TimeSpan horario)
        {
            // Lógica para criar o agendamento no banco de dados
            // Exemplo fictício:
            MessageBox.Show($"Agendamento criado para {horario}");
        }

        private void btnCarregarHorariosDisponiveis_Click(object sender, EventArgs e)
        {
            panelDetalhes.Visible = false;
            CarregarHorariosDisponiveis();
        }
    }
}
