using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ADO_NetProject01
{
    public partial class Form1 : Form
    {
        string connectionStrings = ConfigurationManager.ConnectionStrings["CS_ADO_NET"].ConnectionString;
        public Form1()
        {
           
            InitializeComponent();
            GetAllFornecedores();
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionStrings);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into dbo.fornecedores(nome, cnpj) values (@nome, @cnpj)";
            command.Parameters.AddWithValue("@nome", txtNome.Text);
            command.Parameters.AddWithValue("@cnpj", txtCNPJ.Text);
            command.ExecuteNonQuery(); //abre o banco
            connection.Close(); //fecha o banco

            MessageBox.Show("Fornecedores registrados com sucesso.");
            GetAllFornecedores();
            ClearControls();
        }

        private void GetAllFornecedores()
        {
            var connection = new SqlConnection(connectionStrings);

            var adapter = new SqlDataAdapter("select id, cnpj, nome from fornecedores", connectionStrings);
            var builder = new SqlCommandBuilder(adapter);

            var table = new DataTable();
            adapter.Fill(table);
            
            
            dgvFornecedores.DataSource = table;
            connection.Close();
        }

        private void ClearControls()
        {
            txtId.Text = string.Empty;
            txtCNPJ.Clear();
            txtNome.Text = string.Empty;
        }
    }
}
