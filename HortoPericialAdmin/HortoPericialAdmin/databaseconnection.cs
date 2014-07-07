using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace HortoPericialAdmin
{    
    class databaseconnection
    {
        public static MySqlConnection db = null;
        private string server;
        private string database;
        private string uid;
        private string password;

        public void dbConnection()
        {

            server = "hortopericial.square7.ch";
            database = "hortopericial";
            uid = "hortopericial";
            password = "jonas123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            try
            {
                db = new MySqlConnection(connectionString);
                db.Open();
            }
            catch (Exception msg)
            {
                System.Windows.MessageBox.Show( msg.Message , "Your Caption Here");
            }
        }
    }
}
