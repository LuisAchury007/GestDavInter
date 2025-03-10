<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CredGenerarArchivos.aspx.cs" Inherits="CredGenerarArchivos" Theme="Tema1" StylesheetTheme="Tema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <div>
        <table bgcolor="#ffffff" border="0" cellpadding="4" cellspacing="4" width="100%" class="areaBordes">
            <tr>
                <td class="titulo01" valign="top">Generar Archivos</td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label73" runat="server" Text="Reporte: "
                        Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                    &nbsp;<asp:DropDownList ID="cmbReportes" CssClass="borders" runat="server"
                        OnSelectedIndexChanged="cmbReportes_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label ID="Lanio" runat="server" Text="Año: "
                        Font-Names="Arial" Font-Size="12px" Font-Bold="True" Visible="False"></asp:Label>
                    &nbsp;<asp:DropDownList ID="cmbanio" CssClass="borders" runat="server" Visible="False">
                    </asp:DropDownList>
                    &nbsp;<asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Generar"
                        OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <div class="divBord">
                        <asp:GridView ID="GridArchivos" CssClass="Grid" runat="server" AutoGenerateColumns="False" OnRowCommand="GridArchivos_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Nombre Archivo">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="VerArchivo" CommandArgument='<%# Eval("Name") %>' Text='<%# Eval("Name") %>'> </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Length" HeaderText="Tamaño" SortExpression="Length">
                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CreationTime" HeaderText="Creación" SortExpression="CreationTime">
                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Eliminar" CommandArgument='<%# Eval("Name") %>' ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Desea Eliminar El Archivo Selecionado?')){return false;}" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </td>
            </tr>

        </table>

    </div>

</asp:Content>

