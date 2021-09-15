using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AulaMVCManha.Models
{
    public static class DBFunctions
    {
        private static SqlConnection Connection { get; set; } = new SqlConnection("Data Source=BUE205D39;Initial Catalog=BDTurmaManha;User ID=guest01;Password=@Senac2021");

        public static void InsereConta(string numeroConta,string saldo)
        {
            string insert = $"INSERT into dbo.Conta (NumeroConta,Saldo) values ('{numeroConta}',{Convert.ToInt32(saldo)})";
            SqlCommand cmd = new SqlCommand(insert,Connection);
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }



    }
}
