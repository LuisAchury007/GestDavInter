<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredEmpresaModificar.aspx.cs" Inherits="CredEmpresaModificar" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <script language="JavaScript" type="text/JavaScript">
         function OnContactSelected2(source, eventArgs) {
            document.getElementById("<%= txtPaisActividad.ClientID %>").value = eventArgs.get_value();

        }

     </script>
    <link href="css/bts.css" rel="stylesheet" />

    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">

        <tr>
            <td valign="top" class="titulo01">Modificar Empresa</td>
        </tr>
        <tr>
            <td>
                <div class="container">
                    <div class="row">
                        <div>
                            <div id="accordion" class="panel-group">
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title panel-title-adjust"><a data-parent="#accordion" data-toggle="collapse" href="#collapseOne"><i class="fa fa-plus"></i>Crear empresa</a></h4>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse on  <%= macroState1 %>">
                                        <div class="panel-body" style="overflow: auto; overflow-y: auto; height: 400px">
                                            <table border="0" class="style1" style="width: 1150px">
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="6" cellspacing="6" class="areaInfo" width="100%">

                                                            <tr>
                                                                <td class="tablaItem">Tipo Identificación</td>
                                                                <td class="tablaValor">
                                                                    <asp:DropDownList ID="CmbTipoIdentificacion" CssClass="borders" runat="server" TabIndex="190" AutoPostBack="true" OnSelectedIndexChanged="CmbTipoIdentificacion_SelectedIndexChanged"></asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem">No. Documento </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtNitNew" CssClass="borders" runat="server" TabIndex="10" Width="500px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="TxtNitNew" ErrorMessage="Este campo es requerido" ValidationGroup="ValContacto"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                             <div runat="server" id="DivCons" visible="false">
                                                                <tr>
                                                                    <td class="tablaItem" style="width: 120px">Consecutivo </td>
                                                                    <td class="tablaValor">
                                                                        <asp:TextBox ID="txtConsecutivoNew" CssClass="borders" runat="server" MaxLength="15" Width="500px" autocomplete="off" Enabled="False"></asp:TextBox>
                                                                        <cc1:FilteredTextBoxExtender ID="ftetxtConsecutivoNew"
                                                                            runat="server" Enabled="True" TargetControlID="txtConsecutivoNew" FilterType="Numbers,UppercaseLetters,LowercaseLetters">
                                                                        </cc1:FilteredTextBoxExtender>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <tr>
                                                                <td class="tablaItem">Nombre de Compañía </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtrazonsocialNew" CssClass="borders" runat="server" TabIndex="30" Width="500px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtrazonsocialNew" ErrorMessage="Este campo es requerido" ValidationGroup="ValContacto"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem">Tipo Sociedad</td>
                                                                <td class="tablaValor">
                                                                    <asp:DropDownList ID="cmbTipoSociedadNew" CssClass="borders" runat="server" TabIndex="190"></asp:DropDownList></td>
                                                            </tr>
                                                             <tr>
                                                                <td class="tablaItem">Sector</td>
                                                                <td class="tablaValor">
                                                                    <asp:DropDownList ID="CmbSector" CssClass="borders" runat="server" TabIndex="190"></asp:DropDownList></td>
                                                            </tr>
                                                             <tr>
                                                                <td class="tablaItem">Paìs Actividad </td>
                                                                <td class="tablaValor">
                                                                    
                                                                    <asp:TextBox ID="txtPaisActividad" runat="server" CssClass="borders" Height="20px" placeholder="Busqueda País: " Width="200px"></asp:TextBox>
                                                                    <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="20" DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="OnContactSelected2" ServiceMethod="SearchClients2" ServicePath="" TargetControlID="txtPaisActividad"></cc1:AutoCompleteExtender>
                                                                </td>
                                                            </tr>
                                                            

                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Sigla *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtSiglaNew" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">RepresentanteLegal *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtRepresentanteNew" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                        <td class="tablaItem">Cargo
                                                        </td>
                                                        <td class="tablaValor">
                                                            <asp:TextBox ID="txtCargoNew" runat="server" CssClass="borders" Height="25px"      Width="404px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                             <tr>
                                                        <td class="tablaItem">Revisor Fiscal
                                                        </td>
                                                        <td class="tablaValor">
                                                            <asp:TextBox ID="txtrevisorfiscalNew" runat="server" CssClass="borders" Height="25px" onkeydown="return keyPress(this, event);" Width="404px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                            <tr>
                                                                <td class="tablaItem">Ciudad</td>
                                                                <td class="tablaValor">
                                                                    <asp:DropDownList ID="cmbCiudadNew" CssClass="borders" runat="server" TabIndex="190"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Direccion *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtDireccionNew" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Telefono&nbsp; *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtTelefonoNew" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="TxtTelefono" FilterType="Numbers">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">NumMatricula </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtNumMatriculaNew" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">e-mail </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtMailNew" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Website </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtWebNew" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Ciiu *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtciiuNew" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True" TargetControlID="TxtCiiu" FilterType="Numbers">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem">Fecha de fundación (aaaa/mm/dd)
                                                                </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox runat="server" ID="txtFechaNew" CssClass="borders" />
                                                                    <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click to show calendar" />
                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaNew" PopupButtonID="Image1" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFechaNew" ValidationGroup="ValContacto" ErrorMessage="Este Campo Es Requerido"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem">Objeto Social</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtobjetosocialNew" runat="server" CssClass="borders" Height="100px"  Width="404px"  TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Es Cliente</td>
                                                                <td class="tablaValor">
                                                                    <asp:CheckBox ID="chkEsClienteNew" runat="server" />
                                                                </td>
                                                            </tr>

                                                            <tr align="center">
                                                                <td class="tablaCierre" colspan="2">
                                                                    <asp:ImageButton ID="BtnGuardarEmpNueva" runat="server" ImageUrl="~/Grafix/Guardar.png" OnClick="BtnGuardarEmpNueva_Click" ToolTip="Guardar" ValidationGroup="ValContacto" />
                                                                    <asp:ImageButton ID="LimpiaEmpNueva" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                        ToolTip="Guardar" OnClick="LimpiaEmpNueva_Click" />
                                                                    <asp:HiddenField ID="HidEmpresaNueva" runat="server" />
                                                                    <asp:HiddenField ID="HidNit" runat="server" Value="0" />
                                                                      <asp:HiddenField ID="HidConsecutivo" runat="server" Value="0" />
                                                                    <asp:HiddenField ID="HidTipoID" runat="server" Value="0" />

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>


                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title panel-title-adjust"><a data-parent="#accordion" data-toggle="collapse" href="#collapseTwo"><i class="fa fa-plus"></i>Actualizar Empresa</a></h4>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse  <%= macroState2 %>">
                                        <div class="panel-body" style="overflow: auto; overflow-y: auto; height: 400px">
                                            <table border="0" class="style1" style="width: 1150px">
                                                <tr>
                                                    <td class="tbBord">
                                                        <asp:Label ID="Label1" runat="server" Text="No. Documento o Razón Social a Buscar ::"></asp:Label>
                                                        <asp:TextBox ID="txtBuscar" CssClass="borders" runat="server" Width="368px"></asp:TextBox>
                                                        <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Buscar" OnClick="Button1_Click" ValidationGroup="Busq" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="Busq" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtBuscar"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td valign="top">
                                                        <div class="divBord">
                                                            <asp:GridView ID="GridEmpresas" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="False" AllowSorting="False" DataKeyNames="NIT" OnRowCommand="GridLista_RowCommand">
                                                                <Columns>
                                                                    <asp:BoundField HeaderText="Empresa" DataField="RazonSocial" SortExpression="RazonSocial">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" SortExpression="Ciudad">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField HeaderText="Sector" DataField="Sector" SortExpression="Sector">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Editar">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Empresa" CommandArgument='<%# Eval("NIT") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="6" cellspacing="6" class="areaInfo" width="100%">
                                                             <div runat="server" id="DivEdit" visible="false">
                                                                <tr>
                                                                    <td class="tablaItem">No. Documento </td>
                                                                    <td class="tablaValor">
                                                                        <asp:TextBox ID="txtNItEit" CssClass="borders" runat="server" TabIndex="10" Width="404px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">RazonSocial *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtRazon" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido"
                                                                        ControlToValidate="TxtRazon"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Sigla *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtSigla" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">RepresentanteLegal *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtRepresentante" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem">Ciudad</td>
                                                                <td class="tablaValor">
                                                                    <asp:DropDownList ID="cmbCiudad" CssClass="borders" runat="server" TabIndex="190"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Direccion *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtDireccion" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Telefono&nbsp; *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtTelefono" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="TxtTelefono" FilterType="Numbers">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Fax *&nbsp;</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtFax" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="TxtTelefono_FilteredTextBoxExtender"
                                                                        runat="server" Enabled="True" TargetControlID="TxtFax" FilterType="Numbers">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">AA*</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtAA" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="TxtExtension_FilteredTextBoxExtender"
                                                                        runat="server" Enabled="True" TargetControlID="TxtAA" FilterType="Numbers">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">NumMatricula </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtMatricula" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">e-mail </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtMail" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Website </td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtWebSite" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Ciiu *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="TxtCiiu" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="TxtCiiu" FilterType="Numbers">
                                                                    </cc1:FilteredTextBoxExtender>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem" style="width: 120px">Es Cliente</td>
                                                                <td class="tablaValor">
                                                                    <asp:CheckBox ID="ChkEsCliente" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td colspan="7" class="tablaCierre">

                                                                    <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                        ToolTip="Guardar" ValidationGroup="form" OnClick="ImageButton19_Click" />
                                                                    :&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton20" runat="server" CausesValidation="False"
                    ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cancelar" OnClick="ImageButton20_Click" />
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>


                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>







    </table>
</asp:Content>


