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
    public class Cad_Produto_DAL
    {
        public static string CadProduto(Cad_Produto_DTO obj)
        {
            try
            {
                string sql = "INSERT INTO tb_produto(nome,descricao,categoria,subcategoria,qtd,marca)" +
                    " VALUES (@nome,@descricao,@categoria,@subcategoria,@qtd,@marca)";
                SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
                cmd.Parameters.AddWithValue("@nome", obj.NomeProduto);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@categoria", obj.Categoria);
                cmd.Parameters.AddWithValue("@subcategoria", obj.SubCategoria);
                cmd.Parameters.AddWithValue("@qtd", obj.Qtd);
                cmd.Parameters.AddWithValue("@marca", obj.Marca);
                cmd.ExecuteNonQuery();
                return "Produto Cadastrado com sucesso";
            }
            catch
            {
                throw new Exception("Erro ao cadastrar produto");
            }
            finally
            {
                if(Conexao.Login().State != ConnectionState.Closed)
                {
                    Conexao.Login().Close();
                }
            }

        }
        public static bool VerifProduto(string nome , string marca)
        {
            try
            {
                string sql = "SELECT * FROM tb_produto where nome = @nome and marca = @marca";
                SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@marca", marca);

                SqlDataReader data = cmd.ExecuteReader();
                bool msg = false;

                while (data.Read())
                {
                    if (data.HasRows)
                    {
                        msg = true;
                        return msg;
                    }
                }
                return msg;
            }
            catch
            {
                throw new Exception("Erro ao verificar nome e marca do produto");
            }
            finally
            {
                if (Conexao.Login().State != ConnectionState.Closed)
                {
                    Conexao.Login().Close();
                }
            }
        }
        public static void BuscProduto(Cad_Produto_DTO obj)
        {
            try
            {
                string sql = "SELECT * FROM tb_produto where nome = @nome and marca = @marca";
                SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
                cmd.Parameters.AddWithValue("@nome", obj.NomeProduto);
                cmd.Parameters.AddWithValue("@marca", obj.Marca);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    if (data.HasRows)
                    {
                        obj.NomeProduto = data["nome"].ToString();
                        obj.Descricao = data["descricao"].ToString();
                        obj.Categoria = data["categoria"].ToString();
                        obj.SubCategoria = data["subcategoria"].ToString();
                        obj.Marca = data["marca"].ToString();
                        obj.Qtd = data["qtd"].ToString();

                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao buscar o produto");
            }
            finally
            {
                if(Conexao.Login().State != ConnectionState.Closed)
                {
                    Conexao.Login().Close();
                }
            }
        }
        public static string alterProduto(Cad_Produto_DTO obj,string nome,string marca)
        {
            try
            {
                string sql = "update tb_produto set nome = @nome, descricao = @descricao,categoria = @categoria,subcategoria = @subcategoria, qtd = 10,marca = @marca where nome = @nome1 and marca = @marca1";
                SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
                cmd.Parameters.AddWithValue("@nome", obj.NomeProduto);
                cmd.Parameters.AddWithValue("@descricao", obj.Descricao);
                cmd.Parameters.AddWithValue("@categoria", obj.Categoria);
                cmd.Parameters.AddWithValue("@subcategoria", obj.SubCategoria);
                cmd.Parameters.AddWithValue("@marca", obj.Marca);
                cmd.Parameters.AddWithValue("@qtd", obj.Qtd);
                cmd.Parameters.AddWithValue("@nome1", nome);
                cmd.Parameters.AddWithValue("@marca1", marca);
                cmd.ExecuteNonQuery();
                return "Produto alterado com sucesso";
            }
            catch
            {
                throw new Exception("Erro ao alterar dados do produto");
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
