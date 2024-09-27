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
using System.Windows.Forms.VisualStyles;

namespace Inovaclinica
{

    public partial class modalVisualizarClientes : Form
    {

        private FormClientes _formClientes;


        public modalVisualizarClientes(string clientID, FormClientes formClientes)
        {
            InitializeComponent();

            this.clientID = clientID;
            BuscarClientePeloID(clientID);
            _formClientes = formClientes;

            tabPage1.Text = "Informações";
            tabPage2.Text = "Convênio";
            tabPage3.Text = "Procedimentos";
            tabPage4.Text = "Agendamentos";

        }

        private string clientID;

        private void BuscarClientePeloID(string codigo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT ClienteID, Nome, CPF, DataNascimento, Telefone, Endereco, Ativo, DataCadastro, Email, Estado, CEP, Genero, Observacoes, Cidade FROM Clientes WHERE ClienteID = @ClienteID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClienteID", codigo); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    labelClienteID.Text = reader["ClienteID"].ToString();
                    lblNomeCliente.Text = reader["Nome"].ToString();
                    textBoxNomeCliente.Text = reader["Nome"].ToString();
                    maskTextBoxCpfCliente.Text = reader["CPF"].ToString();
                    dateTimePickerDataNascimento.Value = Convert.ToDateTime(reader["DataNascimento"]);
                    textBoxTelefone.Text = reader["Telefone"].ToString();
                    textBoxEndereco.Text = reader["Endereco"].ToString();
                    checkBoxAtivoCliente.Checked = reader.GetBoolean(reader.GetOrdinal("Ativo"));
                    DateTime dataCadastro = Convert.ToDateTime(reader["DataCadastro"]);
                    labelDataCadastro.Text = dataCadastro.ToString("dd/MM/yyyy HH:mm");
                    txtBoxEmailCliente.Text = reader["Email"].ToString();
                    visualizarEstado.Text = reader["Estado"].ToString();
                    visualizarCepCliente.Text = reader["CEP"].ToString();
                    visualizarObservacaoCliente.Text = reader["Observacoes"].ToString();
                    visualizarGeneroCliente.Text = reader["Genero"].ToString();
                    visualizarCidadeCliente.Text = reader["Cidade"].ToString();
                }
            }
        }

        public string FormatarCPF(string CPF)
        {
            // Remove caracteres não numéricos
            CPF = new string(CPF.Where(char.IsDigit).ToArray());

            // Formata o CPF
            if (CPF.Length == 11)
            {
                return string.Format("{0}.{1}.{2}-{3}",
                    CPF.Substring(0, 3),
                    CPF.Substring(3, 3),
                    CPF.Substring(6, 3),
                    CPF.Substring(9, 2));
            }
            return CPF; // Retorna sem formatação se não for válido
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelarAlteracaoCliente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvarAlteracaoCliente_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"UPDATE Clientes SET Nome = @Nome, CPF = @CPF, DataNascimento = @DataNascimento, Telefone = @Telefone, Ativo = @Ativo, Email = @Email, Estado = @Estado, CEP = @CEP, Observacoes = @Observacoes, Genero = @Genero, Cidade = @Cidade WHERE ClienteID = @ClientID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", textBoxNomeCliente.Text);
                command.Parameters.AddWithValue("@CPF", maskTextBoxCpfCliente.Text);
                command.Parameters.AddWithValue("@DataNascimento", dateTimePickerDataNascimento.Value);
                command.Parameters.AddWithValue("@Telefone", textBoxTelefone.Text);
                command.Parameters.AddWithValue("@ClientID", this.clientID);
                command.Parameters.AddWithValue("@Ativo", checkBoxAtivoCliente.Checked);
                command.Parameters.AddWithValue("@Email", txtBoxEmailCliente.Text);
                command.Parameters.AddWithValue("CEP", visualizarCepCliente.Text);
                command.Parameters.AddWithValue("Estado", visualizarEstado.Text);
                command.Parameters.AddWithValue("Genero", visualizarGeneroCliente.Text);
                command.Parameters.AddWithValue("Observacoes", visualizarObservacaoCliente.Text);
                command.Parameters.AddWithValue("Cidade", visualizarCidadeCliente.Text);


                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Executa o comando SQL

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cliente atualizado com sucesso!");
                    _formClientes.LoadData();
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi feita.");
                }
            }

        }

    }

}
