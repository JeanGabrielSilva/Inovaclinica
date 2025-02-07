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
    public partial class modalCancelarAgendamento : Form
    {
        private FormAgendamento _formAgendamento;
        private string _agendamentoID;
        private string _dataAgendamento;
        public modalCancelarAgendamento(FormAgendamento formAgendamento, string AgendamentoID)
        {
            InitializeComponent();
            _formAgendamento = formAgendamento;
            BuscarAgendamentoPeloID(AgendamentoID);
            _agendamentoID = AgendamentoID;
        }

        private void BuscarAgendamentoPeloID(string AgendamentoID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT A.AgendamentoID, C.Nome, C.Telefone, 
                                CONVERT(varchar, A.DataHora, 23) AS DataAgendamento, O.ValorTotal
                        FROM Agendamentos A
                        INNER JOIN Clientes C ON A.ClienteID = C.ClienteID
                        LEFT JOIN Orcamentos O ON A.OrcamentoID = O.OrcamentoID
                        WHERE A.AgendamentoID = @AgendamentoID";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AgendamentoID", AgendamentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    lblAgendamentoID.Text = reader["AgendamentoID"].ToString();
                    lblCliente.Text = reader["Nome"].ToString();
                    lblTelefoneCliente.Text = reader["Telefone"].ToString();
                    lblValorAgendamento.Text = "R$ " + Convert.ToDecimal(reader["ValorTotal"]).ToString("N2");
                    _dataAgendamento = reader["DataAgendamento"].ToString(); // Salva a data do banco
                }
            }
        }

        private void AtualizarStatusParaCancelado(string AgendamentoID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Agendamentos SET Status = 'Cancelado' WHERE AgendamentoID = @AgendamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AgendamentoID", AgendamentoID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        private void btnFecharModalCancelarAgendamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceitarCancelarAgendamento_Click(object sender, EventArgs e)
        {
            AtualizarStatusParaCancelado(_agendamentoID);
            MessageBox.Show("Agendamento cancelado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _formAgendamento.LoadData(_dataAgendamento);
            this.Close();
        }
    }
}
