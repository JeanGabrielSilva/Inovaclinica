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

namespace Inovaclinica {
    public partial class modalConfirmarAgendamento : Form {

        private FormAgendamento _formAgendamento;
        private string _dataAgendamento;
        public modalConfirmarAgendamento(FormAgendamento formAgendamento, string AgendamentoID) {
            InitializeComponent();

            _formAgendamento = formAgendamento;
            BuscarAgendamentoPeloID(AgendamentoID);
        }

        private void BuscarAgendamentoPeloID(string AgendamentoID) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"SELECT A.AgendamentoID, C.Nome, C.Telefone, CONVERT(varchar, A.DataHora, 23) AS DataAgendamento, O.ValorTotal
                                FROM Agendamentos A
                                INNER JOIN Clientes C ON A.ClienteID = C.ClienteID
                                LEFT JOIN Orcamentos O ON A.OrcamentoID = O.OrcamentoID
                                WHERE A.AgendamentoID = @AgendamentoID";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AgendamentoID", AgendamentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    lblAgendamentoID.Text = reader["AgendamentoID"].ToString();
                    lblCliente.Text = reader["Nome"].ToString();
                    lblTelefoneCliente.Text = reader["Telefone"].ToString();
                    lblValorAgendamento.Text = "R$ " + Convert.ToDecimal(reader["ValorTotal"]).ToString("N2");
                    _dataAgendamento = reader["DataAgendamento"].ToString(); // Salva a data do banco
                }
            }
        }

        private void AtualizarStatusParaConcluido(string AgendamentoID) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"UPDATE Agendamentos SET Status = 'Concluído' WHERE AgendamentoID = @AgendamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AgendamentoID", AgendamentoID);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
            }
        }

        private void btnFecharModalConfirmarAgendamento_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAceitarConfirmarAgendamento_Click(object sender, EventArgs e) {
            AtualizarStatusParaConcluido(lblAgendamentoID.Text);
            MessageBox.Show("Agendamento concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _formAgendamento.LoadData(_dataAgendamento);
            this.Close();
        }
    }
}
