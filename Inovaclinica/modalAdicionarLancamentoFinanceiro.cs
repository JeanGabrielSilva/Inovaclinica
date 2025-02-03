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
    public partial class modalAdicionarLancamentoFinanceiro : Form
    {
        private FormFinanceiro _formFinanceiro;
        private Color corPadrao = Color.Gray;
        private Color corEntrada = Color.FromArgb(100, 150, 100);
        private Color corSaida = Color.FromArgb(200, 50, 50);
        private string tipoOperacao = "";

        public modalAdicionarLancamentoFinanceiro(FormFinanceiro formFinanceiro)
        {
            InitializeComponent();

            _formFinanceiro = formFinanceiro;
            btnEntrada.BackColor = corPadrao;
            btnSaida.BackColor = corPadrao;
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            btnEntrada.BackColor = corEntrada;
            btnSaida.BackColor = corPadrao;
            tipoOperacao = "Entrada";
        }

        private void btnSaida_Click(object sender, EventArgs e)
        {
            btnSaida.BackColor = corSaida;
            btnEntrada.BackColor = corPadrao;
            tipoOperacao = "Saída";
        }

        private void btnAdicionarLancamento_Click(object sender, EventArgs e)
        {
            string descricaoLancamento = textBoxDescricaoLancamento.Text;
            string categoriaLancamento = textBoxCategoriaLancamento.Text;
            string dataComBarras = maskDataVencimentoLancamento.Text;
            DateTime data = DateTime.ParseExact(dataComBarras, "dd/MM/yyyy", null);
            string dataVencimento = data.ToString("yyyy-MM-dd");
            decimal valorLancamento = textBoxValorLancamento.Value;

            // Recupera o status do pagamento (Pago ou Pendente)
            string statusPagamento = checkBoxPagamento.Checked ? "Pago" : "Pendente";

            // Se o pagamento estiver marcado, obter a data de pagamento; se não, será null
            string dataPagamentoFormatada = null;
            if (checkBoxPagamento.Checked)
            {
                string dataComBarrasPagamento = maskDataPagamentoLancamento.Text;
                if (!string.IsNullOrEmpty(dataComBarrasPagamento))
                {
                    DateTime dataPagamento = DateTime.ParseExact(dataComBarrasPagamento, "dd/MM/yyyy", null);
                    dataPagamentoFormatada = dataPagamento.ToString("yyyy-MM-dd");
                }
            }

            // Passa os valores para a função AdicionarLancamento
            AdicionarLancamento(descricaoLancamento, categoriaLancamento, dataVencimento, valorLancamento, tipoOperacao, statusPagamento, dataPagamentoFormatada);
        }


        private void AdicionarLancamento(string descricaoLancamento, string categoriaLancamento, string dataVencimento, decimal valorLancamento, string tipoOperacao, string statusPagamento, string dataPagamento)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            string query = "INSERT INTO Financeiro (DataVencimento, Descricao, Valor, Tipo, Categoria, DataInclusao, Status, DataPagamento) " +
                           "VALUES (@DataVencimento, @DescricaoLancamento, @ValorLancamento, @TipoOperacao, @CategoriaLancamento, @DataInclusao, @StatusPagamento, @DataPagamento)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Cria o comando SQL para a inserção
                SqlCommand command = new SqlCommand(query, connection);

                // Define os parâmetros da query
                command.Parameters.AddWithValue("@DescricaoLancamento", descricaoLancamento);
                command.Parameters.AddWithValue("@CategoriaLancamento", categoriaLancamento);
                command.Parameters.AddWithValue("@DataVencimento", dataVencimento);
                command.Parameters.AddWithValue("@DataInclusao", DateTime.Now);
                command.Parameters.AddWithValue("@TipoOperacao", tipoOperacao);
                command.Parameters.AddWithValue("@ValorLancamento", valorLancamento);
                command.Parameters.AddWithValue("@StatusPagamento", statusPagamento);

                // Se a data de pagamento for informada, passa ela; caso contrário, insere NULL
                if (string.IsNullOrEmpty(dataPagamento))
                {
                    command.Parameters.AddWithValue("@DataPagamento", DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@DataPagamento", dataPagamento);
                }

                try
                {
                    // Abre a conexão
                    connection.Open();

                    // Executa o comando
                    int result = command.ExecuteNonQuery();

                    // Verifica se o cliente foi inserido com sucesso
                    if (result > 0)
                    {
                        MessageBox.Show($"Lançamento adicionado com sucesso!");
                        // Limpa os campos de entrada
                        _formFinanceiro.LoadData();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocorreu um erro ao adicionar o Produto.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}\n{ex.InnerException?.Message}");
                }
            }
        }


        private void btnCancelarLancamento_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void modalAdicionarLancamentoFinanceiro_Load(object sender, EventArgs e) {

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
            }
        }

    }
}