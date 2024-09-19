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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            // Inicializa os componentes do formulário
            InitializeComponent();

            // Associa o evento Load ao método correto
            this.Load += new EventHandler(FormClientes_Load);
            CustomizeDataGridView();

        }

        // Este método será chamado quando o formulário FormClientes for carregado
        private void FormClientes_Load(object sender, EventArgs e)
        {
            LoadData(); // Chama o método para carregar os dados
        }

        // Método para carregar os dados do banco de dados e preencher o DataGridView
        private void LoadData()
        {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = "SELECT ClienteID as ID, Nome, CPF, DataNascimento as [Data Nascimento], Telefone FROM Clientes";

            // Usa SqlConnection e SqlDataAdapter para preencher o DataGridView
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // SqlDataAdapter para executar a consulta e preencher os dados
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados retornados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define a fonte de dados do DataGridView como o DataTable
                    dataGridClientes.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }



        }

        private void CustomizeDataGridView()
        {
            dataGridClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dataGridClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridClientes.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridClientes.Font, FontStyle.Bold);

            dataGridClientes.DefaultCellStyle.BackColor = Color.LightGray;
            dataGridClientes.DefaultCellStyle.ForeColor = Color.Black;
            dataGridClientes.DefaultCellStyle.SelectionBackColor = Color.DarkBlue;
            dataGridClientes.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridClientes.GridColor = Color.LightGray;
            dataGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridClientes.Dock = DockStyle.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}