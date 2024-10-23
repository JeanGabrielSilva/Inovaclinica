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
    public partial class modalAdicionarLancamentoFinanceiro : Form
    {
        private Color corPadrao = Color.Gray;
        private Color corEntrada = Color.FromArgb(100, 150, 100);
        private Color corSaida = Color.FromArgb(200, 50, 50);
        private string tipoOperacao = "";

        public modalAdicionarLancamentoFinanceiro()
        {
            InitializeComponent();
            btnEntrada.BackColor = corPadrao;
            btnSaida.BackColor = corPadrao;
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            btnEntrada.BackColor = corEntrada;
            btnSaida.BackColor = corPadrao;
            tipoOperacao = "Entrada";
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            btnSaida.BackColor = corSaida;
            btnEntrada.BackColor = corPadrao;
            tipoOperacao = "Saída";
        }

        private void btnAdicionarLancamento_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Tipo de operação: {tipoOperacao}");

        }

        private void btnCancelarLancamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}