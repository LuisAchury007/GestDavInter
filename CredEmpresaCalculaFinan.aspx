<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CredEmpresaCalculaFinan.aspx.cs" Inherits="CredEmpresaCalculaFinan" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Calcular Financiera</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td class="tbBord" colspan="3">
                            <asp:Label ID="Label73" runat="server" Text="Nit o Razon Social a Buscar: "
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp; &nbsp;
            <asp:TextBox ID="txtBuscar" CssClass="borders" runat="server" Width="368px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtBuscar"></asp:RequiredFieldValidator>
                            <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Buscar" OnClick="Button1_Click" ValidationGroup="form" />
                            <asp:ImageButton ID="ImageButton1" runat="server"
                                ImageUrl="~/Grafix/Proceso.png" ToolTip="Recalcular Financiera"
                                OnClick="ImageButton1_Click" />

                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                    <asp:GridView ID="GridEmpresas" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="False" AllowSorting="False" DataKeyNames="NIT,IdSector">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSumar" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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

