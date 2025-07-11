<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadCliente.aspx.cs" Inherits="WebForm.CadCliente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <script>
        $(document).ready(function () {
            $('#btnSalvar').click(function (e) {
                var dataNasc = $('#txtDataNascimento').val();
                var dataExpedicao = $('#txtDataExpedicao').val();
                var nome = $('#txtNome').val();
                var cpf = $('#txtCPF').val();

                var sexo = $('#CBOSexo').val();
                var EstadoCivil = $('#CBOEstadoCivil').val();


                var cep = $('#txtCEP').val();
                var log = $('#txtLogradouro').val();
                var nume = $('#txtNumero').val();
                var Bairro = $('#txtBairro').val();

                var cidade = $('#txtCidade').val();
                var UF = $('#CBOUF').val();

                // Verifica se está preenchido
                if (!cpf) {
                    alert("Preencha o CPF.");
                    e.preventDefault();
                    return false;
                }
                if (!nome) {
                    alert("Informe o nome.");
                    e.preventDefault();
                    return false;
                }
                if (!dataNasc) {
                    alert("Preencha a data de nascimento.");
                    e.preventDefault();
                    return false;
                }
                if (!dataExpedicao) {
                    alert("Preencha a data Expedidor.");
                    e.preventDefault();
                    return false;
                }

                if (!CBOSexo) {
                    alert("Preencha a data Expedidor.");
                    e.preventDefault();
                    return false;
                }
                if (!CBOEstadoCivil) {
                    alert("Preencha a data Expedidor.");
                    e.preventDefault();
                    return false;
                }

                //endereço
                if (!cep) {
                    alert("Preencha o CEP.");
                    e.preventDefault();
                    return false;
                }
                if (!log) {
                    alert("Preencha o logradouro.");
                    e.preventDefault();
                    return false;
                }
                if (!nume) {
                    alert("Preencha o número.");
                    e.preventDefault();
                    return false;
                }
                if (!Bairro) {
                    alert("Preencha o bairro.");
                    e.preventDefault();
                    return false;
                }
                if (!cidade) {
                    alert("Preencha a cidade.");
                    e.preventDefault();
                    return false;
                }
                if (!UF) {
                    alert("Preencha a UF.");
                    e.preventDefault();
                    return false;
                }
               

                // Converte para objeto Date
                var partes = dataNasc.split('/');
                if (partes.length !== 3) {
                    alert("Formato inválido. Use dd/mm/yyyy.");
                    e.preventDefault();
                    return false;
                }

                var dataInformada = new Date(partes[2], partes[1] - 1, partes[0]); // yyyy, mm-1, dd
                var hoje = new Date();

                if (dataInformada >= hoje) {
                    alert("A data de nascimento deve ser anterior à data atual.");
                    e.preventDefault();
                    return false;
                }

                // Se passou na validação
                return true;
            });
        });
