using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica {
    public partial class modalVisualizarProcedimento : Form {
        private FormProcedimentos _formProcedimentos;
        public modalVisualizarProcedimento(string procedimentoID, FormProcedimentos formProcedimentos) {
            InitializeComponent();
            _formProcedimentos = formProcedimentos;
            tabPage1.Text = "Informações";
            BuscarProcedientoPeloID(procedimentoID);
        }

        private void BuscarProcedientoPeloID(string procedimentoID) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = $"SELECT ProcedimentoID, Nome, Descricao, Preco, Ativo From Procedimentos WHERE ProcedimentoID = @ProcedimentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProcedimentoID", procedimentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    labelProcedimentoID.Text = reader["ProcedimentoID"].ToString();
                    lblNomeProcedimento.Text = reader["Nome"].ToString();
                    nomeProcedimento.Text = reader["Nome"].ToString();
                    descricaoProcedimento.Text = reader["Descricao"].ToString();
                    checkBoxAtivoProcedimento.Checked = reader.GetBoolean(reader.GetOrdinal("Ativo"));
                    precoProcedimento.Text = reader["Preco"].ToString();
                }
            }
        }

        private void btnCancelarAlteracaoProcedimento_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSalvarAlteracaoProcedimento_Click(object sender, EventArgs e) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;



            using (SqlConnection connection = new SqlConnection(connectionString)) {

                string query = $"UPDATE Procedimentos SET Nome = @NomeProcedimento, Descricao = @DescricaoDetalhadaProcedimento, Preco = @PrecoProcedimento, Ativo = @Ativo WHERE procedimentoID = @procedimentoID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeProcedimento", nomeProcedimento.Text);
                command.Parameters.AddWithValue("@DescricaoDetalhadaProcedimento", descricaoProcedimento.Text);
                decimal PrecoProcedimento = precoProcedimento.Value;
                command.Parameters.AddWithValue("@PrecoProcedimento", PrecoProcedimento);
                command.Parameters.AddWithValue("@procedimentoID", labelProcedimentoID.Text);
                command.Parameters.AddWithValue("@Ativo", checkBoxAtivoProcedimento.Checked);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Executa o comando SQL

                if (rowsAffected > 0) {
                    MessageBox.Show("Procedimento atualizado com sucesso!");
                    _formProcedimentos.LoadData();
                } else {
                    MessageBox.Show("Nenhuma alteração foi feita.");
                }
            }
        }
    }
}
