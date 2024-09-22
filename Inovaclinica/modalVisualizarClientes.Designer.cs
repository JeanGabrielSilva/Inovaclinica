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
            this.textBoxNomeCliente = new System.Windows.Forms.TextBox();
            this.textBoxTelefone = new System.Windows.Forms.TextBox();
            this.textBoxEndereco = new System.Windows.Forms.TextBox();
            this.labelClienteID = new System.Windows.Forms.Label();
            this.checkBoxAtivoCliente = new System.Windows.Forms.CheckBox();
            this.labelDataCadastro = new System.Windows.Forms.Label();
            this.maskTextBoxCpfCliente = new System.Windows.Forms.MaskedTextBox();
            this.dateTimePickerDataNascimento = new System.Windows.Forms.DateTimePicker();
            this.btnSalvarAlteracaoCliente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNomeCliente
            // 
            this.textBoxNomeCliente.Location = new System.Drawing.Point(313, 66);
            this.textBoxNomeCliente.Name = "textBoxNomeCliente";
            this.textBoxNomeCliente.Size = new System.Drawing.Size(165, 20);
            this.textBoxNomeCliente.TabIndex = 3;
            this.textBoxNomeCliente.TextChanged += new System.EventHandler(this.textBoxNomeCliente_TextChanged);
            // 
            // textBoxTelefone
            // 
            this.textBoxTelefone.Location = new System.Drawing.Point(315, 148);
            this.textBoxTelefone.Name = "textBoxTelefone";
            this.textBoxTelefone.Size = new System.Drawing.Size(161, 20);
            this.textBoxTelefone.TabIndex = 5;
            // 
            // textBoxEndereco
            // 
            this.textBoxEndereco.Location = new System.Drawing.Point(313, 229);
            this.textBoxEndereco.Name = "textBoxEndereco";
            this.textBoxEndereco.Size = new System.Drawing.Size(161, 20);
            this.textBoxEndereco.TabIndex = 7;
            // 
            // labelClienteID
            // 
            this.labelClienteID.AutoSize = true;
            this.labelClienteID.Location = new System.Drawing.Point(314, 37);
            this.labelClienteID.Name = "labelClienteID";
            this.labelClienteID.Size = new System.Drawing.Size(35, 13);
            this.labelClienteID.TabIndex = 8;
            this.labelClienteID.Text = "label1";
            // 
            // checkBoxAtivoCliente
            // 
            this.checkBoxAtivoCliente.AutoSize = true;
            this.checkBoxAtivoCliente.Location = new System.Drawing.Point(313, 267);
            this.checkBoxAtivoCliente.Name = "checkBoxAtivoCliente";
            this.checkBoxAtivoCliente.Size = new System.Drawing.Size(50, 17);
            this.checkBoxAtivoCliente.TabIndex = 9;
            this.checkBoxAtivoCliente.Text = "Ativo";
            this.checkBoxAtivoCliente.UseVisualStyleBackColor = true;
            // 
            // labelDataCadastro
            // 
            this.labelDataCadastro.AutoSize = true;
            this.labelDataCadastro.Location = new System.Drawing.Point(310, 304);
            this.labelDataCadastro.Name = "labelDataCadastro";
            this.labelDataCadastro.Size = new System.Drawing.Size(35, 13);
            this.labelDataCadastro.TabIndex = 10;
            this.labelDataCadastro.Text = "label1";
            // 
            // maskTextBoxCpfCliente
            // 
            this.maskTextBoxCpfCliente.Location = new System.Drawing.Point(315, 108);
            this.maskTextBoxCpfCliente.Mask = "000.000.000-00";
            this.maskTextBoxCpfCliente.Name = "maskTextBoxCpfCliente";
            this.maskTextBoxCpfCliente.Size = new System.Drawing.Size(162, 20);
            this.maskTextBoxCpfCliente.TabIndex = 11;
            // 
            // dateTimePickerDataNascimento
            // 
            this.dateTimePickerDataNascimento.Location = new System.Drawing.Point(313, 191);
            this.dateTimePickerDataNascimento.Name = "dateTimePickerDataNascimento";
            this.dateTimePickerDataNascimento.Size = new System.Drawing.Size(162, 20);
            this.dateTimePickerDataNascimento.TabIndex = 12;
            // 
            // btnSalvarAlteracaoCliente
            // 
            this.btnSalvarAlteracaoCliente.Location = new System.Drawing.Point(308, 341);
            this.btnSalvarAlteracaoCliente.Name = "btnSalvarAlteracaoCliente";
            this.btnSalvarAlteracaoCliente.Size = new System.Drawing.Size(170, 39);
            this.btnSalvarAlteracaoCliente.TabIndex = 13;
            this.btnSalvarAlteracaoCliente.Text = "Salvar";
            this.btnSalvarAlteracaoCliente.UseVisualStyleBackColor = true;
            this.btnSalvarAlteracaoCliente.Click += new System.EventHandler(this.btnSalvarAlteracaoCliente_Click);
            // 
            // modalVisualizarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSalvarAlteracaoCliente);
            this.Controls.Add(this.dateTimePickerDataNascimento);
            this.Controls.Add(this.maskTextBoxCpfCliente);
            this.Controls.Add(this.labelDataCadastro);
            this.Controls.Add(this.checkBoxAtivoCliente);
            this.Controls.Add(this.labelClienteID);
            this.Controls.Add(this.textBoxEndereco);
            this.Controls.Add(this.textBoxTelefone);
            this.Controls.Add(this.textBoxNomeCliente);
            this.Name = "modalVisualizarClientes";
            this.Text = "modalVisualizarClientes";
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
        private System.Windows.Forms.Button btnSalvarAlteracaoCliente;
    }
}