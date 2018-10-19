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
    public class Cad_Func_DAL
    {
        
        public static string CadastrarFunc(Cad_Func_DTO obj)
        {
            try
            {
                
                
                string sql = "INSERT INTO tb_funcionario(nome,endereco,rg,cpf,cidade,numero,telefone,bairro,conta,agencia,banco) values(@nome,@endereco,@rg,@cpf,@cidade,@numero,@telefone,@bairro,@conta,@agencia,@banco)";
                SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                cmd.Parameters.AddWithValue("@rg", obj.Rg);
                cmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                cmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                cmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                cmd.Parameters.AddWithValue("@numero", obj.Numero);
                cmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                cmd.Parameters.AddWithValue("@agencia", obj.Agencia);
                cmd.Parameters.AddWithValue("@banco", obj.Banco);
                cmd.Parameters.AddWithValue("@conta", obj.Conta);
                cmd.ExecuteNonQuery();
                return ("Cadastro efetuado com sucesso");
            }
            catch
            {
                throw new Exception("Houve um erro ao cadastrar o cliente no banco");
            }
            finally
            {
                if (Conexao.Login().State != ConnectionState.Closed)
                {
                    Conexao.Login().Close();
                }
            }
        }
        public static bool VerifFunc(string cpf)
        {
            string sql = "SELECT * from tb_funcionario where @cpf = cpf";
            SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
            cmd.Parameters.AddWithValue("@cpf", cpf);
            SqlDataReader data = cmd.ExecuteReader();
            Boolean msg = false;
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
        public static void buscFunc(Cad_Func_DTO obj, string nome)
        {
            try
            {
                string sql = "SELECT * FROM tb_funcionario where nome = @nome";
                SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
                cmd.Parameters.AddWithValue("@nome", nome);
                SqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    if (data.HasRows)
                    {
                        obj.Nome = data["nome"].ToString();
                        obj.Endereco = data["endereco"].ToString();
                        obj.Rg = data["rg"].ToString();
                        obj.Cpf = data["cpf"].ToString();
                        obj.Numero = data["numero"].ToString();
                        obj.Telefone = data["telefone"].ToString();
                        obj.Cidade = data["cidade"].ToString();
                        obj.Bairro = data["bairro"].ToString();
                        obj.Banco = data["banco"].ToString();
                        obj.Agencia = data["agencia"].ToString();
                        obj.Conta = data["conta"].ToString();

                    }
                }
            }
            catch
            {
                throw new Exception("Erro ao buscar nome!! nome nao encontrado");
            }
        }
        public static string alterFunc(Cad_Func_DTO obj, string nome)
        {
            try
            {
                string sql = "update tb_funcionario set nome = @nome, endereco = @endereco,rg = @rg,cpf= @cpf, cidade = @cidade,numero= @numero,telefone = @telefone ,bairro = @bairro,conta = @conta,agencia = @agencia ,banco = @banco where nome = @nome1";
                SqlCommand cmd = new SqlCommand(sql, Conexao.Login());
                cmd.Parameters.AddWithValue("@nome", obj.Nome);
                cmd.Parameters.AddWithValue("@endereco", obj.Endereco);
                cmd.Parameters.AddWithValue("@rg", obj.Rg);
                cmd.Parameters.AddWithValue("@cpf", obj.Cpf);
                cmd.Parameters.AddWithValue("@cidade", obj.Cidade);
                cmd.Parameters.AddWithValue("@numero", obj.Numero);
                cmd.Parameters.AddWithValue("@bairro", obj.Bairro);
                cmd.Parameters.AddWithValue("@telefone", obj.Telefone);
                cmd.Parameters.AddWithValue("@agencia", obj.Agencia);
                cmd.Parameters.AddWithValue("@banco", obj.Banco);
                cmd.Parameters.AddWithValue("@conta", obj.Conta);
                cmd.Parameters.AddWithValue("@nome1", nome);
                cmd.ExecuteNonQuery();
                return "Dados do funcionario alterados com sucesso";
            }
            catch
            {
                throw new Exception("Erro ao alterar dados do funcionario");
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
