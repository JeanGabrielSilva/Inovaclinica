namespace Inovaclinica
{
    partial class modalAgendarOrcamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modalAgendarOrcamento));
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelHorarios = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDetalhes = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataAgendamento = new System.Windows.Forms.MaskedTextBox();
            this.lblValorTotal = new System.Windows.Forms.NumericUpDown();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCarregarHorariosDisponiveis = new System.Windows.Forms.Button();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.flowLayoutPanelHorarios.SuspendLayout();
            this.panelDetalhes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horários Disponíveis";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // flowLayoutPanelHorarios
            // 
            this.flowLayoutPanelHorarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelHorarios.Controls.Add(this.panelDetalhes);
            this.flowLayoutPanelHorarios.Location = new System.Drawing.Point(17, 197);
            this.flowLayoutPanelHorarios.Name = "flowLayoutPanelHorarios";
            this.flowLayoutPanelHorarios.Size = new System.Drawing.Size(533, 154);
            this.flowLayoutPanelHorarios.TabIndex = 1;
            this.flowLayoutPanelHorarios.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelHorarios_Paint);
            // 
            // panelDetalhes
            // 
            this.panelDetalhes.Controls.Add(this.label5);
            this.panelDetalhes.Controls.Add(this.pictureBox1);
            this.panelDetalhes.Location = new System.Drawing.Point(3, 3);
            this.panelDetalhes.Name = "panelDetalhes";
            this.panelDetalhes.Size = new System.Drawing.Size(525, 147);
            this.panelDetalhes.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Black", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Location = new System.Drawing.Point(106, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(365, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Selecione uma data para exibir os horários disponíveis";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(235, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 76);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(13, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome do Cliente:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Data do Agendamento:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dataAgendamento
            // 
            this.dataAgendamento.BackColor = System.Drawing.SystemColors.Window;
            this.dataAgendamento.Font = new System.Drawing.Font("Arial Black", 9.5F, System.Drawing.FontStyle.Bold);
            this.dataAgendamento.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataAgendamento.Location = new System.Drawing.Point(199, 57);
            this.dataAgendamento.Mask = "00/00/0000";
            this.dataAgendamento.Name = "dataAgendamento";
            this.dataAgendamento.Size = new System.Drawing.Size(86, 25);
            this.dataAgendamento.TabIndex = 46;
            this.dataAgendamento.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.dataAgendamento_MaskInputRejected);
            // 
            // lblValorTotal
            // 
            this.lblValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblValorTotal.DecimalPlaces = 2;
            this.lblValorTotal.Font = new System.Drawing.Font("Arial Black", 11F, System.Drawing.FontStyle.Bold);
            this.lblValorTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.lblValorTotal.InterceptArrowKeys = false;
            this.lblValorTotal.Location = new System.Drawing.Point(438, 58);
            this.lblValorTotal.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.lblValorTotal.Name = "lblValorTotal";
            this.lblValorTotal.Size = new System.Drawing.Size(112, 24);
            this.lblValorTotal.TabIndex = 50;
            this.lblValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lblValorTotal.ThousandsSeparator = true;
            this.lblValorTotal.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.lblValorTotal.ValueChanged += new System.EventHandler(this.lblValorTotal_ValueChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.pictureBox3.Image = global::Inovaclinica.Properties.Resources.moedas;
            this.pictureBox3.Location = new System.Drawing.Point(425, 57);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(323, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 19);
            this.label4.TabIndex = 52;
            this.label4.Text = "Valor Total:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnCarregarHorariosDisponiveis
            // 
            this.btnCarregarHorariosDisponiveis.AutoSize = true;
            this.btnCarregarHorariosDisponiveis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.btnCarregarHorariosDisponiveis.FlatAppearance.BorderSize = 0;
            this.btnCarregarHorariosDisponiveis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarregarHorariosDisponiveis.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.btnCarregarHorariosDisponiveis.ForeColor = System.Drawing.Color.White;
            this.btnCarregarHorariosDisponiveis.Image = ((System.Drawing.Image)(resources.GetObject("btnCarregarHorariosDisponiveis.Image")));
            this.btnCarregarHorariosDisponiveis.Location = new System.Drawing.Point(17, 103);
            this.btnCarregarHorariosDisponiveis.Name = "btnCarregarHorariosDisponiveis";
            this.btnCarregarHorariosDisponiveis.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btnCarregarHorariosDisponiveis.Size = new System.Drawing.Size(191, 42);
            this.btnCarregarHorariosDisponiveis.TabIndex = 53;
            this.btnCarregarHorariosDisponiveis.Text = "Carregar Horários";
            this.btnCarregarHorariosDisponiveis.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCarregarHorariosDisponiveis.UseVisualStyleBackColor = false;
            this.btnCarregarHorariosDisponiveis.Click += new System.EventHandler(this.btnCarregarHorariosDisponiveis_Click);
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Arial Black", 10F, System.Drawing.FontStyle.Bold);
            this.lblNomeCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNomeCliente.Location = new System.Drawing.Point(159, 18);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(53, 19);
            this.lblNomeCliente.TabIndex = 54;
            this.lblNomeCliente.Text = "Nome";
            this.lblNomeCliente.Click += new System.EventHandler(this.lblNomeCliente_Click);
            // 
            // modalAgendarOrcamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 369);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.btnCarregarHorariosDisponiveis);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lblValorTotal);
            this.Controls.Add(this.dataAgendamento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanelHorarios);
            this.Name = "modalAgendarOrcamento";
            this.Text = "modalAgendarOrcamento";
            this.Load += new System.EventHandler(this.modalAgendarOrcamento_Load);
            this.flowLayoutPanelHorarios.ResumeLayout(false);
            this.panelDetalhes.ResumeLayout(false);
            this.panelDetalhes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValorTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelHorarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox dataAgendamento;
        private System.Windows.Forms.NumericUpDown lblValorTotal;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCarregarHorariosDisponiveis;
        private System.Windows.Forms.Panel panelDetalhes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNomeCliente;
    }
}