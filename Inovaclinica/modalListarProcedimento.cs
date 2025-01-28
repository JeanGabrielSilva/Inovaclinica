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
    public partial class modalListarProcedimento : Form
    {
        public string CodigoProcedimento { get; private set; }
        public string NomeProcedimento { get; private set; }
        public string PrecoProcedimento { get; private set; }
        public modalListarProcedimento(string consulta)
        {
            InitializeComponent();
            barraPesquisarProcedimentos.Text = consulta;
            CustomizeDataGridView();
            BuscarProcedimentosPeloNome(consulta);
            dataGridProcedimentos.CellDoubleClick += DataGridProcedimentos_CellDoubleClick;
        }

        private void BuscarProcedimentosPeloNome(string consulta)
        {
            // Conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Consulta SQL com parâmetro
            string queryBuscar = "SELECT ProcedimentoID AS Código, Nome, Descricao as [Descrição], Preco as [Preço] " +
                                 "FROM Procedimentos WHERE Nome LIKE @Consulta and Ativo = 1";

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
                        dataGridProcedimentos.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        private void DataGridProcedimentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Garante que o usuário clicou em uma linha válida
            {
                CodigoProcedimento = dataGridProcedimentos.Rows[e.RowIndex].Cells["Código"].Value.ToString();
                NomeProcedimento = dataGridProcedimentos.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
                PrecoProcedimento = dataGridProcedimentos.Rows[e.RowIndex].Cells["Preço"].Value.ToString();

                this.DialogResult = DialogResult.OK; // Indica que a seleção foi feita corretamente
                this.Close(); // Fecha o formulário modal
            }
        }

        private void btnConfirmarSelecaoProcedimento_Click(object sender, EventArgs e)
        {
            if (dataGridProcedimentos.SelectedRows.Count > 0)
            {
                
                CodigoProcedimento = dataGridProcedimentos.SelectedRows[0].Cells["Código"].Value.ToString();
                NomeProcedimento = dataGridProcedimentos.SelectedRows[0].Cells["Nome"].Value.ToString();
                PrecoProcedimento = dataGridProcedimentos.SelectedRows[0].Cells["Preço"].Value.ToString();

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
            //dataGridClientes.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridProcedimentos.RowHeadersVisible = false;
            dataGridProcedimentos.ReadOnly = true;
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

        private void btnCancelarSelecaoProdecimento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
