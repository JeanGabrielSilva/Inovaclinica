﻿using Inovaclinica.Application.DTOs.Produtos;
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


        public IEnumerable<ProdutoListagemDTO> ListarProdutos() {
            return _produtoRepository.ListarProdutos();
        }

        public IEnumerable<ProdutoListagemDTO> BuscarProdutos(string consulta) {
            return _produtoRepository.BuscarProdutos(consulta);
        }

        public IEnumerable<ProdutoListagemDTO> FiltrosProdutos(ProdutoFiltroDTO filtro) {
            return _produtoRepository.FiltrarProdutos(filtro);
        }

        public void AdicionarProduto(ProdutoAdicionarDTO produto) { 
            _produtoRepository.AdicionarProduto(produto);
        }

        public ProdutoDetalhadoDTO ObterProdutoPorId(int produtoId) {
            return _produtoRepository.ObterPorId(produtoId);
        }

        public void AtualizarProduto(ProdutoAtualizarDTO produto) {
            _produtoRepository.AtualizarProduto(produto);
        }

    }
}
