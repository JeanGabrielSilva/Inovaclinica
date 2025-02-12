using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica
{
    public partial class modalVisualizarLancamentoFinanceiro : Form
    {
        private string lancamentoID;

        private FormFinanceiro _formfinanceiro;
        private Color corPadrao = Color.Gray;
        private Color corEntrada = Color.FromArgb(100, 150, 100);
        private Color corSaida = Color.FromArgb(200, 50, 50);
        private string tipoOperacao = "";

        public modalVisualizarLancamentoFinanceiro(string lancamentoID, FormFinanceiro formFinanceiro)
        {
            InitializeComponent();
            this.lancamentoID = lancamentoID;
            BuscarLancamentoFinanceiroPeloID(lancamentoID);
            _formfinanceiro = formFinanceiro;
        }



        private void BuscarLancamentoFinanceiroPeloID(string lancamentoID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $"SELECT DataVencimento, Descricao, Valor, Tipo, Categoria, Status, DataPagamento " +
                               $"FROM Financeiro WHERE ID = @lancamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@lancamentoID", lancamentoID); // Utiliza parâmetros para evitar SQL Injection

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    textBoxVisualizaDescricaoLancamento.Text = reader["Descricao"].ToString();
                    textBoxVisualizaCategoriaLancamento.Text = reader["Categoria"].ToString();
                    DateTime dataVencimento = Convert.ToDateTime(reader["DataVencimento"]);
                    maskVisualizaDataVencimentoLancamento.Text = dataVencimento.ToString("dd/MM/yyyy");
                    textBoxVisualizaValorLancamento.Text = reader["Valor"].ToString();

                    string tipo = reader["Tipo"].ToString();

                    if (tipo.Equals("Entrada", StringComparison.OrdinalIgnoreCase))
                    {
                        btnVisualizarEntrada.BackColor = corEntrada;
                        btnVisualizarSaida.BackColor = corPadrao;
                        tipoOperacao = "Entrada";
                    }
                    else if (tipo.Equals("Saída", StringComparison.OrdinalIgnoreCase))
                    {
                        btnVisualizarSaida.BackColor = corSaida;
                        btnVisualizarEntrada.BackColor = corPadrao;
                        tipoOperacao = "Saída";
                    }

                    // Verifica o status do pagamento
                    string statusPagamento = reader["Status"].ToString();
                    if (statusPagamento.Equals("Pago", StringComparison.OrdinalIgnoreCase))
                    {
                        checkBoxPagamento.Checked = true;

                        // Se estiver pago, preencher a data de pagamento
                        if (reader["DataPagamento"] != DBNull.Value)
                        {
                            DateTime dataPagamento = Convert.ToDateTime(reader["DataPagamento"]);
                            maskDataPagamentoLancamento.Text = dataPagamento.ToString("dd/MM/yyyy");
                            maskDataPagamentoLancamento.Visible = true;
                            lblDataPagamento.Visible = true;    
                        }
                    }
                    else
                    {
                        checkBoxPagamento.Checked = false;
                        maskDataPagamentoLancamento.Visible = false;
                        lblDataPagamento.Visible = false;
                        maskDataPagamentoLancamento.Clear(); // Limpar a data de pagamento, caso não esteja pago
                    }
                }
            }
        }


        private void btnVisualizarEntrada_Click(object sender, EventArgs e)
        {
            btnVisualizarEntrada.BackColor = corEntrada;
            btnVisualizarSaida.BackColor = corPadrao;
            tipoOperacao = "Entrada";
        }

        private void btnVisualizarSaida_Click(object sender, EventArgs e)
        {
            btnVisualizarSaida.BackColor = corSaida;
            btnVisualizarEntrada.BackColor = corPadrao;
            tipoOperacao = "Saída";
        }

        private void btnSalvarAlteracaoLancamento_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DateTime dataVencimento = DateTime.ParseExact(maskVisualizaDataVencimentoLancamento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string dataVencimentoFormatada = dataVencimento.ToString("yyyy-MM-dd");

                // Defina os valores de StatusPagamento e DataPagamento
                string statusPagamento = checkBoxPagamento.Checked ? "Pago" : "Pendente";
                string dataPagamento = checkBoxPagamento.Checked ? DateTime.ParseExact(maskDataPagamentoLancamento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd") : null;

                string query = "UPDATE Financeiro SET Descricao = @DescricaoLancamento, Valor = @ValorLancamento, Categoria = @CategoriaLancamento, Tipo = @TipoOperacao, DataVencimento = @DataVencimento, Status = @StatusPagamento, DataPagamento = @DataPagamento WHERE ID = @lancamentoID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@lancamentoID", lancamentoID);
                command.Parameters.AddWithValue("@DescricaoLancamento", textBoxVisualizaDescricaoLancamento.Text);
                command.Parameters.AddWithValue("@CategoriaLancamento", textBoxVisualizaCategoriaLancamento.Text);
                command.Parameters.AddWithValue("@DataVencimento", dataVencimentoFormatada);
                command.Parameters.AddWithValue("@TipoOperacao", tipoOperacao);
                command.Parameters.AddWithValue("@ValorLancamento", textBoxVisualizaValorLancamento.Value);
                command.Parameters.AddWithValue("@StatusPagamento", statusPagamento);
                command.Parameters.AddWithValue("@DataPagamento", (object)dataPagamento ?? DBNull.Value);  // Se DataPagamento for null, passará DBNull.Value

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery(); // Executa o comando SQL

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Lançamento atualizado com sucesso!");
                    _formfinanceiro.LoadData();
                }
                else
                {
                    MessageBox.Show("Nenhuma alteração foi feita.");
                }
            }
        }

        private void btnCancelarAlteracaoLancamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxPagamento_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPagamento.Checked)
            {
                lblDataPagamento.Visible = true;
                maskDataPagamentoLancamento.Visible = true;
            }
            else
            {
                lblDataPagamento.Visible = false;
                maskDataPagamentoLancamento.Visible = false;
                maskDataPagamentoLancamento.Clear(); // Limpar a data de pagamento, caso desmarcado
            }
        }
    }
}
