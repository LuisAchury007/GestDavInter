<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_Perfiles.aspx.cs" Inherits="Conf_Perfiles" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Perfiles</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td>
                            <div class="divBord">
                                <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" EmptyDataText="No Hay Registros" DataKeyNames="IdPerfil"
                                    OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting"
                                    PagerSettings-Mode="NumericFirstLast" Width="100%"
                                    OnRowCommand="GridLista_RowCommand" OnRowDataBound="GridLista_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="Perfil" HeaderText="Perfil" SortExpression="Perfil">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PaginaInicio" HeaderText="PaginaInicio" SortExpression="PaginaInicio">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Crear Empresas GE">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkCrearEmpresaGE" runat="server" Enabled="False" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <%-- <asp:TemplateField HeaderText="VerInfoFinanciera">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkVerInfoFinanciera" runat="server" Enabled="False" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Editar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente"
                                                    CommandArgument='<%# Eval("IdPerfil") %>' CommandName="Editar"
                                                    ImageUrl="~/Grafix/Editar.png" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Eliminar" CommandArgument='<%# Eval("IdPerfil") %>' ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Realmente desea eliminar el Perfil Seleccionado?')){return false;}" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" />
                                </asp:GridView>

                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <table class="style1" style="width: 600px" border="0">
                                <tr>
                                    <td class="tablaEncabezadoOp" colspan="2">Ingreso/Modificacion Perfiles</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="left">
                                        <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Perfil *</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtPerfil" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="TxtPerfil"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Pagina Inicio *</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtPagina" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="TxtPagina"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <%--  <tr>
                                                <td class="tablaItem" style="height: 28px; width: 120px;">Ver Financiera</td>
                                                <td class="tablaValor" style="height: 28px">
                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                </td>
                                            </tr>--%>
                                            <%--  <tr>
                                                <td class="tablaItem" style="height: 28px; width: 120px;">Ver Rib</td>
                                                <td class="tablaValor" style="height: 28px">
                                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="height: 28px; width: 120px;">Ver Rib ya Asignados</td>
                                                <td class="tablaValor" style="height: 28px">
                                                    <asp:CheckBox ID="CheckBox3" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="height: 28px; width: 120px;">Privilegios M. Control</td>
                                                <td class="tablaValor" style="height: 28px">
                                                    <asp:CheckBox ID="CheckBox4" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="height: 28px; width: 120px;">Privilegios Coordinador</td>
                                                <td class="tablaValor" style="height: 28px">
                                                    <asp:CheckBox ID="CheckBox5" runat="server" />
                                                </td>
                                            </tr>--%>

                                            <tr>
                                                <td class="tablaItem" style="height: 28px; width: 120px;">Crear Empresas GE</td>
                                                <td class="tablaValor" style="height: 28px">
                                                    <asp:CheckBox ID="CheckBox7" runat="server" />
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td colspan="7" class="tablaCierre">

                                                    <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                        ToolTip="Guardar" ValidationGroup="form" OnClick="ImageButton19_Click" />
                                                    &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton20" runat="server" CausesValidation="False"
                    ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cancelar" OnClick="ImageButton20_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <asp:HiddenField ID="HNuevo" runat="server" />
                    <asp:HiddenField ID="HIdPerfil" runat="server" />

                </table>
            </td>
        </tr>
    </table>
</asp:Content>

