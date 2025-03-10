<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Inf_PerfilMenu.aspx.cs" Inherits="Inf_PerfilMenu" StylesheetTheme="Tema1" Theme="Tema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Reporte Perfil Opción</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td class="tbBord" colspan="3">&nbsp;
              <asp:Label ID="Label1" runat="server" Text="Perfil: "
                  Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;<asp:DropDownList ID="CmbPerfil" CssClass="borders" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="CmbUsuarios_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp; &nbsp;
            &nbsp; &nbsp; 
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                    <asp:GridView ID="GridLista" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="50"
                                        EmptyDataText="No Hay Registros" OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting">
                                        <Columns>
                                            <asp:BoundField HeaderText="Menu" DataField="Menu" SortExpression="Menu">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Submenu" DataField="Submenu" SortExpression="Submenu">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Pagina" HeaderText="Pagina" SortExpression="Pagina">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Orden1" HeaderText="Orden1" SortExpression="Orden1">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Orden2" HeaderText="Orden2" SortExpression="Orden2">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Grafix/Excel.png"
                                OnClick="ImageButton1_Click" />
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</asp:Content>

