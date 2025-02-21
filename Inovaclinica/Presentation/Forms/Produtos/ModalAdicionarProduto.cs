using Inovaclinica.Application.DTOs.Produtos;
using Inovaclinica.Application.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Inovaclinica
{
    public partial class modalAdicionarProduto : Form
    {
        private FormProdutos _formProdutos;
        private readonly ProdutoService _produtoService;

        public modalAdicionarProduto(FormProdutos formProdutos)
        {
            InitializeComponent();
            tabPage1.Text = "Informações";
            _formProdutos = formProdutos;
        }

        public modalAdicionarProduto(FormProdutos formProdutos, ProdutoService produtoService) {
            InitializeComponent();
            tabPage1.Text = "Informações";
            _formProdutos = formProdutos;
            _produtoService = produtoService;
        }

        private void btnAdicionarProduto_Click(object sender, EventArgs e) {
            try {
                // Se o campo estiver vazio, a data será null
                DateTime? dataValidade = string.IsNullOrWhiteSpace(dataValidadeProduto.Text)
                    ? (DateTime?)null
                    : DateTime.ParseExact(dataValidadeProduto.Text, "dd/MM/yyyy", null);

                // Criando o DTO
                var produtoDTO = new ProdutoAdicionarDTO {
                    Nome = nomeProduto.Text,
                    Descricao = descricaoProduto.Text,
                    Preco = precoProduto.Value,
                    DataValidade = dataValidade,
                    Estoque = int.Parse(estoqueProduto.Text)
                };

                _produtoService.AdicionarProduto(produtoDTO);

                MessageBox.Show($"Produto {produtoDTO.Nome} adicionado com sucesso!");
                _produtoService.ListarProdutos();
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }


        private void btnCancelarAlteracaoProduto_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
