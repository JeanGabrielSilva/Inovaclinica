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
    public partial class modalListarClientes : Form
    {
        public string ClienteCodigo { get; private set; }
        public string ClienteNome { get; private set; }
        public modalListarClientes(string consulta)
        {
            InitializeComponent();
            barraPesquisarClientes.Text = consulta;
            CustomizeDataGridView();
            BuscarClientesPeloNome(consulta);
            dataGridClientes.CellDoubleClick += DataGridClientes_CellDoubleClick;
        }

        private void BuscarClientesPeloNome(string consulta)
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
                        // Define a fonte de dados do DataGridView como o DataTable
                        dataGridClientes.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        private void DataGridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que o usuário clicou em uma linha válida
            {
                ClienteCodigo = dataGridClientes.Rows[e.RowIndex].Cells["Código"].Value.ToString();
                ClienteNome = dataGridClientes.Rows[e.RowIndex].Cells["Nome"].Value.ToString();

                this.DialogResult = DialogResult.OK; // Indica que a seleção foi feita corretamente
                this.Close(); // Fecha o formulário modal
            }
        }


        private void btnConfirmarSelecaoCliente_Click(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedRows.Count > 0)
            {
                ClienteCodigo = dataGridClientes.SelectedRows[0].Cells["Código"].Value.ToString();
                ClienteNome = dataGridClientes.SelectedRows[0].Cells["Nome"].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um cliente antes de continuar.");
            }
        }

        private void CustomizeDataGridView()
        {
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
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
            //dataGridClientes.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridClientes.RowHeadersVisible = false;
            dataGridClientes.ReadOnly = true;
            dataGridClientes.EnableHeadersVisualStyles = false;
            dataGridClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridClientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridClientes.BackgroundColor = SystemColors.Control;
            dataGridClientes.RowTemplate.Height = 40;

            // Adicionando uma coluna de seleção (opcional)
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Selecionar";
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridClientes.Columns.Insert(0, checkBoxColumn);

            // Impede a alteração no layout do datagrid

            dataGridClientes.AllowUserToAddRows = false;
            dataGridClientes.AllowUserToDeleteRows = false;
            dataGridClientes.AllowUserToOrderColumns = false;
            dataGridClientes.AllowUserToResizeRows = false;
            dataGridClientes.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btnCancelarAlteracaoCliente_Click(object sender, EventArgs e)
        {
            this.Close();   
        }
    }
}
