<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredSectorCalcula.aspx.cs" Inherits="CredSectorCalcula" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Sector por calcular</td>
        </tr>
        <tr>
            <td>
                <div class="divBord">
                <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AutoGenerateColumns="False" EmptyDataText="No Hay Sector por  Calcular " PagerSettings-Mode="NumericFirstLast" Width="100%" OnRowCommand="GridLista_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector">
                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                              <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Calcular">
                            <ItemTemplate>
                                <asp:ImageButton ID="Calcular" runat="server" AlternateText="Calcular" CommandArgument='<%# Eval("IdSector") %>' CommandName="Calcular" ImageUrl="~/Grafix/Run.png" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings Mode="NumericFirstLast" />
                </asp:GridView>
                    </div>
            </td>
        </tr>
    </table>
</asp:Content>

