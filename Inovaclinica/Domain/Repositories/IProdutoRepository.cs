using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovaclinica.Domain.Repositories {
    public interface IProdutoRepository {

        IEnumerable<Produto> ListarProdutos();
        IEnumerable<Produto> BuscarProdutos(string consulta);
        IEnumerable<Produto> FiltrarProdutos(string nome, string estoque, string preco);

    }
}
