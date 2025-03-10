<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CredDescargarModelo.aspx.cs" Inherits="CredDescargarModelo" StylesheetTheme="Tema1" Theme="Tema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table bgcolor="#ffffff" border="0" class="areaBordes" cellpadding="4" cellspacing="4"
        width="100%" title=".:: Cargue Masivo Campañas ::.">
        <tr>
            <td class="titulo01" valign="top">Descarga Maqueta No. Documento</td>
        </tr>
        <tr>
            <td class="tbBord">
                <table border="0" cellpadding="4" cellspacing="4" width="100%">
                    <tr>
                        <td class="tablaValor">&nbsp;&nbsp;
                            <asp:Label ID="lblIdentificacion" runat="server" Text="No. Documento"
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtNIT" CssClass="borders" runat="server" Width="30%"></asp:TextBox>
                            &nbsp;&nbsp;<asp:Label ID="lblRazonSocial" runat="server" Text="Razón Social:"
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;<asp:TextBox ID="txtRazonSocial" CssClass="borders" runat="server" Width="30%"></asp:TextBox>
                            &nbsp;<asp:DropDownList ID="cmbDivisa" runat="server"></asp:DropDownList>
                            &nbsp; <asp:Button ID="btnBuscar" runat="server" Text="Buscar Dato" CssClass="botonDes"
                                OnClick="btnBuscar_Click" />

                        </td>
                    </tr>
                    <tr>
                        <td class="tablaValor">
                            <asp:Label ID="lblCantidadCoincTexto" runat="server" Text="Label" Visible="False">Cantidad de coincidencias: </asp:Label>
                            <asp:Label ID="lblCantidadCoincInfo" runat="server" Text=""
                                Font-Bold="True"></asp:Label>


                            <div class="divBord">
                                <asp:GridView ID="GridNITPlantilla" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                                    EmptyDataText="No Existen datos con la busqueda realizada" OnRowCommand="GridNITPlantilla_RowCommand"
                                    Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="NIT" HeaderText="No. Documento">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Direccion" HeaderText="Direccion">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Email" HeaderText="Email">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Descargar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Descargar" CommandArgument='<%#Eval("NIT") %>' ImageUrl="~/Grafix/Descarga2.png" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
       <%-- <tr>
            <td class="tbBord">
                <table border="0" cellpadding="4" cellspacing="4" width="100%">
                    <tr>
                        <td class="tablaValor">
                            <asp:Label ID="Label73" runat="server" Text="Grupo Económico"
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;<asp:DropDownList ID="CmbGrupos" CssClass="borders" runat="server"></asp:DropDownList>

                            &nbsp; <asp:Button ID="Button1" runat="server" CssClass="botonDes" Text="Descargar Grupo" OnClick="Button1_Click" />

                        </td>
                    </tr>


                </table>
            </td>
        </tr>--%>
    </table>


</asp:Content>

