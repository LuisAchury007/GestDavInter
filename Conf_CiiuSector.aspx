<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_CiiuSector.aspx.cs" Inherits="Conf_CiiuSector" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%" bgcolor="#FFFFFF">
        <tr>
            <td valign="top" class="titulo01">Configurar Ciiu Sector</td>
        </tr>
        <tr>
            <td class="tbBord">
                <table width="100%" border="0" cellpadding="4" cellspacing="4">
                    <tr>
                        <td>
                            <asp:Label ID="Label73" runat="server" Text="Buscar:: "
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp; &nbsp;
        <asp:TextBox ID="txtBuscar" CssClass="borders" runat="server" AutoPostBack="True" Width="368px"></asp:TextBox>
                            &nbsp;<asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Buscar" OnClick="Button1_Click" ValidationGroup="form" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellpadding="4" cellspacing="4">
                    <tr>
                        <td style="margin-left: 40px">
                            <div class="divBord">
                            <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting"
                                PagerSettings-Mode="NumericFirstLast" Width="100%"
                                OnRowCommand="GridLista_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="Ciiu" HeaderText="Ciiu" SortExpression="Ciiu">
                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Descripcion" SortExpression="Nombre">
                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IdSector" HeaderText="IdSector" SortExpression="IdSector">
                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector">
                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Eliminar">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Eliminar" CommandArgument='<%# Eval("Ciiu") + "#" + Eval("IdSector") %>' ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Realmente desea eliminar Ciiu Sector?')){return false;}" />
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
                                    <td valign="top" class="tablaEncabezadoOp">Ingreso Ciiu Sector</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%" align="left">
                                        <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Ciiu *</td>
                                                <td class="tablaValor">
                                                    <asp:DropDownList ID="CmbCiiu" CssClass="borders" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Sector *</td>
                                                <td class="tablaValor">
                                                    <asp:DropDownList ID="cmbSectores" CssClass="borders" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td colspan="7" class="tablaCierre">

                                                    <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                        ToolTip="Guardar" OnClick="ImageButton19_Click" />
                                                    :&nbsp;&nbsp;&nbsp;
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
