using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Inovaclinica {
    public partial class FormTelaInicial : Form {
        public FormTelaInicial() {

            this.WindowState = FormWindowState.Maximized;
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
            footerLabelRodape.ForeColor = Color.White;
            footerLabelRodape1.Text = $"Versão: {GetAssemblyVersion()}";
            footerLabelRodape1.Font = new Font("Arial", 10, FontStyle.Italic);
            footerLabelRodape1.AutoSize = true;
            footerLabelRodape1.Location = new Point(10, 40);
            footerLabelRodape1.TextAlign = ContentAlignment.MiddleCenter;

            panelRodape.Controls.Add(footerLabelRodape);
            panelRodape.Controls.Add(footerLabelRodape1);

        }

        private void AdicionarCabecalho() {
            panelCabecalho.BackColor = Color.Transparent;
            panelCabecalho.Dock = DockStyle.Top;
            panelCabecalho.Height = 80;

            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Img", "LogoTemporario.png");
            LogoCabecalho.Image = Image.FromFile(imagePath);

            LogoCabecalho.SizeMode = PictureBoxSizeMode.Zoom;
            LogoCabecalho.Width = 120;  // Ajuste a largura conforme necessário
            LogoCabecalho.Height = 60;  // Ajuste a altura conforme necessário

            // Definir a posição do PictureBox
            LogoCabecalho.Location = new Point(10, (panelCabecalho.Height - LogoCabecalho.Height) / 2);

            // Adicionar o PictureBox ao painel
            panelCabecalho.Controls.Add(LogoCabecalho);

        }

        private void LogoCabecalho_Click(object sender, EventArgs e) {

        }

        private string GetAssemblyVersion() {
            // Obtém a versão do assembly do projeto
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void btnMenuCliente_Click(object sender, EventArgs e)
        {
            FormClientes formclientes = new FormClientes();
            formclientes.StartPosition = FormStartPosition.CenterScreen;
            formclientes.WindowState = FormWindowState.Maximized;
            formclientes.Show();
        }

        private void btnMenuProduto_Click(object sender, EventArgs e)
        {
            FormProdutos formprodutos = new FormProdutos();
            formprodutos.StartPosition = FormStartPosition.CenterScreen;
            formprodutos.WindowState = FormWindowState.Maximized;
            formprodutos.Show();    

        }
    }
}
