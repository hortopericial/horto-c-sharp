﻿namespace WpfNutWatch
{
    partial class FormPagIni
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPagIni = new System.Windows.Forms.TextBox();
            this.buttonSair = new System.Windows.Forms.Button();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.textBoxFich = new System.Windows.Forms.TextBox();
            this.buttonFicheiro = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mensagem:";
            // 
            // textBoxPagIni
            // 
            this.textBoxPagIni.Location = new System.Drawing.Point(86, 97);
            this.textBoxPagIni.MaxLength = 1000;
            this.textBoxPagIni.Multiline = true;
            this.textBoxPagIni.Name = "textBoxPagIni";
            this.textBoxPagIni.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPagIni.Size = new System.Drawing.Size(747, 118);
            this.textBoxPagIni.TabIndex = 1;
            // 
            // buttonSair
            // 
            this.buttonSair.Location = new System.Drawing.Point(758, 440);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(75, 23);
            this.buttonSair.TabIndex = 2;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(15, 440);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(75, 23);
            this.buttonInserir.TabIndex = 3;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // textBoxFich
            // 
            this.textBoxFich.Location = new System.Drawing.Point(219, 224);
            this.textBoxFich.Name = "textBoxFich";
            this.textBoxFich.ReadOnly = true;
            this.textBoxFich.Size = new System.Drawing.Size(614, 20);
            this.textBoxFich.TabIndex = 6;
            // 
            // buttonFicheiro
            // 
            this.buttonFicheiro.Location = new System.Drawing.Point(15, 221);
            this.buttonFicheiro.Name = "buttonFicheiro";
            this.buttonFicheiro.Size = new System.Drawing.Size(178, 23);
            this.buttonFicheiro.TabIndex = 7;
            this.buttonFicheiro.Text = "Selecionar Imagem";
            this.buttonFicheiro.UseVisualStyleBackColor = true;
            this.buttonFicheiro.Click += new System.EventHandler(this.buttonFicheiro_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 252);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(562, 182);
            this.dataGridView1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(605, 252);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // textBoxTitulo
            // 
            this.textBoxTitulo.Location = new System.Drawing.Point(137, 57);
            this.textBoxTitulo.MaxLength = 100;
            this.textBoxTitulo.Name = "textBoxTitulo";
            this.textBoxTitulo.Size = new System.Drawing.Size(696, 20);
            this.textBoxTitulo.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Título da Mensagem:";
            // 
            // FormPagIni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 472);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTitulo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonFicheiro);
            this.Controls.Add(this.textBoxFich);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.textBoxPagIni);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPagIni";
            this.Text = "Pagina Inicial";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPagIni;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.TextBox textBoxFich;
        private System.Windows.Forms.Button buttonFicheiro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxTitulo;
        private System.Windows.Forms.Label label2;
    }
}