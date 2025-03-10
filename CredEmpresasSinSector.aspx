<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredEmpresasSinSector.aspx.cs" Inherits="CredEmpresasSinSector" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="Javascript" type="text/JavaScript">
        function DatosEmpresaCred(IdSector, NombreSec, NIT) {
            var altoActual;
            var anchoActual;

            altoActual = screen.height * 0.70;
            anchoActual = screen.width * 0.95;

            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.height = '80%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.width = '90%'; // = anchoActual + 'px';

            altoActual = screen.height * 0.65
            anchoActual = screen.width * 0.94

            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.height = '100%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.width = '100%'; // = anchoActual + 'px';

            var modal = $find('ModalPopupExtender2');  //haciendo referencia al behavior, y NO al id
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "CredEmpresa.aspx?IdSector=" + IdSector + "&NombreSec=" + NombreSec + "&NIT=" + NIT;
            modal.show();
        }
    </script>
    
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Empresas Sin Sector</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td class="titulo02" colspan="3">
                            <asp:Label ID="Label73" runat="server" Text="Nit o Razón Social a Buscar: "
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="txtNitBuscar" CssClass="borders" runat="server" Width="368px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtNitBuscar"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnBuscar" CssClass="botonDes" runat="server" Text="Buscar" OnClick="btnBuscar_Click" ValidationGroup="form" />
                            <asp:Button ID="Button17" runat="server" Text="Button" CssClass="invisible" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Grafix/Proceso.png" ToolTip="Asignar Sector" />
                        </td>
                    </tr>
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
                                                    NavigateUrl=<%#"javascript:DatosEmpresaCred(99,'Sin Sector'"  + ",'" +  Eval("NIT") + "');"%>></asp:HyperLink>
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Ciiu" HeaderText="Ciiu" SortExpression="Ciiu">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" SortExpression="Ciudad">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>

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

                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" CssClass="ModalPopup" Style="display: none">
                                <div>
                                    <p>
                                        <table width="400px" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff">
                                            <tr>
                                                <td valign="top" class="titulo01">Seleccione un Sector</td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                                        <tr align="center">
                                                            <td class="tablaDescribe">Por favor escoja el Sector que quiere asignar a las empresas seleccionadas.</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="tablaDescribe">
                                                                <asp:DropDownList ID="cmbSectores" CssClass="borders" runat="server"></asp:DropDownList>
                                                                <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="ImageButton1" PopupControlID="Panel1"
                                                                    BackgroundCssClass="ModalBackground" CancelControlID="CancelButton" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Button ID="OkButton" CssClass="botonDes" runat="server" Text="Asignar" OnClick="OkButton_Click" />
                                                                <asp:Button ID="CancelButton" CssClass="botonDes" runat="server" Text="Cancel" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </p>
                                </div>
                            </asp:Panel>

                        </td>
                    </tr>

                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <asp:Panel ID="PanelDatosEmpresa" runat="server" CssClass="ModalPopup" Style="display: none; border-radius: 8px"
                    Width="100%">
                    <div style="width: 100%; height: 100%">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 99%; height: 100%">
                            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Button17" PopupControlID="PanelDatosEmpresa"
                                BackgroundCssClass="ModalBackground" BehaviorID="ModalPopupExtender2" CancelControlID="ImageButton1" />
                            <tr>
                                <td style="width: 100%; height: 6%" align="right">
                                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageUrl="~/Grafix/Limpiar.png"
                                        ToolTip="Cerrar" Width="25px" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="width: 100%">
                                    <iframe id="IframeDatosEmpresa" runat="server" width="100%" height="100%" style="border-radius: 8px" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

