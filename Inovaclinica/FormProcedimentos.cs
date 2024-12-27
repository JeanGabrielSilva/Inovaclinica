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

namespace Inovaclinica {
    public partial class FormProcedimentos : Form {
        public FormProcedimentos() {

            InitializeComponent();
            LoadData(); 
            CustomizeDataGridView();

            dataGridProcedimentos.CellValueChanged += new DataGridViewCellEventHandler(DataGridClientes_CellValueChanged);
            dataGridProcedimentos.CurrentCellDirtyStateChanged += new EventHandler(DataGridClientes_CurrentCellDirtyStateChanged);
        }

        public void LoadData() {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = "SELECT ProcedimentoID as Código, Nome, Descricao as Descrição, Preco as Preço FROM Procedimentos WHERE Ativo = 1";

            // Usa SqlConnection e SqlDataAdapter para preencher o DataGridView
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                try {
                    // Abre a conexão
                    connection.Open();

                    // SqlDataAdapter para executar a consulta e preencher os dados
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados retornados da consulta
                    dataAdapter.Fill(dataTable);


                    // Define a fonte de dados do DataGridView como o DataTable
                    dataGridProcedimentos.DataSource = dataTable;

                    ApplyRowColors();

                    foreach (DataGridViewColumn column in dataGridProcedimentos.Columns) {
                        if (column.Name != "checkBoxColumn") {
                            column.ReadOnly = true;
                        }
                    }


                } catch (Exception ex) {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        private void ApplyRowColors() {
            for (int i = 0; i < dataGridProcedimentos.Rows.Count; i++) {
                if (i % 2 == 0) // Se for uma linha par
                {
                    dataGridProcedimentos.Rows[i].DefaultCellStyle.BackColor = Color.White;
                } else // Se for uma linha ímpar
                  {
                    dataGridProcedimentos.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                }
            }
        }


        private void CustomizeDataGridView() {
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            dataGridProcedimentos.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridProcedimentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridProcedimentos.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridProcedimentos.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridProcedimentos.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridProcedimentos.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridProcedimentos.GridColor = gridColor;

            // Fontes
            dataGridProcedimentos.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridProcedimentos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridProcedimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridProcedimentos.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridProcedimentos.RowHeadersVisible = false;
            dataGridProcedimentos.EnableHeadersVisualStyles = false;
            dataGridProcedimentos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridProcedimentos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridProcedimentos.BackgroundColor = SystemColors.Control;
            dataGridProcedimentos.RowTemplate.Height = 40;

            // Adicionando uma coluna de seleção (opcional)
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Selecionar";
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridProcedimentos.Columns.Insert(0, checkBoxColumn);

            // Impede a alteração no layout do datagrid

            dataGridProcedimentos.AllowUserToAddRows = false;
            dataGridProcedimentos.AllowUserToDeleteRows = false;
            dataGridProcedimentos.AllowUserToOrderColumns = false;
            dataGridProcedimentos.AllowUserToResizeRows = false;
            dataGridProcedimentos.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridProcedimentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void DataGridClientes_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            // Verifica se a coluna é a checkbox
            if (dataGridProcedimentos.Columns[e.ColumnIndex].Name == "checkBoxColumn") {
                // Verifica se a checkbox foi marcada ou desmarcada
                bool isChecked = Convert.ToBoolean(dataGridProcedimentos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                if (isChecked) {
                    // Se estiver marcada, muda a cor da linha para roxa
                    dataGridProcedimentos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(148, 94, 220);
                    dataGridProcedimentos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White; // Muda a cor do texto também, se desejar
                } else {
                    // Se estiver desmarcada, redefine para a cor original
                    if (e.RowIndex % 2 == 0) // Se for uma linha par
                    {
                        dataGridProcedimentos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    } else // Se for uma linha ímpar
                      {
                        dataGridProcedimentos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                    }

                    dataGridProcedimentos.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // Volta para a cor original do texto
                }
            }
        }

        private void DataGridClientes_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (dataGridProcedimentos.IsCurrentCellDirty) {
                dataGridProcedimentos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnAbrirModalAdicionarProcedimentos_Click(object sender, EventArgs e)
        {
            modalAdicionarProcedimento modaladicionarprocedimento = new modalAdicionarProcedimento(this);
            modaladicionarprocedimento.StartPosition = FormStartPosition.CenterParent;
            modaladicionarprocedimento.ShowDialog();
        }

        private void btnAbrirModalVisualizarProcedimentos_Click(object sender, EventArgs e)
        {
            if (dataGridProcedimentos.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridProcedimentos.SelectedRows[0];
                string procedimentoID = selectedRow.Cells["Código"].Value.ToString();


                modalVisualizarProcedimento modalvisualizarprocedimento = new modalVisualizarProcedimento(procedimentoID, this);
                modalvisualizarprocedimento.Text = "Visualizar Procedimento";
                modalvisualizarprocedimento.StartPosition = FormStartPosition.CenterParent;
                modalvisualizarprocedimento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um procedimento para visualizar.");
            }
        }
    }
}
