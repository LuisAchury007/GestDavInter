<%@ Page Language="C#" MasterPageFile="~/Sector.master" AutoEventWireup="true" CodeFile="CredSectorRanking.aspx.cs" Inherits="BencSectorRanking" Title=".:: Ranking Sector ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="2" class="areaBordes">
        <tr>
            <td class="areaInfo">
                <asp:DropDownList ID="CmbIndicadores" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="CmbIndicadores_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png"
                    OnClick="ImageButton7_Click" />

            </td>
        </tr>
        <tr>
            <td class="areaInfo">
                <asp:GridView ID="GridLista" runat="server" AllowPaging="True" AllowSorting="True"
                    AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                    Height="120px" OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting"
                    PagerSettings-Mode="NumericFirstLast" PageSize="50" Width="100%" DataKeyNames="Nit">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSumar" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NIT" HeaderText="Nit" />
                        <asp:TemplateField HeaderText="Razon Social" SortExpression="RazonSocial">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server"
                                    Text='<%# Eval("RazonSocial") %>'
                                    NavigateUrl='<%# "~/CredEmpresa.aspx?IdSector=" + Microsoft.Security.Application.Encoder.HtmlEncode(Request.QueryString["IdSector"]) + "&NombreSec=" + Microsoft.Security.Application.Encoder.HtmlEncode(Request["NombreSec"]) + Eval("NIT", "&NIT={0}") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" />
                </asp:GridView>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </td>
        </tr>






    </table>
</asp:Content>

