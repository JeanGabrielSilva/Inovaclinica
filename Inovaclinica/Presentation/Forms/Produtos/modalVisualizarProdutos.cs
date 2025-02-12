using System;
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

namespace Inovaclinica
{
    public partial class modalVisualizarProdutos : Form
    {
        private FormProdutos _formProdutos;
        public modalVisualizarProdutos(string produtoID, FormProdutos formProdutos)
        {
            InitializeComponent();
            BuscarProdutoPeloID(produtoID);
            tabPage1.Text = "Informações";
            tabPage2.Text = "Histórico";
            _formProdutos = formProdutos;    
        }



        private void BuscarProdutoPeloID(string produtoID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT ProdutoID, Nome, Descricao, DataValidade, Ativo, DataCadastro, Preco, Estoque From Produtos WHERE ProdutoID = @ProdutoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProdutoID", produtoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    labelProdutoID.Text = reader["ProdutoID"].ToString();
                    lblNomeProduto.Text = reader["Nome"].ToString();
                    nomeProduto.Text = reader["Nome"].ToString();
                    descricaoProduto.Text = reader["Descricao"].ToString();
                    DateTime dataValidade = Convert.ToDateTime(reader["DataValidade"]);
                    dataValidadeProduto.Text = dataValidade.ToString("dd/MM/yyyy");
                    checkBoxAtivoProduto.Checked = reader.GetBoolean(reader.GetOrdinal("Ativo"));
                    DateTime dataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                    labelDataCadastro.Text = dataCadastro.ToString("dd/MM/yyyy HH:mm");
                    precoProduto.Text = reader["Preco"].ToString();
                    estoqueProduto.Text = reader["Estoque"].ToString();
                }
            }
        }

        private void btnCancelarAlteracaoProduto_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSalvarAlteracaoProduto_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DateTime dataValidade = DateTime.ParseExact(dataValidadeProduto.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dataValidadeFormatada = dataValidade.ToString("yyyy-MM-dd");
                string query = $"UPDATE Produtos SET Nome = @NomeProduto, Descricao = @DescricaoDetalhadaProduto, Estoque = @Estoque, DataValidade = @DataValidade, Ativo = @Ativo, Preco = @PrecoProduto WHERE ProdutoID = @ProdutoID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NomeProduto", nomeProduto.Text);
                command.Parameters.AddWithValue("@DescricaoDetalhadaProduto", descricaoProduto.Text);
                command.Parameters.AddWithValue("@Estoque", estoqueProduto.Text);
                command.Parameters.AddWithValue("@DataValidade", dataValidadeFormatada);
                decimal PrecoProduto = precoProduto.Value;
                command.Parameters.AddWithValue("@PrecoProduto", PrecoProduto);
                command.Parameters.AddWithValue("@ProdutoID", labelProdutoID.Text);
                command.Parameters.AddWithValue("@Ativo", checkBoxAtivoProduto.Checked);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Executa o comando SQL

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Produto atualizado com sucesso!");
                    _formProdutos.LoadData();
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi feita.");
                }
            }
        }

        private void modalVisualizarProdutos_Load(object sender, EventArgs e) {

        }
    }
}
