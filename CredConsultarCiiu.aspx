<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredConsultarCiiu.aspx.cs" Inherits="CredConsultarCiiu" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Consultar Ciiu</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td class="tbBord" colspan="3">
                            <asp:Label ID="Label73" runat="server" Text=" Ciiu a Buscar: "
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp; &nbsp;
            <asp:TextBox ID="txtBuscar" CssClass="borders" runat="server" AutoPostBack="True" Width="368px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtBuscar"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtBuscar" FilterType="Numbers"></cc1:FilteredTextBoxExtender>
                            &nbsp;<asp:Button ID="Button1" runat="server" CssClass="botonDes" Text="Buscar" OnClick="Button1_Click" ValidationGroup="form" />
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                    <asp:GridView ID="GridLista" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="True" AllowSorting="True" PageSize="50"
                                        EmptyDataText="No Hay Registros">
                                        <Columns>
                                            <asp:BoundField HeaderText="Ciiu" DataField="Ciiu" SortExpression="Ciiu">
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

