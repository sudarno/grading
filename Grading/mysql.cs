using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Grading
{
    class mysql
    {
        string Server = Properties.Settings.Default.Server;
        string Database = Properties.Settings.Default.Database;
        string strCon;
        public MySqlConnection Conn = new MySqlConnection();

        //method untuk koneksi database
        public void Konek()
        {
            Conn.Close();
            try
            {
                strCon = "Server=" + Server + ";Port=3306;UID=root;PWD='';Database=" + Database;
                Conn.ConnectionString = strCon;
                Conn.Open();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }

        }
        public void Putus()
        {
            Conn.Close();
        }


    }
}
