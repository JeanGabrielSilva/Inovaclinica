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
    public partial class modalListarProduto : Form
    {
        public string CodigoProduto { get; private set; }
        public string NomeProduto { get; private set; }
        public string QuantidadeProduto { get; private set; }
        public string ValorUnitarioProduto { get; private set; }
        public string ValorTotalProduto { get; private set; }

        public modalListarProduto(string consulta)
        {
            InitializeComponent();
            barraPesquisarProdutos.Text = consulta;
            CustomizeDataGridView();
            BuscarProdutosPeloNome(consulta);
            dataGridProdutos.CellDoubleClick += DataGridProdutos_CellDoubleClick;
        }

        private void BuscarProdutosPeloNome(string consulta)
        {
            // Conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Consulta SQL com parâmetro
            string queryBuscar = "SELECT ProdutoID AS Código, Nome, Descricao as [Descrição], Preco as [Preço], DataValidade as [Data de Validade], Estoque FROM Produtos WHERE Nome LIKE @Consulta and Ativo = 1";

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
                        dataGridProdutos.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        private void DataGridProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que o usuário clicou em uma linha válida
            {
                CodigoProduto = dataGridProdutos.Rows[e.RowIndex].Cells["Código"].Value.ToString();
                NomeProduto = dataGridProdutos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                QuantidadeProduto = dataGridProdutos.Rows[e.RowIndex].Cells["Estoque"].Value.ToString();
                ValorUnitarioProduto = dataGridProdutos.Rows[e.RowIndex].Cells["Preço"].Value.ToString();



                this.DialogResult = DialogResult.OK; // Indica que a seleção foi feita corretamente
                this.Close(); // Fecha o formulário modal
            }
        }

        private void btnConfirmarSelecaoProduto_Click(object sender, EventArgs e)
        {
            if (dataGridProdutos.SelectedRows.Count > 0)
            {
                CodigoProduto = dataGridProdutos.SelectedRows[0].Cells["Código"].Value.ToString();
                NomeProduto = dataGridProdutos.SelectedRows[0].Cells["Nome"].Value.ToString();
                QuantidadeProduto = dataGridProdutos.SelectedRows[0].Cells["Estoque"].Value.ToString();
                ValorUnitarioProduto = dataGridProdutos.SelectedRows[0].Cells["Preço"].Value.ToString();


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
            dataGridProdutos.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridProdutos.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridProdutos.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridProdutos.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridProdutos.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridProdutos.GridColor = gridColor;

            // Fontes
            dataGridProdutos.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridProdutos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridClientes.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridProdutos.RowHeadersVisible = false;
            dataGridProdutos.ReadOnly = true;
            dataGridProdutos.EnableHeadersVisualStyles = false;
            dataGridProdutos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridProdutos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridProdutos.BackgroundColor = SystemColors.Control;
            dataGridProdutos.RowTemplate.Height = 40;

            // Adicionando uma coluna de seleção (opcional)
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Selecionar";
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridProdutos.Columns.Insert(0, checkBoxColumn);

            // Impede a alteração no layout do datagrid

            dataGridProdutos.AllowUserToAddRows = false;
            dataGridProdutos.AllowUserToDeleteRows = false;
            dataGridProdutos.AllowUserToOrderColumns = false;
            dataGridProdutos.AllowUserToResizeRows = false;
            dataGridProdutos.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void btnCancelarSelecaoProduto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
