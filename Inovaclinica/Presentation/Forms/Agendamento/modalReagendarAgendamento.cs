using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica
{
    public partial class modalReagendarAgendamento : Form
    {
        private FormAgendamento _formAgendamento;
        private string _agendamentoID;
        public modalReagendarAgendamento(FormAgendamento formAgendamento, string AgendamentoID)
        {
            InitializeComponent();
            _formAgendamento = formAgendamento;
            _agendamentoID = AgendamentoID;
        }
    }
}
