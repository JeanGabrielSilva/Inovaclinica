namespace Inovaclinica
{
    partial class FormClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientes));
            this.panelRodape = new System.Windows.Forms.Panel();
            this.footerLabel = new System.Windows.Forms.Label();
            this.footerLabel1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgProcurar = new System.Windows.Forms.PictureBox();
            this.barraPesquisaClientes = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridClientes = new System.Windows.Forms.DataGridView();
            this.panelRodape.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProcurar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.footerLabel);
            this.panelRodape.Controls.Add(this.footerLabel1);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 488);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(947, 80);
            this.panelRodape.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.imgProcurar);
            this.panel1.Controls.Add(this.barraPesquisaClientes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 78);
            this.panel1.TabIndex = 2;
            // 
            // imgProcurar
            // 
            this.imgProcurar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgProcurar.Image = ((System.Drawing.Image)(resources.GetObject("imgProcurar.Image")));
            this.imgProcurar.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgProcurar.InitialImage")));
            this.imgProcurar.Location = new System.Drawing.Point(26, 12);
            this.imgProcurar.Name = "imgProcurar";
            this.imgProcurar.Size = new System.Drawing.Size(48, 47);
            this.imgProcurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgProcurar.TabIndex = 1;
            this.imgProcurar.TabStop = false;
            // 
            // barraPesquisaClientes
            // 
            this.barraPesquisaClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.barraPesquisaClientes.CausesValidation = false;
            this.barraPesquisaClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraPesquisaClientes.Location = new System.Drawing.Point(72, 12);
            this.barraPesquisaClientes.Name = "barraPesquisaClientes";
            this.barraPesquisaClientes.Size = new System.Drawing.Size(842, 47);
            this.barraPesquisaClientes.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridClientes);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(947, 410);
            this.panel2.TabIndex = 3;
            // 
            // dataGridClientes
            // 
            this.dataGridClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridClientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridClientes.Location = new System.Drawing.Point(0, 0);
            this.dataGridClientes.Name = "dataGridClientes";
            this.dataGridClientes.Size = new System.Drawing.Size(947, 410);
            this.dataGridClientes.TabIndex = 0;
            // 
            // FormClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 568);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelRodape);
            this.Name = "FormClientes";
            this.Text = "FormClientes";
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgProcurar)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.Label footerLabel;
        private System.Windows.Forms.Label footerLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox barraPesquisaClientes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridClientes;
        private System.Windows.Forms.PictureBox imgProcurar;
    }
}