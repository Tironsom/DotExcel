using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DotExcel
{
    internal class Conexao
    {
        SqlConnection con = new SqlConnection();
        //conector
        public Conexao()
        {
            con.ConnectionString = "Data Source=DESKTOP-5F3LU5P\\SQLEXPRESS;Initial Catalog=dotconect;Integrated Security=True";
        }
        //metodo de conectar 
        public SqlConnection conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        //metodo para desconectar
        public void desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
 