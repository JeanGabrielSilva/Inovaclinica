﻿using Inovaclinica.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Inovaclinica.Application.DTOs.Produtos;

namespace Inovaclinica.Infrastruture.Persistence.Repositories {
    public class ProdutoRepository : IProdutoRepository {

        private readonly string _connectionString;

        public ProdutoRepository() {
            _connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;
        }

        public IEnumerable<ProdutoListagemDTO> ListarProdutos() {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();  
                string query = "SELECT ProdutoID, Nome, Descricao, Preco, Estoque, DataValidade From Produtos WHERE Ativo = 1";

                return connection.Query<ProdutoListagemDTO>(query);
            }
        }

        public IEnumerable<Produto> BuscarProdutos(string consulta) {
            using (var connection = new SqlConnection(_connectionString)) {
                string query = $"SELECT ProdutoID, Nome, Descricao, Preco, Estoque, DataValidade From Produtos WHERE Ativo = 1 AND Nome like '%{consulta}%'";
                return connection.Query<Produto>(query);
            }
        }

        public IEnumerable<Produto> FiltrarProdutos(string nome , string estoque, string preco) {
            using (var connection = new SqlConnection(_connectionString)) {
                connection.Open();

                string query = "SELECT ProdutoID, Nome, Descricao, Preco, Estoque, DataValidade From Produtos WHERE Ativo = 1";

                if (!string.IsNullOrEmpty(nome)) {
                    query += "AND Nome Like @Nome";
                }

                if (!string.IsNullOrEmpty(estoque)) {
                    query += "AND Estoque LIKE @Estoque";
                }

                if (!string.IsNullOrEmpty(preco)) {
                    query += "AND Preco Like @Preco";
                }

                return connection.Query<Produto>(query);

            }

        }
    }
}
