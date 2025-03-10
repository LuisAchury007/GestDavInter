<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredRecalcularIndXEmp.aspx.cs" Inherits="CredRecalcularIndXEmp" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>

    <script type="text/javascript">
        function preventMultipleSubmissions() {
      

            div1.style.backgroundColor = "#ffffff6e";
            div1.style.width = "99%";
            div1.style.height = "100%";
            div1.style.top = "0";
            div1.style.position = "fixed";
            div1.style.zIndex = "100001"
            msjLoad.style.zIndex = "1"

            msjLoad.style.visibility = "visible";
            msjLoad.style.top = "40%";
            msjLoad.style.left = "48%";
            msjLoad.style.position = "fixed";

            msjLoad.style.zIndex = "1000"

        }


        function bloqueacontrol() {
            window.onbeforeunload = preventMultipleSubmissions;
        }
    </script>
    <link href="css/bts.css" rel="stylesheet" />
    <div id="div1">
    </div>

    <div id="msjLoad" style="visibility: hidden; position: fixed;" align="center">
        <img src="Grafix/loader.gif" />
    </div>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Recalcular Indicadores por empresa</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="Label73" runat="server" Text="Nit o Razón Social a Buscar"
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp; &nbsp;
            <asp:TextBox ID="txtBuscar" CssClass="borders" runat="server" Width="368px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="form" runat="server" ErrorMessage="(*)" ControlToValidate="txtBuscar"></asp:RequiredFieldValidator>
                            <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Buscar" OnClick="Button1_Click" ValidationGroup="form" />
                            &nbsp;<asp:Label ID="lblTipoCargue" runat="server" Text="Tipo cargue"
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;
                             <asp:DropDownList ID="CmbAnioPeriodo" CssClass="borders" runat="server" TabIndex="200" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="CmbAnioPeriodo_SelectedIndexChanged">
                                 <asp:ListItem Text="--Seleccione--" Value="-1" />
                                 <asp:ListItem Text="Anual" Value="1" />
                                 <asp:ListItem Text="Parcial" Value="2" />
                             </asp:DropDownList>
                            &nbsp;<asp:Label ID="Label1" runat="server" Text="Periodo" Visible="false"
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;
                            <asp:DropDownList ID="CmbAnio" CssClass="borders" runat="server" TabIndex="200" Width="200px" Visible="false">
                            </asp:DropDownList>

                        </td>

                    </tr>
                   
                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                    <asp:GridView ID="GridEmpresas" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="False" AllowSorting="False" DataKeyNames="NIT,IdSector" OnRowCommand="GridEmpresas_RowCommand">
                                        <Columns>
                                            <asp:BoundField HeaderText="Empresa" DataField="RazonSocial" SortExpression="RazonSocial">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" SortExpression="Ciudad">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Sector" DataField="Sector" SortExpression="Sector">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Recalcular">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Recalcular" CommandArgument='<%# Eval("NIT") %>' ImageUrl="~/Grafix/recualcular.png"  OnClientClick="bloqueacontrol();" />
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


