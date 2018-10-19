using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM_DTO;
using System.Data;
using System.Data.SqlClient;


namespace ADM_DAL
{
    public class Login_DAL
    {
        public static string login (Login_DTO obj)
        {
            try
            {
                string sql = "SELECT * FROM tb_login where usuario = @usuario and senha = @senha";
                SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
                cmd.Parameters.AddWithValue("@usuario", obj.user);
                cmd.Parameters.AddWithValue("@senha", obj.senha);
                SqlDataReader ler = cmd.ExecuteReader();
                string msg = "lalala";
                
                while (ler.Read())
                {
                    if (ler.HasRows)
                    {
                        msg = "tanana";
                        return msg;
                    }
                }
                return msg;

            }
            catch
            {
                throw new Exception("Houve um erro ao conectar com o banco");
            }
            finally
            {
                if (Conexao.Login().State != ConnectionState.Closed)
                {
                    Conexao.Login().Close();
                }
            }
        }
    }
}
