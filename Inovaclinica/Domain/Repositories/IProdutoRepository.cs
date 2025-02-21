using Inovaclinica.Application.DTOs.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovaclinica.Domain.Repositories {
    public interface IProdutoRepository {

        IEnumerable<ProdutoListagemDTO> ListarProdutos();
        IEnumerable<ProdutoListagemDTO> BuscarProdutos(string consulta);
        IEnumerable<ProdutoListagemDTO> FiltrarProdutos(ProdutoFiltroDTO filtro);
        void AdicionarProduto(ProdutoAdicionarDTO produto);
    }
}
