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
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormProdutos_Load);
            CustomizeDataGridView();

            // Associa eventos para detectar mudança no checkbox - Adicionado para mudança de cor ao marcar a checkbox
            DataGridProdutos.CellValueChanged += new DataGridViewCellEventHandler(DataGridProdutos_CellValueChanged);
            DataGridProdutos.CurrentCellDirtyStateChanged += new EventHandler(DataGridProdutos_CurrentCellDirtyStateChanged);

            barraPesquisaProdutos.KeyDown += new KeyEventHandler(barraPesquisaProdutos_KeyDown);
        }

        private void FormProdutos_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAbrirModalAdicionarProduto_Click(object sender, EventArgs e)
        {
            modalAdicionarProduto modaladicionarproduto = new modalAdicionarProduto(this);
            modaladicionarproduto.StartPosition = FormStartPosition.CenterParent;
            modaladicionarproduto.ShowDialog();
        }

        public void LoadData()
        {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = "SELECT ProdutoID as Código, Nome as [Nome do Produto], Descricao as [Descrição do Produto], Preco as [Preço], Estoque, DataValidade as [Data de Validade] From Produtos WHERE Ativo = 1";

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

                    // Formatar o CPF antes de exibir

                    // Define a fonte de dados do DataGridView como o DataTable
                    DataGridProdutos.DataSource = dataTable;

                    ApplyRowColors();

                    foreach (DataGridViewColumn column in DataGridProdutos.Columns)
                    {
                        if (column.Name != "checkBoxColumn")
                        {
                            column.ReadOnly = true;
                        }
                    }


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
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            DataGridProdutos.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            DataGridProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridProdutos.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            DataGridProdutos.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            DataGridProdutos.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            DataGridProdutos.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            DataGridProdutos.GridColor = gridColor;

            // Fontes
            DataGridProdutos.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            DataGridProdutos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            DataGridProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridProdutos.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            DataGridProdutos.RowHeadersVisible = false;
            DataGridProdutos.EnableHeadersVisualStyles = false;
            DataGridProdutos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGridProdutos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            DataGridProdutos.BackgroundColor = SystemColors.Control;
            DataGridProdutos.RowTemplate.Height = 40;

            // Adicionando uma coluna de seleção (opcional)
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Selecionar";
            checkBoxColumn.Name = "checkBoxColumn";
            DataGridProdutos.Columns.Insert(0, checkBoxColumn);

            // Impede a alteração no layout do datagrid

            DataGridProdutos.AllowUserToAddRows = false;
            DataGridProdutos.AllowUserToDeleteRows = false;
            DataGridProdutos.AllowUserToOrderColumns = false;
            DataGridProdutos.AllowUserToResizeRows = false;
            DataGridProdutos.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            DataGridProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        // Metodo criado para que o datagrid fique com cores alternadas
        private void ApplyRowColors()
        {
            for (int i = 0; i < DataGridProdutos.Rows.Count; i++)
            {
                if (i % 2 == 0) // Se for uma linha par
                {
                    DataGridProdutos.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else // Se for uma linha ímpar
                {
                    DataGridProdutos.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                }
            }
        }

        //
        private void DataGridProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a coluna é a checkbox
            if (DataGridProdutos.Columns[e.ColumnIndex].Name == "checkBoxColumn")
            {
                // Verifica se a checkbox foi marcada ou desmarcada
                bool isChecked = Convert.ToBoolean(DataGridProdutos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                if (isChecked)
                {
                    // Se estiver marcada, muda a cor da linha para roxa
                    DataGridProdutos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(148, 94, 220);
                    DataGridProdutos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White; // Muda a cor do texto também, se desejar
                }
                else
                {
                    // Se estiver desmarcada, redefine para a cor original
                    if (e.RowIndex % 2 == 0) // Se for uma linha par
                    {
                        DataGridProdutos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                    else // Se for uma linha ímpar
                    {
                        DataGridProdutos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                    }

                    DataGridProdutos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // Volta para a cor original do texto
                }
            }
        }


        private void DataGridProdutos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DataGridProdutos.IsCurrentCellDirty)
            {
                DataGridProdutos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void atualizarGridProdutos_Click(object sender, EventArgs e)
        {
            LoadData();
            barraPesquisaProdutos.Clear();
        }

        private void btnBarraPesquisaProdutos_Click(object sender, EventArgs e)
        {
            var consulta = barraPesquisaProdutos.Text;

            BuscarProdutos(consulta);
        }

        private void BuscarProdutos(string consulta)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Define a query SQL de inserção
            string queryBuscar = $"SELECT ProdutoID as Código, Nome as [Nome do Produto], Descricao as [Descrição do Produto], Preco as [Preço], Estoque, DataValidade as [Data de Validade] From Produtos WHERE Ativo = 1 AND Nome like '%{consulta}%'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // SqlDataAdapter para executar a consulta e preencher os dados
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryBuscar, connection);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados retornados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define a fonte de dados do DataGridView como o DataTable
                    DataGridProdutos.DataSource = dataTable;

                    // Aplica as cores das linhas
                    ApplyRowColors();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }

            }
        }

        private void barraPesquisaProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Cancela o som padrão de "ding"
                btnBarraPesquisaProdutos_Click(this, EventArgs.Empty); // Chama o método do botão de pesquisa
            }
        }
    }
}
