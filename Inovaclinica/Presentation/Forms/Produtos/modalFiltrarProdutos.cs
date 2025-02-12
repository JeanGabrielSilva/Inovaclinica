using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica
{
    public partial class modalFiltrarProdutos : Form
    {
        public string filtroNomeProduto { get; set; }
        public string filtroEstoque { get; set; }
        public string filtroPreco { get; set; }
        public string filtroDataValidade { get; set; }

        private FormProdutos _formProdutos;
        public modalFiltrarProdutos(FormProdutos formProdutos)
        {
            InitializeComponent();
            _formProdutos = formProdutos;
        }

        private void btnCancelarFiltroProduto_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrarProdutos_Click(object sender, EventArgs e)
        {
            filtroNomeProduto = textBoxFiltrarProdutosNome.Text;
            filtroEstoque = filtrarEstoqueProduto.Text;
            filtroPreco = filtrarPrecoProduto.Text;
            this.Close();
        }
    }
}
