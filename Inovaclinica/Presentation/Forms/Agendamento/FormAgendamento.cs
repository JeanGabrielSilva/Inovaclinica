using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Inovaclinica {
    public partial class FormAgendamento : Form {
        private int anoAtual = DateTime.Now.Year;
        private int mesAtual = DateTime.Now.Month;
        private readonly HashSet<(int, int, int)> diasMarcados = new HashSet<(int, int, int)>();


        public FormAgendamento() {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormAgendamento_Load);
            dataGridViewCalendarioProcedimento.CellClick += DataGridViewCalendarioProcedimento_CellClick; // Adicionar o evento de clique
            string dataAtual = DateTime.Now.ToString("yyyy-MM-dd");
            string dataParaExibir = DateTime.Now.ToString("dd-MM-yyyy"); // Formato usuário
            // Exibir no label de seleção
            lblDetalhesDiaSelecionado.Text = $"Agendamentos do dia: {dataParaExibir}";
            LoadData(dataAtual);
            CustomizeDataGridView();
        }

        private void DataGridViewCalendarioProcedimento_CellClick(object sender, DataGridViewCellEventArgs e) {
            // Verifica se a célula clicada contém um valor numérico (dia)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var celulaSelecionada = dataGridViewCalendarioProcedimento.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (celulaSelecionada.Value != null && int.TryParse(celulaSelecionada.Value.ToString(), out int diaSelecionado))
                {
                    // Formatar a data no formato correto para o banco de dados
                    DateTime dataSelecionada = new DateTime(anoAtual, mesAtual, diaSelecionado);
                    // Formatos de data
                    string dataParaBanco = dataSelecionada.ToString("yyyy-MM-dd"); // Formato SQL
                    string dataParaExibir = dataSelecionada.ToString("dd-MM-yyyy"); // Formato usuário

                    // Exibir no label de seleção
                    lblDetalhesDiaSelecionado.Text = $"Agendamentos do dia: {dataParaExibir}";

                    // Chamar a função LoadData com a data selecionada
                    LoadData(dataParaBanco);
                }
            }
        }

            private void FormAgendamento_Load(object sender, EventArgs e) {
            CriarCalendario(DateTime.Now.Year, DateTime.Now.Month);
        }

        private void CriarCalendario(int ano, int mes) {
            // Limpar DataGridView
            dataGridViewCalendarioProcedimento.Columns.Clear();
            dataGridViewCalendarioProcedimento.Rows.Clear();

            // Adicionar colunas (dias da semana)
            string[] diasSemana = { "Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sab" };
            foreach (string dia in diasSemana) {
                dataGridViewCalendarioProcedimento.Columns.Add(dia, dia);
            }

            dataGridViewCalendarioProcedimento.AllowUserToOrderColumns = false;
            dataGridViewCalendarioProcedimento.ScrollBars = ScrollBars.None;

            // Adicionar 6 linhas para as semanas
            dataGridViewCalendarioProcedimento.Rows.Add(6);

            // Determinar o primeiro dia do mês
            DateTime primeiroDia = new DateTime(ano, mes, 1);
            int diasNoMes = DateTime.DaysInMonth(ano, mes);
            int diaSemanaInicio = (int)primeiroDia.DayOfWeek;

            // Obter o dia atual
            int diaAtual = DateTime.Now.Day;
            int mesAtualSistema = DateTime.Now.Month;
            int anoAtualSistema = DateTime.Now.Year;

            DataGridViewCell celulaAtual = null;

            // Preencher o calendário com os dias
            int diaDoMes = 1;
            for (int i = 0; i < 6; i++) {
                for (int j = 0; j < 7; j++) {
                    if ((i == 0 && j >= diaSemanaInicio) || (i > 0 && diaDoMes <= diasNoMes)) {
                        var cell = dataGridViewCalendarioProcedimento.Rows[i].Cells[j];
                        cell.Value = diaDoMes.ToString();

                        // Destacar o dia atual em cinza se o mês e o ano forem iguais ao sistema
                        if (diaDoMes == diaAtual && mes == mesAtualSistema && ano == anoAtualSistema) {
                            cell.Style.BackColor = Color.LightGray;
                            cell.Style.ForeColor = Color.Black;

                            // Armazenar a célula atual para seleção temporária
                            celulaAtual = cell;
                        }

                        diaDoMes++;
                    }
                }
            }
            // Ajustar o tamanho das células
            foreach (DataGridViewColumn col in dataGridViewCalendarioProcedimento.Columns) {
                col.Width = dataGridViewCalendarioProcedimento.Width / dataGridViewCalendarioProcedimento.Columns.Count - 1;
            }
            foreach (DataGridViewRow row in dataGridViewCalendarioProcedimento.Rows) {
                row.Height = dataGridViewCalendarioProcedimento.Height / dataGridViewCalendarioProcedimento.Rows.Count - 1;
            }

            AjustarLayoutDataGridView();
            AtualizarTituloMesAno(ano, mes);

            // Selecionar a célula atual de forma temporária
            if (celulaAtual != null) {
                dataGridViewCalendarioProcedimento.CurrentCell = celulaAtual;
            }
        }

        private void AjustarLayoutDataGridView() {
            // Configurar o DataGridView para não ser editável e evitar linhas extras
            dataGridViewCalendarioProcedimento.ReadOnly = true;
            dataGridViewCalendarioProcedimento.AllowUserToAddRows = false; // Garante que nenhuma linha extra seja criada
            dataGridViewCalendarioProcedimento.AllowUserToDeleteRows = false;
            dataGridViewCalendarioProcedimento.AllowUserToResizeRows = false;
            dataGridViewCalendarioProcedimento.AllowUserToResizeColumns = false;
            dataGridViewCalendarioProcedimento.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Configurar o Dock para preencher o Panel
            dataGridViewCalendarioProcedimento.Dock = DockStyle.Fill;

            // Ajustar o tamanho das colunas
            dataGridViewCalendarioProcedimento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Manter as grades visíveis
            dataGridViewCalendarioProcedimento.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridViewCalendarioProcedimento.GridColor = Color.LightGray;

            // Configurar cores e fontes
            dataGridViewCalendarioProcedimento.BackgroundColor = Color.White;
            dataGridViewCalendarioProcedimento.DefaultCellStyle.Font = new Font("Arial", 15, FontStyle.Regular);
            dataGridViewCalendarioProcedimento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dataGridViewCalendarioProcedimento.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dataGridViewCalendarioProcedimento.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewCalendarioProcedimento.RowHeadersVisible = false;

            // Centralizar o conteúdo das células
            dataGridViewCalendarioProcedimento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ajustar a altura das linhas dinamicamente para evitar espaços
            if (dataGridViewCalendarioProcedimento.Rows.Count > 0) {
                int alturaTotal = dataGridViewCalendarioProcedimento.ClientSize.Height;
                int alturaCabecalho = dataGridViewCalendarioProcedimento.ColumnHeadersHeight;
                int alturaLinha = (alturaTotal - alturaCabecalho) / dataGridViewCalendarioProcedimento.Rows.Count;

                foreach (DataGridViewRow row in dataGridViewCalendarioProcedimento.Rows) {
                    row.Height = alturaLinha;
                }
            }
        }




        private void AtualizarTituloMesAno(int ano, int mes) {
            // Obter o nome do mês em português
            DateTimeFormatInfo formatoData = CultureInfo.GetCultureInfo("pt-BR").DateTimeFormat;
            string nomeMes = formatoData.GetMonthName(mes);

            // Formatar o título (ex: "Janeiro - 2025")
            lblTituloMesCalendario.Text = $"{char.ToUpper(nomeMes[0])}{nomeMes.Substring(1)} - {ano}";
        }


        private void btnMesAnterior_Click(object sender, EventArgs e) {
            // Ir para o mês anterior
            mesAtual--;
            if (mesAtual < 1) {
                mesAtual = 12;
                anoAtual--;
            }
            CriarCalendario(anoAtual, mesAtual);
        }

        private void btnProximoMes_Click(object sender, EventArgs e) {
            // Ir para o próximo mês
            mesAtual++;
            if (mesAtual > 12) {
                mesAtual = 1;
                anoAtual++;
            }
            CriarCalendario(anoAtual, mesAtual);
        }

        private void btnMarcarDia_Click(object sender, EventArgs e) {
            // Obter a célula selecionada no DataGridView
            var celulaSelecionada = dataGridViewCalendarioProcedimento.CurrentCell;

            if (celulaSelecionada != null && int.TryParse(celulaSelecionada.Value?.ToString(), out int diaSelecionado)) {
                // Adicionar o dia selecionado aos dias marcados
                diasMarcados.Add((anoAtual, mesAtual, diaSelecionado));

                // Atualizar o calendário para aplicar a marcação
                CriarCalendario(anoAtual, mesAtual);
            } else {
                MessageBox.Show("Por favor, selecione um dia válido.");
            }
        }

        public void LoadData(string data)
        {
            // Obtém a string de conexão a partir do App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InovaclinicaConnectionString"].ConnectionString;

            // Define as datas inicial e final com base no parâmetro recebido
            string dataInicial = $"{data} 00:00:00";
            string dataFinal = $"{data} 23:59:59";

            // Query SQL para buscar os dados da tabela 'Agendamentos' com filtro de data e ordenação
            string query = @"
        SELECT 
            a.AgendamentoID AS [Código], 
            c.Nome AS [Nome], 
            c.Telefone AS [Telefone], 
            a.DataHora AS [Data e Hora], 
            a.Status AS [Status], 
            ISNULL((SELECT SUM(ai.Quantidade) FROM dbo.Agendamento_Itens ai WHERE ai.AgendamentoID = a.AgendamentoID AND ai.Tipo = 'Procedimento'), 0) AS [Quantidade de Procedimentos], 
            ISNULL((SELECT SUM(ai.Quantidade) FROM dbo.Agendamento_Itens ai WHERE ai.AgendamentoID = a.AgendamentoID AND ai.Tipo = 'Produto'), 0) AS [Quantidade de Produtos], 
            o.ValorTotal AS [Valor Total] 
        FROM 
            dbo.Agendamentos a 
        JOIN 
            dbo.Clientes c ON a.ClienteID = c.ClienteID 
        LEFT JOIN 
            dbo.Orcamentos o ON a.OrcamentoID = o.OrcamentoID 
        WHERE 
            a.DataHora BETWEEN @DataInicial AND @DataFinal 
        ORDER BY 
            a.DataHora ASC";

            // Usa SqlConnection e SqlDataAdapter para preencher o DataGridView
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abre a conexão
                    connection.Open();

                    // SqlCommand para executar a consulta com parâmetros
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DataInicial", dataInicial);
                    command.Parameters.AddWithValue("@DataFinal", dataFinal);

                    // SqlDataAdapter para preencher os dados
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    // Cria um DataTable para armazenar os dados
                    DataTable dataTable = new DataTable();

                    // Preenche o DataTable com os dados retornados da consulta
                    dataAdapter.Fill(dataTable);

                    // Define a fonte de dados do DataGridView como o DataTable
                    dataGridViewAgendamentos.DataSource = dataTable;

                    //ApplyRowColors();
                }
                catch (Exception ex)
                {
                    // Exibe uma mensagem de erro caso ocorra uma exceção
                    MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
                }
            }
        }

        public void CustomizeDataGridView()
        {
            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            dataGridViewAgendamentos.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGridViewAgendamentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewAgendamentos.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGridViewAgendamentos.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGridViewAgendamentos.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGridViewAgendamentos.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGridViewAgendamentos.GridColor = gridColor;

            // Fontes
            dataGridViewAgendamentos.Font = new Font("Arial", 10F); // Aumentei o tamanho da fonte para melhor legibilidade
            dataGridViewAgendamentos.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGridViewAgendamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAgendamentos.Dock = DockStyle.Fill; // Ocupa todo o espaço disponível
            dataGridViewAgendamentos.RowHeadersVisible = false;
            dataGridViewAgendamentos.EnableHeadersVisualStyles = false;
            dataGridViewAgendamentos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewAgendamentos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewAgendamentos.BackgroundColor = SystemColors.Control;
            dataGridViewAgendamentos.RowTemplate.Height = 40;

            // Impede a alteração no layout do datagrid

            dataGridViewAgendamentos.AllowUserToAddRows = false;
            dataGridViewAgendamentos.AllowUserToDeleteRows = false;
            dataGridViewAgendamentos.AllowUserToOrderColumns = false;
            dataGridViewAgendamentos.AllowUserToResizeRows = false;
            dataGridViewAgendamentos.AllowUserToResizeColumns = false;

            // Ação necessário para conseguir selecionar a linha para visualização dos clientes
            dataGridViewAgendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnSalvarAlteracaoLancamento_Click(object sender, EventArgs e) {

            if (dataGridViewAgendamentos.SelectedRows.Count > 0) {
                var selectedRow = dataGridViewAgendamentos.SelectedRows[0];
                string AgendamentoID = selectedRow.Cells["Código"].Value.ToString();


                modalConfirmarAgendamento modalconfirmaragendamento = new modalConfirmarAgendamento(this, AgendamentoID);
                modalconfirmaragendamento.Text = "Visualizar Agendamento";
                modalconfirmaragendamento.StartPosition = FormStartPosition.CenterParent;
                modalconfirmaragendamento.ShowDialog();
            } else {
                MessageBox.Show("Selecione um agendamento para visualizar.");
            }

        }

        private void atualizarGridAgendamentos_Click(object sender, EventArgs e) {
            
        }

        private void btnCancelarAgendamento_Click(object sender, EventArgs e)
        {
            if (dataGridViewAgendamentos.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewAgendamentos.SelectedRows[0];
                string AgendamentoID = selectedRow.Cells["Código"].Value.ToString();


                modalCancelarAgendamento modalcancelaragendamento = new modalCancelarAgendamento(this, AgendamentoID);
                modalcancelaragendamento.Text = "Cancelar Agendamento";
                modalcancelaragendamento.StartPosition = FormStartPosition.CenterParent;
                modalcancelaragendamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um agendamento para cancelar.");
            }
        }

        private void btnAbrirModalReagendarAgendamento_Click(object sender, EventArgs e)
        {
            if (dataGridViewAgendamentos.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewAgendamentos.SelectedRows[0];
                string AgendamentoID = selectedRow.Cells["Código"].Value.ToString();


                modalReagendarAgendamento modalreagendaragendamento = new modalReagendarAgendamento(this, AgendamentoID);
                modalreagendaragendamento.Text = "Cancelar Agendamento";
                modalreagendaragendamento.StartPosition = FormStartPosition.CenterParent;
                modalreagendaragendamento.ShowDialog();
            }
            else
            {
                MessageBox.Show("Selecione um agendamento para cancelar.");
            }
        }

        private void btnVisualizarAgendamento_Click(object sender, EventArgs e) {

            if (dataGridViewAgendamentos.SelectedRows.Count > 0) {
                var selectedRow = dataGridViewAgendamentos.SelectedRows[0];
                string AgendamentoID = selectedRow.Cells["Código"].Value.ToString();


                modalVisualizarAgendamento modalvisualizaragendamento = new modalVisualizarAgendamento(this, AgendamentoID);
                modalvisualizaragendamento.Text = "Visualizar Agendamento";
                modalvisualizaragendamento.StartPosition = FormStartPosition.CenterParent;
                modalvisualizaragendamento.ShowDialog();
            } else {
                MessageBox.Show("Selecione um agendamento para visualizar.");
            }
        }
    }
}
