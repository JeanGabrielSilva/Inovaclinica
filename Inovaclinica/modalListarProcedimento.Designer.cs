﻿namespace Inovaclinica
{
    partial class modalListarProcedimento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(modalListarProcedimento));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBuscarCliente = new System.Windows.Forms.PictureBox();
            this.barraPesquisarProcedimentos = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridProcedimentos = new System.Windows.Forms.DataGridView();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCancelarVisualizarClientes = new System.Windows.Forms.Label();
            this.btnConfirmarSelecaoProcedimento = new System.Windows.Forms.PictureBox();
            this.btnCancelarSelecaoProdecimento = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarCliente)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcedimentos)).BeginInit();
            this.panelRodape.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmarSelecaoProcedimento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarSelecaoProdecimento)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBuscarCliente);
            this.panel1.Controls.Add(this.barraPesquisarProcedimentos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 63);
            this.panel1.TabIndex = 65;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.btnBuscarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.Image")));
            this.btnBuscarCliente.Location = new System.Drawing.Point(16, 12);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(43, 38);
            this.btnBuscarCliente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBuscarCliente.TabIndex = 59;
            this.btnBuscarCliente.TabStop = false;
            // 
            // barraPesquisarProcedimentos
            // 
            this.barraPesquisarProcedimentos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.barraPesquisarProcedimentos.CausesValidation = false;
            this.barraPesquisarProcedimentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.barraPesquisarProcedimentos.Location = new System.Drawing.Point(58, 12);
            this.barraPesquisarProcedimentos.Name = "barraPesquisarProcedimentos";
            this.barraPesquisarProcedimentos.Size = new System.Drawing.Size(730, 38);
            this.barraPesquisarProcedimentos.TabIndex = 58;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridProcedimentos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 381);
            this.panel2.TabIndex = 66;
            // 
            // dataGridProcedimentos
            // 
            this.dataGridProcedimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProcedimentos.Location = new System.Drawing.Point(16, 69);
            this.dataGridProcedimentos.Name = "dataGridProcedimentos";
            this.dataGridProcedimentos.Size = new System.Drawing.Size(772, 302);
            this.dataGridProcedimentos.TabIndex = 61;
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.tableLayoutPanel1);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 381);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(800, 69);
            this.panelRodape.TabIndex = 64;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCancelarVisualizarClientes, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirmarSelecaoProcedimento, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelarSelecaoProdecimento, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(330, 3);
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
            this.label5.Text = "Confirmar";
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
            // btnConfirmarSelecaoProcedimento
            // 
            this.btnConfirmarSelecaoProcedimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirmarSelecaoProcedimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarSelecaoProcedimento.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmarSelecaoProcedimento.Image")));
            this.btnConfirmarSelecaoProcedimento.Location = new System.Drawing.Point(3, 3);
            this.btnConfirmarSelecaoProcedimento.Name = "btnConfirmarSelecaoProcedimento";
            this.btnConfirmarSelecaoProcedimento.Size = new System.Drawing.Size(70, 38);
            this.btnConfirmarSelecaoProcedimento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnConfirmarSelecaoProcedimento.TabIndex = 14;
            this.btnConfirmarSelecaoProcedimento.TabStop = false;
            this.btnConfirmarSelecaoProcedimento.Click += new System.EventHandler(this.btnConfirmarSelecaoProcedimento_Click);
            // 
            // btnCancelarSelecaoProdecimento
            // 
            this.btnCancelarSelecaoProdecimento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarSelecaoProdecimento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelarSelecaoProdecimento.Image = global::Inovaclinica.Properties.Resources.circulo_x__1_;
            this.btnCancelarSelecaoProdecimento.Location = new System.Drawing.Point(79, 3);
            this.btnCancelarSelecaoProdecimento.Name = "btnCancelarSelecaoProdecimento";
            this.btnCancelarSelecaoProdecimento.Size = new System.Drawing.Size(70, 38);
            this.btnCancelarSelecaoProdecimento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnCancelarSelecaoProdecimento.TabIndex = 17;
            this.btnCancelarSelecaoProdecimento.TabStop = false;
            this.btnCancelarSelecaoProdecimento.Click += new System.EventHandler(this.btnCancelarSelecaoProdecimento_Click);
            // 
            // modalListarProcedimento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelRodape);
            this.Name = "modalListarProcedimento";
            this.Text = "modalListarProcedimento";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBuscarCliente)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcedimentos)).EndInit();
            this.panelRodape.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirmarSelecaoProcedimento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancelarSelecaoProdecimento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox btnBuscarCliente;
        private System.Windows.Forms.TextBox barraPesquisarProcedimentos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCancelarVisualizarClientes;
        private System.Windows.Forms.PictureBox btnConfirmarSelecaoProcedimento;
        private System.Windows.Forms.PictureBox btnCancelarSelecaoProdecimento;
        private System.Windows.Forms.DataGridView dataGridProcedimentos;
    }
}