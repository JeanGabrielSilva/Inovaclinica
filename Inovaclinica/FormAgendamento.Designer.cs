namespace Inovaclinica {
    partial class FormAgendamento {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgendamento));
            this.dataGridViewCalendarioProcedimento = new System.Windows.Forms.DataGridView();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCancelarVisualizarClientes = new System.Windows.Forms.Label();
            this.btnAdicionarProcedimento = new System.Windows.Forms.PictureBox();
            this.btnCancelarAlteracaoProcedimento = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalendarioProcedimento)).BeginInit();
            this.panelRodape.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionarProcedimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarAlteracaoProcedimento)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCalendarioProcedimento
            // 
            this.dataGridViewCalendarioProcedimento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCalendarioProcedimento.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewCalendarioProcedimento.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewCalendarioProcedimento.Name = "dataGridViewCalendarioProcedimento";
            this.dataGridViewCalendarioProcedimento.Size = new System.Drawing.Size(819, 635);
            this.dataGridViewCalendarioProcedimento.TabIndex = 0;
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.tableLayoutPanel1);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(819, 566);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(351, 69);
            this.panelRodape.TabIndex = 25;
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(351, 66);
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
            this.label5.Size = new System.Drawing.Size(169, 22);
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
            this.labelCancelarVisualizarClientes.Location = new System.Drawing.Point(178, 44);
            this.labelCancelarVisualizarClientes.Name = "labelCancelarVisualizarClientes";
            this.labelCancelarVisualizarClientes.Size = new System.Drawing.Size(170, 22);
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
            this.btnAdicionarProcedimento.Size = new System.Drawing.Size(169, 38);
            this.btnAdicionarProcedimento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAdicionarProcedimento.TabIndex = 14;
            this.btnAdicionarProcedimento.TabStop = false;
            // 
            // btnCancelarAlteracaoProcedimento
            // 
            this.btnCancelarAlteracaoProcedimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarAlteracaoProcedimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelarAlteracaoProcedimento.Image = global::Inovaclinica.Properties.Resources.circulo_x__1_;
            this.btnCancelarAlteracaoProcedimento.Location = new System.Drawing.Point(178, 3);
            this.btnCancelarAlteracaoProcedimento.Name = "btnCancelarAlteracaoProcedimento";
            this.btnCancelarAlteracaoProcedimento.Size = new System.Drawing.Size(170, 38);
            this.btnCancelarAlteracaoProcedimento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCancelarAlteracaoProcedimento.TabIndex = 17;
            this.btnCancelarAlteracaoProcedimento.TabStop = false;
            // 
            // FormAgendamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 635);
            this.Controls.Add(this.panelRodape);
            this.Controls.Add(this.dataGridViewCalendarioProcedimento);
            this.Name = "FormAgendamento";
            this.Text = "FormAgendamento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCalendarioProcedimento)).EndInit();
            this.panelRodape.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdicionarProcedimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarAlteracaoProcedimento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCalendarioProcedimento;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCancelarVisualizarClientes;
        private System.Windows.Forms.PictureBox btnAdicionarProcedimento;
        private System.Windows.Forms.PictureBox btnCancelarAlteracaoProcedimento;
    }
}