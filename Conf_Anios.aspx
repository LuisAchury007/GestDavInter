<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_Anios.aspx.cs" Inherits="Conf_Anios" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <link href="App_Themes/Tema1/StyleSheet.css" rel="stylesheet" />
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Configuración de periodos</td>
        </tr>
        <tr align="center">
            <td class="tbBord">
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td>
                            <div class="divBord">
                                <asp:GridView ID="GrvPeriodos" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                    OnPageIndexChanging="GrvPeriodos_PageIndexChanging" OnSorting="GrvPeriodos_Sorting"
                                    PagerSettings-Mode="NumericFirstLast" Width="100%"
                                    OnRowCommand="GrvPeriodos_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="Anio_Mes" HeaderText="Periodo" SortExpression="Anio_Mes">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EstadoPeriodo" HeaderText="Activo" SortExpression="EstadoPeriodo">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Consultar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImaBotDetalle" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Anio_Mes") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Eliminar" CommandArgument='<%# Eval("Anio_Mes") %>' ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Realmente desea eliminar el periodo Seleccionado?')){return false;}" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
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
                                    <td valign="top" class="tablaEncabezadoOp">
                                        <asp:Label ID="Label3" runat="server" Text="Ingreso Periodo"
                                            Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="left">
                                        <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">
                                                    <asp:Label ID="Label4" runat="server" Text="Periodo *"
                                                        Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label></td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtAnio2" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="form2"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="TxtAnio2"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">
                                                    <asp:Label ID="Label5" runat="server" Text="Activo *"
                                                        Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label></td>
                                                <td class="tablaValor">
                                                    <asp:CheckBox ID="ChkOficial2" runat="server" />
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td colspan="7" class="tablaCierre">

                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Grafix/Guardar.png" ToolTip="Guardar" ValidationGroup="form2" OnClick="ImageButton21_Click" />
                                                    :&nbsp;&nbsp;&nbsp;
                                                    <asp:HiddenField ID="HidPeriodos" runat="server" />
                                                    <asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False" ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cancelar" OnClick="ImageButton22_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
