﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovaclinica.Application.DTOs.Produtos {
    public class ProdutoAdicionarDTO {

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public DateTime? DataValidade { get; set; }
        public DateTime? DataCadastro { get; set; }


    }
}