</script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server" />

        <div class="container">
            <div class="card">
                <div class="card-header">
                    <h5>Cadastro de Cliente</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <label for="txtCPF" class="form-label">CPF</label>
                            <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control" BorderColor="Red" MaxLength="14" />
                            <ajaxToolkit:MaskedEditExtender ID="maskCPF" runat="server"
                                TargetControlID="txtCPF"
                                Mask="999.999.999-99"
                                MaskType="None"
                                PromptCharacter="_" />

                        </div>
                        <div class="col-md-3">
                            <label for="txtNome" class="form-label">Nome</label>
                            <asp:TextBox ID="txtNome" runat="server"  CssClass="form-control" MaxLength="100" BorderColor="Red"/>

                        </div>
                        <div class="col-md-2">
                            <label for="txtDataNascimento" class="form-label">Data de Nascimento</label>
                            <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control" BorderColor="Red" />

                        </div>
                        <div class="col-md-2">
                            <label for="txtRG" class="form-label">RG</label>
                            <asp:TextBox ID="txtRG" runat="server" CssClass="form-control" />
                        </div>
                        <div class="col-md-2">
                            <label for="CBOSexo" class="form-label">Sexo</label>
                            <asp:DropDownList ID="CBOSexo" runat="server" CssClass="form-select" BorderColor="Red">
                                <asp:ListItem Value="M">Masculino</asp:ListItem>
                                <asp:ListItem Value="F">Feminino</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="row">


                        <div class="col-md-2">
                            <label for="txtDataExpedicao" class="form-label">Data Expedidor</label>
                            <asp:TextBox ID="txtDataExpedicao" CssClass="form-control" BorderColor="Red" TextMode="Date" runat="server" Placeholder="Data Expedidor" />
                        </div>

                        <div class="col-md-2">
                            <label for="txtOrgaoExpedicao" class="form-label">Órgão Expedidor</label>
                            <asp:TextBox ID="txtOrgaoExpedicao" CssClass="form-control"  runat="server" Placeholder="Órgão Expedidor" />
                        </div>

                        <div class="col-md-2">
                            <label for="txtUF_Expedicao" class="form-label">UF Expedição</label>
                            <asp:TextBox ID="txtUF_Expedicao" CssClass="form-control" runat="server" Placeholder="UF Expedição" />
                        </div>

                        <div class="col-md-2">
                            <label for="CBOEstadoCivil" class="form-label">Estado Civil</label>
                            <asp:DropDownList ID="CBOEstadoCivil" runat="server" CssClass="form-select" BorderColor="Red">
                                <asp:ListItem Value="C">Casado</asp:ListItem>
                                <asp:ListItem Value="S">Solteiro</asp:ListItem>
                                <asp:ListItem Value="V">Viuvo</asp:ListItem>
                            </asp:DropDownList>

                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-3">
                            <label for="txtCEP" class="form-label">CEP</label>
                            <asp:TextBox ID="txtCEP" CssClass="form-control" MaxLength="9" runat="server" Placeholder="CEP" BorderColor="Red"/>
                        </div>

                        <div class="col-md-4">
                            <label for="txtLogradouro" class="form-label">Logradouro</label>
                            <asp:TextBox ID="txtLogradouro" CssClass="form-control" runat="server" Placeholder="Logradouro" MaxLength="100" BorderColor="Red"/>
                        </div>

                        <div class="col-md-1">
                            <label for="txtNumero" class="form-label">Número</label>
                            <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server" Placeholder="Número" MaxLength="5" BorderColor="Red"/>
                        </div>

                        <div class="col-md-4">
                            <label for="txtComplemento" class="form-label">Complemento</label>
                            <asp:TextBox ID="txtComplemento" CssClass="form-control" runat="server" Placeholder="Complemento" MaxLength="100"/>
                        </div>

                        <div class="col-md-2">
                            <label for="txtBairro" class="form-label">Bairro</label>
                            <asp:TextBox ID="txtBairro" CssClass="form-control" runat="server" Placeholder="Bairro" MaxLength="30" BorderColor="Red"/>
                        </div>
                        <div class="col-md-2">
                            <label for="txtCidade" class="form-label">Cidade</label>
                            <asp:TextBox ID="txtCidade" CssClass="form-control" runat="server" Placeholder="Cidade" MaxLength="30" BorderColor="Red"/>
                        </div>
                        <div class="col-md-3">
                            <label for="CBOUF" class="form-label">UF</label>
                            <asp:DropDownList ID="CBOUF" runat="server" CssClass="form-select" BorderColor="Red">
                                <asp:ListItem Text="Selecione..." Value="" />
                                <asp:ListItem Text="AC - Acre" Value="AC" />
                                <asp:ListItem Text="AL - Alagoas" Value="AL" />
                                <asp:ListItem Text="AP - Amapá" Value="AP" />
                                <asp:ListItem Text="AM - Amazonas" Value="AM" />
                                <asp:ListItem Text="BA - Bahia" Value="BA" />
                                <asp:ListItem Text="CE - Ceará" Value="CE" />
                                <asp:ListItem Text="DF - Distrito Federal" Value="DF" />
                                <asp:ListItem Text="ES - Espírito Santo" Value="ES" />
                                <asp:ListItem Text="GO - Goiás" Value="GO" />
                                <asp:ListItem Text="MA - Maranhão" Value="MA" />
                                <asp:ListItem Text="MT - Mato Grosso" Value="MT" />
                                <asp:ListItem Text="MS - Mato Grosso do Sul" Value="MS" />
                                <asp:ListItem Text="MG - Minas Gerais" Value="MG" />
                                <asp:ListItem Text="PA - Pará" Value="PA" />
                                <asp:ListItem Text="PB - Paraíba" Value="PB" />
                                <asp:ListItem Text="PR - Paraná" Value="PR" />
                                <asp:ListItem Text="PE - Pernambuco" Value="PE" />
                                <asp:ListItem Text="PI - Piauí" Value="PI" />
                                <asp:ListItem Text="RJ - Rio de Janeiro" Value="RJ" />
                                <asp:ListItem Text="RN - Rio Grande do Norte" Value="RN" />
                                <asp:ListItem Text="RS - Rio Grande do Sul" Value="RS" />
                                <asp:ListItem Text="RO - Rondônia" Value="RO" />
                                <asp:ListItem Text="RR - Roraima" Value="RR" />
                                <asp:ListItem Text="SC - Santa Catarina" Value="SC" />
                                <asp:ListItem Text="SP - São Paulo" Value="SP" />
                                <asp:ListItem Text="SE - Sergipe" Value="SE" />
                                <asp:ListItem Text="TO - Tocantins" Value="TO" />
                            </asp:DropDownList>
                        </div>

                    </div>

                    <div class="row">
                        <div class="col-md-12 text-end">
                            <asp:Button ID="btnSalvar" Text="Salvar" runat="server" CssClass="btn btn-success me-2" OnClick="btnSalvar_Click" />
                            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" CssClass="btn btn-primary me-2" OnClick="btnBuscar_Click" />
                            <asp:Button ID="btnCancelar" Visible="false" Text="Cancelar Alterar" runat="server" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                        </div>
                    </div>

                    <div class="row">
                        <br />
                    </div>
                    <div class="row">
                        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered"
                            CellPadding="0" GridLines="None" RowHeaderColumn="1" Width="100%" OnRowCommand="gvClientes_RowCommand">

                            <Columns>
                                <asp:TemplateField>
                                    <ItemStyle Width="90px" />
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="fas fa-edit" Style="font-size: 20px" ID="linkEditar" CommandName="Editar" CommandArgument='<%# Eval("CPF")%>' runat="server"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle Width="90px" />
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="fas fa-trash-alt" Style="font-size: 20px" ID="linkExcluir" CommandName="Excluir" CommandArgument='<%# Eval("CPF")%>' runat="server" ToolTip="Excluir cliente" />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:BoundField DataField="CPF" HeaderText="CPF" ReadOnly="True" />
                                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                                <asp:BoundField DataField="Cidade" HeaderText="Cidade" />

                            </Columns>
                        </asp:GridView>
                    </div>


                </div>
            </div>
        </div>






    </form>
</body>
</html>
