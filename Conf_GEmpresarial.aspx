<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_GEmpresarial.aspx.cs" Inherits="Conf_GEmpresarial" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">

        function validar(element) {
            if (document.forms[0].TabContainer1_TabPanel1_chkActEmpresa.checked == true) {
                confirmar = confirm("Usted Marco la Opción de actualizar Informacion del cliente,esto quiere decir que la fecha de actualización de la empresa y el estado cambiara,¿desea Continuar?");
                if (confirmar) {
                    // si pulsamos en aceptar
                    return true;
                }
                else {
                    // si pulsamos en cancelar
                    return false;
                }
            }

            return true;
        }


        function Actualizaframes(IdSector, NIT) {

            var modal = $find('ModalPopupExtender2');
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "GCredEmpresa.aspx?IdSector=" + IdSector + "&NIT=" + NIT;
            modal.show();

        }
        function DatosEmpresa(IdGrupoEm, GrupoEmpresarial) {
            var altoActual;
            var anchoActual;

            altoActual = screen.height * 0.70;
            anchoActual = screen.width * 0.95;


            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.height = '80%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.width = '90%'; //  = anchoActual + 'px';

            altoActual = screen.height * 0.65
            anchoActual = screen.width * 0.94

            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.height = '100%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.width = '100%'; // = anchoActual + 'px';

            var modal = $find('ModalPopupExtender2');  //haciendo referencia al behavior, y NO al id
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "Conf_EmpresaXGrupoEm.aspx?IdGrupoEm=" + IdGrupoEm + "&GrupoEmpresarial=" + GrupoEmpresarial;
            modal.show();
        }
    </script>
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">

        <tr>
            <td valign="top">
                <asp:Panel ID="Panel1" runat="server">
                    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
                        <tr>

                            <td class="titulo01" valign="top">
                                <asp:Label ID="lblParametrosCPI" runat="server">Configurar Grupos Económicos</asp:Label>

                            </td>
                        </tr>

                        <tr align="center">
                            <td>
                                <table>
                                    <tr>
                                        <td class="tablaItem">&nbsp;Ingrese el grupo económico a buscar</td>
                                        <td>
                                            <asp:TextBox ID="txtBuscarGrupo" CssClass="borders" runat="server"
                                                Width="200px"></asp:TextBox>
                                            <asp:Button ID="btnBuscarGEconomico" CssClass="botonDes" runat="server" Text="Buscar" OnClick="btnBuscarGEconomico_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                        </td>
                                    </tr>
                                </table>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCalFinancieraDetalles" runat="server" Text="Grupos Económicos" Font-Names="Arial" Font-Underline="True"></asp:Label>
                                            <asp:Button ID="Button17" runat="server" Text="Button" CssClass="invisible" />
                                            <br />
                                            <br />
                                            <div class="divBord">
                                                <asp:GridView ID="grvGEmpresarial" CssClass="Grid" runat="server" AllowSorting="True" AllowPaging="True" 
                                                    AutoGenerateColumns="False" EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdGrupoEm" 
                                                    OnPageIndexChanging="grvGEmpresarial_PageIndexChanging" OnSorting="grvGEmpresarial_Sorting" 
                                                    OnRowDataBound="grvGEmpresarial_RowDataBound" OnRowCommand="grvGEmpresarial_RowCommand" Width="100%">
                                                    <Columns>

                                                        <asp:BoundField DataField="IdGrupoEm" HeaderText="Id G. Económico">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CodGEconomico" HeaderText="Codigo G. Económico">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Grupo Económico" SortExpression="GrupoEmpresarial">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=<%#"javascript:DatosEmpresa("+  Eval("IdGrupoEm") + ",'" + Eval("GrupoEmpresarial") +"'" +");"%> Text='<%# Eval("GrupoEmpresarial") %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                              <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="SectorGE" HeaderText="Sector Límite GE">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Estado">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkEstadoGrupo" runat="server" Enabled="False" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImaBotDetalle3" runat="server" CausesValidation="False" 
                                                                    CommandName="Editar" CommandArgument='<%# Eval("IdGrupoEm") %>' ImageUrl="~/Grafix/Editar2.png" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Eliminar">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Eliminar" 
                                                                    CommandArgument='<%# Eval("IdGrupoEm") %>' 
                                                                    ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Realmente desea eliminar este dato?')){return false;}" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>

                                                </asp:GridView>
                                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                            </div>
                                            <br />
                                        </td>
                                    </tr>

                                </table>
                                <table>
                                    <tr align="center">
                                        <td class="tbBord">
                                            <table class="style1" style="width: 100%" border="0">
                                                <tr>
                                                    <td class="tablaItem">Id grupo económico</td>
                                                    <td>
                                                        <asp:TextBox ID="txtIdGrupoEm" CssClass="borders" runat="server" TabIndex="220" Width="250px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValRespuesta"
                                                            runat="server" ErrorMessage="Este campo es requerido"
                                                            ControlToValidate="txtIdGrupoEm"></asp:RequiredFieldValidator>
                                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender26" runat="server" Enabled="True" FilterType="Custom, Numbers"
                                                            TargetControlID="txtIdGrupoEm">
                                                        </cc1:FilteredTextBoxExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Codigo grupo económico</td>
                                                    <td>
                                                        <asp:TextBox ID="txtCodGEconomico" CssClass="borders" runat="server" TabIndex="220" Width="250px" MaxLength="10"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ValRespuesta"
                                                            runat="server" ErrorMessage="Este campo es requerido"
                                                            ControlToValidate="txtCodGEconomico"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Grupo económico</td>
                                                    <td>
                                                        <asp:TextBox ID="txtGrupoEmp" CssClass="borders" runat="server" TabIndex="220" Width="250px"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="ValRespuesta"
                                                            runat="server" ErrorMessage="Este campo es requerido"
                                                            ControlToValidate="txtGrupoEmp"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Sector Límite GE</td>
                                                    <td>
                                                        <asp:DropDownList ID="CmbSectorLimiteGE" CssClass="borders" runat="server" TabIndex="200" Width="253px"></asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tablaItem">Estado</td>
                                                    <td>
                                                        <asp:CheckBox ID="chkEstadoEstado" runat="server" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="tablaItem">
                                                        <asp:Label ID="LblComentarioEliminacion" runat="server" Text="Comentario de eliminacion" Visible="False"></asp:Label></td>
                                                    <td>
                                                        <asp:TextBox ID="txtAntecedentes" CssClass="borders" runat="server" Height="60px" TextMode="MultiLine" Width="400px" Visible="False"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:ImageButton ID="ImgGuardarGEmp" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                            ToolTip="Guardar" ValidationGroup="ValRespuesta" OnClick="ImgGuardarDias_Click" Width="29px" />
                                                        <asp:ImageButton ID="ImgLimpiarDias" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                            ToolTip="Guardar" OnClick="ImgLimpiarDias_Click" />
                                                        <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton7_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>



                        <asp:HiddenField ID="HidGrupoEm" runat="server" Value="true" />
                        <asp:HiddenField ID="HidCodGEmp" runat="server" Value="" />
                        <asp:HiddenField ID="HidGrupoEmpresarial" runat="server" Value="" />
                        <asp:HiddenField ID="HidSectorLim" runat="server" Value="" />



                    </table>
                </asp:Panel>
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
