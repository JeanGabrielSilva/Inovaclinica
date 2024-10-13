using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Inovaclinica
{
    public partial class modalAdicionarProduto : Form
    {
        private FormProdutos _formProdutos;
        public modalAdicionarProduto(FormProdutos formProdutos)
        {
            InitializeComponent();
            tabPage1.Text = "Informações";
            _formProdutos = formProdutos;
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            string NomeProduto = nomeProduto.Text;
            string DescricaoDetalhadaProduto = descricaoProduto.Text;
            string EstoqueProduto = estoqueProduto.Text;
            int Estoque = int.Parse(EstoqueProduto);
            string dataComBarras = dataValidadeProduto.Text;
            DateTime data = DateTime.ParseExact(dataComBarras, "dd/MM/yyyy", null);
            string DataValidade = data.ToString("yyyy-MM-dd"); 
            decimal PrecoProduto = precoProduto.Value;


            AdicionarProduto(NomeProduto, DescricaoDetalhadaProduto, Estoque, DataValidade, PrecoProduto);
        }

        private void AdicionarProduto(string NomeProduto, string DescricaoDetalhadaProduto, int Estoque, string DataValidade, decimal PrecoProduto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            string query = "INSERT INTO Produtos (Nome, Descricao, Preco, DataCadastro, DataValidade, Estoque) VALUES (@NomeProduto, @DescricaoDetalhadaProduto, @PrecoProduto, @DataCadastro, @DataValidade, @Estoque)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Cria o comando SQL para a inserção
                SqlCommand command = new SqlCommand(query, connection);
                // Define os parâmetros da query
                command.Parameters.AddWithValue("@NomeProduto", NomeProduto);
                command.Parameters.AddWithValue("@DescricaoDetalhadaProduto", DescricaoDetalhadaProduto);
                command.Parameters.AddWithValue("@Estoque", Estoque);
                command.Parameters.AddWithValue("@DataCadastro", DateTime.Now);
                command.Parameters.AddWithValue("@DataValidade", DataValidade);
                command.Parameters.AddWithValue("@PrecoProduto", PrecoProduto);


                try
                {
                    // Abre a conexão
                    connection.Open();
                    // Executa o comando
                    int result = command.ExecuteNonQuery();

                    // Verifica se o cliente foi inserido com sucesso
                    if (result > 0)
                    {
                        MessageBox.Show($"Produto {NomeProduto} adicionado com sucesso!");
                        // Limpa os campos de entrada
                        nomeProduto.Clear();
                        descricaoProduto.Clear();
                        dataValidadeProduto.Clear();
                        _formProdutos.LoadData();
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

        private void btnCancelarAlteracaoProduto_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
