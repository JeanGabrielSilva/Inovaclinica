namespace Inovaclinica
{
    partial class FormProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProdutos));
            this.panelBarraPesquisa = new System.Windows.Forms.Panel();
            this.btnBarraPesquisaProdutos = new System.Windows.Forms.PictureBox();
            this.barraPesquisaProdutos = new System.Windows.Forms.TextBox();
            this.panelRodape = new System.Windows.Forms.Panel();
            this.tablePanelMenuClientes = new System.Windows.Forms.TableLayoutPanel();
            this.btnAbrirModalFiltrarProdutos = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.atualizarGridProdutos = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAbrirModalVisualizarProdutos = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAbrirModalAdicionarProduto = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DataGridProdutos = new System.Windows.Forms.DataGridView();
            this.panelBarraPesquisa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBarraPesquisaProdutos)).BeginInit();
            this.panelRodape.SuspendLayout();
            this.tablePanelMenuClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbrirModalFiltrarProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.atualizarGridProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbrirModalVisualizarProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbrirModalAdicionarProduto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBarraPesquisa
            // 
            this.panelBarraPesquisa.Controls.Add(this.btnBarraPesquisaProdutos);
            this.panelBarraPesquisa.Controls.Add(this.barraPesquisaProdutos);
            this.panelBarraPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraPesquisa.Location = new System.Drawing.Point(0, 0);
            this.panelBarraPesquisa.Name = "panelBarraPesquisa";
            this.panelBarraPesquisa.Size = new System.Drawing.Size(943, 78);
            this.panelBarraPesquisa.TabIndex = 3;
            // 
            // btnBarraPesquisaProdutos
            // 
            this.btnBarraPesquisaProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.btnBarraPesquisaProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnBarraPesquisaProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBarraPesquisaProdutos.Image = ((System.Drawing.Image)(resources.GetObject("btnBarraPesquisaProdutos.Image")));
            this.btnBarraPesquisaProdutos.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnBarraPesquisaProdutos.InitialImage")));
            this.btnBarraPesquisaProdutos.Location = new System.Drawing.Point(13, 16);
            this.btnBarraPesquisaProdutos.Name = "btnBarraPesquisaProdutos";
            this.btnBarraPesquisaProdutos.Size = new System.Drawing.Size(48, 47);
            this.btnBarraPesquisaProdutos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnBarraPesquisaProdutos.TabIndex = 1;
            this.btnBarraPesquisaProdutos.TabStop = false;
            this.btnBarraPesquisaProdutos.Click += new System.EventHandler(this.btnBarraPesquisaProdutos_Click);
            // 
            // barraPesquisaProdutos
            // 
            this.barraPesquisaProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.barraPesquisaProdutos.CausesValidation = false;
            this.barraPesquisaProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraPesquisaProdutos.Location = new System.Drawing.Point(59, 16);
            this.barraPesquisaProdutos.Name = "barraPesquisaProdutos";
            this.barraPesquisaProdutos.Size = new System.Drawing.Size(869, 47);
            this.barraPesquisaProdutos.TabIndex = 0;
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.tablePanelMenuClientes);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 489);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(943, 69);
            this.panelRodape.TabIndex = 4;
            // 
            // tablePanelMenuClientes
            // 
            this.tablePanelMenuClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tablePanelMenuClientes.ColumnCount = 5;
            this.tablePanelMenuClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelMenuClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelMenuClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelMenuClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelMenuClientes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelMenuClientes.Controls.Add(this.btnAbrirModalFiltrarProdutos, 0, 0);
            this.tablePanelMenuClientes.Controls.Add(this.label1, 3, 1);
            this.tablePanelMenuClientes.Controls.Add(this.label3, 4, 1);
            this.tablePanelMenuClientes.Controls.Add(this.pictureBox1, 3, 0);
            this.tablePanelMenuClientes.Controls.Add(this.atualizarGridProdutos, 4, 0);
            this.tablePanelMenuClientes.Controls.Add(this.label5, 2, 1);
            this.tablePanelMenuClientes.Controls.Add(this.btnAbrirModalVisualizarProdutos, 2, 0);
            this.tablePanelMenuClientes.Controls.Add(this.label2, 1, 1);
            this.tablePanelMenuClientes.Controls.Add(this.btnAbrirModalAdicionarProduto, 1, 0);
            this.tablePanelMenuClientes.Controls.Add(this.label4, 0, 1);
            this.tablePanelMenuClientes.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tablePanelMenuClientes.Location = new System.Drawing.Point(242, 0);
            this.tablePanelMenuClientes.Name = "tablePanelMenuClientes";
            this.tablePanelMenuClientes.RowCount = 2;
            this.tablePanelMenuClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tablePanelMenuClientes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanelMenuClientes.Size = new System.Drawing.Size(431, 66);
            this.tablePanelMenuClientes.TabIndex = 10;
            // 
            // btnAbrirModalFiltrarProdutos
            // 
            this.btnAbrirModalFiltrarProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.btnAbrirModalFiltrarProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirModalFiltrarProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAbrirModalFiltrarProdutos.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirModalFiltrarProdutos.Image")));
            this.btnAbrirModalFiltrarProdutos.Location = new System.Drawing.Point(3, 3);
            this.btnAbrirModalFiltrarProdutos.Name = "btnAbrirModalFiltrarProdutos";
            this.btnAbrirModalFiltrarProdutos.Size = new System.Drawing.Size(80, 46);
            this.btnAbrirModalFiltrarProdutos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAbrirModalFiltrarProdutos.TabIndex = 6;
            this.btnAbrirModalFiltrarProdutos.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(261, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Excluir";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(347, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Atualizar";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(261, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // atualizarGridProdutos
            // 
            this.atualizarGridProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.atualizarGridProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.atualizarGridProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atualizarGridProdutos.Image = ((System.Drawing.Image)(resources.GetObject("atualizarGridProdutos.Image")));
            this.atualizarGridProdutos.Location = new System.Drawing.Point(347, 3);
            this.atualizarGridProdutos.Name = "atualizarGridProdutos";
            this.atualizarGridProdutos.Size = new System.Drawing.Size(81, 46);
            this.atualizarGridProdutos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.atualizarGridProdutos.TabIndex = 4;
            this.atualizarGridProdutos.TabStop = false;
            this.atualizarGridProdutos.Click += new System.EventHandler(this.atualizarGridProdutos_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(175, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 14);
            this.label5.TabIndex = 9;
            this.label5.Text = "Visualizar";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAbrirModalVisualizarProdutos
            // 
            this.btnAbrirModalVisualizarProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.btnAbrirModalVisualizarProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirModalVisualizarProdutos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbrirModalVisualizarProdutos.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirModalVisualizarProdutos.Image")));
            this.btnAbrirModalVisualizarProdutos.Location = new System.Drawing.Point(175, 3);
            this.btnAbrirModalVisualizarProdutos.Name = "btnAbrirModalVisualizarProdutos";
            this.btnAbrirModalVisualizarProdutos.Size = new System.Drawing.Size(80, 46);
            this.btnAbrirModalVisualizarProdutos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAbrirModalVisualizarProdutos.TabIndex = 8;
            this.btnAbrirModalVisualizarProdutos.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(89, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Adicionar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAbrirModalAdicionarProduto
            // 
            this.btnAbrirModalAdicionarProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.btnAbrirModalAdicionarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrirModalAdicionarProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAbrirModalAdicionarProduto.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrirModalAdicionarProduto.Image")));
            this.btnAbrirModalAdicionarProduto.Location = new System.Drawing.Point(89, 3);
            this.btnAbrirModalAdicionarProduto.Name = "btnAbrirModalAdicionarProduto";
            this.btnAbrirModalAdicionarProduto.Size = new System.Drawing.Size(80, 46);
            this.btnAbrirModalAdicionarProduto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnAbrirModalAdicionarProduto.TabIndex = 2;
            this.btnAbrirModalAdicionarProduto.TabStop = false;
            this.btnAbrirModalAdicionarProduto.Click += new System.EventHandler(this.btnAbrirModalAdicionarProduto_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Filtrar";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataGridProdutos
            // 
            this.DataGridProdutos.AllowUserToAddRows = false;
            this.DataGridProdutos.AllowUserToDeleteRows = false;
            this.DataGridProdutos.AllowUserToOrderColumns = true;
            this.DataGridProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridProdutos.Location = new System.Drawing.Point(0, 78);
            this.DataGridProdutos.Name = "DataGridProdutos";
            this.DataGridProdutos.ReadOnly = true;
            this.DataGridProdutos.Size = new System.Drawing.Size(942, 411);
            this.DataGridProdutos.TabIndex = 5;
            // 
            // FormProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 558);
            this.Controls.Add(this.DataGridProdutos);
            this.Controls.Add(this.panelRodape);
            this.Controls.Add(this.panelBarraPesquisa);
            this.Name = "FormProdutos";
            this.Text = "Produtos";
            this.panelBarraPesquisa.ResumeLayout(false);
            this.panelBarraPesquisa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBarraPesquisaProdutos)).EndInit();
            this.panelRodape.ResumeLayout(false);
            this.tablePanelMenuClientes.ResumeLayout(false);
            this.tablePanelMenuClientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbrirModalFiltrarProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.atualizarGridProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbrirModalVisualizarProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAbrirModalAdicionarProduto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBarraPesquisa;
        private System.Windows.Forms.PictureBox btnBarraPesquisaProdutos;
        private System.Windows.Forms.TextBox barraPesquisaProdutos;
        private System.Windows.Forms.Panel panelRodape;
        private System.Windows.Forms.TableLayoutPanel tablePanelMenuClientes;
        private System.Windows.Forms.PictureBox btnAbrirModalFiltrarProdutos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox atualizarGridProdutos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox btnAbrirModalVisualizarProdutos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox btnAbrirModalAdicionarProduto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView DataGridProdutos;
    }
}