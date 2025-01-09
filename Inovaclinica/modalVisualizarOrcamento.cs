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

    public partial class modalVisualizarOrcamento : Form {

        private FormOrcamentos _formOrcamentos;
        public modalVisualizarOrcamento(string orcamentoID,FormOrcamentos formOrcamentos) {
            InitializeComponent();
            BuscarOrcamentoPeloID(orcamentoID);
            _formOrcamentos = formOrcamentos;
        }

        private void BuscarOrcamentoPeloID(string orcamentoID) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = $"Select O.OrcamentoID as [Código], C.Nome as [Nome], O.DataCriacao [Data de Criação], O.Status, O.ValorTotal as [Valor Total] from Orcamentos as O inner join Clientes as C on O.ClienteID = C.ClienteID WHERE OrcamentoID = @OrcamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrcamentoID", orcamentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    txtBoxNomeCliente.Text = reader["Nome"].ToString();
                }
            }
        }

        private void modalVisualizarOrcamento_Load(object sender, EventArgs e) {

        }
    }
}
