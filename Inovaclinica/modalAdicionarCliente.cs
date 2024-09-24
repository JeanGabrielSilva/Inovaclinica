using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica {
    public partial class modalAdicionarCliente : Form {

        private FormClientes _formClientes;

        public modalAdicionarCliente(FormClientes formClientes) {
            InitializeComponent();

            _formClientes = formClientes;

        }

        private void btnAdicionarCliente_Click(object sender, EventArgs e) {
            // Captura os valores inseridos pelo usuário
            string nome = nomeAdicionarCliente.Text;
            string cpf = cpfAdicionarCliente.Text;
            DateTime dataNascimento = dataNascimentoAdicionarCliente.Value;

            cpf = FormatarCPF(cpf);

            AdicionarCliente(nome, cpf, dataNascimento);

        }

        private string FormatarCPF(string cpf) {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Formata o CPF
            if (cpf.Length == 11) {
                return string.Format("{0}.{1}.{2}-{3}",
                    cpf.Substring(0, 3),
                    cpf.Substring(3, 3),
                    cpf.Substring(6, 3),
                    cpf.Substring(9, 2));
            }
            return cpf; // Retorna sem formatação se não for válido
        }


        // Método para adicionar o cliente no banco de dados
        private void AdicionarCliente(string nome, string cpf, DateTime dataNascimento) {
            // Obtém a string de conexão do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Define a query SQL de inserção
            string query = "INSERT INTO Clientes (Nome, CPF, DataNascimento, DataCadastro) VALUES (@Nome, @cpf, @DataNascimento, @DataCadastro)";


            using (SqlConnection connection = new SqlConnection(connectionString)) {
                // Cria o comando SQL para a inserção
                SqlCommand command = new SqlCommand(query, connection);
                // Define os parâmetros da query
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@CPF", cpf);
                command.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                command.Parameters.AddWithValue("@DataCadastro", DateTime.Now);

                try {
                    // Abre a conexão
                    connection.Open();
                    // Executa o comando
                    int result = command.ExecuteNonQuery();

                    // Verifica se o cliente foi inserido com sucesso
                    if (result > 0) {
                        MessageBox.Show($"Cliente {nome} adicionado com sucesso!");
                        // Limpa os campos de entrada
                        nomeAdicionarCliente.Clear();
                        cpfAdicionarCliente.Clear();
                        _formClientes.LoadData();
                    } else {
                        MessageBox.Show("Ocorreu um erro ao adicionar o cliente.");
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }
    }
}
