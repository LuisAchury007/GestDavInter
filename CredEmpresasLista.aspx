<%@ Page Language="C#" MasterPageFile="~/Sector.master" AutoEventWireup="true" CodeFile="CredEmpresasLista.aspx.cs" Inherits="BencEmpresasLista" Title="Página sin título" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/bts.js"></script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="2" cellspacing="2" class="areaBordes" width="100%">

        <tr>
            <td>
                <div class="divBord">
                    <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                        Height="120px" OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting"
                        PagerSettings-Mode="NumericFirstLast" PageSize="50" Width="100%" DataKeyNames="Nit">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSumar" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="NIT" HeaderText="NIT" SortExpression="NIT">
                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Razon Social" SortExpression="RazonSocial">
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLink1" runat="server"
                                        Text='<%# Eval("RazonSocial") %>'
                                        NavigateUrl='<%# "~/CredEmpresa.aspx?IdSector=" + Microsoft.Security.Application.Encoder.HtmlEncode(Request.QueryString["IdSector"]) + "&NombreSec=" + Microsoft.Security.Application.Encoder.HtmlEncode(Request["NombreSec"]) + Eval("NIT", "&NIT={0}") %>'></asp:HyperLink>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" SortExpression="Ciudad">
                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" />
                    </asp:GridView>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton7_Click" />
            </td>
        </tr>




    </table>
</asp:Content>

