using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class CadCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarGrid();
            }
        }
        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                CPF = LimparCPF(txtCPF.Text),
                Nome = txtNome.Text,
                RG = txtRG.Text,
                DataExpedicao = DateTime.TryParse(txtDataExpedicao.Text, out var exp) ? (DateTime?)exp : null,
                OrgaoExpedicao = txtOrgaoExpedicao.Text,
                UF_Expedicao = txtUF_Expedicao.Text,
                DataNascimento = DateTime.TryParse(txtDataNascimento.Text, out var nasc) ? (DateTime?)nasc : null,
                Sexo = CBOSexo.SelectedValue,
                EstadoCivil = CBOEstadoCivil.SelectedValue,
                CEP = txtCEP.Text,
                Logradouro = txtLogradouro.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text,
                Bairro = txtBairro.Text,
                Cidade = txtCidade.Text,
                UF = CBOUF.SelectedValue
            };
            if ("A".Equals(ViewState["TipoAcao"]?.ToString()))
            {
                var proxy = new ClienteService();
                proxy.Alterar(cliente);
                ViewState["TipoAcao"] = null; // Limpa o estado da ação após a alteração
                btnSalvar.Equals("Salvar"); // Reseta o botão para o estado de salvar
                btnCancelar.Visible = false; // esconder o botão de cancelar
                CarregarGrid();
                LimparCampos();
            }
            else
            {
                if (CPFExiste(LimparCPF(txtCPF.Text)))
                {
                    var proxy = new ClienteService();
                    proxy.Incluir(cliente);
                    CarregarGrid();
                    LimparCampos();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('CPF já cadastrado!');", true);
                }
            }
        }
        public static string LimparCPF(string cpf)
        {
            return Regex.Replace(cpf, @"[^\d]", "");
        }

        private void CarregarGrid()
        {
            var proxy = new ClienteService(); 
            gvClientes.DataSource = proxy.ListarTodos(); 
            gvClientes.DataBind();
        }
        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            string chave = e.CommandArgument.ToString();
            string comando = e.CommandName;
            if (!string.IsNullOrEmpty(chave) | chave == "0")
            {
                if (comando == "Editar")
                {
                    var proxy = new ClienteService();
                    var cliente = proxy.BuscarPorCPF(chave);
                    if (cliente != null)
                    {
                        txtCPF.Text = cliente.CPF;
                        txtNome.Text = cliente.Nome;
                        txtRG.Text = cliente.RG;
                        txtDataExpedicao.Text = cliente.DataExpedicao.ToString();
                        txtOrgaoExpedicao.Text = cliente.OrgaoExpedicao;
                        txtUF_Expedicao.Text = cliente.UF_Expedicao;
                        txtDataNascimento.Text = cliente.DataNascimento.ToString();
                        CBOSexo.SelectedValue = cliente.Sexo;
                        CBOEstadoCivil.SelectedValue = cliente.EstadoCivil;
                        txtCEP.Text = cliente.CEP;
                        txtLogradouro.Text = cliente.Logradouro;
                        txtNumero.Text = cliente.Numero;
                        txtComplemento.Text = cliente.Complemento;
                        txtBairro.Text = cliente.Bairro;
                        txtCidade.Text = cliente.Cidade;
                        CBOUF.SelectedValue = cliente.UF;
                        ViewState["TipoAcao"] = "A";
                        btnSalvar.Text = "Alterar Dados"; // Muda o texto do botão para "Alterar"
                        btnCancelar.Visible=true; // Exibe o botão de cancelar
                    }
                }
                else if (comando == "Excluir")
                {
                    string cpf = chave;

                    var proxy = new ClienteService();
                    proxy.Excluir(cpf);
                    CarregarGrid();
                }
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var proxy = new ClienteService();
            var cliente = proxy.BuscarPorCPF(txtCPF.Text);
            if (cliente != null)
            {
                txtNome.Text = cliente.Nome;
                txtCidade.Text = cliente.Cidade;
            }
        }

        private bool CPFExiste(string cpf)
        {
            bool retun = true;
            var proxy = new ClienteService(); // ou ClienteServiceClient se estiver usando WCF proxy
            var cliente = proxy.BuscarPorCPF(cpf);
            if(cliente != null)
            {
                retun = false;
            }
            return retun;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ViewState["TipoAcao"] = null;
            btnSalvar.Text = "Salvar"; 
            btnCancelar.Visible = false;
            LimparCampos();
        }

        private void LimparCampos()
        {
            foreach (Control controle in Page.Form.Controls)
            {
                LimparControle(controle);
            }
        }

        private void LimparControle(Control controle)
        {
            if (controle is TextBox)
                ((TextBox)controle).Text = string.Empty;

            else if (controle is DropDownList)
                ((DropDownList)controle).SelectedIndex = 0;

            else if (controle.HasControls())
            {
                foreach (Control filho in controle.Controls)
                {
                    LimparControle(filho);
                }
            }
        }
    }
}