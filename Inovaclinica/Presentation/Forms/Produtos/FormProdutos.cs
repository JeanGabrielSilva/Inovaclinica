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
        private readonly ProdutoService _produtoService;

        public FormProdutos()
        {
            InitializeComponent();

            DataGridViewHelper.CustomizeDataGridView(DataGridProdutos);
            IProdutoRepository produtoRepository = new ProdutoRepository();
            _produtoService = new ProdutoService(produtoRepository);
            this.Load += new EventHandler(FormProdutos_Load);

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
            modalAdicionarProduto modaladicionarproduto = new modalAdicionarProduto(this, _produtoService);
            modaladicionarproduto.StartPosition = FormStartPosition.CenterParent;
            modaladicionarproduto.ShowDialog();

            DataGridProdutos.DataSource = _produtoService.ListarProdutos().ToList();
            ConfigurarDataGridView();
        }
      

        private void atualizarGridProdutos_Click(object sender, EventArgs e)
        {
            DataGridProdutos.DataSource = _produtoService.ListarProdutos().ToList();
            ConfigurarDataGridView();
            barraPesquisaProdutos.Clear();
        }

        private void btnBarraPesquisaProdutos_Click(object sender, EventArgs e)
        {
            var consulta = barraPesquisaProdutos.Text;

            BuscarProdutos(consulta);
        }

        private void BuscarProdutos(string consulta)
        {
            try {
                var produtos = _produtoService.BuscarProdutos(consulta);

                DataGridProdutos.DataSource = produtos.ToList();

                DataGridViewHelper.ApplyRowColors(DataGridProdutos);

            } catch (Exception ex) {
                MessageBox.Show($"Erro ao buscar produtos: {ex.Message}");
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
                int produtoId = Convert.ToInt32(DataGridProdutos.SelectedRows[0].Cells["ProdutoID"].Value);
                var produtoService = new ProdutoService(new ProdutoRepository()); // Injeção de dependência pode ser melhorada
                var modal = new modalVisualizarProdutos(this, produtoId, produtoService);
                modal.Text = "Visualizar Produtos";
                modal.StartPosition = FormStartPosition.CenterParent;
                modal.ShowDialog();
                DataGridProdutos.DataSource = _produtoService.ListarProdutos().ToList();
                ConfigurarDataGridView();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para visualizar.");
            }
        }

        private void btnAbrirModalFiltrarProdutos_Click(object sender, EventArgs e)
        {
            modalFiltrarProdutos modalfiltrarproduto = new modalFiltrarProdutos();
            modalfiltrarproduto.Text = "Filtrar Produtos";
            modalfiltrarproduto.StartPosition = FormStartPosition.CenterParent;

            if (modalfiltrarproduto.ShowDialog() == DialogResult.OK) {
                var produtos = _produtoService.FiltrosProdutos(modalfiltrarproduto.Filtros);
                DataGridProdutos.DataSource = produtos.ToList();
            }

        }
    }
}
