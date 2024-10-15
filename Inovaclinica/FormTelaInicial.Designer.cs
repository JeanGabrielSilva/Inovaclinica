﻿using System.Drawing;
using System.Windows.Forms;

namespace Inovaclinica {
    partial class FormTelaInicial {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.panelRodape = new System.Windows.Forms.Panel();
            this.footerLabel = new System.Windows.Forms.Label();
            this.footerLabel1 = new System.Windows.Forms.Label();
            this.panelCabecalho = new System.Windows.Forms.Panel();
            this.tableLayoutPanelTelaInicial = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.btnMenuCliente = new System.Windows.Forms.Button();
            this.btnMenuProduto = new System.Windows.Forms.Button();
            this.LogoCabecalho = new System.Windows.Forms.PictureBox();
            this.panelRodape.SuspendLayout();
            this.panelCabecalho.SuspendLayout();
            this.tableLayoutPanelTelaInicial.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoCabecalho)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRodape
            // 
            this.panelRodape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.panelRodape.Controls.Add(this.footerLabel);
            this.panelRodape.Controls.Add(this.footerLabel1);
            this.panelRodape.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRodape.Location = new System.Drawing.Point(0, 553);
            this.panelRodape.Name = "panelRodape";
            this.panelRodape.Size = new System.Drawing.Size(1238, 80);
            this.panelRodape.TabIndex = 0;
            // 
            // footerLabel
            // 
            this.footerLabel.AutoSize = true;
            this.footerLabel.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.footerLabel.ForeColor = System.Drawing.Color.White;
            this.footerLabel.Location = new System.Drawing.Point(10, 20);
            this.footerLabel.Name = "footerLabel";
            this.footerLabel.Size = new System.Drawing.Size(111, 18);
            this.footerLabel.TabIndex = 0;
            this.footerLabel.Text = "INOVACLINICA";
            this.footerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // footerLabel1
            // 
            this.footerLabel1.AutoSize = true;
            this.footerLabel1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Italic);
            this.footerLabel1.ForeColor = System.Drawing.Color.White;
            this.footerLabel1.Location = new System.Drawing.Point(10, 40);
            this.footerLabel1.Name = "footerLabel1";
            this.footerLabel1.Size = new System.Drawing.Size(55, 16);
            this.footerLabel1.TabIndex = 1;
            this.footerLabel1.Text = "Versão:";
            this.footerLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelCabecalho
            // 
            this.panelCabecalho.BackColor = System.Drawing.Color.Transparent;
            this.panelCabecalho.Controls.Add(this.label5);
            this.panelCabecalho.Controls.Add(this.label4);
            this.panelCabecalho.Controls.Add(this.LogoCabecalho);
            this.panelCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecalho.Location = new System.Drawing.Point(0, 0);
            this.panelCabecalho.Name = "panelCabecalho";
            this.panelCabecalho.Size = new System.Drawing.Size(1238, 80);
            this.panelCabecalho.TabIndex = 1;
            // 
            // tableLayoutPanelTelaInicial
            // 
            this.tableLayoutPanelTelaInicial.AutoScroll = true;
            this.tableLayoutPanelTelaInicial.ColumnCount = 3;
            this.tableLayoutPanelTelaInicial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelTelaInicial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelTelaInicial.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanelTelaInicial.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanelTelaInicial.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanelTelaInicial.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanelTelaInicial.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanelTelaInicial.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanelTelaInicial.Controls.Add(this.tableLayoutPanel3, 2, 1);
            this.tableLayoutPanelTelaInicial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTelaInicial.Location = new System.Drawing.Point(0, 80);
            this.tableLayoutPanelTelaInicial.Name = "tableLayoutPanelTelaInicial";
            this.tableLayoutPanelTelaInicial.RowCount = 2;
            this.tableLayoutPanelTelaInicial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelTelaInicial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanelTelaInicial.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTelaInicial.Size = new System.Drawing.Size(1238, 473);
            this.tableLayoutPanelTelaInicial.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(406, 48);
            this.label1.TabIndex = 3;
            this.label1.Text = "Movimento";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button6, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 431);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 209);
            this.button2.TabIndex = 0;
            this.button2.Text = "Procedimentos";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(206, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 209);
            this.button3.TabIndex = 1;
            this.button3.Text = "Orçamento";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(206, 218);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(197, 210);
            this.button6.TabIndex = 3;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label2.Location = new System.Drawing.Point(415, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(406, 48);
            this.label2.TabIndex = 7;
            this.label2.Text = "Cadastro";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Arial Black", 20F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label3.Location = new System.Drawing.Point(827, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(408, 48);
            this.label3.TabIndex = 8;
            this.label3.Text = "Relatório";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.button9, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.button10, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button11, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button12, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(827, 51);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(408, 431);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(3, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(198, 209);
            this.button9.TabIndex = 3;
            this.button9.Text = "Análise de Procedimentos";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(3, 218);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(198, 210);
            this.button10.TabIndex = 3;
            this.button10.Text = "button6";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(207, 3);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(198, 209);
            this.button11.TabIndex = 3;
            this.button11.Text = "Análise de Produtos";
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.button12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button12.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(207, 218);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(198, 210);
            this.button12.TabIndex = 3;
            this.button12.Text = "button6";
            this.button12.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(86)))));
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(206, 218);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(197, 210);
            this.button8.TabIndex = 3;
            this.button8.Text = "button6";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnMenuCliente, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnMenuProduto, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button8, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(415, 51);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(406, 431);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(86)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(3, 218);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 210);
            this.button1.TabIndex = 3;
            this.button1.Text = "button6";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(89)))), ((int)(((byte)(91)))));
            this.label4.Location = new System.Drawing.Point(104, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 56);
            this.label4.TabIndex = 1;
            this.label4.Text = "INOVA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(94)))), ((int)(((byte)(220)))));
            this.label5.Location = new System.Drawing.Point(254, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 56);
            this.label5.TabIndex = 2;
            this.label5.Text = "CLINICA";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::Inovaclinica.Properties.Resources.circulo_usd__1_;
            this.button5.Location = new System.Drawing.Point(3, 218);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(197, 210);
            this.button5.TabIndex = 2;
            this.button5.Text = "Financeiro";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // btnMenuCliente
            // 
            this.btnMenuCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(86)))));
            this.btnMenuCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuCliente.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnMenuCliente.ForeColor = System.Drawing.Color.White;
            this.btnMenuCliente.Image = global::Inovaclinica.Properties.Resources.usuarios__1_;
            this.btnMenuCliente.Location = new System.Drawing.Point(3, 3);
            this.btnMenuCliente.Name = "btnMenuCliente";
            this.btnMenuCliente.Size = new System.Drawing.Size(197, 209);
            this.btnMenuCliente.TabIndex = 3;
            this.btnMenuCliente.Text = "Clientes";
            this.btnMenuCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuCliente.UseVisualStyleBackColor = false;
            this.btnMenuCliente.Click += new System.EventHandler(this.btnMenuCliente_Click);
            // 
            // btnMenuProduto
            // 
            this.btnMenuProduto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(161)))), ((int)(((byte)(86)))));
            this.btnMenuProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuProduto.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnMenuProduto.ForeColor = System.Drawing.Color.White;
            this.btnMenuProduto.Image = global::Inovaclinica.Properties.Resources.caixa_aberta__3_;
            this.btnMenuProduto.Location = new System.Drawing.Point(206, 3);
            this.btnMenuProduto.Name = "btnMenuProduto";
            this.btnMenuProduto.Size = new System.Drawing.Size(197, 209);
            this.btnMenuProduto.TabIndex = 3;
            this.btnMenuProduto.Text = "Produtos";
            this.btnMenuProduto.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMenuProduto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMenuProduto.UseVisualStyleBackColor = false;
            this.btnMenuProduto.Click += new System.EventHandler(this.btnMenuProduto_Click);
            // 
            // LogoCabecalho
            // 
            this.LogoCabecalho.Location = new System.Drawing.Point(16, 19);
            this.LogoCabecalho.Name = "LogoCabecalho";
            this.LogoCabecalho.Size = new System.Drawing.Size(60, 50);
            this.LogoCabecalho.TabIndex = 0;
            this.LogoCabecalho.TabStop = false;
            this.LogoCabecalho.Click += new System.EventHandler(this.LogoCabecalho_Click);
            // 
            // FormTelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 633);
            this.Controls.Add(this.tableLayoutPanelTelaInicial);
            this.Controls.Add(this.panelCabecalho);
            this.Controls.Add(this.panelRodape);
            this.Name = "FormTelaInicial";
            this.Text = "Form1";
            this.panelRodape.ResumeLayout(false);
            this.panelRodape.PerformLayout();
            this.panelCabecalho.ResumeLayout(false);
            this.panelCabecalho.PerformLayout();
            this.tableLayoutPanelTelaInicial.ResumeLayout(false);
            this.tableLayoutPanelTelaInicial.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoCabecalho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRodape;
        private Label footerLabel;
        private Label footerLabel1;
        private Panel panelCabecalho;
        private PictureBox LogoCabecalho;
        private TableLayoutPanel tableLayoutPanelTelaInicial;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Button button3;
        private Button button5;
        private Button button6;
        private TableLayoutPanel tableLayoutPanel3;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button1;
        private Button btnMenuCliente;
        private Button btnMenuProduto;
        private Button button8;
        private Label label5;
        private Label label4;
    }
}

