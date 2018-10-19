using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADM_DTO
{
    public class ListaProduto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Qtd { get; set; }
        public string SubCategoria { get; set; }
        public string Marca { get; set; }
        public static List<ListaProduto> listaProdutos = new List<ListaProduto>()
        {
            new ListaProduto{Id = 0,NomeProduto = "",Marca = "",Descricao = "",Categoria = "",Qtd = "",SubCategoria =""}
        };
    }
}
