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
            tabPage1.Text = "Informações";

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


        private void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            // Captura os valores inseridos pelo usuário
            string Nome = nomeAdicionarCliente.Text;
            string cpf = cpfAdicionarCliente.Text;
            DateTime dataNascimento = dataNascimentoAdicionarCliente.Value;
            string telefone = telefoneAdicionarCliente.Text;
            string sexo = sexoAdicionarCliente.Text;
            string cidade = cidadeAdicionarCliente.Text;
            string rua = ruaAdicionarCliente.Text;
            string cep = cepAdicionarCliente.Text;
            string estado = estadoAdicionarCliente.Text;
            string observacao = observacaoAdicionarCliente.Text;
            MessageBox.Show($"{Nome}, {cpf}, {dataNascimento}, {telefone}, {sexo}, {cidade}, {rua}, {cep}, {observacao}");
            cpf = FormatarCPF(cpf);

            AdicionarCliente(Nome, cpf, dataNascimento, telefone, sexo, cidade, rua, cep, estado, observacao);
        }


        // Método para adicionar o cliente no banco de dados
        private void AdicionarCliente(string Nome, string cpf, DateTime dataNascimento, string telefone, string sexo, string cidade, string rua, string cep, string estado, string observacao) {
            // Obtém a string de conexão do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Define a query SQL de inserção
            string query = "INSERT INTO Clientes (Nome, CPF, DataNascimento, DataCadastro, Genero, Telefone, Endereco, Cidade, Estado, CEP, Observacoes) VALUES (@Nome, @CPF, @DataNascimento, @DataCadastro, @Genero, @Telefone, @Endereco, @Cidade, @Estado, @CEP, @Observacoes)";


            using (SqlConnection connection = new SqlConnection(connectionString)) {
                // Cria o comando SQL para a inserção
                SqlCommand command = new SqlCommand(query, connection);
                // Define os parâmetros da query
                command.Parameters.AddWithValue("@Nome", Nome);
                command.Parameters.AddWithValue("@CPF", cpf);
                command.Parameters.AddWithValue("@DataNascimento", dataNascimento);
                command.Parameters.AddWithValue("@DataCadastro", DateTime.Now);
                command.Parameters.AddWithValue("@Genero", sexo);
                command.Parameters.AddWithValue("@Telefone", telefone);
                command.Parameters.AddWithValue("@Endereco", rua);
                command.Parameters.AddWithValue("@Cidade", cidade);
                command.Parameters.AddWithValue("@Estado", estado);
                command.Parameters.AddWithValue("@CEP", cep);
                command.Parameters.AddWithValue("@Observacoes", observacao);


                try {
                    // Abre a conexão
                    connection.Open();
                    // Executa o comando
                    int result = command.ExecuteNonQuery();

                    // Verifica se o cliente foi inserido com sucesso
                    if (result > 0) {
                        MessageBox.Show($"Cliente {Nome} adicionado com sucesso!");
                        // Limpa os campos de entrada
                        nomeAdicionarCliente.Clear();
                        cpfAdicionarCliente.Clear();
                        _formClientes.LoadData();
                    } else {
                        MessageBox.Show("Ocorreu um erro ao adicionar o cliente.");
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"Erro: {ex.Message}\n{ex.InnerException?.Message}");
                }
            }
        }



        private void btnCancelarAlteracaoCliente_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
    }
}
