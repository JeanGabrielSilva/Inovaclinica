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
    public partial class modalAdicionarProcedimento : Form
    {
        private FormProcedimentos _formProcedimentos; 
        public modalAdicionarProcedimento(FormProcedimentos formProcedimentos)
        {
            InitializeComponent();
            tabPage1.Text = "Informações";
            _formProcedimentos = formProcedimentos; 
        }

        private void btnAdicionarProcedimento_Click(object sender, EventArgs e)
        {
            string NomeProcedimento = nomeProcedimento.Text;
            string DescricaoDetalhadaProcedimento = descricaoProcedimento.Text;
            decimal PrecoProcedimento = precoProcedimento.Value;


            AdicionarProcedimento(NomeProcedimento, DescricaoDetalhadaProcedimento, PrecoProcedimento);
        }

        private void AdicionarProcedimento(string NomeProcedimento, string DescricaoDetalhadaProcedimento, decimal PrecoProcedimento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            string query = "INSERT INTO Procedimentos (Nome, Descricao, Preco) VALUES (@NomeProcedimento, @DescricaoDetalhadaProcedimento, @PrecoProcedimento)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Cria o comando SQL para a inserção
                SqlCommand command = new SqlCommand(query, connection);
                // Define os parâmetros da query
                command.Parameters.AddWithValue("@NomeProcedimento", NomeProcedimento);
                command.Parameters.AddWithValue("@DescricaoDetalhadaProcedimento", DescricaoDetalhadaProcedimento);
                command.Parameters.AddWithValue("@PrecoProcedimento", PrecoProcedimento);

                try
                {
                    // Abre a conexão
                    connection.Open();
                    // Executa o comando
                    int result = command.ExecuteNonQuery();

                    // Verifica se o cliente foi inserido com sucesso
                    if (result > 0)
                    {
                        MessageBox.Show($"{NomeProcedimento} adicionado com sucesso!");
                        // Limpa os campos de entrada
                        this.Close();
                        _formProcedimentos.LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao adicionar o Produto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}\n{ex.InnerException?.Message}");
                }
            }
        }

        private void btnCancelarAlteracaoProcedimento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modalAdicionarProcedimento_Load(object sender, EventArgs e) {

        }
    }


}
