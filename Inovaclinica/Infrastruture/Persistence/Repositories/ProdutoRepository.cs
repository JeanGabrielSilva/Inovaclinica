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

        public IEnumerable<ProdutoListagemDTO> BuscarProdutos(string consulta) {
            using (var connection = new SqlConnection(_connectionString)) {
                string query = $"SELECT ProdutoID, Nome, Descricao, Preco, Estoque, DataValidade From Produtos WHERE Ativo = 1 AND Nome like '%{consulta}%'";
                return connection.Query<ProdutoListagemDTO>(query);
            }
        }

        public IEnumerable<ProdutoListagemDTO> FiltrarProdutos(ProdutoFiltroDTO filtro) {
            using (var connection = new SqlConnection(_connectionString)) {
                // Construindo a consulta base
                string query = "SELECT ProdutoID, Nome, Descricao, Preco, Estoque, DataValidade FROM Produtos WHERE 1 = 1";

                // Adicionando filtros dinamicamente
                if (!string.IsNullOrEmpty(filtro.NomeProduto)) {
                    query += " AND Nome LIKE @Nome";
                }

                if (!string.IsNullOrEmpty(filtro.Estoque)) {
                    query += " AND Estoque = @Estoque";
                }

                if (!string.IsNullOrEmpty(filtro.Preco)) {
                    query += " AND Preco = @Preco";
                }

                if (!string.IsNullOrEmpty(filtro.DataInicial) && !string.IsNullOrEmpty(filtro.DataFinal)) {
                    query += " AND DataValidade BETWEEN @DataInicial AND @DataFinal";
                } else {
                    if (!string.IsNullOrEmpty(filtro.DataInicial)) {
                        query += " AND DataValidade >= @DataInicial";
                    }

                    if (!string.IsNullOrEmpty(filtro.DataFinal)) {
                        query += " AND DataValidade <= @DataFinal";
                    }
                }

                // Parâmetros para a consulta
                var parameters = new {
                    Nome = $"%{filtro.NomeProduto}%",
                    Estoque = int.TryParse(filtro.Estoque, out int estoque) ? estoque : (int?)null, // Parâmetro numérico para Estoque
                    Preco = decimal.TryParse(filtro.Preco, out decimal preco) ? preco : (decimal?)null, // Parâmetro numérico para Preço
                    DataInicial = filtro.DataInicial,
                    DataFinal = filtro.DataFinal
                };

                // Executando a consulta com Dapper
                return connection.Query<ProdutoListagemDTO>(query, parameters);
            }
        }


    }
}
