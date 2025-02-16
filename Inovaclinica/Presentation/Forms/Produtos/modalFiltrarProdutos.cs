  using Inovaclinica.Application.DTOs.Produtos;
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
        
        public ProdutoFiltroDTO Filtros {  get; private set; }

        public modalFiltrarProdutos() {
            InitializeComponent();
        }

        private void btnFiltrarProdutos_Click(object sender, EventArgs e) {

            string DataInicial = ConverterParaFormatoBanco(maskFiltrarProdutosDataInicio.Text);
            string DataFinal = ConverterParaFormatoBanco(maskFiltrarProdutosDataFinal.Text);

            Filtros = new ProdutoFiltroDTO {
                NomeProduto = textBoxFiltrarProdutosNome.Text,
                Estoque = filtrarEstoqueProduto.Text,
                Preco = filtrarPrecoProduto.Text,
                DataInicial = DataInicial,
                DataFinal = DataFinal,
            };

            this.DialogResult = DialogResult.OK;
        }

        private string ConverterParaFormatoBanco(string dataComBarras) {
            if (DateTime.TryParseExact(dataComBarras, "dd/MM/yyyy", null,
                                       System.Globalization.DateTimeStyles.None, out DateTime data)) {
                return data.ToString("yyyy-MM-dd");
            }
            return null; // Retorna null caso a conversão falhe
        }



        private void btnCancelarFiltroProduto_Click(object sender, EventArgs e) {
            this.Close();
        }


    }
}
