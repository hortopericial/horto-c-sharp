namespace WpfNutWatch
{
    partial class Especies
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
            this.buttonIns = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.textBoxEspNCo = new System.Windows.Forms.TextBox();
            this.textBoxEspNCi = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonSair = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Comum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome Cientifico:";
            // 
            // buttonIns
            // 
            this.buttonIns.Location = new System.Drawing.Point(31, 158);
            this.buttonIns.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonIns.Name = "buttonIns";
            this.buttonIns.Size = new System.Drawing.Size(100, 43);
            this.buttonIns.TabIndex = 2;
            this.buttonIns.Text = "Inserir";
            this.buttonIns.UseVisualStyleBackColor = true;
            this.buttonIns.Click += new System.EventHandler(this.buttonIns_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(151, 158);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(100, 43);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Gravar Alterações";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(272, 158);
            this.buttonDel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(100, 43);
            this.buttonDel.TabIndex = 4;
            this.buttonDel.Text = "Apagar";
            this.buttonDel.UseVisualStyleBackColor = true;
            // 
            // textBoxEspNCo
            // 
            this.textBoxEspNCo.Location = new System.Drawing.Point(144, 81);
            this.textBoxEspNCo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEspNCo.Name = "textBoxEspNCo";
            this.textBoxEspNCo.Size = new System.Drawing.Size(228, 22);
            this.textBoxEspNCo.TabIndex = 5;
            this.textBoxEspNCo.TextChanged += new System.EventHandler(this.textBoxEspNCo_TextChanged);
            // 
            // textBoxEspNCi
            // 
            this.textBoxEspNCi.Location = new System.Drawing.Point(144, 118);
            this.textBoxEspNCi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEspNCi.Name = "textBoxEspNCi";
            this.textBoxEspNCi.Size = new System.Drawing.Size(228, 22);
            this.textBoxEspNCi.TabIndex = 6;
            this.textBoxEspNCi.TextChanged += new System.EventHandler(this.textBoxEspNCi_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 244);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(341, 185);
            this.dataGridView1.TabIndex = 7;
            // 
            // buttonSair
            // 
            this.buttonSair.Location = new System.Drawing.Point(163, 457);
            this.buttonSair.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSair.Name = "buttonSair";
            this.buttonSair.Size = new System.Drawing.Size(100, 28);
            this.buttonSair.TabIndex = 8;
            this.buttonSair.Text = "Sair";
            this.buttonSair.UseVisualStyleBackColor = true;
            this.buttonSair.Click += new System.EventHandler(this.buttonSair_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(121, 208);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(167, 28);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancelar Operação";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Espécie";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(144, 49);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(228, 24);
            this.comboBox1.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 56);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "QuestionSet:";
            // 
            // Especies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 513);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSair);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxEspNCi);
            this.Controls.Add(this.textBoxEspNCo);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonIns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Especies";
            this.Text = "Especies";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonIns;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.TextBox textBoxEspNCo;
        private System.Windows.Forms.TextBox textBoxEspNCi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSair;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}