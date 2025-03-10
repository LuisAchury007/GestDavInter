<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="LogIngresos.aspx.cs" Inherits="LogIngresos" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Log de Ingresos Al Sistema</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td class="tbBord" colspan="3">&nbsp;
             <asp:Label ID="Label73" runat="server" Text="Usuario: "
                 Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;<asp:DropDownList ID="CmbUsuarios" CssClass="borders" runat="server" AutoPostBack="True"
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
                                <asp:GridView ID="GridLista"  CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="50"
                                    EmptyDataText="No Hay Registros" OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting">
                                    <Columns>
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" SortExpression="Fecha">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" SortExpression="Nombre">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DireccionIP" HeaderText="DireccionIP" SortExpression="DireccionIP">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Correcto" HeaderText="Correcto" SortExpression="Correcto">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                      <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
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

