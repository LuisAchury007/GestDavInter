<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Conf_EmpresaXGrupoEm.aspx.cs" Inherits="Conf_EmpresaXGrupoEm" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.:: Empresas del grupo Económico ::.</title>
    <script language="JavaScript" type="text/JavaScript">

        function Actualizaframes(IdSector, NIT) {

            var modal = $find('ModalPopupExtender2');
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "GCredEmpresa.aspx?IdSector=" + IdSector + "&NIT=" + NIT;
            modal.show();

        }

        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Esta empresa puede pertenecer a otro grupo económico, ¿quiere asignarla a este grupo de todos modos?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }

    </script>
    <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/bts.js"></script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
</head>
<body>
    <script language="JavaScript" type="text/JavaScript">
        function OnContactSelected2(source, eventArgs) {
            document.getElementById("<%= txtPaisActividad.ClientID %>").value = eventArgs.get_value();

        }
    </script>
    <form id="form1" runat="server" method="post">
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajaxToolkit:ToolkitScriptManager>
        <div>
            <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                <tr>
                    <td valign="top" class="titulo01">Empresas del grupo económico</td>
                </tr>
                <tr align="center">
                    <td valign="top">
                        <asp:Panel ID="Panel2" runat="server">
                            <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
                                <tr align="center">
                                    <td>
                                        <table style="width: 900px" border="0">
                                            <tr>
                                                <td>


                                                    <asp:Button ID="Button17" runat="server" Text="Button" CssClass="invisible" />
                                                    <br />
                                                    <br />
                                                    <div class="divBord">
                                                        <asp:GridView ID="grvEmpXGrupoEmp" CssClass="Grid" runat="server" AllowSorting="True" AllowPaging="False" AutoGenerateColumns="False"
                                                            EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdGrupoEm" OnRowDataBound="grvEmpXGrupoEmp_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="GrupoEmpresarial" HeaderText="Grupo Económico" SortExpression="GrupoEmpresarial">
                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>

                                                                        <asp:GridView ID="grvEmpresas" CssClass="Grid" runat="server" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="NIT" OnPageIndexChanging="grvEmpresas_PageIndexChanging" OnSorting="grvEmpresas_Sorting" OnRowDeleting="grvEmpresas_RowDeleting">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Identificacion" HeaderText="Tipo identificación" SortExpression="Identificacion">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="NIT" HeaderText="No. Documento" SortExpression="NIT">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="NitConDigito" HeaderText="Nit con dígito" SortExpression="NitConDigito">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="RazonSocial" HeaderText="Nombre" SortExpression="RazonSocial">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="CodPais" HeaderText="País" SortExpression="CodPais">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="Segmento" HeaderText="Segmento" SortExpression="Segmento">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>


                                                                                <asp:CommandField ShowDeleteButton="True" DeleteText="Desasociar" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                         <asp:Label ID="Label11" runat="server" Text=""></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                    <asp:LinkButton ID="LinkBtnContacto" runat="server" OnClick="LinkBtnContacto_Click">Agregar nueva Empresa</asp:LinkButton>
                                                    <br />
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="LblComentarioEliminacion" runat="server" Text="Comentario de desasociación" Visible="False" Font-Bold="True"></asp:Label>
                                                    <br />
                                                    <asp:TextBox ID="txtAntecedentes" runat="server" Height="60px" CssClass="borders" TextMode="MultiLine" Width="900px" Visible="False"></asp:TextBox>

                                                </td>
                                            </tr>

                                        </table>
                                        <table>
                                            <tr align="center">
                                                <td class="tbBord">
                                                    <table class="style1" style="width: 900px" border="0">
                                                        <tr>
                                                            <td class="tablaItem">&nbsp; No. Documento o Nombre de la empresa</td>
                                                            <td>
                                                                <asp:TextBox ID="txtBuscarEmpresa" runat="server" CssClass="borders"
                                                                    Width="250px"></asp:TextBox>
                                                                <asp:Button ID="btnBuscarEmp" runat="server" Text="Buscar" CssClass="botonDes" OnClick="btnBuscarEmp_Click" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">&nbsp;</td>
                                                            <td>
                                                                <div class="divBord">
                                                                    <asp:GridView ID="GridEmpresas" CssClass="Grid" runat="server" Width="80%" AllowSorting="True" AllowPaging="True" PageSize="5"
                                                                        AutoGenerateColumns="False" DataKeyNames="NIT" OnPageIndexChanging="GridEmpresas_PageIndexChanging" OnSorting="GridEmpresas_Sorting">
                                                                        <Columns>
                                                                            <asp:TemplateField SortExpression="RazonSocial">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkSeleccion" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="Nombre" DataField="RazonSocial" SortExpression="RazonSocial">
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
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Razón por la cual componen o no grupo</td>
                                                            <td class="tablaValor" style="height: 28px">
                                                                <asp:DropDownList ID="CmbRazonesComponen" CssClass="borders" runat="server" TabIndex="200" Width="250px"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Comentarios adicionales que sustenten la novedad</td>
                                                            <td class="tablaValor" style="height: 28px">
                                                                <asp:TextBox ID="txtComentarioSolicitud" CssClass="borders" runat="server" Height="60px" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:ImageButton ID="ImgGuardarPeriodo" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                    ToolTip="Asociar" ValidationGroup="ValRespuesta" OnClick="ImgGuardarPeriodo_Click" OnClientClick="Confirm()" />
                                                                <asp:ImageButton ID="ImgLimpiarPeriodo" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                    ToolTip="Guardar" OnClick="ImgLimpiarPeriodo_Click" />

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="pnlCrearEmp" runat="server" Visible="False">
                                            <table border="0" cellpadding="6" cellspacing="6" class="areaInfo" width="100%">
                                                <tr>
                                                    <td class="tablaEncabezadoOp" colspan="2">Crear/modificar empresa</td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Tipo Identificación</td>
                                                    <td class="tablaValor">
                                                        <asp:DropDownList ID="CmbTipoIdentificacion" CssClass="borders" runat="server" TabIndex="190" AutoPostBack="true" OnSelectedIndexChanged="CmbTipoIdentificacion_SelectedIndexChanged"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">No. Documento </td>
                                                    <td class="tablaValor">
                                                        <asp:TextBox ID="TxtNit" runat="server" CssClass="borders" TabIndex="10" Width="500px"></asp:TextBox>

                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator99" runat="server" ControlToValidate="TxtNit" ErrorMessage="Este campo es requerido" ValidationGroup="ValContacto"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <div runat="server" id="DivCons" visible="false">
                                                    <tr>
                                                        <td class="tablaItem" style="width: 120px">Consecutivo </td>
                                                        <td class="tablaValor">
                                                            <asp:TextBox ID="txtConsecutivoNew" CssClass="borders" runat="server" MaxLength="15" Width="500px" autocomplete="off" Enabled="False"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="ftetxtConsecutivoNew"
                                                                runat="server" Enabled="True" TargetControlID="txtConsecutivoNew" FilterType="Numbers,UppercaseLetters,LowercaseLetters">
                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                        </td>
                                                    </tr>
                                                </div>
                                                <tr>
                                                    <td class="tablaItem">No. Documento con dígito de verificación </td>
                                                    <td class="tablaValor">
                                                        <asp:TextBox ID="TxtNitConDigito" CssClass="borders" runat="server" TabIndex="10" Width="500px" Visible="true"></asp:TextBox>
                                                        <asp:TextBox ID="TxtNitDigitoNew" CssClass="borders" runat="server" TabIndex="10" Width="500px" MaxLength="9" Visible="false" AutoPostBack="true" OnTextChanged="TxtNitDigitoNew_TextChanged"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="fteNitDigitoNew" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="TxtNitDigitoNew"></ajaxToolkit:FilteredTextBoxExtender>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Nombre de Compañía </td>
                                                    <td class="tablaValor">
                                                        <asp:TextBox ID="txtrazonsocial" CssClass="borders" runat="server" TabIndex="30" Width="500px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtrazonsocial" ErrorMessage="Este campo es requerido" ValidationGroup="ValContacto"></asp:RequiredFieldValidator></td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Tipo Sociedad</td>
                                                    <td class="tablaValor">
                                                        <asp:DropDownList ID="cmbTipoSociedad" CssClass="borders" runat="server" TabIndex="190"></asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Sector</td>
                                                    <td class="tablaValor">
                                                        <asp:DropDownList ID="CmbSector" CssClass="borders" runat="server" TabIndex="190"></asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">País Filial</td>
                                                    <td class="tablaValor">
                                                        <asp:DropDownList ID="CmbPaisFilial" CssClass="borders" runat="server" TabIndex="190"></asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Paìs Actividad </td>
                                                    <td class="tablaValor">

                                                        <asp:TextBox ID="txtPaisActividad" runat="server" CssClass="borders" Height="20px" placeholder="Busqueda País: " Width="200px"></asp:TextBox>
                                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="20" DelimiterCharacters="" EnableCaching="False" Enabled="True" MinimumPrefixLength="1" OnClientItemSelected="OnContactSelected2" ServiceMethod="SearchClients2" ServicePath="" TargetControlID="txtPaisActividad"></ajaxToolkit:AutoCompleteExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Banca </td>
                                                    <td class="tablaValor">
                                                        <asp:DropDownList ID="cmbBanca" CssClass="borders" runat="server" TabIndex="190"></asp:DropDownList></td>
                                                </tr>
                                                <tr align="center">
                                                    <td class="tablaCierre" colspan="2">
                                                        <asp:ImageButton ID="BtnGuardarEmpNueva" runat="server" ImageUrl="~/Grafix/Guardar.png" OnClick="BtnGuardarEmpNueva_Click" ToolTip="Guardar" ValidationGroup="ValContacto" />
                                                        <asp:ImageButton ID="LimpiaEmpNueva" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                            ToolTip="Guardar" OnClick="LimpiaEmpNueva_Click" />
                                                        <asp:HiddenField ID="HidEmpresaNueva" runat="server" />

                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>

                    </td>

                </tr>
            </table>
        </div>
    </form>


</body>

</html>
