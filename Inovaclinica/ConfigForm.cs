using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inovaclinica {
    public partial class ConfigForm : Form {
        public ConfigForm() {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e) {
        string server = txtServer.Text;
        string database = txtDatabase.Text;

        // Criar a string de conexão com autenticação Windows
        string connectionString = $"Server={server};Database={database};Integrated Security=True;";

        // Salvar a string de conexão no arquivo de configuração
        SaveConnectionString(connectionString);

        // Fechar o formulário de configuração
        this.Close();
    }

    private void SaveConnectionString(string connectionString) {
        var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        if (config.ConnectionStrings.ConnectionStrings["DefaultConnection"] != null) {
            config.ConnectionStrings.ConnectionStrings["DefaultConnection"].ConnectionString = connectionString;
        } else {
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("DefaultConnection", connectionString));
        }
        config.Save(ConfigurationSaveMode.Modified);
        ConfigurationManager.RefreshSection("connectionStrings");
    }
}
}
