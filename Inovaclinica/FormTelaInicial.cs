using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;

namespace Inovaclinica {
    public partial class FormTelaInicial : Form {
        public FormTelaInicial() {
            InitializeComponent();
            this.Load += new EventHandler(FormTelaInicial_Load);
        }

        private void FormTelaInicial_Load(object sender, EventArgs e) {
            AdicionarRodape();
            AdicionarCabecalho();

            
        }

        private void AdicionarRodape() {
            panelRodape.BackColor = ColorTranslator.FromHtml("#945EDC");
            panelRodape.Dock = DockStyle.Bottom; 
            panelRodape.Height = 80;

            Label footerLabelRodape = new Label();
            footerLabelRodape.Text = "INOVACLINICA";
            footerLabelRodape.Font = new Font("Arial", 10, FontStyle.Italic);
            footerLabelRodape.AutoSize = true;
            footerLabelRodape.Location = new Point(10, 20);
            footerLabelRodape.TextAlign = ContentAlignment.MiddleCenter;

            Label footerLabelRodape1 = new Label();
            footerLabelRodape1.Text = $"Versão: {GetAssemblyVersion()}";
            footerLabelRodape1.Font = new Font("Arial", 10, FontStyle.Italic);
            footerLabelRodape1.AutoSize = true;
            footerLabelRodape1.Location = new Point(10, 40);
            footerLabelRodape1.TextAlign = ContentAlignment.MiddleCenter;

            panelRodape.Controls.Add(footerLabelRodape);
            panelRodape.Controls.Add(footerLabelRodape1);

        }

        private void AdicionarCabecalho() {
            panelCabecalho.BackColor = ColorTranslator.FromHtml("#945EDC");
            panelCabecalho.Dock = DockStyle.Top;
            panelCabecalho.Height = 80;

            Label footerLabelCabecalho = new Label();
            footerLabelCabecalho.Text = "INOVACLINICA";
            footerLabelCabecalho.Font = new Font("Arial", 10, FontStyle.Italic);
            footerLabelCabecalho.AutoSize = true;
            footerLabelCabecalho.Location = new Point(10, 20);
            footerLabelCabecalho.TextAlign = ContentAlignment.MiddleCenter;

            Label footerLabelCabecalho1 = new Label();
            footerLabelCabecalho1.Text = $"Cabeçalho";
            footerLabelCabecalho1.Font = new Font("Arial", 10, FontStyle.Italic);
            footerLabelCabecalho1.AutoSize = true;
            footerLabelCabecalho1.Location = new Point(10, 40);
            footerLabelCabecalho1.TextAlign = ContentAlignment.MiddleCenter;

            panelCabecalho.Controls.Add(footerLabelCabecalho);
            panelCabecalho.Controls.Add(footerLabelCabecalho1);

        }



        private string GetAssemblyVersion() {
            // Obtém a versão do assembly do projeto
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

    }
}
