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
        public void LoadData()
        {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = "SELECT ClienteID as Código, Nome, CPF, DataNascimento as [Data Nascimento], Telefone FROM Clientes";

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
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(230, 230, 255);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            dataGridClientes.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridClientes.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridClientes.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridClientes.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridClientes.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridClientes.GridColor = gridColor;

            // Fontes
            dataGridClientes.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridClientes.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridClientes.RowHeadersVisible = false;
            dataGridClientes.EnableHeadersVisualStyles = false;
            dataGridClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Adicionando uma coluna de seleção (opcional)
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Selecionar";
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridClientes.Columns.Insert(0, checkBoxColumn);
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

        private void tablePanelMenuClientes_Paint(object sender, PaintEventArgs e) {

        }

        private void btnAbrirModalAdicionarCliente_Click(object sender, EventArgs e) {
            modalAdicionarCliente modaladicionarcliente = new modalAdicionarCliente();
            modaladicionarcliente.StartPosition = FormStartPosition.CenterParent;  
            modaladicionarcliente.ShowDialog();

        }

        private void atualizarGridClientes_Click(object sender, EventArgs e) {
            LoadData();
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            
        }
    }
}