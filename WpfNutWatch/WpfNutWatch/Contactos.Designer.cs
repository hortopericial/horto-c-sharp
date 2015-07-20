namespace WpfNutWatch
{
    partial class Contactos
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxMorada = new System.Windows.Forms.TextBox();
            this.textBoxTel1 = new System.Windows.Forms.TextBox();
            this.textBoxTel2 = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonIns = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Morada:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefone 1:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 187);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefone 2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 225);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email:";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(103, 26);
            this.textBoxNome.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(396, 22);
            this.textBoxNome.TabIndex = 5;
            this.textBoxNome.TextChanged += new System.EventHandler(this.textBoxNome_TextChanged);
            // 
            // textBoxMorada
            // 
            this.textBoxMorada.Location = new System.Drawing.Point(103, 62);
            this.textBoxMorada.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMorada.Multiline = true;
            this.textBoxMorada.Name = "textBoxMorada";
            this.textBoxMorada.Size = new System.Drawing.Size(396, 80);
            this.textBoxMorada.TabIndex = 6;
            // 
            // textBoxTel1
            // 
            this.textBoxTel1.Location = new System.Drawing.Point(103, 150);
            this.textBoxTel1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTel1.MaxLength = 9;
            this.textBoxTel1.Name = "textBoxTel1";
            this.textBoxTel1.Size = new System.Drawing.Size(296, 22);
            this.textBoxTel1.TabIndex = 7;
            // 
            // textBoxTel2
            // 
            this.textBoxTel2.Location = new System.Drawing.Point(103, 183);
            this.textBoxTel2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTel2.MaxLength = 9;
            this.textBoxTel2.Name = "textBoxTel2";
            this.textBoxTel2.Size = new System.Drawing.Size(296, 22);
            this.textBoxTel2.TabIndex = 8;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(103, 222);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(396, 22);
            this.textBoxEmail.TabIndex = 9;
            // 
            // buttonIns
            // 
            this.buttonIns.Location = new System.Drawing.Point(79, 278);
            this.buttonIns.Margin = new System.Windows.Forms.Padding(4);
            this.buttonIns.Name = "buttonIns";
            this.buttonIns.Size = new System.Drawing.Size(100, 44);
            this.buttonIns.TabIndex = 10;
            this.buttonIns.Text = "Inserir";
            this.buttonIns.UseVisualStyleBackColor = true;
            this.buttonIns.Click += new System.EventHandler(this.buttonIns_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(212, 277);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(100, 46);
            this.buttonEdit.TabIndex = 11;
            this.buttonEdit.Text = "Gravar Alterações";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(347, 278);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(100, 44);
            this.buttonDel.TabIndex = 12;
            this.buttonDel.Text = "Apagar";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(181, 330);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(161, 28);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancelar Operação";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(212, 647);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 28);
            this.buttonClose.TabIndex = 14;
            this.buttonClose.Text = "Sair";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 366);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(477, 261);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Contactos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 697);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonIns);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxTel2);
            this.Controls.Add(this.textBoxTel1);
            this.Controls.Add(this.textBoxMorada);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Contactos";
            this.Text = "Contactos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxMorada;
        private System.Windows.Forms.TextBox textBoxTel1;
        private System.Windows.Forms.TextBox textBoxTel2;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button buttonIns;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}