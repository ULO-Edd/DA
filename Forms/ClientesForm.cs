using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_DA_BooKids.Forms
{
    public partial class ClientesForm : Form
    {
        public ClientesForm()
        {
            InitializeComponent();
        }

        public bool VerifyIDPessoa(string idPessoa)
        {
            SqlConnection conn = null;
            bool returning = false;
            try
            {
                // Configurar ligação à Base de Dados
                conn = new SqlConnection();
                conn.ConnectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Eduardo-PC\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\BooKids_DB.mdf'");
                //conn.ConnectionString = Properties.Settings.Default.connectionString;

                // Abrir ligação à Base de Dados
                conn.Open();

                // Declaração do comando SQL
                String sql = "SELECT * FROM PessoaSet WHERE idPessoa = @idPessoa";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;

                // Declaração dos parâmetros do comando SQL
                SqlParameter param = new SqlParameter("@idPessoa", idPessoa);

                // Introduzir valor ao parâmentro registado no comando SQL
                cmd.Parameters.Add(param);

                // Associar ligação à Base de Dados ao comando a ser executado
                cmd.Connection = conn;

                // Executar comando SQL
                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                } 
                else
                {
                     returning = true;
                }

                return returning;
            }
            catch
            {
                MessageBox.Show("Ocorreu um Erro", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return returning;
            }
        }



        private void pessoaSet_ClienteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.idPessoaTextBox.TextLength == 0 || this.nrCartaoTextBox.TextLength == 0 || this.valorOfertaTextBox.TextLength == 0)
                {
                    MessageBox.Show("Campos por Preencher !!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (this.nrCartaoTextBox.TextLength < 4)
                {
                    MessageBox.Show("Campo NrCartao tem que possuir 4 carateres", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else if (VerifyIDPessoa(idPessoaTextBox.Text) == false)
                {
                    MessageBox.Show("Erro ao aceder a uma Pessoa (Verifique o IdPessoa introduzido)", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Validate();
                    this.pessoaSet_ClienteBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.booKids_DBDataSet);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao salvar", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'booKids_DBDataSet.PessoaSet_Cliente' table. You can move, or remove it, as needed.
            this.pessoaSet_ClienteTableAdapter.Fill(this.booKids_DBDataSet.PessoaSet_Cliente);

        }

        private void BTN_InserirFilho_Click(object sender, EventArgs e)
        {
            FilhosForm filhos = new FilhosForm();
            filhos.Show();
        }
    }
}
