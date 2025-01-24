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
    public partial class modalAdicionarOrcamento : Form
    {
        public modalAdicionarOrcamento()
        {
            InitializeComponent();
            barraPesquisarClientes.KeyDown += new KeyEventHandler(barraPesquisarClientes_KeyDown);
        }

        private void barraPesquisarClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Cancela o som padrão de "ding"
                var consulta = barraPesquisarClientes.Text.Trim();
                BuscarCliente(consulta);
            }
        }

        private void BuscarCliente(string consulta)
        {
            // Conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Consulta SQL com parâmetro
            string queryBuscar = "SELECT ClienteID AS Código, Nome, CPF, DataNascimento AS [Data Nascimento], Telefone " +
                                 "FROM Clientes WHERE Nome LIKE @Consulta and Ativo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Cria o comando SQL
                    using (SqlCommand command = new SqlCommand(queryBuscar, connection))
                    {
                        // Adiciona o parâmetro
                        command.Parameters.AddWithValue("@Consulta", "%" + consulta + "%");

                        // SqlDataAdapter para preencher o DataTable
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        // DataTable para armazenar os dados
                        DataTable dataTable = new DataTable();

                        // Preenche o DataTable com os dados retornados
                        dataAdapter.Fill(dataTable);

                        // Verifica se há um único cliente
                        if (dataTable.Rows.Count == 1)
                        {
                            // Preenche o nome do cliente e o ID
                            lblNomeCliente.Text = dataTable.Rows[0]["Nome"].ToString();
                            int clienteId = Convert.ToInt32(dataTable.Rows[0]["Código"]); // Certifique-se que "Código" está correto
                            MessageBox.Show($"Cliente encontrado:\nID: {clienteId}\nNome: {dataTable.Rows[0]["Nome"]}");

                            // Armazena o ID do cliente para uso futuro
                            var ClienteId = clienteId; // Variável de instância ou propriedade
                        }
                        else if (dataTable.Rows.Count > 1)
                        {
                            // Se houver vários resultados, exibe a modal passando os dados
                            ExibirModalListarClientes();
                        }
                        else
                        {
                            // Caso não encontre nenhum resultado
                            MessageBox.Show("Cliente não encontrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        // Método para exibir a modal de clientes encontrados
        private void ExibirModalListarClientes()
        {
            // Aqui você abre a modal passando a lista de clientes para o controle que a lista os exibe
            modalListarClientes modallistarClientes = new modalListarClientes();
            modallistarClientes.Text = "Listar Clientes";
            modallistarClientes.StartPosition = FormStartPosition.CenterParent;
            modallistarClientes.ShowDialog();
        }

    }
}
