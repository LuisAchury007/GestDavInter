<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CredSectorPG.aspx.cs" Inherits="BencSectorPG" Title="Gestor Comercial y De Credito" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">



        function Actualizaframes(NIT) {
            var sectores = document.getElementById("<%=cmbSector.ClientID%>").value;

            var modal = $find('ModalPopupExtender2');
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "CredEmpresa.aspx?IdSector=" + IdSectores + "&NIT=" + NIT;
            modal.show();

        }

        function DatosEmpresa(NIT) {
            var altoActual;
            var anchoActual;

            var sectores = document.getElementById("<%=cmbSector.ClientID%>").value;
            altoActual = screen.height * 0.70;
            anchoActual = screen.width * 0.95;


            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.height = '80%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.width = '90%'; // = anchoActual + 'px';

            altoActual = screen.height * 0.65
            anchoActual = screen.width * 0.94

            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.height = '100%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.width = '100%'; // = anchoActual + 'px';

            var modal = $find('ModalPopupExtender2');  //haciendo referencia al behavior, y NO al id
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "CredEmpresa.aspx?IdSector=" + sectores + "&NIT=" + NIT;
            modal.show();
        }
    </script>
    <table width="100%" border="0" cellpadding="6" cellspacing="6" class="areaBordes">
        <tr>
            <td class="areaInfo">
                <table class="style1" style="width: 20%" border="0">
                    <tr>
                        <td class="tablaItem">Sector</td>
                        <td>
                            <asp:DropDownList ID="cmbSector" runat="server" AutoPostBack="True" name="cmbSector" OnSelectedIndexChanged="cmbSector_SelectedIndexChanged"></asp:DropDownList>
                            <asp:Button ID="Button17" runat="server" Text="Button" CssClass="invisible" />
                        </td>

                    </tr>
                </table>
            </td>

        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="8">
                    <tr>
                        <td style="width: 100%; height: 100%; margin-left: 40px;" valign="top">
                            <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">

                                <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Balance">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="4" cellspacing="4" width="100%">
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:DropDownList ID="CmbAgregadoBalance" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="CmbAgregadoBalance_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="SUM">Suma</asp:ListItem>
                                                        <asp:ListItem Value="AVG">Promedio</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="ImgExcleBalance" runat="server" ImageUrl="~/Grafix/Excel.png"
                                                        OnClick="ImageButton9_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:GridView ID="GridListaBalance" runat="server" EmptyDataText="No Hay Registros" Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                        </table>

                                    </ContentTemplate>





                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Indicadores">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="4" cellspacing="4" width="100%">
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:DropDownList ID="CmbAgregadoIndicador" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="CmbAgregadoIndicador_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="0">Suma</asp:ListItem>
                                                        <asp:ListItem Value="1">Promedio</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Grafix/Excel.png"
                                                        OnClick="ImageButton11_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:GridView ID="GridListaInidicadores" runat="server" EmptyDataText="No Hay Registros" Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>

                                    </ContentTemplate>



                                </cc1:TabPanel>
                                <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="P&G">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="4" cellspacing="4" width="100%">
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:DropDownList ID="CmbAgregado" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="CmbAgregado_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="SUM">Suma</asp:ListItem>
                                                        <asp:ListItem Value="AVG">Promedio</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png"
                                                        OnClick="ImageButton7_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:GridView ID="GridLista" runat="server" EmptyDataText="No Hay Registros" Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>

                                    </ContentTemplate>




                                </cc1:TabPanel>
                                <cc1:TabPanel runat="server" HeaderText="Lista de empresas" ID="TabPanel4">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="4" cellspacing="4" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="Button3" runat="server" Text="Copiar" CssClass="boton1" />





                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="grvEmpresaLista" runat="server" AllowPaging="True" AllowSorting="True"
                                                        AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                                        Height="120px" OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting" PageSize="50" Width="100%" DataKeyNames="Nit">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSumar" runat="server" />

                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NIT" HeaderText="Nit" />
                                                            <asp:TemplateField HeaderText="Razon Socia" SortExpression="RazonSocial">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"javascript:DatosEmpresa("+  Eval("NIT") + ");"%>' Text='<%# Eval("RazonSocial") %>'></asp:HyperLink>

                                                                </ItemTemplate>

                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" SortExpression="Ciudad">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                        </Columns>

                                                        <PagerSettings Mode="NumericFirstLast" />
                                                    </asp:GridView>
                                                     <asp:Label ID="Label2" runat="server" Text=""></asp:Label>


                                                    <asp:HiddenField ID="HiEmpresas" runat="server" />




                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton8_Click" />














                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Panel ID="Panel4" runat="server" CssClass="ModalPopup" Style="display: none">
                                                        <asp:Panel ID="Panel5" runat="server" Style="cursor: move; background-color: #DDDDDD; border: solid 1px Gray; color: Black">
                                                            <div>
                                                                <p>Seleccione el Sector al que desea Copiar :</p>
                                                            </div>
                                                        </asp:Panel>



                                                        <div>
                                                            <p>
                                                                <asp:TreeView ID="MisSectores" runat="server" ShowCheckBoxes="Leaf"></asp:TreeView>




                                                                <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server"
                                                                    TargetControlID="Button3"
                                                                    PopupControlID="Panel4"
                                                                    BackgroundCssClass="ModalBackground" DynamicServicePath="" Enabled="True" />




                                                            </p>
                                                            <p style="text-align: center;">
                                                                <asp:Button ID="OkButton" runat="server" Text="Copiar" OnClick="OkButton_Click" />





                                                                <asp:Button ID="CancelButton" runat="server" Text="Cancel" />




                                                            </p>
                                                        </div>
                                                    </asp:Panel>




                                                </td>
                                            </tr>
                                        </table>

                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel runat="server" HeaderText="Ranking" ID="TabPanel5">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="4" cellspacing="4" width="100%">
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:DropDownList ID="CmbIndicadores" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="CmbIndicadores_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Grafix/Excel.png"
                                                        OnClick="ImageButton10_Click" />
                                                    <asp:Button ID="Button1" runat="server" Text="Copiar" CssClass="boton1" />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:GridView ID="Gridlista2" runat="server" AllowPaging="True" AllowSorting="True"
                                                        AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                                        Height="120px" OnPageIndexChanging="Grid2_PageIndexChanging" OnSorting="Grid2_Sorting" PageSize="50" Width="100%" DataKeyNames="Nit">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSumar" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NIT" HeaderText="Nit" />
                                                            <asp:TemplateField HeaderText="Razon Socia" SortExpression="RazonSocial">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#"javascript:DatosEmpresa("+  Eval("NIT") + ");"%>' Text='<%# Eval("RazonSocial") %>'></asp:HyperLink>
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

                                    </ContentTemplate>
                                </cc1:TabPanel>
                                <cc1:TabPanel runat="server" HeaderText="Flujo" ID="TabPanel6">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="4" cellspacing="4" width="100%">
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:DropDownList ID="CmbAgregadoFlujo" runat="server" AutoPostBack="True"
                                                        OnSelectedIndexChanged="CmbAgregadoFlujo_SelectedIndexChanged">
                                                        <asp:ListItem Selected="True" Value="0">Suma</asp:ListItem>
                                                        <asp:ListItem Value="1">Promedio</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton12_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="areaInfo">
                                                    <asp:GridView ID="GridListaFlujo" runat="server" EmptyDataText="No Hay Registros" Width="100%">
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>

                                    </ContentTemplate>
                                </cc1:TabPanel>

                            </cc1:TabContainer>
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
                                                <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False" ImageUrl="~/Grafix/Limpiar.png"
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
            </td>

        </tr>


    </table>
</asp:Content>

