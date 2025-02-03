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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inovaclinica
{
    public partial class FormFinanceiro : Form
    {
        public FormFinanceiro()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormFinanceiro_Load);
            CustomizeDataGridView();
        }

        private void FormFinanceiro_Load(object sender, EventArgs e)
        {
            LoadData();
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
            DataGridFinanceiro.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            DataGridFinanceiro.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridFinanceiro.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            DataGridFinanceiro.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            DataGridFinanceiro.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            DataGridFinanceiro.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            DataGridFinanceiro.GridColor = gridColor;

            // Fontes
            DataGridFinanceiro.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            DataGridFinanceiro.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            DataGridFinanceiro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajuste automático de todas as colunas com base no conteúdo das células
            DataGridFinanceiro.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            DataGridFinanceiro.RowHeadersVisible = false;
            DataGridFinanceiro.EnableHeadersVisualStyles = false;
            DataGridFinanceiro.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGridFinanceiro.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            DataGridFinanceiro.BackgroundColor = SystemColors.Control;
            DataGridFinanceiro.RowTemplate.Height = 40;

            // Adicionando uma coluna de seleção (opcional)
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Selecionar";
            checkBoxColumn.Name = "checkBoxColumn";
            DataGridFinanceiro.Columns.Insert(0, checkBoxColumn);

            // Impede a alteração no layout do datagrid
            DataGridFinanceiro.AllowUserToAddRows = false;
            DataGridFinanceiro.AllowUserToDeleteRows = false;
            DataGridFinanceiro.AllowUserToOrderColumns = false;
            DataGridFinanceiro.AllowUserToResizeRows = false;
            DataGridFinanceiro.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            DataGridFinanceiro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Evento para ajustes de layout após o carregamento de dados
            DataGridFinanceiro.DataBindingComplete += DataGridFinanceiro_DataBindingComplete;
        }

        private void DataGridFinanceiro_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Ajusta a largura de todas as colunas com base no conteúdo
            foreach (DataGridViewColumn column in DataGridFinanceiro.Columns)
            {
                if (column.Name != "checkBoxColumn" && column.Name != "Descrição")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; // Ajusta todas as colunas automaticamente
                }
            }

            // A coluna "Descrição" vai preencher o restante do espaço
            DataGridFinanceiro.Columns["Descrição"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }




        public void LoadData()
        {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = "SELECT Id as Código, Descricao as [Descrição], DataVencimento as [Data de Vencimento], Valor, Tipo, Status, Categoria, DataPagamento as [Data de Pagamento], DataInclusao as [Data de Lançamento] From Financeiro";

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
                    DataGridFinanceiro.DataSource = dataTable;

                    ApplyRowColors();

                    foreach (DataGridViewColumn column in DataGridFinanceiro.Columns)
                    {
                        if (column.Name != "checkBoxColumn")
                        {
                            column.ReadOnly = true;
                        }
                    }
                    // Chama as funções para calcular os totais após preencher o DataGridView
                    decimal totalEntradas = CalcularTotalEntradas();
                    decimal totalSaidas = CalcularTotalSaidas();
                    decimal totalAReceber = CalcularTotalReceber();
                    decimal TotalAPagar = CalcularTotalPagar();

                    decimal total = totalEntradas - totalSaidas;

                    // Atualiza os rótulos ou botões com os valores calculados
                    labelTotalEntradas.Text = $"{totalEntradas}";
                    labelTotalSaidas.Text = $"-{totalSaidas}";
                    labelTotalReceber.Text = $"{totalAReceber}";
                    labelTotalPagar.Text = $"{TotalAPagar}";
                    labelTotal.Text = $"{total}";


                    // Verifica se a coluna já foi adicionada antes de criar uma nova
                    if (!DataGridFinanceiro.Columns.Contains("colunaIcones"))
                    {
                        DataGridViewImageColumn colunaIcones = new DataGridViewImageColumn();
                        colunaIcones.HeaderText = "Operação";
                        colunaIcones.Name = "colunaIcones";
                        DataGridFinanceiro.Columns.Insert(6, colunaIcones);

                        // Associa o evento CellFormatting apenas uma vez
                        DataGridFinanceiro.CellFormatting += DataGridFinanceiro_CellFormatting;
                    }

                    // Associar o evento CellFormatting
                    DataGridFinanceiro.CellFormatting += DataGridFinanceiro_CellFormatting;
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        private decimal CalcularTotalEntradas()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in DataGridFinanceiro.Rows)
            {
                if (row.Cells["Valor"].Value != DBNull.Value)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);
                    string status = Convert.ToString(row.Cells["Status"].Value);
                    string tipo = Convert.ToString(row.Cells["Tipo"].Value);
                    if (valor >= 0 && status == "Pago" && tipo == "Entrada") // Validate type and value
                    {
                        total += valor;
                    }
                }
            }
            return total;
        }

        private decimal CalcularTotalReceber()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in DataGridFinanceiro.Rows)
            {
                if (row.Cells["Valor"].Value != DBNull.Value)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);
                    string status = Convert.ToString(row.Cells["Status"].Value);
                    string tipo = Convert.ToString(row.Cells["Tipo"].Value);
                    if (valor > 0 && status == "Pendente" && tipo == "Entrada") // Apenas valores positivos e status Pendente
                    {
                        total += valor;
                    }
                }
            }
            return total;
        }


        private decimal CalcularTotalSaidas()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in DataGridFinanceiro.Rows)
            {
                if (row.Cells["Valor"].Value != DBNull.Value)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);
                    string status = Convert.ToString(row.Cells["Status"].Value);
                    string tipo = Convert.ToString(row.Cells["Tipo"].Value);
                    if (valor >= 0 && status == "Pago" && tipo == "Saída") // Validate type and value
                    {
                        total += valor;
                    }
                }
            }
            return total;
        }

        private decimal CalcularTotalPagar()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in DataGridFinanceiro.Rows)
            {
                if (row.Cells["Valor"].Value != DBNull.Value)
                {
                    decimal valor = Convert.ToDecimal(row.Cells["Valor"].Value);
                    string status = Convert.ToString(row.Cells["Status"].Value);
                    string tipo = Convert.ToString(row.Cells["Tipo"].Value);
                    if (valor >= 0 && status == "Pendente" && tipo == "Saída") // Apenas valores negativos e status Pendente
                    {
                        total += valor;
                    }
                }
            }
            return total;
        }

        private void DataGridFinanceiro_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == DataGridFinanceiro.Columns["colunaIcones"].Index)
            {
                string tipo = Convert.ToString(DataGridFinanceiro.Rows[e.RowIndex].Cells["Tipo"].Value);
                if (tipo == "Entrada")
                {
                    //e.Value = Image.FromFile(@"C:\Users\jeang\Source\Repos\Inovaclinica\Inovaclinica\Resources\seta-para-cima-preenchida24.png");
                }
                else if (tipo == "Saída")
                {
                   // e.Value = Image.FromFile(@"C:\Users\jeang\Source\Repos\Inovaclinica\Inovaclinica\Resources\seta-para-baixo-preenchida24.png");
                }
            }
        }

        private void ApplyRowColors()
        {
            for (int i = 0; i < DataGridFinanceiro.Rows.Count; i++)
            {
                if (i % 2 == 0) // Se for uma linha par
                {
                    DataGridFinanceiro.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else // Se for uma linha ímpar
                {
                    DataGridFinanceiro.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                }
            }
        }


        private void btnAbrirModalAdicionarLancamentoFinanceiro_Click(object sender, EventArgs e)
        {
            modalAdicionarLancamentoFinanceiro modaladicionarlancamentofinanceiro = new modalAdicionarLancamentoFinanceiro(this);
            modaladicionarlancamentofinanceiro.StartPosition = FormStartPosition.CenterParent;
            modaladicionarlancamentofinanceiro.ShowDialog();
        }

        private void btnAbrirModalVisualizarLancamentoFinanceiro_Click(object sender, EventArgs e)
        {
            if (DataGridFinanceiro.SelectedRows.Count > 0)
            {
                var selectedRow = DataGridFinanceiro.SelectedRows[0];
                string lancamentoID = selectedRow.Cells["Código"].Value.ToString();


                modalVisualizarLancamentoFinanceiro modalvisualizarlancamentofinanceiro = new modalVisualizarLancamentoFinanceiro(lancamentoID, this);
                modalvisualizarlancamentofinanceiro.StartPosition = FormStartPosition.CenterParent;
                modalvisualizarlancamentofinanceiro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para visualizar.");
            }
        }

        private void btnAbrirModalEliminarLancamentoFinanceiro_Click(object sender, EventArgs e) {
            if (DataGridFinanceiro.SelectedRows.Count > 0) 
            {
                var selectedRow = DataGridFinanceiro.SelectedRows[0];
                string lancamentoID = selectedRow.Cells["Código"].Value.ToString();

                modalExcluirLancamentoFinanceiro modalexcluirlancamentofinanceiro = new modalExcluirLancamentoFinanceiro(this, lancamentoID);
                modalexcluirlancamentofinanceiro.StartPosition = FormStartPosition.CenterParent;
                modalexcluirlancamentofinanceiro.ShowDialog();
            } else {
                MessageBox.Show("Selecione um cliente para visualizar.");
            }
        }

        private void atualizarGridFinanceiro_Click(object sender, EventArgs e) {
            this.LoadData();
        }
    }
}
