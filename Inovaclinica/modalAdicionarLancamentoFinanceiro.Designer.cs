namespace Inovaclinica
{
    partial class modalAdicionarLancamentoFinanceiro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modalAdicionarLancamentoFinanceiro));
            this.panelRodape = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCancelarVisualizarClientes = new System.Windows.Forms.Label();
            this.btnSaida = new System.Windows.Forms.Button();
            this.btnEntrada = new System.Windows.Forms.Button();
            this.btnAdicionarLancamento = new System.Windows.Forms.PictureBox();
            this.btnCancelarLancamento = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxValorLancamento = new System.Windows.Forms.NumericUpDown();
            this.lblFiltrarNomeCliente = new System.Windows.Forms.Label();
            this.textBoxDescricaoLancamento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCategoriaLancamento = new System.Windows.Forms.TextBox();
            this.lblFiltrarDataNascimentoCliente = new System.Windows.Forms.Label();
            this.maskDataVencimentoLancamento = new System.Windows.Forms.MaskedTextBox();
            this.panelRodape.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionarLancamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarLancamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxValorLancamento)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.tableLayoutPanel1);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 341);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(329, 69);
            this.panelRodape.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCancelarVisualizarClientes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAdicionarLancamento, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelarLancamento, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(88, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(152, 66);
            this.tableLayoutPanel1.TabIndex = 18;
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
            // btnSaida
            // 
            this.btnSaida.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaida.ForeColor = System.Drawing.Color.White;
            this.btnSaida.Image = global::Inovaclinica.Properties.Resources.seta_alt_circulo_para_baixo__1_;
            this.btnSaida.Location = new System.Drawing.Point(189, 262);
            this.btnSaida.Name = "btnSaida";
            this.btnSaida.Size = new System.Drawing.Size(119, 61);
            this.btnSaida.TabIndex = 26;
            this.btnSaida.Text = "Saída";
            this.btnSaida.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSaida.UseVisualStyleBackColor = true;
            this.btnSaida.Click += new System.EventHandler(this.btnSaida_Click);
            // 
            // btnEntrada
            // 
            this.btnEntrada.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.btnEntrada.ForeColor = System.Drawing.Color.White;
            this.btnEntrada.Image = global::Inovaclinica.Properties.Resources.seta_alt_circulo_para_cima__1_;
            this.btnEntrada.Location = new System.Drawing.Point(24, 262);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(119, 61);
            this.btnEntrada.TabIndex = 25;
            this.btnEntrada.Text = "Entrada";
            this.btnEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnEntrada.UseVisualStyleBackColor = true;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // btnAdicionarLancamento
            // 
            this.btnAdicionarLancamento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionarLancamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarLancamento.Image = ((System.Drawing.Image)(resources.GetObject("btnAdicionarLancamento.Image")));
            this.btnAdicionarLancamento.Location = new System.Drawing.Point(3, 3);
            this.btnAdicionarLancamento.Name = "btnAdicionarLancamento";
            this.btnAdicionarLancamento.Size = new System.Drawing.Size(70, 38);
            this.btnAdicionarLancamento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAdicionarLancamento.TabIndex = 14;
            this.btnAdicionarLancamento.TabStop = false;
            this.btnAdicionarLancamento.Click += new System.EventHandler(this.btnAdicionarLancamento_Click);
            // 
            // btnCancelarLancamento
            // 
            this.btnCancelarLancamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarLancamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelarLancamento.Image = global::Inovaclinica.Properties.Resources.circulo_x__1_;
            this.btnCancelarLancamento.Location = new System.Drawing.Point(79, 3);
            this.btnCancelarLancamento.Name = "btnCancelarLancamento";
            this.btnCancelarLancamento.Size = new System.Drawing.Size(70, 38);
            this.btnCancelarLancamento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCancelarLancamento.TabIndex = 17;
            this.btnCancelarLancamento.TabStop = false;
            this.btnCancelarLancamento.Click += new System.EventHandler(this.btnCancelarLancamento_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.pictureBox3.Image = global::Inovaclinica.Properties.Resources.moedas;
            this.pictureBox3.Location = new System.Drawing.Point(180, 211);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 57;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(108, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 22);
            this.label4.TabIndex = 56;
            this.label4.Text = "Valor";
            // 
            // textBoxValorLancamento
            // 
            this.textBoxValorLancamento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxValorLancamento.DecimalPlaces = 2;
            this.textBoxValorLancamento.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.textBoxValorLancamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.textBoxValorLancamento.InterceptArrowKeys = false;
            this.textBoxValorLancamento.Location = new System.Drawing.Point(194, 211);
            this.textBoxValorLancamento.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.textBoxValorLancamento.Name = "textBoxValorLancamento";
            this.textBoxValorLancamento.Size = new System.Drawing.Size(112, 24);
            this.textBoxValorLancamento.TabIndex = 55;
            this.textBoxValorLancamento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxValorLancamento.ThousandsSeparator = true;
            this.textBoxValorLancamento.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            // 
            // lblFiltrarNomeCliente
            // 
            this.lblFiltrarNomeCliente.AutoSize = true;
            this.lblFiltrarNomeCliente.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblFiltrarNomeCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFiltrarNomeCliente.Location = new System.Drawing.Point(20, 36);
            this.lblFiltrarNomeCliente.Name = "lblFiltrarNomeCliente";
            this.lblFiltrarNomeCliente.Size = new System.Drawing.Size(93, 22);
            this.lblFiltrarNomeCliente.TabIndex = 58;
            this.lblFiltrarNomeCliente.Text = "Descrição";
            // 
            // textBoxDescricaoLancamento
            // 
            this.textBoxDescricaoLancamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescricaoLancamento.Location = new System.Drawing.Point(119, 34);
            this.textBoxDescricaoLancamento.Name = "textBoxDescricaoLancamento";
            this.textBoxDescricaoLancamento.Size = new System.Drawing.Size(194, 24);
            this.textBoxDescricaoLancamento.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(20, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.TabIndex = 60;
            this.label1.Text = "Categoria";
            // 
            // textBoxCategoriaLancamento
            // 
            this.textBoxCategoriaLancamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCategoriaLancamento.Location = new System.Drawing.Point(119, 96);
            this.textBoxCategoriaLancamento.Name = "textBoxCategoriaLancamento";
            this.textBoxCategoriaLancamento.Size = new System.Drawing.Size(194, 24);
            this.textBoxCategoriaLancamento.TabIndex = 61;
            // 
            // lblFiltrarDataNascimentoCliente
            // 
            this.lblFiltrarDataNascimentoCliente.AutoSize = true;
            this.lblFiltrarDataNascimentoCliente.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblFiltrarDataNascimentoCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFiltrarDataNascimentoCliente.Location = new System.Drawing.Point(20, 156);
            this.lblFiltrarDataNascimentoCliente.Name = "lblFiltrarDataNascimentoCliente";
            this.lblFiltrarDataNascimentoCliente.Size = new System.Drawing.Size(177, 22);
            this.lblFiltrarDataNascimentoCliente.TabIndex = 62;
            this.lblFiltrarDataNascimentoCliente.Text = "Data de Vencimento";
            // 
            // maskDataVencimentoLancamento
            // 
            this.maskDataVencimentoLancamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskDataVencimentoLancamento.Location = new System.Drawing.Point(231, 156);
            this.maskDataVencimentoLancamento.Mask = "00/00/0000";
            this.maskDataVencimentoLancamento.Name = "maskDataVencimentoLancamento";
            this.maskDataVencimentoLancamento.Size = new System.Drawing.Size(77, 24);
            this.maskDataVencimentoLancamento.TabIndex = 63;
            this.maskDataVencimentoLancamento.ValidatingType = typeof(System.DateTime);
            // 
            // modalAdicionarLancamentoFinanceiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 410);
            this.Controls.Add(this.maskDataVencimentoLancamento);
            this.Controls.Add(this.lblFiltrarDataNascimentoCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCategoriaLancamento);
            this.Controls.Add(this.lblFiltrarNomeCliente);
            this.Controls.Add(this.textBoxDescricaoLancamento);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxValorLancamento);
            this.Controls.Add(this.btnSaida);
            this.Controls.Add(this.btnEntrada);
            this.Controls.Add(this.panelRodape);
            this.Name = "modalAdicionarLancamentoFinanceiro";
            this.Text = "modalAdicionarLancamentoFinanceiro";
            this.panelRodape.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionarLancamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarLancamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxValorLancamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCancelarVisualizarClientes;
        private System.Windows.Forms.PictureBox btnAdicionarLancamento;
        private System.Windows.Forms.PictureBox btnCancelarLancamento;
        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Button btnSaida;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown textBoxValorLancamento;
        private System.Windows.Forms.Label lblFiltrarNomeCliente;
        private System.Windows.Forms.TextBox textBoxDescricaoLancamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCategoriaLancamento;
        private System.Windows.Forms.Label lblFiltrarDataNascimentoCliente;
        private System.Windows.Forms.MaskedTextBox maskDataVencimentoLancamento;
    }
}