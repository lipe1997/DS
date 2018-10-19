using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM_DTO;
using ADM_DAL;
using System.Text.RegularExpressions;

namespace ADM_BLL
{
    public class Cad_Produto_BLL
    {
        public static string CadProduto(Cad_Produto_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.NomeProduto))
            {
                throw new Exception("Campo nome vazio");
            }
            if (string.IsNullOrWhiteSpace(obj.Descricao))
            {
                throw new Exception("Campo descrição vazio");
            }
            bool regEx = Regex.IsMatch(obj.Qtd, @"^\d");
            if (!regEx)
            {
                throw new Exception("Campo quantidade deve conter apenas números");
            }
            if (string.IsNullOrWhiteSpace(obj.Categoria))
            {
                throw new Exception("Campo categoria vazio");
            }
            if (string.IsNullOrWhiteSpace(obj.SubCategoria))
            {
                throw new Exception("Campo sub-categoria vazio");
            }
            if (string.IsNullOrWhiteSpace(obj.Marca))
            {
                throw new Exception("Campo marca vazio");
            }
            bool result = Cad_Produto_DAL.VerifProduto(obj.NomeProduto, obj.Marca);
            if (result)
            {
                throw new Exception("Nome do produto e marca ja cadastrados\n se deseja altera-lo selecione na lista acima");
            }
            string msg = Cad_Produto_DAL.CadProduto(obj);
            return msg;
        }
        public static void bucProduto(Cad_Produto_DTO obj)
        {
            if (string.IsNullOrWhiteSpace(obj.NomeProduto))
            {
                throw new Exception("Para buscar preencha o nome do produto!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Marca))
            {
                throw new Exception("Para buscar preencha a marca do produto!!");
            }
            Cad_Produto_DAL.BuscProduto(obj);
        }
        public static string AlterProduto(Cad_Produto_DTO obj,string nome,string marca)
        {
            if (string.IsNullOrWhiteSpace(obj.NomeProduto))
            {
                throw new Exception("Campo nome vazio");
            }
            if (string.IsNullOrWhiteSpace(obj.Descricao))
            {
                throw new Exception("Campo descrição vazio");
            }
            bool regEx = Regex.IsMatch(obj.Qtd, @"^\d");
            if (!regEx)
            {
                throw new Exception("Campo quantidade deve conter apenas números");
            }
            if (string.IsNullOrWhiteSpace(obj.Categoria))
            {
                throw new Exception("Campo categoria vazio");
            }
            if (string.IsNullOrWhiteSpace(obj.SubCategoria))
            {
                throw new Exception("Campo sub-categoria vazio");
            }
            if (string.IsNullOrWhiteSpace(obj.Marca))
            {
                throw new Exception("Campo marca vazio");
            }
            string msg = Cad_Produto_DAL.alterProduto(obj,nome,marca);
            return msg;
        }
    }
}
