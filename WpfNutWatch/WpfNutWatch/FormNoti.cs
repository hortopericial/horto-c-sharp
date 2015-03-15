using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WpfNutWatch
{
    public partial class FormNoti : Form
    {
        public FormNoti()
        {
            InitializeComponent();
            fillgridNoti();
        }

        private void fillgridNoti()
        {
            //id = -1;
            //buttonDel.Visible = false;
            //buttonEdit.Visible = false;
            //buttonIns.Visible = false;
            //buttonCancel.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select * From noticias", DBConnect.db);

            try
            {
                MySqlDataAdapter dados = new MySqlDataAdapter();
                dados.SelectCommand = querysql;
                DataTable tabela = new DataTable();
                dados.Fill(tabela);
                BindingSource fonte = new BindingSource();
                fonte.DataSource = tabela;
                dataGridView1.DataSource = fonte;
               //this.dataGridView1.Columns[0].Visible = false;
               //this.dataGridView1.Columns[1].Visible = false;
               //dataGridView1.Columns[2].HeaderText = "Distrito";
               //dataGridView1.Columns[3].HeaderText = "Concelho";
                dados.Update(tabela);
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnect.db.Close();
            //textBoxConc.Clear();
            //comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

    }
}
