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

            // Associa eventos para detectar mudança no checkbox - Adicionado para mudança de cor ao marcar a checkbox
            dataGridClientes.CellValueChanged += new DataGridViewCellEventHandler(DataGridClientes_CellValueChanged);
            dataGridClientes.CurrentCellDirtyStateChanged += new EventHandler(DataGridClientes_CurrentCellDirtyStateChanged);

            barraPesquisaClientes.KeyDown += new KeyEventHandler(barraPesquisaClientes_KeyDown);

        }

        // Este método será chamado quando o formulário FormClientes for carregado
        private void FormClientes_Load(object sender, EventArgs e)
        {
            LoadData(); // Chama o método para carregar os dados
            foreach (DataGridViewRow row in dataGridClientes.Rows) {
                string cpf = row.Cells["CPF"].Value.ToString();
                row.Cells["CPF"].Value = FormatarCPF(cpf);
            }
        }

        // Método para carregar os dados do banco de dados e preencher o DataGridView
        public void LoadData()
        {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Query SQL para buscar os dados da tabela 'Produtos'
            string query = "SELECT ClienteID as Código, Nome, CPF, DataNascimento as [Data Nascimento], Telefone FROM Clientes WHERE Ativo = 1";

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

                    ApplyRowColors();

                    foreach (DataGridViewColumn column in dataGridClientes.Columns)
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


        }

        // Metodo criado para que o datagrid fique com cores alternadas
        private void ApplyRowColors()
        {
            for (int i = 0; i < dataGridClientes.Rows.Count; i++)
            {
                if (i % 2 == 0) // Se for uma linha par
                {
                    dataGridClientes.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else // Se for uma linha ímpar
                {
                    dataGridClientes.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                }
            }
        }

        //
        private void DataGridClientes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a coluna é a checkbox
            if (dataGridClientes.Columns[e.ColumnIndex].Name == "checkBoxColumn")
            {
                // Verifica se a checkbox foi marcada ou desmarcada
                bool isChecked = Convert.ToBoolean(dataGridClientes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                if (isChecked)
                {
                    // Se estiver marcada, muda a cor da linha para roxa
                    dataGridClientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(148, 94, 220);
                    dataGridClientes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White; // Muda a cor do texto também, se desejar
                }
                else
                {
                    // Se estiver desmarcada, redefine para a cor original
                    if (e.RowIndex % 2 == 0) // Se for uma linha par
                    {
                        dataGridClientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    }
                    else // Se for uma linha ímpar
                    {
                        dataGridClientes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                    }

                    dataGridClientes.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black; // Volta para a cor original do texto
                }
            }
        }


        private void DataGridClientes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridClientes.IsCurrentCellDirty)
            {
                dataGridClientes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
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
            barraPesquisaClientes.Clear();
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e) {
        }

        private void btnBarraPesquisaClientes_Click(object sender, EventArgs e)
        {
            var consulta = barraPesquisaClientes.Text;

            BuscarCliente(consulta);
        }

        private void BuscarCliente(string consulta)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Define a query SQL de inserção
            string queryBuscar = $"SELECT ClienteID as Código, Nome, CPF, DataNascimento as [Data Nascimento], Telefone FROM Clientes WHERE Nome like '%{consulta}%'";

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
                    dataGridClientes.DataSource = dataTable;

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

        private void barraPesquisaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Cancela o som padrão de "ding"
                btnBarraPesquisaClientes_Click(this, EventArgs.Empty); // Chama o método do botão de pesquisa
            }
        }

        // 
        private string FormatarCPF(string cpf) {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Formata o CPF
            if (cpf.Length == 11) {
                return string.Format("{0}.{1}.{2}-{3}",
                    cpf.Substring(0, 3),
                    cpf.Substring(3, 3),
                    cpf.Substring(6, 3),
                    cpf.Substring(9, 2));
            }
            return cpf; // Retorna sem formatação se não for válido
        }

    }
}