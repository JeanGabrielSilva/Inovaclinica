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

namespace Inovaclinica {

    public partial class modalVisualizarAgendamento : Form {

        private FormAgendamento _formAgendamento;

        public modalVisualizarAgendamento(FormAgendamento formAgendamento, string AgendamentoID) {
            InitializeComponent();

            _formAgendamento = formAgendamento;

            // Buscar informações do agendamento
            BuscarAgendamentoPeloID(AgendamentoID);

            // Buscar Procedimentos e Produtos
            BuscarProcedimentosPeloAgendamento(AgendamentoID);
            BuscarProdutosPeloAgendamento(AgendamentoID);

            CustomizeDataGridViewProcedimentos();
            CustomizeDataGridViewProdutos();


    }


        private void BuscarAgendamentoPeloID(string AgendamentoID) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"SELECT A.AgendamentoID, C.Nome, C.Telefone, CONVERT(varchar, A.DataHora, 23) AS DataAgendamento, O.ValorTotal
                                FROM Agendamentos A
                                INNER JOIN Clientes C ON A.ClienteID = C.ClienteID
                                LEFT JOIN Orcamentos O ON A.OrcamentoID = O.OrcamentoID
                                WHERE A.AgendamentoID = @AgendamentoID";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AgendamentoID", AgendamentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) {
                    lblAgendamentoID.Text = reader["AgendamentoID"].ToString();
                    lblCliente.Text = reader["Nome"].ToString();
                    lblTelefoneCliente.Text = reader["Telefone"].ToString();
                    lblValorAgendamento.Text = "R$ " + Convert.ToDecimal(reader["ValorTotal"]).ToString("N2");  
                }
            }
        }

        private void dataGridViewVisualizarProcedimentosAgendamento_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void dataGridViewVisualizarProdutosAgendamento_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void BuscarProcedimentosPeloAgendamento(string AgendamentoID) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"select AI.IDReferencia as Código, P.Nome, AI.Quantidade ,AI.Preco as [Preço] FROM Agendamento_Itens As AI inner join Procedimentos as P on AI.IDReferencia = P.ProcedimentoID where AI.AgendamentoID = @agendamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AgendamentoID", AgendamentoID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewVisualizarProcedimentosAgendamento.DataSource = dataTable;
            }
        }

        private void BuscarProdutosPeloAgendamento(string AgendamentoID) {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString)) {
                string query = @"select AI.IDReferencia as Código, P.Nome, AI.Quantidade ,AI.Preco as [Preço] FROM Agendamento_Itens As AI inner join Produtos as P on AI.IDReferencia = P.ProdutoID where AI.AgendamentoID = @agendamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AgendamentoID", AgendamentoID);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewVisualizarProdutosAgendamento.DataSource = dataTable;
            }
        }

        public void CustomizeDataGridViewProcedimentos() {
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            dataGridViewVisualizarProcedimentosAgendamento.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridViewVisualizarProcedimentosAgendamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewVisualizarProcedimentosAgendamento.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridViewVisualizarProcedimentosAgendamento.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridViewVisualizarProcedimentosAgendamento.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridViewVisualizarProcedimentosAgendamento.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridViewVisualizarProcedimentosAgendamento.GridColor = gridColor;

            dataGridViewVisualizarProcedimentosAgendamento.ReadOnly = true;

            // Fontes
            dataGridViewVisualizarProcedimentosAgendamento.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridViewVisualizarProcedimentosAgendamento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridViewVisualizarProcedimentosAgendamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVisualizarProcedimentosAgendamento.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridViewVisualizarProcedimentosAgendamento.RowHeadersVisible = false;
            dataGridViewVisualizarProcedimentosAgendamento.EnableHeadersVisualStyles = false;
            dataGridViewVisualizarProcedimentosAgendamento.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewVisualizarProcedimentosAgendamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewVisualizarProcedimentosAgendamento.BackgroundColor = SystemColors.Control;
            dataGridViewVisualizarProcedimentosAgendamento.RowTemplate.Height = 40;

            // Impede a alteração no layout do datagrid

            dataGridViewVisualizarProcedimentosAgendamento.AllowUserToAddRows = false;
            dataGridViewVisualizarProcedimentosAgendamento.AllowUserToDeleteRows = false;
            dataGridViewVisualizarProcedimentosAgendamento.AllowUserToOrderColumns = false;
            dataGridViewVisualizarProcedimentosAgendamento.AllowUserToResizeRows = false;
            dataGridViewVisualizarProcedimentosAgendamento.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridViewVisualizarProcedimentosAgendamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void CustomizeDataGridViewProdutos() {
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            dataGridViewVisualizarProdutosAgendamento.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridViewVisualizarProdutosAgendamento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewVisualizarProdutosAgendamento.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridViewVisualizarProdutosAgendamento.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridViewVisualizarProdutosAgendamento.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridViewVisualizarProdutosAgendamento.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridViewVisualizarProdutosAgendamento.GridColor = gridColor;

            dataGridViewVisualizarProdutosAgendamento.ReadOnly = true;

            // Fontes
            dataGridViewVisualizarProdutosAgendamento.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridViewVisualizarProdutosAgendamento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridViewVisualizarProdutosAgendamento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewVisualizarProdutosAgendamento.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridViewVisualizarProdutosAgendamento.RowHeadersVisible = false;
            dataGridViewVisualizarProdutosAgendamento.EnableHeadersVisualStyles = false;
            dataGridViewVisualizarProdutosAgendamento.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewVisualizarProdutosAgendamento.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewVisualizarProdutosAgendamento.BackgroundColor = SystemColors.Control;
            dataGridViewVisualizarProdutosAgendamento.RowTemplate.Height = 40;

            // Impede a alteração no layout do datagrid

            dataGridViewVisualizarProdutosAgendamento.AllowUserToAddRows = false;
            dataGridViewVisualizarProdutosAgendamento.AllowUserToDeleteRows = false;
            dataGridViewVisualizarProdutosAgendamento.AllowUserToOrderColumns = false;
            dataGridViewVisualizarProdutosAgendamento.AllowUserToResizeRows = false;
            dataGridViewVisualizarProdutosAgendamento.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridViewVisualizarProdutosAgendamento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

    }
}
