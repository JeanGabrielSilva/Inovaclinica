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
    public partial class FormOrcamentos : Form {
        public FormOrcamentos() {
            InitializeComponent();
            this.Load += new EventHandler(FormOrcamento_Load);
            CustomizeDataGridView();

            DataGridOrcamento.RowEnter += DataGridOrcamento_RowEnter;
            DataGridOrcamento.CellValueChanged += new DataGridViewCellEventHandler(DataGridOrcamento_CellValueChanged);
            DataGridOrcamento.CurrentCellDirtyStateChanged += new EventHandler(DataGridOrcamento_CurrentCellDirtyStateChanged);
        }


        private void FormOrcamento_Load(object sender, EventArgs e) {
            LoadData();
        }

        private void DataGridOrcamento_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a linha é válida (evita erro com linhas vazias ou cabeçalhos)
            if (e.RowIndex >= 0)
            {
                // Obtém a linha clicada
                var selectedRow = DataGridOrcamento.Rows[e.RowIndex];

                // Exemplo: Obtém os valores das células pelo nome da coluna
                string orcamentoID = selectedRow.Cells["Código"].Value?.ToString();
                string cliente = selectedRow.Cells["Nome"].Value?.ToString();
                string valor = selectedRow.Cells["Valor Total"].Value?.ToString();
                string status = selectedRow.Cells["Status"].Value?.ToString();
                //if (selectedRow.Cells["Data de Criação"].Value != null &&
                //    DateTime.TryParse(selectedRow.Cells["Data de Criação"].Value.ToString(), out DateTime dataCriacao))
                //{
                //    // Atualiza a label com a data formatada
                //    lblDataCriacao.Text = dataCriacao.ToString("dd/MM/yyyy HH:mm");
                //}
                //else
                //{
                //   lblDataCriacao.Text = "Data inválida"; // Ou deixe vazio
                //}

                // Exemplo: Atualiza labels ou processa os dados
                lblCodigo.Text = orcamentoID;
                lblNomeCliente.Text = cliente;
                lblTotalOrcamento.Text = valor;
                lblStatus.Text = status;    
                MostrarDadosOrcamento(orcamentoID);
            }
        }

        public void MostrarDadosOrcamento(string orcamentoID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"Select O.OrcamentoID as [Código], C.Nome as [Nome], O.DataCriacao [Data de Criação], O.Status, O.ValorTotal as [Valor Total] from Orcamentos as O inner join Clientes as C on O.ClienteID = C.ClienteID WHERE OrcamentoID = @OrcamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrcamentoID", orcamentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    //txtBoxNomeCliente.Text = reader["Nome"].ToString();
                }
            }
        }

        public void LoadData() {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = "Select O.OrcamentoID as [Código], C.Nome as [Nome], O.DataCriacao [Data de Criação], O.Status, O.ValorTotal as [Valor Total] from Orcamentos as O inner join Clientes as C on O.ClienteID = C.ClienteID";

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

                    // Formatar o CPF antes de exibir

                    // Define a fonte de dados do DataGridView como o DataTable
                    DataGridOrcamento.DataSource = dataTable;

                    ApplyRowColors();

                    foreach (DataGridViewColumn column in DataGridOrcamento.Columns) {
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

        private void CustomizeDataGridView() {
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            DataGridOrcamento.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            DataGridOrcamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridOrcamento.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            DataGridOrcamento.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            DataGridOrcamento.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            DataGridOrcamento.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            DataGridOrcamento.GridColor = gridColor;

            // Fontes
            DataGridOrcamento.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            DataGridOrcamento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            DataGridOrcamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridOrcamento.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            DataGridOrcamento.RowHeadersVisible = false;
            DataGridOrcamento.EnableHeadersVisualStyles = false;
            DataGridOrcamento.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGridOrcamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            DataGridOrcamento.BackgroundColor = SystemColors.Control;
            DataGridOrcamento.RowTemplate.Height = 40;

            // Adicionando uma coluna de seleção (opcional)
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Selecionar";
            checkBoxColumn.Name = "checkBoxColumn";
            DataGridOrcamento.Columns.Insert(0, checkBoxColumn);

            // Impede a alteração no layout do datagrid

            DataGridOrcamento.AllowUserToAddRows = false;
            DataGridOrcamento.AllowUserToDeleteRows = false;
            DataGridOrcamento.AllowUserToOrderColumns = false;
            DataGridOrcamento.AllowUserToResizeRows = false;
            DataGridOrcamento.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            DataGridOrcamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void ApplyRowColors() {
            for (int i = 0; i < DataGridOrcamento.Rows.Count; i++) {
                if (i % 2 == 0) // Se for uma linha par
                {
                    DataGridOrcamento.Rows[i].DefaultCellStyle.BackColor = Color.White;
                } else // Se for uma linha ímpar
                  {
                    DataGridOrcamento.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                }
            }
        }

        //
        private void DataGridOrcamento_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            // Verifica se a coluna é a checkbox
            if (DataGridOrcamento.Columns[e.ColumnIndex].Name == "checkBoxColumn") {
                // Verifica se a checkbox foi marcada ou desmarcada
                bool isChecked = Convert.ToBoolean(DataGridOrcamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                if (isChecked) {
                    // Se estiver marcada, muda a cor da linha para roxa
                    DataGridOrcamento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(148, 94, 220);
                    DataGridOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White; // Muda a cor do texto também, se desejar
                } else {
                    // Se estiver desmarcada, redefine para a cor original
                    if (e.RowIndex % 2 == 0) // Se for uma linha par
                    {
                        DataGridOrcamento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    } else // Se for uma linha ímpar
                      {
                        DataGridOrcamento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                    }

                    DataGridOrcamento.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // Volta para a cor original do texto
                }
            }
        }

        private void DataGridOrcamento_CurrentCellDirtyStateChanged(object sender, EventArgs e) {
            if (DataGridOrcamento.IsCurrentCellDirty) {
                DataGridOrcamento.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void label13_Click(object sender, EventArgs e) {

        }

        private void btnAbrirModalVisualizarOrcamento_Click(object sender, EventArgs e) {
            if (DataGridOrcamento.SelectedRows.Count > 0) {
                var selectedRow = DataGridOrcamento.SelectedRows[0];
                string orcamentoID = selectedRow.Cells["Código"].Value.ToString();


                modalVisualizarOrcamento modalvisualizarorcamento = new modalVisualizarOrcamento(orcamentoID, this);
                modalvisualizarorcamento.Text = "Visualizar Cliente";
                modalvisualizarorcamento.StartPosition = FormStartPosition.CenterParent;
                modalvisualizarorcamento.ShowDialog();
            } else {
                MessageBox.Show("Selecione um cliente para visualizar.");
            }
        }

        private void btnAbrirModalAdicionarOrcamento_Click(object sender, EventArgs e)
        {
            modalAdicionarOrcamento modaladicionarorcamento = new modalAdicionarOrcamento(this);
            modaladicionarorcamento.Text = "Adicionar Orçamento";
            modaladicionarorcamento.StartPosition = FormStartPosition.CenterParent;
            modaladicionarorcamento.ShowDialog();   
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
