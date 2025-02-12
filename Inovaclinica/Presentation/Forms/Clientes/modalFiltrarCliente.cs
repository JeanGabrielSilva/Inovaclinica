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

namespace Inovaclinica {
    public partial class modalFiltrarCliente : Form
    {
        public string filtroNomeCliente { get; set; }
        public string filtroCpfCliente { get; set; }
        public string filtroCidadeCliente { get; set; }
        public string filtroSexoCliente { get; set; }


        private FormClientes _formClientes;
        public modalFiltrarCliente(FormClientes formClientes) {
            InitializeComponent();
            _formClientes = formClientes;
            
        }

        private void LimparCampos()
        {
            textBoxFiltrarClientesNome.Clear();
            textBoxFiltrarClientesCPF.Clear();
            textBoxFiltrarClientesCidade.Clear();
            ComboBoxFiltrarClientesSexo.SelectedIndex = -1;
        }

        private void btnCancelarAlteracaoCliente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFiltrarClientes_Click(object sender, EventArgs e)
        {
            filtroNomeCliente = textBoxFiltrarClientesNome.Text;
            filtroCpfCliente = LimparMascaraCPF(textBoxFiltrarClientesCPF.Text);
            filtroCidadeCliente = textBoxFiltrarClientesCidade.Text;
            filtroSexoCliente = ComboBoxFiltrarClientesSexo.Text;
            LimparCampos();
            this.Close();

        }

        private string LimparMascaraCPF(string cpfComMascara)
        {
            // Remove qualquer caractere que não seja dígito
            return new string(cpfComMascara.Where(char.IsDigit).ToArray());
        }

    }
}
