using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovaclinica.Application.DTOs.Produtos {
    public class ProdutoFiltroDTO {
        public string NomeProduto {  get; set; }
        public string Estoque {  get; set; }
        public string Preco {  get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
    }
}
