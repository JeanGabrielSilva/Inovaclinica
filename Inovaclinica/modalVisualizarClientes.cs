using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica {

    public partial class modalVisualizarClientes : Form {

        private FormClientes _formClientes;


        public modalVisualizarClientes(string clientID, FormClientes formClientes) {
            InitializeComponent();
            
            this.clientID = clientID;
            BuscarClientePeloID(clientID);
            _formClientes = formClientes;

        }

        private string clientID;

        private void BuscarClientePeloID(string codigo) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = $"SELECT Nome, CPF, DataNascimento, Telefone, Endereco, Ativo, DataCadastro FROM Clientes WHERE ClienteID = @ClienteID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClienteID", codigo); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    textBoxNomeCliente.Text = reader["Nome"].ToString();
                    maskTextBoxCpfCliente.Text = FormatarCPF(reader["CPF"].ToString());
                    dateTimePickerDataNascimento.Value = Convert.ToDateTime(reader["DataNascimento"]);
                    textBoxTelefone.Text = reader["Telefone"].ToString();
                    textBoxEndereco.Text = reader["Endereco"].ToString();
                    checkBoxAtivoCliente.Checked = reader.GetBoolean(reader.GetOrdinal("Ativo"));
                    DateTime dataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                    labelDataCadastro.Text = dataCadastro.ToString("dd/MM/yyyy HH:MM");
                }
            }
        }

        private void lblNome_Click(object sender, EventArgs e) {
        }



        private void textBoxNomeCliente_TextChanged(object sender, EventArgs e) {

        }

        private void btnSalvarAlteracaoCliente_Click(object sender, EventArgs e) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = $"UPDATE Clientes SET Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento, Telefone = @Telefone, Ativo = @Ativo WHERE ClienteID = @ClientID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", textBoxNomeCliente.Text);
                command.Parameters.AddWithValue("@CPF", FormatarCPF(maskTextBoxCpfCliente.Text));
                command.Parameters.AddWithValue("@DataNascimento", dateTimePickerDataNascimento.Value);
                command.Parameters.AddWithValue("@Telefone", textBoxTelefone.Text);
                command.Parameters.AddWithValue("@ClientID", this.clientID);
                command.Parameters.AddWithValue("@Ativo", checkBoxAtivoCliente.Checked);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Executa o comando SQL

                if (rowsAffected > 0) {
                    MessageBox.Show("Cliente atualizado com sucesso!");
                    _formClientes.LoadData();
                } else {
                    MessageBox.Show("Nenhuma alteração foi feita.");
                }
            }
        }

        public string FormatarCPF(string CPF) {
            // Remove caracteres não numéricos
            CPF = new string(CPF.Where(char.IsDigit).ToArray());

            // Formata o CPF
            if (CPF.Length == 11) {
                return string.Format("{0}.{1}.{2}-{3}",
                    CPF.Substring(0, 3),
                    CPF.Substring(3, 3),
                    CPF.Substring(6, 3),
                    CPF.Substring(9, 2));
            }
            return CPF; // Retorna sem formatação se não for válido
        }
    }

}
