using MySql.Data.MySqlClient;

namespace GravarDadosMySql
{
    public partial class Form1 : Form
    {

        private MySqlConnection Connection;

        private string data_source = "datasource=localhost;username=root;password=System256715;database=db_agenda";
        private int? id_contato_selecionado = null;

        public Form1()
        {
            InitializeComponent();

            lst_Contatos.View = View.Details;
            lst_Contatos.LabelEdit = true;
            lst_Contatos.AllowColumnReorder = true;
            lst_Contatos.FullRowSelect = true;
            lst_Contatos.GridLines = true;

            lst_Contatos.Columns.Add("ID", 30, HorizontalAlignment.Left);
            lst_Contatos.Columns.Add("NOME", 150, HorizontalAlignment.Left);
            lst_Contatos.Columns.Add("E-MAIL", 150, HorizontalAlignment.Left);
            lst_Contatos.Columns.Add("TELEFONE", 150, HorizontalAlignment.Left);

            carregar_contatos();
            LimparCampos();
        }

        // SALVAR E ATUALIZAR CONTATO
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connection = new MySqlConnection(data_source);

                Connection.Open();

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = Connection;

                if (id_contato_selecionado == null)
                {
                    //Salvar contato
                    cmd.CommandText = "INSERT INTO contato(nome, email, telefone) VALUES (@nome, @email, @telefone)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Deu tudo certo, Inserido", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carregar_contatos();

                    LimparCampos();
                }
                else
                {
                    //Atualizar contato
                    cmd.CommandText = "UPDATE contato SET nome=@nome, email=@email, telefone=@telefone WHERE id = @id";

                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@telefone", TxtTelefone.Text);
                    cmd.Parameters.AddWithValue("@id", id_contato_selecionado);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Deu tudo certo, contato atualizado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    carregar_contatos();

                    LimparCampos();
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Number + " ocorreu: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }
        }

        // bUSCAR POR NOME OU EMAIL
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Criando conexão com MySQL
                Connection = new MySqlConnection(data_source);
                Connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Connection;

                //Executando o select
                cmd.CommandText = "SELECT * FROM contato WHERE nome LIKE @q OR email LIKE @q";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@q", "%" + txt_BuscarContato.Text + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                //Limpa a lista de contatos
                lst_Contatos.Items.Clear();

                //Listar contato na tela
                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    };
                    lst_Contatos.Items.Add(new ListViewItem(row));
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Number + " ocorreu: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }
        }

        // CARREGA LISTA DE CONTATOS
        private void carregar_contatos()
        {
            try
            {
                Connection = new MySqlConnection(data_source);
                Connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = Connection;

                cmd.CommandText = "SELECT * FROM contato ORDER BY nome DESC";

                MySqlDataReader reader = cmd.ExecuteReader();

                //Limpa a lista de contatos
                lst_Contatos.Items.Clear();

                //Listar contato na tela
                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
                    };
                    lst_Contatos.Items.Add(new ListViewItem(row));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Number + " ocorreu: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }
        }

        // LISTA CONTATO POR ID PARA EDIÇÃO
        private void lst_Contatos_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView.SelectedListViewItemCollection itens_selecionado = lst_Contatos.SelectedItems;

            foreach (ListViewItem item in itens_selecionado)
            {
                id_contato_selecionado = Convert.ToInt32(item.SubItems[0].Text);
                txtNome.Text = item.SubItems[1].Text;
                txtEmail.Text = item.SubItems[2].Text;
                TxtTelefone.Text = item.SubItems[3].Text;
            }

            btn_excluir.Visible = true;
        }

        // BUTTON LIMPA OS CAMPOS
        private void btn_limpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // LIMPAR CAMPOS
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtEmail.Text = "";
            TxtTelefone.Text = "";
            id_contato_selecionado = null;

            txtNome.Focus();

            btn_excluir.Visible = false;
        }

        // EXCLUIR CONTATO COM O BOTÃO DIREITO DO MAUSE
        private void CMS_excluir_contato_Click(object sender, EventArgs e)
        {
            ExcluirContato();
        }

        // BUTTON EXCLUIR CONTATO
        private void btn_excluir_Click(object sender, EventArgs e)
        {
            ExcluirContato();
        }

        // EXCLUIR CONTATO
        private void ExcluirContato()
        {
            try
            {
                var resposta = MessageBox.Show("Tem certeza que deseja excluir o registro?", "Exceluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resposta == DialogResult.Yes)
                {

                    Connection = new MySqlConnection(data_source);
                    Connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = Connection;

                    cmd.CommandText = "DELETE FROM contato WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id_contato_selecionado);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Contato excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                carregar_contatos();
                LimparCampos();
                btn_excluir.Visible = false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Number + " ocorreu: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}