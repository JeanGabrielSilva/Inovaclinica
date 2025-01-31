using System;
using System.Collections.Generic;
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
        }

        private void DataGridViewCalendarioProcedimento_CellClick(object sender, DataGridViewCellEventArgs e) {
            // Verifica se a célula clicada contém um valor numérico (dia)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                var celulaSelecionada = dataGridViewCalendarioProcedimento.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (celulaSelecionada.Value != null && int.TryParse(celulaSelecionada.Value.ToString(), out int diaSelecionado)) {
                    // Atualiza o texto da label com o dia selecionado
                    lblDiaSelecionado.Text = $"Dia Selecionado: {diaSelecionado}";
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
    }
}
