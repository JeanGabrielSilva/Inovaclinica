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
    public partial class FormProdutos : Form
    {
        public FormProdutos()
        {
            InitializeComponent();
        }

        private void btnAbrirModalAdicionarProduto_Click(object sender, EventArgs e)
        {
            modalAdicionarProduto modaladicionarproduto = new modalAdicionarProduto();
            modaladicionarproduto.StartPosition = FormStartPosition.CenterParent;
            modaladicionarproduto.ShowDialog();
        }
    }
}
