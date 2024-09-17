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
            this.footerLabelCabecalho = new System.Windows.Forms.Label();
            this.footerLabelCabecalho1 = new System.Windows.Forms.Label();
            this.panelRodape.SuspendLayout();
            this.panelCabecalho.SuspendLayout();
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
            this.panelCabecalho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelCabecalho.Controls.Add(this.footerLabelCabecalho);
            this.panelCabecalho.Controls.Add(this.footerLabelCabecalho1);
            this.panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(1238, 80);
            this.panelCabecalho.TabIndex = 1;
            // 
            // footerLabelCabecalho
            // 
            this.footerLabelCabecalho.AutoSize = true;
            this.footerLabelCabecalho.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.footerLabelCabecalho.Location = new System.Drawing.Point(10, 20);
            this.footerLabelCabecalho.Name = "footerLabelCabecalho";
            this.footerLabelCabecalho.Size = new System.Drawing.Size(104, 16);
            this.footerLabelCabecalho.TabIndex = 0;
            this.footerLabelCabecalho.Text = "INOVACLINICA";
            this.footerLabelCabecalho.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerLabelCabecalho1
            // 
            this.footerLabelCabecalho1.AutoSize = true;
            this.footerLabelCabecalho1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.footerLabelCabecalho1.Location = new System.Drawing.Point(10, 40);
            this.footerLabelCabecalho1.Name = "footerLabelCabecalho1";
            this.footerLabelCabecalho1.Size = new System.Drawing.Size(75, 16);
            this.footerLabelCabecalho1.TabIndex = 1;
            this.footerLabelCabecalho1.Text = "Cabeçalho";
            this.footerLabelCabecalho1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.panelCabecalho.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRodape;
        private Label footerLabel;
        private Label footerLabel1;
        private Panel panelCabecalho;
        private Label footerLabelCabecalho;
        private Label footerLabelCabecalho1;
    }
}

