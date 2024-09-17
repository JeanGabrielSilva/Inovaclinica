using System.Drawing;
using System.Windows.Forms;

namespace Inovaclinica {
    partial class FormTelaInicial {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.panelRodape = new System.Windows.Forms.Panel();
            this.footerLabel = new System.Windows.Forms.Label();
            this.footerLabel1 = new System.Windows.Forms.Label();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.LogoCabecalho = new System.Windows.Forms.PictureBox();
            this.panelRodape.SuspendLayout();
            this.panelCabecalho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoCabecalho)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.footerLabel);
            this.panelRodape.Controls.Add(this.footerLabel1);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 553);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(1238, 80);
            this.panelRodape.TabIndex = 0;
            // 
            // footerLabel
            // 
            this.footerLabel.AutoSize = true;
            this.footerLabel.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.footerLabel.Location = new System.Drawing.Point(10, 20);
            this.footerLabel.Name = "footerLabel";
            this.footerLabel.Size = new System.Drawing.Size(104, 16);
            this.footerLabel.TabIndex = 0;
            this.footerLabel.Text = "INOVACLINICA";
            this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerLabel1
            // 
            this.footerLabel1.AutoSize = true;
            this.footerLabel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.footerLabel1.Location = new System.Drawing.Point(10, 40);
            this.footerLabel1.Name = "footerLabel1";
            this.footerLabel1.Size = new System.Drawing.Size(55, 16);
            this.footerLabel1.TabIndex = 1;
            this.footerLabel1.Text = "Versão:";
            this.footerLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = System.Drawing.Color.Transparent;
            this.panelCabecalho.Controls.Add(this.LogoCabecalho);
            this.panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(1238, 80);
            this.panelCabecalho.TabIndex = 1;
            // 
            // LogoCabecalho
            // 
            this.LogoCabecalho.Location = new System.Drawing.Point(24, 12);
            this.LogoCabecalho.Name = "LogoCabecalho";
            this.LogoCabecalho.Size = new System.Drawing.Size(100, 50);
            this.LogoCabecalho.TabIndex = 0;
            this.LogoCabecalho.TabStop = false;
            this.LogoCabecalho.Click += new System.EventHandler(this.LogoCabecalho_Click);
            // 
            // FormTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 633);
            this.Controls.Add(this.panelCabecalho);
            this.Controls.Add(this.panelRodape);
            this.Name = "FormTelaInicial";
            this.Text = "Form1";
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.panelCabecalho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoCabecalho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRodape;
        private Label footerLabel;
        private Label footerLabel1;
        private Panel panelCabecalho;
        private PictureBox LogoCabecalho;
    }
}

