﻿using System;
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
        private modalFiltrarCliente _modalFiltrarCliente;
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

                    // Formatar o CPF antes de exibir
                    foreach (DataRow row in dataTable.Rows) {
                        string cpf = row["CPF"].ToString();
                        row["CPF"] = FormatarCPF(cpf); // Aplica a função de formatação
                    }


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

        public string FormatarCPF(string CPF) {
            CPF = new string(CPF.Where(char.IsDigit).ToArray());

            if (CPF.Length == 11) {
                return string.Format("{0}.{1}.{2}-{3}",
                    CPF.Substring(0, 3),
                    CPF.Substring(3, 3),
                    CPF.Substring(6, 3),
                    CPF.Substring(9, 2));
            }
            return CPF;
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

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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


        private void btnAbrirModalAdicionarCliente_Click(object sender, EventArgs e) {
            modalAdicionarCliente modaladicionarcliente = new modalAdicionarCliente(this);
            modaladicionarcliente.StartPosition = FormStartPosition.CenterParent;  
            modaladicionarcliente.ShowDialog();

        }

        private void btnAbrirModalVisualizarClientes_Click(object sender, EventArgs e) {
            if (dataGridClientes.SelectedRows.Count > 0) {
                var selectedRow = dataGridClientes.SelectedRows[0];
                string clientID = selectedRow.Cells["Código"].Value.ToString();


                modalVisualizarClientes modalvisualizarcliente = new modalVisualizarClientes(clientID, this);
                modalvisualizarcliente.Text = "Visualizar Cliente";
                modalvisualizarcliente.StartPosition = FormStartPosition.CenterParent;
                modalvisualizarcliente.ShowDialog();
            } else {
                MessageBox.Show("Selecione um cliente para visualizar.");
            }
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

        private void btnAbrirModalFiltrarClientes_Click(object sender, EventArgs e)
        {
            if (_modalFiltrarCliente == null)
            {
                _modalFiltrarCliente = new modalFiltrarCliente(this);
            }
            _modalFiltrarCliente.StartPosition = FormStartPosition.CenterParent;
            _modalFiltrarCliente.FormClosed += modalFiltrarCliente_FormClosed;
            _modalFiltrarCliente.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            MessageBox.Show("a");
        }

        private void barraPesquisaClientes_TextChanged(object sender, EventArgs e)
        {

        }

        private void modalFiltrarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_modalFiltrarCliente != null)
            {
                string nome = _modalFiltrarCliente.filtroNomeCliente;
                string cpf = _modalFiltrarCliente.filtroCpfCliente;
                string cidade = _modalFiltrarCliente.filtroCidadeCliente;
                string sexo = _modalFiltrarCliente.filtroSexoCliente;

                FiltrarClientes(nome, cpf, cidade, sexo);

            }
        }

        private void FiltrarClientes(string nome, string cpf, string cidade, string sexo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Inicia a consulta sem qualquer critério adicional.
            string queryFiltrar = "SELECT ClienteID as Código, Nome, CPF, DataNascimento as [Data Nascimento], Telefone FROM Clientes WHERE Ativo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryFiltrar, connection))
            {
                // Adiciona condições à consulta conforme os parâmetros não vazios
                if (!string.IsNullOrEmpty(nome))
                {
                    queryFiltrar += " AND Nome LIKE @Nome";
                    command.Parameters.AddWithValue("@Nome", "%" + nome + "%");
                }

                if (!string.IsNullOrEmpty(cpf))
                {
                    queryFiltrar += " AND CPF LIKE @CPF";
                    command.Parameters.AddWithValue("@CPF", "%" + cpf + "%");

                }

                if (!string.IsNullOrEmpty(cidade))
                {
                    queryFiltrar += " AND CIDADE LIKE @CIDADE";
                    command.Parameters.AddWithValue("@CIDADE", "%" + cidade + "%");
                }

                if (!string.IsNullOrEmpty(sexo))
                {
                    queryFiltrar += " AND GENERO LIKE @SEXO";
                    command.Parameters.AddWithValue("@SEXO", "%" + sexo + "%");
                }

                command.CommandText = queryFiltrar; // Atualiza o comando SQL com a query completa

                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Verifica se foram encontrados registros
                    if (dataTable.Rows.Count > 0)
                    {
                        // Preenche o DataGridView e aplica as cores
                        dataGridClientes.DataSource = dataTable;
                        dataGridClientes.Refresh();
                        ApplyRowColors();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum cliente encontrado com os critérios especificados.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao filtrar os dados: " + ex.Message);
                }
            }
        }
    }
}