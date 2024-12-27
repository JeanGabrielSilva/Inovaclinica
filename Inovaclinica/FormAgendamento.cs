using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Inovaclinica {
    public partial class FormAgendamento : Form {
        private int anoAtual = DateTime.Now.Year;
        private int mesAtual = DateTime.Now.Month;
        private readonly HashSet<(int, int, int)> diasMarcados = new HashSet<(int, int, int)>();

        public FormAgendamento() {
            InitializeComponent();
            this.Load += new System.EventHandler(this.FormAgendamento_Load);
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

            // Adicionar 6 linhas para as semanas
            dataGridViewCalendarioProcedimento.Rows.Add(6);

            // Determinar o primeiro dia do mês
            DateTime primeiroDia = new DateTime(ano, mes, 1);
            int diasNoMes = DateTime.DaysInMonth(ano, mes);
            int diaSemanaInicio = (int)primeiroDia.DayOfWeek;

            // Preencher o calendário com os dias
            int diaAtual = 1;
            for (int i = 0; i < 6; i++) {
                for (int j = 0; j < 7; j++) {
                    if ((i == 0 && j >= diaSemanaInicio) || (i > 0 && diaAtual <= diasNoMes)) {
                        dataGridViewCalendarioProcedimento.Rows[i].Cells[j].Value = diaAtual.ToString();
                        diaAtual++;
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
