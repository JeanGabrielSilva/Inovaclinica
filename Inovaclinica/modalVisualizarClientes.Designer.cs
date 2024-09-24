namespace Inovaclinica {
    partial class modalVisualizarClientes {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modalVisualizarClientes));
            this.textBoxNomeCliente = new System.Windows.Forms.TextBox();
            this.textBoxTelefone = new System.Windows.Forms.TextBox();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.labelClienteID = new System.Windows.Forms.Label();
            this.checkBoxAtivoCliente = new System.Windows.Forms.CheckBox();
            this.labelDataCadastro = new System.Windows.Forms.Label();
            this.maskTextBoxCpfCliente = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePickerDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.Dados = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalvarAlteracaoCliente1 = new System.Windows.Forms.Button();
            this.btnSalvarAlteracaoCliente = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Dados.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelRodape.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvarAlteracaoCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNomeCliente
            // 
            this.textBoxNomeCliente.Location = new System.Drawing.Point(20, 23);
            this.textBoxNomeCliente.Name = "textBoxNomeCliente";
            this.textBoxNomeCliente.Size = new System.Drawing.Size(165, 20);
            this.textBoxNomeCliente.TabIndex = 3;
            this.textBoxNomeCliente.TextChanged += new System.EventHandler(this.textBoxNomeCliente_TextChanged);
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.Location = new System.Drawing.Point(24, 111);
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.Size = new System.Drawing.Size(161, 20);
            this.textBoxTelefone.TabIndex = 5;
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Location = new System.Drawing.Point(22, 192);
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(161, 20);
            this.textBoxEndereco.TabIndex = 7;
            // 
            // labelClienteID
            // 
            this.labelClienteID.AutoSize = true;
            this.labelClienteID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClienteID.Location = new System.Drawing.Point(681, 20);
            this.labelClienteID.Name = "labelClienteID";
            this.labelClienteID.Size = new System.Drawing.Size(92, 25);
            this.labelClienteID.TabIndex = 8;
            this.labelClienteID.Text = "ClienteID";
            this.labelClienteID.Click += new System.EventHandler(this.labelClienteID_Click);
            // 
            // checkBoxAtivoCliente
            // 
            this.checkBoxAtivoCliente.AutoSize = true;
            this.checkBoxAtivoCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAtivoCliente.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxAtivoCliente.Location = new System.Drawing.Point(717, 35);
            this.checkBoxAtivoCliente.Name = "checkBoxAtivoCliente";
            this.checkBoxAtivoCliente.Size = new System.Drawing.Size(56, 19);
            this.checkBoxAtivoCliente.TabIndex = 9;
            this.checkBoxAtivoCliente.Text = "Ativo";
            this.checkBoxAtivoCliente.UseVisualStyleBackColor = true;
            this.checkBoxAtivoCliente.CheckedChanged += new System.EventHandler(this.checkBoxAtivoCliente_CheckedChanged);
            // 
            // labelDataCadastro
            // 
            this.labelDataCadastro.AutoSize = true;
            this.labelDataCadastro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.labelDataCadastro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDataCadastro.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelDataCadastro.Location = new System.Drawing.Point(123, 35);
            this.labelDataCadastro.Name = "labelDataCadastro";
            this.labelDataCadastro.Size = new System.Drawing.Size(94, 15);
            this.labelDataCadastro.TabIndex = 10;
            this.labelDataCadastro.Text = "DataCadastro";
            this.labelDataCadastro.Click += new System.EventHandler(this.labelDataCadastro_Click);
            // 
            // maskTextBoxCpfCliente
            // 
            this.maskTextBoxCpfCliente.Location = new System.Drawing.Point(24, 71);
            this.maskTextBoxCpfCliente.Mask = "000.000.000-00";
            this.maskTextBoxCpfCliente.Name = "maskTextBoxCpfCliente";
            this.maskTextBoxCpfCliente.Size = new System.Drawing.Size(162, 20);
            this.maskTextBoxCpfCliente.TabIndex = 11;
            // 
            // dateTimePickerDataNascimento
            // 
            this.dateTimePickerDataNascimento.Location = new System.Drawing.Point(22, 154);
            this.dateTimePickerDataNascimento.Name = "dateTimePickerDataNascimento";
            this.dateTimePickerDataNascimento.Size = new System.Drawing.Size(162, 20);
            this.dateTimePickerDataNascimento.TabIndex = 12;
            // 
            // Dados
            // 
            this.Dados.Controls.Add(this.tabPage1);
            this.Dados.Controls.Add(this.tabPage2);
            this.Dados.Location = new System.Drawing.Point(0, 62);
            this.Dados.Name = "Dados";
            this.Dados.SelectedIndex = 0;
            this.Dados.Size = new System.Drawing.Size(799, 331);
            this.Dados.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxNomeCliente);
            this.tabPage1.Controls.Add(this.textBoxTelefone);
            this.tabPage1.Controls.Add(this.dateTimePickerDataNascimento);
            this.tabPage1.Controls.Add(this.textBoxEndereco);
            this.tabPage1.Controls.Add(this.maskTextBoxCpfCliente);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(791, 305);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(791, 305);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(604, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Código:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(1, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Data do Cadastro:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nome:";
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.Location = new System.Drawing.Point(67, 20);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(125, 25);
            this.lblNomeCliente.TabIndex = 18;
            this.lblNomeCliente.Text = "NomeCliente";
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.btnSalvarAlteracaoCliente1);
            this.panelRodape.Controls.Add(this.tableLayoutPanel1);
            this.panelRodape.Controls.Add(this.checkBoxAtivoCliente);
            this.panelRodape.Controls.Add(this.labelDataCadastro);
            this.panelRodape.Controls.Add(this.label2);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 381);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(800, 69);
            this.panelRodape.TabIndex = 19;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSalvarAlteracaoCliente, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(357, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(61, 55);
            this.tableLayoutPanel1.TabIndex = 17;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnSalvarAlteracaoCliente1
            // 
            this.btnSalvarAlteracaoCliente1.Location = new System.Drawing.Point(519, 18);
            this.btnSalvarAlteracaoCliente1.Name = "btnSalvarAlteracaoCliente1";
            this.btnSalvarAlteracaoCliente1.Size = new System.Drawing.Size(123, 39);
            this.btnSalvarAlteracaoCliente1.TabIndex = 13;
            this.btnSalvarAlteracaoCliente1.Text = "Salvar";
            this.btnSalvarAlteracaoCliente1.UseVisualStyleBackColor = true;
            this.btnSalvarAlteracaoCliente1.Click += new System.EventHandler(this.btnSalvarAlteracaoCliente_Click);
            // 
            // btnSalvarAlteracaoCliente
            // 
            this.btnSalvarAlteracaoCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvarAlteracaoCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvarAlteracaoCliente.Image")));
            this.btnSalvarAlteracaoCliente.Location = new System.Drawing.Point(3, 3);
            this.btnSalvarAlteracaoCliente.Name = "btnSalvarAlteracaoCliente";
            this.btnSalvarAlteracaoCliente.Size = new System.Drawing.Size(55, 30);
            this.btnSalvarAlteracaoCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSalvarAlteracaoCliente.TabIndex = 14;
            this.btnSalvarAlteracaoCliente.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Gravar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // modalVisualizarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dados);
            this.Controls.Add(this.labelClienteID);
            this.Controls.Add(this.panelRodape);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "modalVisualizarClientes";
            this.Text = "modalVisualizarClientes";
            this.Load += new System.EventHandler(this.modalVisualizarClientes_Load);
            this.Dados.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalvarAlteracaoCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxNomeCliente;
        private System.Windows.Forms.TextBox textBoxTelefone;
        private System.Windows.Forms.TextBox textBoxEndereco;
        private System.Windows.Forms.Label labelClienteID;
        private System.Windows.Forms.CheckBox checkBoxAtivoCliente;
        private System.Windows.Forms.Label labelDataCadastro;
        private System.Windows.Forms.MaskedTextBox maskTextBoxCpfCliente;
        private System.Windows.Forms.DateTimePicker dateTimePickerDataNascimento;
        private System.Windows.Forms.TabControl Dados;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSalvarAlteracaoCliente1;
        private System.Windows.Forms.PictureBox btnSalvarAlteracaoCliente;
        private System.Windows.Forms.Label label4;
    }
}