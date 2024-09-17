using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Inovaclinica {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        // Este método será chamado quando o formulário for carregado
        private void Form1_Load(object sender, EventArgs e) {
            LoadData(); // Chama o método para carregar os dados
        }

        // Método para carregar os dados do banco de dados e preencher o DataGridView
        private void LoadData() {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = "SELECT * FROM Produtos";

            // Usa SqlConnection e SqlDataAdapter para preencher o DataGridView
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    // Abre a conexão
                    connection.Open();

                    // SqlDataAdapter para executar a consulta e preencher os dados
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados retornados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define a fonte de dados do DataGridView como o DataTable
                    dataGridView1.DataSource = dataTable;
                } catch (Exception ex) {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        // Método chamado ao clicar numa célula (opcional, pode ser removido)
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            // Esse método será chamado quando o usuário clicar numa célula do DataGridView
        }



        private void btnAdicionarProduto_Click(object sender, EventArgs e) {
            // Captura os valores inseridos pelo usuário
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;
            decimal preco;

            // Verifica se o preço é válido
            if (!decimal.TryParse(txtPreco.Text, out preco)) {
                MessageBox.Show("Por favor, insira um valor válido para o preço.");
                return;
            }

            // Chama o método para adicionar o produto ao banco de dados
            AdicionarProduto(nome, descricao, preco);
        }

        // Método para adicionar o produto no banco de dados
        private void AdicionarProduto(string nome, string descricao, decimal preco) {
            // Obtém a string de conexão do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Define a query SQL de inserção
            string query = "INSERT INTO Produtos (Nome, Descricao, Preco, DataCadastro) VALUES (@Nome, @Descricao, @Preco, @DataCadastro)";

            
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                // Cria o comando SQL para a inserção
                SqlCommand command = new SqlCommand(query, connection);
                // Define os parâmetros da query
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Descricao", descricao);
                command.Parameters.AddWithValue("@Preco", preco);
                command.Parameters.AddWithValue("@DataCadastro", DateTime.Now);

                try {
                    // Abre a conexão
                    connection.Open();
                    // Executa o comando
                    int result = command.ExecuteNonQuery();

                    // Verifica se o produto foi inserido com sucesso
                    if (result > 0) {
                        MessageBox.Show("Produto adicionado com sucesso!");
                        // Limpa os campos de entrada
                        txtNome.Clear();
                        txtDescricao.Clear();
                        txtPreco.Clear();
                    } else {
                        MessageBox.Show("Ocorreu um erro ao adicionar o produto.");
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"Erro: {ex.Message}");
                }


            }
        }

    }
}
