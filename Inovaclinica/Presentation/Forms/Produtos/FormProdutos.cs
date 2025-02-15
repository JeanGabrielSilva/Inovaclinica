using Inovaclinica.Application.Services;
using Inovaclinica.Domain.Repositories;
using Inovaclinica.Helpers;
using Inovaclinica.Infrastruture.Persistence.Repositories;
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
        private modalFiltrarProdutos _modalFiltrarProdutos;
        private readonly ProdutoService _produtoService;
        public FormProdutos()
        {
            InitializeComponent();

            DataGridViewHelper.CustomizeDataGridView(DataGridProdutos);
            IProdutoRepository produtoRepository = new ProdutoRepository();
            _produtoService = new ProdutoService(produtoRepository);
            this.Load += new EventHandler(FormProdutos_Load);

            // Associa eventos para detectar mudança no checkbox - Adicionado para mudança de cor ao marcar a checkbox
            DataGridProdutos.CellValueChanged += new DataGridViewCellEventHandler(DataGridProdutos_CellValueChanged);
            DataGridProdutos.CurrentCellDirtyStateChanged += new EventHandler(DataGridProdutos_CurrentCellDirtyStateChanged);

            barraPesquisaProdutos.KeyDown += new KeyEventHandler(barraPesquisaProdutos_KeyDown);
        }

        private void FormProdutos_Load(object sender, EventArgs e)
        {
            var produtos = _produtoService.ListarProdutos();
            DataGridProdutos.DataSource = produtos.ToList();
            
            ConfigurarDataGridView();   
        }

        private void ConfigurarDataGridView()
        {
            // Define os cabeçalhos das colunas
            DataGridProdutos.Columns["ProdutoID"].HeaderText = "Código";
            DataGridProdutos.Columns["Nome"].HeaderText = "Nome";
            DataGridProdutos.Columns["Descricao"].HeaderText = "Descrição";
            DataGridProdutos.Columns["Preco"].HeaderText = "Preço";
            DataGridProdutos.Columns["Estoque"].HeaderText = "Estoque";
            DataGridProdutos.Columns["DataValidade"].HeaderText = "Data de Validade";

            // Aplica a formatação das cores
            DataGridViewHelper.ApplyRowColors(DataGridProdutos);
        }

        private void btnAbrirModalAdicionarProduto_Click(object sender, EventArgs e)
        {
            modalAdicionarProduto modaladicionarproduto = new modalAdicionarProduto(this);
            modaladicionarproduto.StartPosition = FormStartPosition.CenterParent;
            modaladicionarproduto.ShowDialog();
        }

        // Metodo criado para que o datagrid fique com cores alternadas
      

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
            _produtoService.ListarProdutos();
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
                    //ApplyRowColors();
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

        private void btnAbrirModalVisualizarProdutos_Click(object sender, EventArgs e)
        {
            if (DataGridProdutos.SelectedRows.Count > 0)
            {
                var selectedRow = DataGridProdutos.SelectedRows[0];
                string produtoID = selectedRow.Cells["ProdutoID"].Value.ToString();


                modalVisualizarProdutos modalvisualizarprodutos = new modalVisualizarProdutos(produtoID, this);
                modalvisualizarprodutos.Text = "Visualizar Cliente";
                modalvisualizarprodutos.StartPosition = FormStartPosition.CenterParent;
                modalvisualizarprodutos.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para visualizar.");
            }
        }

        private void btnAbrirModalFiltrarProdutos_Click(object sender, EventArgs e)
        {
            if (_modalFiltrarProdutos == null)
            {
                _modalFiltrarProdutos = new modalFiltrarProdutos(this);
            }
            _modalFiltrarProdutos.StartPosition = FormStartPosition.CenterParent;
            _modalFiltrarProdutos.FormClosed += modalFiltrarProdutos_FormClosed;
            _modalFiltrarProdutos.ShowDialog();
        }


        private void modalFiltrarProdutos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_modalFiltrarProdutos != null)
            {
                string NomeProduto = _modalFiltrarProdutos.filtroNomeProduto;
                string EstoqueProduto = _modalFiltrarProdutos.filtroEstoque;
                string PrecoProduto = _modalFiltrarProdutos.filtroPreco;
                MessageBox.Show($"{NomeProduto}, {EstoqueProduto}, {PrecoProduto}");
                FiltrarProdutos(NomeProduto, EstoqueProduto, PrecoProduto);

            }
        }

        private void FiltrarProdutos(string NomeProduto, string EstoqueProduto, string PrecoProduto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Inicia a consulta sem qualquer critério adicional.
            string queryFiltrar = "SELECT ProdutoID as Código, Nome as [Nome do Produto], Descricao as [Descrição do Produto], Preco as [Preço], Estoque, DataValidade as [Data de Validade] From Produtos WHERE Ativo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryFiltrar, connection))
            {
                // Adiciona condições à consulta conforme os parâmetros não vazios
                if (!string.IsNullOrEmpty(NomeProduto))
                {
                    queryFiltrar += " AND Nome LIKE @Nome";
                    command.Parameters.AddWithValue("@Nome", "%" + NomeProduto + "%");
                }

                if (!string.IsNullOrEmpty(EstoqueProduto))
                {
                    queryFiltrar += " AND Estoque LIKE @Estoque";
                    command.Parameters.AddWithValue("@Estoque", "%" + EstoqueProduto + "%");

                }

                if (!string.IsNullOrEmpty(PrecoProduto))
                {
                    queryFiltrar += " AND Preco LIKE @Preco";
                    command.Parameters.AddWithValue("@Preco", "%" + PrecoProduto + "%");
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
                        DataGridProdutos.DataSource = dataTable;
                        DataGridProdutos.Refresh();
                        //ApplyRowColors();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum Produto encontrado com os critérios especificados.");
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
