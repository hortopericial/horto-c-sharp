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
    public partial class Concelho : Form
    {
        int id;

        public Concelho()
        {
            InitializeComponent();
            fillcombo();
            fillgrid();
        }

        public void fillcombo()
        {
            DBConnect NewConnection = new DBConnect();
            NewConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("select * from distrito", DBConnect.db);
            MySqlDataReader dataread = querysql.ExecuteReader();            
            comboBox1.Items.Add("Selecione um Distrito");
            int count = 0;
            while (dataread.Read())
            {
                count = count + 1;
                comboBox1.Items.Add(dataread["id_distrito"].ToString() + " " + "-" + " " + dataread["nome_dist"].ToString());
            }
            if (count == 0)
            {
                comboBox1.Visible = false;
            }
            else
            {
                comboBox1.Visible = true;
            }

            DBConnect.db.Close();
        }


        private void fillgrid()
        {

            //buttonDel.Visible = false;
            //buttonEdit.Visible = false;
            //buttonIns.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select id_concelho, iddistrito_fk, nome_dist, nome_conc From concelho, distrito where iddistrito_fk = id_distrito", DBConnect.db);

            try
            {
                MySqlDataAdapter dados = new MySqlDataAdapter();
                dados.SelectCommand = querysql;
                DataTable tabela = new DataTable();
                dados.Fill(tabela);
                BindingSource fonte = new BindingSource();
                fonte.DataSource = tabela;
                dataGridView1.DataSource = fonte;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].HeaderText = "Distrito";
                dataGridView1.Columns[3].HeaderText = "Concelho";
                dados.Update(tabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnect.db.Close();
            textBoxConc.Clear();
            comboBox1.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                  //  buttonDel.Visible = true;
                  //  buttonEdit.Visible = true;

                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_concelho"].Value.ToString());
                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("Select id_concelho, iddistrito_fk, nome_dist, nome_conc From concelho, distrito where iddistrito_fk = id_distrito and id_concelho =" + id + "", DBConnect.db);
                    querysql.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dados = new MySqlDataAdapter(querysql);
                    dados.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxConc.Text = dr["nome_conc"].ToString();
                        comboBox1.SelectedIndex = comboBox1.FindStringExact(dr["iddistrito_fk"].ToString() +" "+"-"+" " + dr["nome_dist"].ToString());
                    }
                }
                catch
                {
                   // buttonDel.Visible = false;
                   // buttonEdit.Visible = false;
                   // buttonIns.Visible = false;
                    textBoxConc.Clear();
                    MessageBox.Show("Selecione uma celula valida");
                }
            }
        }




    }
}
