namespace Inovaclinica {
    partial class modalAdicionarCliente {
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
            this.nomeAdicionarCliente = new System.Windows.Forms.TextBox();
            this.btnAdicionarCliente = new System.Windows.Forms.Button();
            this.cpfAdicionarCliente = new System.Windows.Forms.MaskedTextBox();
            this.dataNascimentoAdicionarCliente = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // nomeAdicionarCliente
            // 
            this.nomeAdicionarCliente.Location = new System.Drawing.Point(276, 66);
            this.nomeAdicionarCliente.Name = "nomeAdicionarCliente";
            this.nomeAdicionarCliente.Size = new System.Drawing.Size(142, 20);
            this.nomeAdicionarCliente.TabIndex = 0;
            this.nomeAdicionarCliente.Text = "Nome";
            // 
            // btnAdicionarCliente
            // 
            this.btnAdicionarCliente.Location = new System.Drawing.Point(276, 222);
            this.btnAdicionarCliente.Name = "btnAdicionarCliente";
            this.btnAdicionarCliente.Size = new System.Drawing.Size(142, 41);
            this.btnAdicionarCliente.TabIndex = 4;
            this.btnAdicionarCliente.Text = "Adicionar";
            this.btnAdicionarCliente.UseVisualStyleBackColor = true;
            this.btnAdicionarCliente.Click += new System.EventHandler(this.btnAdicionarCliente_Click);
            // 
            // cpfAdicionarCliente
            // 
            this.cpfAdicionarCliente.Location = new System.Drawing.Point(276, 105);
            this.cpfAdicionarCliente.Mask = "000.000.000-00";
            this.cpfAdicionarCliente.Name = "cpfAdicionarCliente";
            this.cpfAdicionarCliente.Size = new System.Drawing.Size(142, 20);
            this.cpfAdicionarCliente.TabIndex = 5;
            // 
            // dataNascimentoAdicionarCliente
            // 
            this.dataNascimentoAdicionarCliente.Location = new System.Drawing.Point(266, 163);
            this.dataNascimentoAdicionarCliente.Name = "dataNascimentoAdicionarCliente";
            this.dataNascimentoAdicionarCliente.Size = new System.Drawing.Size(215, 20);
            this.dataNascimentoAdicionarCliente.TabIndex = 7;
            // 
            // modalAdicionarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataNascimentoAdicionarCliente);
            this.Controls.Add(this.cpfAdicionarCliente);
            this.Controls.Add(this.btnAdicionarCliente);
            this.Controls.Add(this.nomeAdicionarCliente);
            this.Name = "modalAdicionarCliente";
            this.Text = "modalAdicionarCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nomeAdicionarCliente;
        private System.Windows.Forms.Button btnAdicionarCliente;
        private System.Windows.Forms.MaskedTextBox cpfAdicionarCliente;
        private System.Windows.Forms.DateTimePicker dataNascimentoAdicionarCliente;
    }
}