﻿namespace Inovaclinica
{
    partial class modalAdicionarProcedimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modalAdicionarProcedimento));
            this.Dados = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.precoProcedimento = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nomeProcedimento = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.descricaoProcedimento = new System.Windows.Forms.TextBox();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCancelarVisualizarClientes = new System.Windows.Forms.Label();
            this.btnAdicionarProcedimento = new System.Windows.Forms.PictureBox();
            this.btnCancelarAlteracaoProcedimento = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Dados.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.precoProcedimento)).BeginInit();
            this.panelRodape.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionarProcedimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarAlteracaoProcedimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Dados
            // 
            this.Dados.Controls.Add(this.tabPage1);
            this.Dados.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Dados.Location = new System.Drawing.Point(0, 64);
            this.Dados.Name = "Dados";
            this.Dados.SelectedIndex = 0;
            this.Dados.Size = new System.Drawing.Size(800, 323);
            this.Dados.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nomeProcedimento);
            this.tabPage1.Controls.Add(this.lblNome);
            this.tabPage1.Controls.Add(this.descricaoProcedimento);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 292);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.precoProcedimento);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(585, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 70);
            this.panel1.TabIndex = 47;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Location = new System.Drawing.Point(34, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(29, 33);
            this.panel3.TabIndex = 49;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Inovaclinica.Properties.Resources.moedas;
            this.pictureBox3.Location = new System.Drawing.Point(0, -1);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 49;
            this.pictureBox3.TabStop = false;
            // 
            // precoProcedimento
            // 
            this.precoProcedimento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.precoProcedimento.DecimalPlaces = 2;
            this.precoProcedimento.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.precoProcedimento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.precoProcedimento.InterceptArrowKeys = false;
            this.precoProcedimento.Location = new System.Drawing.Point(34, 36);
            this.precoProcedimento.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.precoProcedimento.Name = "precoProcedimento";
            this.precoProcedimento.Size = new System.Drawing.Size(112, 24);
            this.precoProcedimento.TabIndex = 49;
            this.precoProcedimento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.precoProcedimento.ThousandsSeparator = true;
            this.precoProcedimento.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(4, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 23);
            this.label3.TabIndex = 39;
            this.label3.Text = "Preço";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 38;
            this.label1.Text = "Nome";
            // 
            // nomeProcedimento
            // 
            this.nomeProcedimento.Location = new System.Drawing.Point(24, 43);
            this.nomeProcedimento.Name = "nomeProcedimento";
            this.nomeProcedimento.Size = new System.Drawing.Size(348, 24);
            this.nomeProcedimento.TabIndex = 37;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblNome.Location = new System.Drawing.Point(20, 94);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(182, 22);
            this.lblNome.TabIndex = 22;
            this.lblNome.Text = "Descrição Detalhada";
            // 
            // descricaoProcedimento
            // 
            this.descricaoProcedimento.Location = new System.Drawing.Point(24, 119);
            this.descricaoProcedimento.Name = "descricaoProcedimento";
            this.descricaoProcedimento.Size = new System.Drawing.Size(479, 24);
            this.descricaoProcedimento.TabIndex = 3;
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.tableLayoutPanel1);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 381);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(800, 69);
            this.panelRodape.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCancelarVisualizarClientes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAdicionarProcedimento, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelarAlteracaoProcedimento, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(328, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(152, 66);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(3, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 22);
            this.label5.TabIndex = 16;
            this.label5.Text = "Gravar";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCancelarVisualizarClientes
            // 
            this.labelCancelarVisualizarClientes.AutoSize = true;
            this.labelCancelarVisualizarClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCancelarVisualizarClientes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCancelarVisualizarClientes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelCancelarVisualizarClientes.Location = new System.Drawing.Point(79, 44);
            this.labelCancelarVisualizarClientes.Name = "labelCancelarVisualizarClientes";
            this.labelCancelarVisualizarClientes.Size = new System.Drawing.Size(70, 22);
            this.labelCancelarVisualizarClientes.TabIndex = 15;
            this.labelCancelarVisualizarClientes.Text = "Cancelar";
            this.labelCancelarVisualizarClientes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAdicionarProcedimento
            // 
            this.btnAdicionarProcedimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarProcedimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarProcedimento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarProcedimento.Image")));
            this.btnAdicionarProcedimento.Location = new System.Drawing.Point(3, 3);
            this.btnAdicionarProcedimento.Name = "btnAdicionarProcedimento";
            this.btnAdicionarProcedimento.Size = new System.Drawing.Size(70, 38);
            this.btnAdicionarProcedimento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAdicionarProcedimento.TabIndex = 14;
            this.btnAdicionarProcedimento.TabStop = false;
            this.btnAdicionarProcedimento.Click += new System.EventHandler(this.btnAdicionarProcedimento_Click);
            // 
            // btnCancelarAlteracaoProcedimento
            // 
            this.btnCancelarAlteracaoProcedimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarAlteracaoProcedimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelarAlteracaoProcedimento.Image = global::Inovaclinica.Properties.Resources.circulo_x__1_;
            this.btnCancelarAlteracaoProcedimento.Location = new System.Drawing.Point(79, 3);
            this.btnCancelarAlteracaoProcedimento.Name = "btnCancelarAlteracaoProcedimento";
            this.btnCancelarAlteracaoProcedimento.Size = new System.Drawing.Size(70, 38);
            this.btnCancelarAlteracaoProcedimento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCancelarAlteracaoProcedimento.TabIndex = 17;
            this.btnCancelarAlteracaoProcedimento.TabStop = false;
            this.btnCancelarAlteracaoProcedimento.Click += new System.EventHandler(this.btnCancelarAlteracaoProcedimento_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Inovaclinica.Properties.Resources.seringa__1_2;
            this.pictureBox1.Location = new System.Drawing.Point(720, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(68, 67);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // modalAdicionarProcedimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelRodape);
            this.Controls.Add(this.Dados);
            this.Name = "modalAdicionarProcedimento";
            this.Text = "modalAdicionarProcedimento";
            this.Load += new System.EventHandler(this.modalAdicionarProcedimento_Load);
            this.Dados.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.precoProcedimento)).EndInit();
            this.panelRodape.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionarProcedimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarAlteracaoProcedimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Dados;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCancelarVisualizarClientes;
        private System.Windows.Forms.PictureBox btnAdicionarProcedimento;
        private System.Windows.Forms.PictureBox btnCancelarAlteracaoProcedimento;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.NumericUpDown precoProcedimento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nomeProcedimento;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox descricaoProcedimento;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}