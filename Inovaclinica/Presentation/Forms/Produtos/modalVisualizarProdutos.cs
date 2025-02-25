using Inovaclinica.Application.DTOs.Produtos;
using Inovaclinica.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica
{
    public partial class modalVisualizarProdutos : Form
    {
        private FormProdutos _formProdutos;
        private readonly ProdutoService _produtoService;
        private readonly int _produtoId;

        public modalVisualizarProdutos(FormProdutos formProdutos, int produtoId, ProdutoService produtoService)
        {
            InitializeComponent();
            tabPage1.Text = "Informações";
            tabPage2.Text = "Histórico";
            _formProdutos = formProdutos;
            _produtoService = produtoService;
            _produtoId = produtoId;
            CarregarDadosProduto();
        }

        private void CarregarDadosProduto() {
            var produto = _produtoService.ObterProdutoPorId(_produtoId);
            if (produto != null) {
                nomeProduto.Text = produto.Nome;
                lblNomeProduto.Text = produto.Nome;
                descricaoProduto.Text = produto.Descricao;
                precoProduto.Text = produto.Preco.ToString(); // Formato de moeda
                estoqueProduto.Text = produto.Estoque.ToString();
                dataValidadeProduto.Text = produto.DataValidade?.ToString("dd/MM/yyyy");
                checkBoxAtivoProduto.Checked = produto.Ativo;
                labelDataCadastro.Text = produto.DataCadastro.ToString("dd/MM/yyyy HH:mm");
                labelProdutoID.Text = produto.ProdutoID.ToString();
            } else {
                MessageBox.Show("Produto não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        private void btnCancelarAlteracaoProduto_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSalvarAlteracaoProduto_Click(object sender, EventArgs e)
        {

            var produtoEditado = new ProdutoAtualizarDTO {
                ProdutoID = int.Parse(labelProdutoID.Text),
                Nome = nomeProduto.Text,
                Descricao = descricaoProduto.Text,
                Preco = decimal.Parse(precoProduto.Text),
                DataCadastro = DateTime.Now,
                DataValidade = DateTime.Parse(dataValidadeProduto.Text),
                Estoque = int.Parse(estoqueProduto.Text),
                Ativo = checkBoxAtivoProduto.Checked,
            };

            _produtoService.AtualizarProduto(produtoEditado);
            MessageBox.Show("Produto atualizado com sucesso!");
        }

        private void modalVisualizarProdutos_Load(object sender, EventArgs e) {

        }
    }
}
