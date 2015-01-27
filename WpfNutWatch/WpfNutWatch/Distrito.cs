using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace WpfNutWatch
{
    public partial class Distrito : Form
    {
        int id;
        
        public Distrito()
        {
            InitializeComponent();
            fillgrid();
        }

        private void buttonSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonIns_Click(object sender, EventArgs e)
        {
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM distrito WHERE nome_dist LIKE @distrito", DBConnect.db);
          
            verifica.Parameters.AddWithValue("@distrito", this.textBoxDis.Text);
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
            }
            DBConnect.db.Close(); 
            if (count == 0)
            {
                NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand querysql = new MySqlCommand("INSERT INTO distrito (nome_dist) Values ('" + this.textBoxDis.Text + "')", DBConnect.db);
                querysql.ExecuteNonQuery();
                MessageBox.Show("Sucesso!!");
            }
            else
            {
                MessageBox.Show("Distrito já existe!!");
            }
            DBConnect.db.Close();           
            fillgrid();
        }

        private void fillgrid()
        {

            buttonDel.Visible = false;
            buttonEdit.Visible = false;
            buttonIns.Visible = false;
            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand querysql = new MySqlCommand("Select * From distrito", DBConnect.db);

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
                dataGridView1.Columns[1].HeaderText = "Distrito";
                dados.Update(tabela);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            DBConnect.db.Close();
            textBoxDis.Clear();
        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    buttonDel.Visible = true;
                    buttonEdit.Visible = true;
                    
                    id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_distrito"].Value.ToString());
                    DBConnect NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand("Select * From distrito where id_distrito =" + id + "", DBConnect.db);
                    querysql.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dados = new MySqlDataAdapter(querysql);
                    dados.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxDis.Text = dr["nome_dist"].ToString();
                    }
                }
                catch
                {
                    buttonDel.Visible = false;
                    buttonEdit.Visible = false;
                    buttonIns.Visible = false;
                    textBoxDis.Clear();
                    MessageBox.Show("Selecione uma celula valida");
                 
                }
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect NewcConnection = new DBConnect();
                NewcConnection.dbConnection();
                MySqlCommand querysql = new MySqlCommand(" UPDATE distrito set nome_dist = @distrito where id_distrito =@Id", DBConnect.db);
                MessageBox.Show(id.ToString());
                querysql.Parameters.AddWithValue("@Id", id.ToString());
                querysql.Parameters.AddWithValue("@distrito", this.textBoxDis.Text);


                querysql.ExecuteNonQuery();
                DBConnect.db.Close();
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro!!");
            }
            MessageBox.Show("actualizado!!");
            fillgrid();

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {

            DBConnect NewcConnection = new DBConnect();
            NewcConnection.dbConnection();
            MySqlCommand verifica = new MySqlCommand("SELECT * FROM concelho WHERE iddistrito_fk = @Id", DBConnect.db);

            verifica.Parameters.AddWithValue("@Id", id.ToString());
            MySqlDataReader read = verifica.ExecuteReader();
            int count = 0;
            while (read.Read())
            {
                count = count + 1;
            }
            DBConnect.db.Close();
            if (count == 0)
            {
                try
                {
                    NewcConnection = new DBConnect();
                    NewcConnection.dbConnection();
                    MySqlCommand querysql = new MySqlCommand(" Delete from distrito where id_distrito =@Id", DBConnect.db);
                    MessageBox.Show(id.ToString());
                    querysql.Parameters.AddWithValue("@Id", id.ToString());
                    querysql.ExecuteNonQuery();
                    MessageBox.Show("Apagado com sucesso!!");
                    DBConnect.db.Close();
                }
                catch
                {
                    MessageBox.Show("Ocorreu um erro!!");
                }
            }
            else
            {
                DialogResult dlg = MessageBox.Show("Quer apagar o Distrito e os concelhos associados?", "MessageBox Title", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == DialogResult.Yes)
                {

                    MessageBox.Show("Apagados com sucesso!!!");



                }
                else
                {
                    MessageBox.Show("Operação anulada!!!");
                }
            }
            fillgrid();
        }

        private void textBoxDis_TextChanged(object sender, EventArgs e)
        {

            if (textBoxDis.TextLength == 0)
            {
                buttonDel.Visible = false;
                buttonEdit.Visible = false;
            }

            if (textBoxDis.TextLength > 0)
            {
                buttonIns.Visible = true;
            
            }
        }
    }
}
