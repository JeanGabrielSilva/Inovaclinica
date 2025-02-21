using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica.Application.DTOs.Produtos {
    public class ProdutoDetalhadoDTO {

        public int ProdutoID {  get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco {  get; set; }
        public int Estoque { get; set; }
        public DateTime? DataValidade { get; set; }

    }
}
