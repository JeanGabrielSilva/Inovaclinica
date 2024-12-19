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
    public partial class modalExcluirLancamentoFinanceiro : Form {

        private FormFinanceiro _formFinanceiro;
        private string lancamentoID;


        public modalExcluirLancamentoFinanceiro(FormFinanceiro formFinanceiro, string lancamentoID) {
            InitializeComponent();
            this.lancamentoID = lancamentoID;
            BuscarLancamentoFinanceiroPeloID(lancamentoID);
            _formFinanceiro = formFinanceiro;
        }

        private void modalExcluirLancamentoFinanceiro_Load(object sender, EventArgs e) {
            
        }

        private void BuscarLancamentoFinanceiroPeloID(string lancamentoID) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = $"SELECT Descricao, Valor, Tipo, Categoria From Financeiro WHERE ID = @lancamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@lancamentoID", lancamentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    labelVisualizaDescricaoLancamento.Text = reader["Descricao"].ToString();
                    labelVisualizaCategoriaLancamento.Text = reader["Categoria"].ToString();
                    labelVisualizarTipoLancamento.Text = reader["Tipo"].ToString();
                    labelVisualizarValorLancamento.Text = $"R$ {Convert.ToDecimal(reader["Valor"]).ToString("N2")}";

                    string tipo = reader["Tipo"].ToString();
                }
            }
        }

        private void btnFecharModalExcluirLancamento_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnAceitarEliminarLancamento_Click(object sender, EventArgs e) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = $"Delete from Financeiro WHERE ID = @lancamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@lancamentoID", lancamentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                _formFinanceiro.LoadData();
                this.Close();
                


            }
            

            }
    }
}
