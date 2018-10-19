using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADM_DTO;
using ADM_DAL;

namespace ADM_BLL
{
    public class Cad_Func_BLL
    {
        public static string ValidarCad(Cad_Func_DTO obj){

                if (string.IsNullOrWhiteSpace(obj.Nome))
                {
                    throw new Exception("Campo nome vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Endereco))
                {
                    throw new Exception("Campo endereço vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Cpf))
                {
                    throw new Exception("Campo CPF vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Rg))
                {
                    throw new Exception("Campo RG vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Bairro))
                {
                    throw new Exception("Campo bairro vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Cidade))
                {
                    throw new Exception("Campo cidade vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Numero))
                {
                    throw new Exception("Campo número vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Telefone))
                {
                    throw new Exception("Campo telefone vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Agencia))
                {
                    throw new Exception("Campo agência vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Banco))
                {
                    throw new Exception("Campo banco vazio!!!");
                }
                if (string.IsNullOrWhiteSpace(obj.Conta))
                {
                    throw new Exception("Campo conta vazio!!!");

                }
                
                bool result = Cad_Func_DAL.VerifFunc(obj.Cpf);
                if (result == true)
                {
                    throw new Exception("CPF ja cadastrado");
                }
                string msg = Cad_Func_DAL.CadastrarFunc(obj);
                return msg;
        }
        public static void bucFunc(Cad_Func_DTO obj, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Digite o nome do funcionario que deseja buscar");
            }
            Cad_Func_DAL.buscFunc(obj, nome);
        }
        public static string AlterFunc(Cad_Func_DTO obj,string nome)
        {

            if (string.IsNullOrWhiteSpace(obj.Nome))
            {
                throw new Exception("Campo nome vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Endereco))
            {
                throw new Exception("Campo endereço vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Cpf))
            {
                throw new Exception("Campo CPF vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Rg))
            {
                throw new Exception("Campo RG vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Bairro))
            {
                throw new Exception("Campo bairro vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Cidade))
            {
                throw new Exception("Campo cidade vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Numero))
            {
                throw new Exception("Campo número vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Telefone))
            {
                throw new Exception("Campo telefone vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Agencia))
            {
                throw new Exception("Campo agência vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Banco))
            {
                throw new Exception("Campo banco vazio!!!");
            }
            if (string.IsNullOrWhiteSpace(obj.Conta))
            {
                throw new Exception("Campo conta vazio!!!");

            }
            string msg = Cad_Func_DAL.alterFunc(obj,nome);
            return msg;
        }
    }
}
