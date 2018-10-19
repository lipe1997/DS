using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADM_DTO;
using ADM_BLL;


namespace ADM_UI
{
    public partial class ADM_Home : Form
    {
        public ADM_Home()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cad_Func_DTO obj = new Cad_Func_DTO();
                obj.Nome = txtNome.Text.ToUpper();
                obj.Endereco = txtEndereco.Text.ToUpper();
                obj.Numero = txtNumero.Text.ToUpper();
                obj.Cpf = txtCpf.Text;
                obj.Rg = txtRg.Text;
                obj.Cidade = txtCidade.Text.ToUpper();
                obj.Bairro = txtBairro.Text.ToUpper();
                obj.Conta = txtConta.Text.ToUpper();
                obj.Agencia = txtAgencia.Text.ToUpper();
                obj.Banco = txtBanco.Text.ToUpper();
                obj.Telefone = txtTel.Text;
                string msg = Cad_Func_BLL.ValidarCad(obj);
                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                limparFunc();
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message,"ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparFunc();
        }

        private void btnCadProduto_Click(object sender, EventArgs e)
        {
            try
            {
                Cad_Produto_DTO obj = new Cad_Produto_DTO();
                obj.NomeProduto = txtNomeProduto.Text.ToUpper();
                obj.Descricao = txtDescricao.Text.ToUpper();
                obj.Categoria = cbCategoria.SelectedItem.ToString();
                obj.Qtd = txtQtd.Text;
                obj.SubCategoria = cbSubCategoria.SelectedItem.ToString();
                obj.Marca = txtMarca.Text.ToUpper();
                string msg = Cad_Produto_BLL.CadProduto(obj);
                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                limpar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Cad_Produto_DTO obj = new Cad_Produto_DTO();
                obj.NomeProduto = txtBuscNome.Text.ToUpper();
                obj.Marca = txtBuscMarca.Text.ToUpper();
                Cad_Produto_BLL.bucProduto(obj);

                txtNomeProduto.Text = obj.NomeProduto;
                txtMarca.Text = obj.Marca;
                int selectCat = 0;
                switch (obj.Categoria)
                {
                    case "Bebida":
                        selectCat = 0;
                        break;
                    case "Perecível":
                        selectCat = 1;
                        break;
                    case "Não perecível":
                        selectCat = 2;
                        break;
                        
                }
                cbCategoria.SelectedIndex = selectCat;
                int selectsubCat = 0;
                switch (obj.SubCategoria)
                {
                    case "Bebida alcoolica":
                        selectsubCat = 0;
                        break;
                    case "Bebida não alcoolica":
                        selectsubCat = 1;
                        break;
                    case "Ingrediente":
                        selectsubCat = 2;
                        break;
                    case "Carnes":
                        selectsubCat = 3;
                        break;
                    case "Aperitivo":
                        selectsubCat = 4;
                        break;
                    case "Sobremesa":
                        selectsubCat = 5;
                        break;
                    case "Tempero":
                        selectsubCat = 6;
                        break;
                    case "Pão":
                        selectsubCat = 7;
                        break;
                    case "Frutos do mar":
                        selectsubCat = 8;
                        break;

                }
                cbSubCategoria.SelectedIndex = selectsubCat;
                txtDescricao.Text = obj.Descricao;
                txtQtd.Text = obj.Qtd;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Cad_Produto_DTO obj = new Cad_Produto_DTO();
                obj.NomeProduto = txtNomeProduto.Text;
                obj.Descricao = txtDescricao.Text;
                obj.Categoria = cbCategoria.SelectedItem.ToString();
                obj.SubCategoria = cbSubCategoria.SelectedItem.ToString();
                obj.Qtd = txtQtd.Text;
                obj.Marca = txtMarca.Text;
                string nome = txtBuscNome.Text.ToUpper(), marca = txtBuscMarca.Text.ToUpper();

                string msg = Cad_Produto_BLL.AlterProduto(obj, nome, marca);

                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                limpar();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpar();
        }
        void limpar()
        {
            txtNomeProduto.Clear();
            txtDescricao.Clear();
            cbCategoria.SelectedIndex = -1;
            cbSubCategoria.SelectedIndex = -1;
            txtQtd.Clear();
            txtMarca.Clear();
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Cad_Func_DTO obj = new Cad_Func_DTO();
                string msg = txtNomeBuscFunc.Text.ToUpper();
                Cad_Func_BLL.bucFunc(obj,msg);
                txtNome.Text = obj.Nome;
                txtEndereco.Text = obj.Endereco;
                txtNumero.Text = obj.Numero ;
                txtCpf.Text = obj.Cpf;
                txtRg.Text = obj.Rg;
                txtCidade.Text = obj.Cidade;
                txtBairro.Text = obj.Bairro;
                txtConta.Text = obj.Conta;
                txtAgencia.Text = obj.Agencia;
                txtBanco.Text = obj.Banco;
                txtTel.Text = obj.Telefone;

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void limparFunc()
        {
            txtAgencia.Clear();
            txtBairro.Clear();
            txtBanco.Clear();
            txtCidade.Clear();
            txtConta.Clear();
            txtCpf.Clear();
            txtEndereco.Clear();
            txtNome.Clear();
            txtNumero.Clear();
            txtRg.Clear();
            txtTel.Clear();
        }
        private void ADM_Home_Load(object sender, EventArgs e)
        {

        }

        private void btnAlterFunc_Click(object sender, EventArgs e)
        {
            try
            {
                Cad_Func_DTO obj = new Cad_Func_DTO();
                obj.Nome = txtNome.Text.ToUpper();
                obj.Endereco = txtEndereco.Text.ToUpper();
                obj.Numero = txtNumero.Text.ToUpper();
                obj.Cpf = txtCpf.Text;
                obj.Rg = txtRg.Text;
                obj.Cidade = txtCidade.Text.ToUpper();
                obj.Bairro = txtBairro.Text.ToUpper();
                obj.Conta = txtConta.Text.ToUpper();
                obj.Agencia = txtAgencia.Text.ToUpper();
                obj.Banco = txtBanco.Text.ToUpper();
                obj.Telefone = txtTel.Text;
                string nome = txtNomeBuscFunc.Text.ToUpper();
                string msg = Cad_Func_BLL.AlterFunc(obj, nome);
                MessageBox.Show(msg, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                limparFunc();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
