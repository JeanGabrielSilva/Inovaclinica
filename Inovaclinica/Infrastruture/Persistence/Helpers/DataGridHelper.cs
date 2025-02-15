using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inovaclinica.Helpers
{
    public static class DataGridViewHelper
    {
        public static void CustomizeDataGridView(DataGridView dataGrid)
        {
            if (dataGrid == null) return;

            // Cores
            Color headerColor = Color.FromArgb(45, 45, 45);
            Color rowColor1 = Color.White;
            Color rowColor2 = Color.FromArgb(211, 211, 211);
            Color selectionBackColor = Color.FromArgb(153, 102, 255);
            Color selectionForeColor = Color.White;
            Color gridColor = Color.LightGray;

            // Aplicando as cores
            dataGrid.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGrid.RowTemplate.DefaultCellStyle.BackColor = rowColor1; // Cor padrão para todas as linhas
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = rowColor2; // Cor alternada para linhas pares
            dataGrid.DefaultCellStyle.SelectionBackColor = selectionBackColor;
            dataGrid.DefaultCellStyle.SelectionForeColor = selectionForeColor;
            dataGrid.GridColor = gridColor;

            // Fontes
            dataGrid.Font = new Font("Arial", 10F);
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10F, FontStyle.Bold);

            // Layout
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.RowHeadersVisible = false;
            dataGrid.EnableHeadersVisualStyles = false;
            dataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGrid.BackgroundColor = SystemColors.Control;
            dataGrid.RowTemplate.Height = 40;

            // Adicionando uma coluna de seleção (opcional)
            if (!dataGrid.Columns.Contains("checkBoxColumn"))
            {
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    HeaderText = "Selecionar",
                    Name = "checkBoxColumn"
                };
                dataGrid.Columns.Insert(0, checkBoxColumn);
            }

            // Impede a alteração no layout do DataGridView
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToOrderColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.AllowUserToResizeColumns = false;

            // Ação necessária para conseguir selecionar a linha para visualização dos clientes
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void ApplyRowColors(DataGridView dataGrid)
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                if (i % 2 == 0) // Linha par → branca
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else // Linha ímpar → roxo claro
                {
                    dataGrid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(230, 230, 255);
                }
            }
        }
    }
}
