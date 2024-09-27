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
    public partial class modalFiltrarCliente : Form {

        private FormClientes _formClientes;
        public modalFiltrarCliente(FormClientes formClientes) {
            InitializeComponent();
            _formClientes = formClientes;

        }

        private void btnCancelarAlteracaoCliente_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrarClientes_Click(object sender, EventArgs e)
        {
            var filtroNomeCliente = textBoxFiltrarClientesNome.Text;
            var filtroCpfCliente = textBoxFiltrarClientesCPF.Text;
            var filtroCidadeCliente = textBoxFiltrarClientesCidade.Text;
            var filtroSexoCliente = ComboBoxFiltrarClientesSexo.Text;
            var filtroDataNascimentoInicio = maskFiltrarClientesDataInicio.Text;
            var filtroDataNascimentoFinal = maskFiltrarClientesDataFinal.Text;

            FiltrarClientes(filtroNomeCliente, filtroCpfCliente, filtroCidadeCliente, filtroSexoCliente, filtroDataNascimentoInicio, filtroDataNascimentoFinal);

        }

        private void FiltrarClientes(string filtroNomeCliente,string filtroCpfCliente, string filtroCidadeCliente,string filtroSexoCliente,string filtroDataNascimentoInicio,string filtroDataNascimentoFinal)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            var queryFiltrar = $"SELECT ClienteID as Código, Nome, CPF, DataNascimento as [Data Nascimento] FROM Clientes WHERE Ativo = 1 OR Nome = {filtroNomeCliente} OR CPF = {filtroCpfCliente} OR Cidade = {filtroCidadeCliente} OR Genero = {filtroSexoCliente}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // SqlDataAdapter para executar a consulta e preencher os dados
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryFiltrar, connection);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados retornados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define a fonte de dados do DataGridView como o DataTable
                    dataGridClientes.DataSource = dataTable;

                    // Aplica as cores das linhas
                    ApplyRowColors();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }

            }
        }
    }
}
