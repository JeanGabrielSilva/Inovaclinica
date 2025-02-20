using Inovaclinica.Application.DTOs.Produtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica
{
    public partial class modalAdicionarOrcamento : Form
    {
        private FormOrcamentos _formOrcamentos;
        private string clienteSelecionadoCodigo;
        private List<Procedimento> listaProcedimentos = new List<Procedimento>();
        private List<ProdutoOrcamentoDTO> listaProdutos = new List<ProdutoOrcamentoDTO>();

        public modalAdicionarOrcamento(FormOrcamentos formOrcamentos)
        {
            InitializeComponent();
            barraPesquisarClientes.KeyDown += new KeyEventHandler(barraPesquisarClientes_KeyDown);
            barraPesquisarProcedimentos.KeyDown += new KeyEventHandler(barraPesquisarProcedimentos_KeyDown);
            barraPesquisarProdutos.KeyDown += new KeyEventHandler(barraPesquisarProdutos_KeyDown);
            CustomizeDataGridView();
            _formOrcamentos = formOrcamentos;
        }


        private void barraPesquisarClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Cancela o som padrão de "ding"
                var consulta = barraPesquisarClientes.Text.Trim();
                BuscarCliente(consulta);
            }
        }

        private void BuscarCliente(string consulta)
        {
            // Conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Consulta SQL com parâmetro
            string queryBuscar = "SELECT ClienteID AS Código, Nome, CPF, DataNascimento AS [Data Nascimento], Telefone " +
                                 "FROM Clientes WHERE Nome LIKE @Consulta and Ativo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Cria o comando SQL
                    using (SqlCommand command = new SqlCommand(queryBuscar, connection))
                    {
                        // Adiciona o parâmetro
                        command.Parameters.AddWithValue("@Consulta", "%" + consulta + "%");

                        // SqlDataAdapter para preencher o DataTable
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        // DataTable para armazenar os dados
                        DataTable dataTable = new DataTable();

                        // Preenche o DataTable com os dados retornados
                        dataAdapter.Fill(dataTable);

                        // Verifica se há um único cliente
                        if (dataTable.Rows.Count == 1)
                        {
                            // Preenche o nome do cliente e o ID
                            lblNomeCliente.Text = dataTable.Rows[0]["Nome"].ToString();
                            int clienteSelecionadoCodigo = Convert.ToInt32(dataTable.Rows[0]["Código"]); // Certifique-se que "Código" está correto
                            MessageBox.Show($"Cliente encontrado:\nID: {clienteSelecionadoCodigo}\nNome: {dataTable.Rows[0]["Nome"]}");
                        }
                        else if (dataTable.Rows.Count > 1)
                        {
                            // Se houver vários resultados, exibe a modal passando os dados
                            ExibirModalListarClientes(consulta);
                        }
                        else
                        {
                            // Caso não encontre nenhum resultado
                            MessageBox.Show("Cliente não encontrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        // Método para exibir a modal de clientes encontrados
        private void ExibirModalListarClientes(string consulta)
        {
            using (modalListarClientes modal = new modalListarClientes(consulta))
            {
                modal.Text = "Listar Clientes";
                modal.StartPosition = FormStartPosition.CenterParent;

                // Exibe o formulário modal e verifica se um cliente foi selecionado
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    lblNomeCliente.Text = modal.ClienteNome;
                    barraPesquisarClientes.Text = modal.ClienteNome;
                    clienteSelecionadoCodigo = modal.ClienteCodigo; // Armazena o código do cliente para futuras inserções
                }
            }
        }

        private void barraPesquisarProcedimentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Cancela o som padrão de "ding"
                var consulta = barraPesquisarProcedimentos.Text.Trim();
                BuscarProcedimentos(consulta);
            }
        }

        private void BuscarProcedimentos(string consulta)
        {
            // Conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Consulta SQL com parâmetro
            string queryBuscar = "SELECT ProcedimentoID AS Código, Nome, Descricao as [Descrição], Preco as [Preço] " +
                                 "FROM Procedimentos WHERE Nome LIKE @Consulta and Ativo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Cria o comando SQL
                    using (SqlCommand command = new SqlCommand(queryBuscar, connection))
                    {
                        // Adiciona o parâmetro
                        command.Parameters.AddWithValue("@Consulta", "%" + consulta + "%");

                        // SqlDataAdapter para preencher o DataTable
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        // DataTable para armazenar os dados
                        DataTable dataTable = new DataTable();

                        // Preenche o DataTable com os dados retornados
                        dataAdapter.Fill(dataTable);

                        // Verifica se há um único cliente
                        if (dataTable.Rows.Count == 1)
                        {
                            int codigo = Convert.ToInt32(dataTable.Rows[0]["Código"]);
                            string nome = dataTable.Rows[0]["Nome"].ToString();
                            decimal valor = Convert.ToDecimal(dataTable.Rows[0]["Preço"]);
                            barraPesquisarProcedimentos.Clear();
                            // Adiciona ao DataGridView diretamente
                            AdicionarProcedimentoAoGrid(codigo, nome, valor);
                        }
                        else if (dataTable.Rows.Count > 1)
                        {
                            // Se houver vários resultados, exibe a modal passando os dados
                            ExibirModalListarProcedimentos(consulta);
                        }
                        else
                        {
                            // Caso não encontre nenhum resultado
                            MessageBox.Show("Cliente não encontrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        // Método para exibir a modal de clientes encontrados
        private void ExibirModalListarProcedimentos(string consulta)
        {
            using (modalListarProcedimento modal = new modalListarProcedimento(consulta))
            {
                modal.Text = "Listar Procedimentos";
                modal.StartPosition = FormStartPosition.CenterParent;

                // Exibe o formulário modal e verifica se um cliente foi selecionado
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    int codigo = Convert.ToInt32(modal.CodigoProcedimento);
                    string nome = modal.NomeProcedimento;
                    decimal valor = Convert.ToDecimal(modal.PrecoProcedimento);

                    AdicionarProcedimentoAoGrid(codigo, nome, valor);
                }
            }
        }

        private void AdicionarProcedimentoAoGrid(int codigo, string nome, decimal valor)
        {
            // Criando um objeto para armazenar os dados temporariamente
            var procedimento = new Procedimento
            {
                Codigo = codigo,
                Nome = nome,
                Valor = valor
            };

            // Adiciona à lista
            listaProcedimentos.Add(procedimento);
            AtualizarGridProcedimentos();
        }

        private void AtualizarGridProcedimentos()
        {
            dataGridProcedimentoOrcamento.DataSource = null; // Limpa o grid
            dataGridProcedimentoOrcamento.DataSource = listaProcedimentos; // Define os dados
            lblTotalProcedimentos.Value = listaProcedimentos.Count;
            AtualizarValorTotalOrcamento();
        }

        private void barraPesquisarProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Cancela o som padrão de "ding"
                var consulta = barraPesquisarProdutos.Text.Trim();
                BuscarProdutos(consulta);
            }
        }

        private void BuscarProdutos(string consulta)
        {
            // Conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Consulta SQL com parâmetro
            string queryBuscar = "SELECT ProdutoID AS Código, Nome, Descricao as [Descrição], Preco as [Preço], DataValidade as [Data de Validade], Estoque FROM Produtos WHERE Nome LIKE @Consulta and Ativo = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Cria o comando SQL
                    using (SqlCommand command = new SqlCommand(queryBuscar, connection))
                    {
                        // Adiciona o parâmetro
                        command.Parameters.AddWithValue("@Consulta", "%" + consulta + "%");

                        // SqlDataAdapter para preencher o DataTable
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        // DataTable para armazenar os dados
                        DataTable dataTable = new DataTable();

                        // Preenche o DataTable com os dados retornados
                        dataAdapter.Fill(dataTable);

                        // Verifica se há um único cliente
                        if (dataTable.Rows.Count == 1)
                        {
                            int codigo = Convert.ToInt32(dataTable.Rows[0]["Código"]);
                            string nome = dataTable.Rows[0]["Nome"].ToString();
                            int quantidade = 1;
                            decimal valorUnitario = Convert.ToDecimal(dataTable.Rows[0]["Preço"]);
                            barraPesquisarProdutos.Clear();
                            // Adiciona ao DataGridView diretamente
                            AdicionarProdutoAoGrid(codigo, nome, quantidade, valorUnitario);
                        }
                        else if (dataTable.Rows.Count > 1)
                        {
                            // Se houver vários resultados, exibe a modal passando os dados
                            ExibirModalListarProdutos(consulta);
                        }
                        else
                        {
                            // Caso não encontre nenhum resultado
                            MessageBox.Show("Cliente não encontrado.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Exibe mensagem de erro
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        // Método para exibir a modal de clientes encontrados
        private void ExibirModalListarProdutos(string consulta)
        {
            using (modalListarProduto modal = new modalListarProduto(consulta))
            {
                modal.Text = "Listar Clientes";
                modal.StartPosition = FormStartPosition.CenterParent;

                // Exibe o formulário modal e verifica se um cliente foi selecionado
                if (modal.ShowDialog() == DialogResult.OK)
                {
                    int codigo = Convert.ToInt32(modal.CodigoProduto);
                    string nome = modal.NomeProduto;
                    int quantidade = 1;
                    decimal valorUnitario = Convert.ToDecimal(modal.ValorUnitarioProduto);

                    AdicionarProdutoAoGrid(codigo, nome, quantidade, valorUnitario);
                }
            }
        }

        private void AdicionarProdutoAoGrid(int codigo, string nome, int quantidade, decimal valorUnitario)
        {
            // Criando um objeto para armazenar os dados temporariamente
            var produto = new ProdutoOrcamentoDTO
            {
                ProdutoID = codigo,
                Nome = nome,
                Quantidade = quantidade,
                ValorUnitario = valorUnitario,
            };

            // Adiciona à lista
            listaProdutos.Add(produto);
            
            // Atualiza o DataGridView
            AtualizarGridProdutos();
        }

        private void AtualizarGridProdutos()
        {
            dataGridProdutosOrcamento.DataSource = null; // Limpa o grid
            dataGridProdutosOrcamento.DataSource = listaProdutos; // Define os dados

            lblTotalProdutos.Value = listaProdutos.Count;
            AtualizarValorTotalOrcamento();
        }

        private void AtualizarValorTotalOrcamento()
        {
            decimal totalProcedimentos = listaProcedimentos.Sum(p => p.Valor);

            // Soma os valores dos produtos considerando a quantidade
            decimal totalProdutos = listaProdutos.Sum(p => p.ValorUnitario * p.Quantidade);

            // Calcula o total geral
            decimal totalOrcamento = totalProcedimentos + totalProdutos;

            // Atualiza o label de total formatado como moeda
            lblTotalOrcamento.Value = totalOrcamento;
        }

        private void CustomizeDataGridView()
        {
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            dataGridProcedimentoOrcamento.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridProcedimentoOrcamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridProcedimentoOrcamento.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridProcedimentoOrcamento.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridProcedimentoOrcamento.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridProcedimentoOrcamento.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridProcedimentoOrcamento.GridColor = gridColor;

            // Fontes
            dataGridProcedimentoOrcamento.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridProcedimentoOrcamento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridProcedimentoOrcamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridClientes.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridProcedimentoOrcamento.RowHeadersVisible = false;
            dataGridProdutosOrcamento.ReadOnly = false; // Permitir edição global

            dataGridProcedimentoOrcamento.EnableHeadersVisualStyles = false;
            dataGridProcedimentoOrcamento.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridProcedimentoOrcamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridProcedimentoOrcamento.BackgroundColor = SystemColors.Control;
            dataGridProcedimentoOrcamento.RowTemplate.Height = 40;

            // Impede a alteração no layout do datagrid

            dataGridProcedimentoOrcamento.AllowUserToAddRows = false;
            dataGridProcedimentoOrcamento.AllowUserToDeleteRows = false;
            dataGridProcedimentoOrcamento.AllowUserToOrderColumns = false;
            dataGridProcedimentoOrcamento.AllowUserToResizeRows = false;
            dataGridProcedimentoOrcamento.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridProcedimentoOrcamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Orcamento produtos

            // Aplicando as cores
            dataGridProdutosOrcamento.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridProdutosOrcamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridProdutosOrcamento.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridProdutosOrcamento.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridProdutosOrcamento.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridProdutosOrcamento.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridProdutosOrcamento.GridColor = gridColor;

            // Fontes
            dataGridProdutosOrcamento.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridProdutosOrcamento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridProdutosOrcamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridClientes.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridProdutosOrcamento.RowHeadersVisible = false;
            dataGridProdutosOrcamento.ReadOnly = true;
            dataGridProdutosOrcamento.EnableHeadersVisualStyles = false;
            dataGridProdutosOrcamento.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridProdutosOrcamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridProdutosOrcamento.BackgroundColor = SystemColors.Control;
            dataGridProdutosOrcamento.RowTemplate.Height = 40;

            // Impede a alteração no layout do datagrid

            dataGridProdutosOrcamento.AllowUserToAddRows = false;
            dataGridProdutosOrcamento.AllowUserToDeleteRows = false;
            dataGridProdutosOrcamento.AllowUserToOrderColumns = false;
            dataGridProdutosOrcamento.AllowUserToResizeRows = false;
            dataGridProdutosOrcamento.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridProdutosOrcamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void btnCancelarAdicaoOrcamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int InserirOrcamento(string clienteId, decimal valorTotal)
        {
            int novoOrcamentoId = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            string query = @"INSERT INTO Orcamentos (ClienteID, DataCriacao, Status, ValorTotal) 
                     OUTPUT INSERTED.OrcamentoID 
                     VALUES (@ClienteID, GETDATE(), 'Pendente', @ValorTotal)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClienteID", clienteId);
                        command.Parameters.AddWithValue("@ValorTotal", valorTotal);

                        // Obtém o ID gerado automaticamente
                        novoOrcamentoId = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao inserir orçamento: {ex.Message}");
                }
            }
            return novoOrcamentoId;
        }

        private void InserirItensOrcamento(int orcamentoId, List<Procedimento> procedimentos, List<ProdutoOrcamentoDTO> produtos)
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;
            string query = @"INSERT INTO Orcamento_Itens (OrcamentoID, Tipo, IDReferencia, Quantidade, Preco) 
                     VALUES (@OrcamentoID, @Tipo, @IDReferencia, @Quantidade, @Preco)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (var procedimento in procedimentos)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@OrcamentoID", orcamentoId);
                            command.Parameters.AddWithValue("@Tipo", "Procedimento");
                            command.Parameters.AddWithValue("@IDReferencia", procedimento.Codigo);
                            command.Parameters.AddWithValue("@Quantidade", 1); // Procedimento geralmente é único
                            command.Parameters.AddWithValue("@Preco", procedimento.Valor);

                            command.ExecuteNonQuery();
                        }
                    }

                    foreach (var produto in produtos)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@OrcamentoID", orcamentoId);
                            command.Parameters.AddWithValue("@Tipo", "Produto");
                            command.Parameters.AddWithValue("@IDReferencia", produto.ProdutoID);
                            command.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                            command.Parameters.AddWithValue("@Preco", produto.ValorUnitario);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Orçamento inserido com sucesso!");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao inserir itens do orçamento: {ex.Message}");
                }
            }
        }



        private void btnGravarOrcamento_Click(object sender, EventArgs e)
        {
            if (listaProcedimentos.Count == 0 && listaProdutos.Count == 0)
            {
                MessageBox.Show("Adicione ao menos um procedimento ou produto!");
                return;
            }

            // Pegamos os dados do cliente e o valor total do orçamento
            string clienteId = clienteSelecionadoCodigo;
            decimal valorTotal = listaProcedimentos.Sum(p => p.Valor) + listaProdutos.Sum(p => p.ValorUnitario * p.Quantidade);

            // Insere o orçamento e obtém o ID gerado
            int orcamentoId = InserirOrcamento(clienteId, valorTotal);

            if (orcamentoId > 0)
            {
                // Insere os itens do orçamento
                InserirItensOrcamento(orcamentoId, listaProcedimentos, listaProdutos);
            }
            _formOrcamentos.LoadData();
            this.Close();   
        }
    }
}
