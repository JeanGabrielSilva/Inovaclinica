using Inovaclinica.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inovaclinica.Application.Services {
    public class ProdutoService {

        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }


        public IEnumerable<Produto> ListarProdutos() {
            return _produtoRepository.ListarProdutos();
        }

        public IEnumerable<Produto> BuscarProdutos(string consulta) {
            return _produtoRepository.BuscarProdutos(consulta);
        }

        public IEnumerable<Produto> FiltrosProdutos(string nome, string estoque, string preco) {
            return _produtoRepository.FiltrarProdutos(nome, estoque, preco);
        }

    }
}
