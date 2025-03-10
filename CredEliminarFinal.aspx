<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredEliminarFinal.aspx.cs" Inherits="CredEliminarFinal" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" Theme="Tema1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Eliminar Finales</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td class="tbBord" colspan="3"> <asp:Label ID="Label73" runat="server" Text="Nit o Razon Social a Buscar: "
 Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
        &nbsp; &nbsp;
        <asp:TextBox ID="txtBuscar" CssClass="borders" runat="server" Width="368px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtBuscar"></asp:RequiredFieldValidator>
                            <asp:Button ID="Button1" runat="server" CssClass="botonDes" Text="Buscar" OnClick="Button1_Click" ValidationGroup="form" />
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                    <asp:GridView ID="GridEmpresas" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="False" AllowSorting="False" DataKeyNames="NIT,Anio" OnRowCommand="GridLista_RowCommand">
                                        <Columns>
                                            <asp:BoundField HeaderText="NIT" DataField="NIT" SortExpression="NIT">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Empresa" DataField="RazonSocial" SortExpression="RazonSocial">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Sector" DataField="Sector" SortExpression="Sector">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Ciiu" DataField="Ciiu" SortExpression="Ciiu">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Anio" DataField="Anio" SortExpression="Anio">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Eliminar">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="Editar" runat="server" CausesValidation="False" CommandName="Eliminar" AlternateText="Eliminar Parcial" CommandArgument='<%# Eval("NIT") + "#"  +   Eval("Anio") %>' ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Desea Eliminar Parcial Seleccionado?')){return false;}" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
