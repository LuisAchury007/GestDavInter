<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_IndicadoresPadre.aspx.cs" Inherits="Conf_IndicadoresPadre" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">

        function Actualizaframes(IdIndicador, Indicador, IdModelo) {

            var modal = $find('ModalPopupExtender2');
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "GCredEmpresa.aspx?IdIndicador=" + IdIndicador + "&Indicador=" + Indicador + "&IdModelo=" + IdModelo;
            modal.show();

        }

        function check_cantidad(element) {
            var cant = element.value;
            if (isNaN(cant)) {
                alert('Introduce solo valores numericos o Decimales con (.)');
                document.getElementById(element.id).value = "0";
            }
            else if (cant == '') {
                document.getElementById(element.id).value = "0";

            }
        }


        function validar(element) {
            if (document.getElementById("<%=txtPeso.ClientID%>").value == '') {
                parseInt(document.getElementById("<%=txtPeso.ClientID%>").value = 0)
            }

            if (document.getElementById("<%=txtPeso.ClientID%>").value < 0 || document.getElementById("<%=txtPeso.ClientID%>").value > 100) {
                alert('el Valor de los pesos debe estar entre 1 y 100');
                parseInt(document.getElementById("<%=txtPeso.ClientID%>").focus)
                return false;
            }

            if (document.getElementById("<%=txtPesoParcial.ClientID%>").value == '') {
                parseInt(document.getElementById("<%=txtPesoParcial.ClientID%>").value = 0)
            }

            if (document.getElementById("<%=txtPesoParcialAnio.ClientID%>").value == '') {
                parseInt(document.getElementById("<%=txtPesoParcialAnio.ClientID%>").value = 0)
            }

            if (document.getElementById("<%=txtPesoParcial.ClientID%>").value < 0 || document.getElementById("<%=txtPesoParcial.ClientID%>").value > 100) {
                alert('el Valor de los pesos debe estar entre 1 y 100');
                parseInt(document.getElementById("<%=txtPesoParcial.ClientID%>").focus)
                return false;
            }

            if (document.getElementById("<%=txtPesoParcialAnio.ClientID%>").value < 0 || document.getElementById("<%=txtPesoParcialAnio.ClientID%>").value > 100) {
                alert('el Valor de los pesos Año debe estar entre 1 y 100');
                parseInt(document.getElementById("<%=txtPesoParcialAnio.ClientID%>").focus)
                return false;
            }

            if (document.getElementById("<%=txtValorVeto.ClientID%>").value == '') {
                parseInt(document.getElementById("<%=txtValorVeto.ClientID%>").value = 0)

            }

            if (document.getElementById("<%=txtVetoDefault.ClientID%>").value == '') {
                parseInt(document.getElementById("<%=txtVetoDefault.ClientID%>").value = 0)

            }


            return true;
        }

        function DatosEmpresa(IdIndicador, Indicador, IdModelo) {
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
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "Conf_IndicadoresHijos.aspx?IdIndicador=" + IdIndicador + "&Indicador=" + Indicador + "&IdModelo=" + IdModelo;
            modal.show();
        }
    </script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
                    <tr>
                        <td valign="top" class="titulo01">Configuración Indicadores (Padre)</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Modelo</td>
                                    <td class="tablaValor">
                                        <asp:DropDownList ID="CmbModelo" runat="server" CssClass="borders" AutoPostBack="True" OnSelectedIndexChanged="CmbModelo_SelectedIndexChanged"></asp:DropDownList>
                                        <asp:Button ID="Button17" runat="server" Text="Button" CssClass="invisible" />
                                    </td>

                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <br />
                                        <div class="divBord">
                                            <asp:GridView ID="grvIndicadoresPadre" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                                                EmptyDataText="No Hay Registros" DataKeyNames="IdIndicador,IdModelo" OnRowDataBound="grvIndicadoresPadre_RowDataBound" OnRowCommand="grvIndicadoresPadre_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Indicador" SortExpression="Indicador">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=<%#"javascript:DatosEmpresa("+  Eval("IdIndicador") + ",'" + Eval("Indicador") + "'," +  Eval("IdModelo") + ");"%> Text='<%# Eval("Indicador") %>'></asp:HyperLink>
                                                        </ItemTemplate>
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Peso" HeaderText="Peso Anual" SortExpression="Peso" DataFormatString="{0:p}">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PesoParcialAnio" HeaderText="Peso Parcial Año" SortExpression="PesoParcialAnio" DataFormatString="{0:p}">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PesoParcial" HeaderText="PesoParcial" SortExpression="PesoParcial" DataFormatString="{0:p}">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DesviacionTecho" HeaderText="Desviacion Techo" SortExpression="DesviacionTecho">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DesviacionPiso" HeaderText="Desviacion Piso" SortExpression="DesviacionPiso">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VetoValor" HeaderText="Veto Valor" SortExpression="VetoValor">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VetoComparador" HeaderText="Comparador Veto" SortExpression="VetoComparador">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="VetoDefault" HeaderText="Default Veto" SortExpression="VetoDefault">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="orden" HeaderText="Orden" SortExpression="orden">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:TemplateField HeaderText="Descendente">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkDesc" runat="server" Enabled="False" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Veto">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkVeto" runat="server" Enabled="False" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Afecta Final">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkAfectaFinal" runat="server" Enabled="False" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activo">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkActivo" runat="server" Enabled="False" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FechaSistema" HeaderText="Fecha de Creacion" SortExpression="FechaSistema">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Editar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdIndicador") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Eliminar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Eliminar" CommandArgument='<%# Eval("IdIndicador") %>' ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Realmente desea eliminar esta Información?')){return false;}" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Right" />
                                                        <HeaderStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <br />

                                    </td>

                                </tr>
                                <tr align="center">
                                    <td>
                                        <table class="style1" style="width: 600px" border="0">
                                            <tr>
                                                <td class="tablaEncabezadoOp" colspan="2">Ingreso/Modificación Indicadores Modelo</td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Nombre Indicador</td>
                                                <td>
                                                    <asp:TextBox ID="txtNomIndicador" CssClass="borders" runat="server" Visible="true" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Indicadores</td>
                                                <td>
                                                    <asp:DropDownList ID="CmbIndicadores" CssClass="borders" runat="server"></asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Orden</td>
                                                <td>
                                                    <asp:TextBox ID="txtOrden" CssClass="borders" runat="server"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtOrden" FilterType="Numbers" Enabled="True">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Descendente</td>
                                                <td>
                                                    <asp:CheckBox ID="ChkDesendente" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Activo</td>
                                                <td>
                                                    <asp:CheckBox ID="ChkEstado" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Pesos</td>
                                                <td>
                                                    <table>

                                                        <tr>
                                                            <td class="tablaItem">Año</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPeso" CssClass="borders" runat="server" TabIndex="220" Width="100px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPeso" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Parcial</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoParcial" CssClass="borders" runat="server" TabIndex="220" Width="150px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPesoParcial" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Parcial Año</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoParcialAnio" CssClass="borders" runat="server" TabIndex="220" Width="150px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPesoParcialAnio" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Vetos</td>
                                                <td>
                                                    <table>
                                                        <tr>
                                                            <td class="tablaItem">Aplica Veto</td>
                                                            <td>
                                                                <asp:CheckBox ID="chkVeto" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Valor Veto</td>
                                                            <td>
                                                                <asp:TextBox ID="txtValorVeto" CssClass="borders" runat="server" TabIndex="220" Width="150px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True" TargetControlID="txtValorVeto" ValidChars="," FilterType="Custom, Numbers"></ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Default Veto</td>
                                                            <td>
                                                                <asp:TextBox ID="txtVetoDefault" CssClass="borders" runat="server" TabIndex="220" Width="100px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtVetoDefault" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator2" runat="server"
                                                                    ControlToValidate="txtVetoDefault"
                                                                    MinimumValue="0"
                                                                    MaximumValue="3"
                                                                    Type="Integer"
                                                                    Text="El valor debe estar entre 0 y 3!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Comparador Veto</td>
                                                            <td>
                                                                <asp:DropDownList ID="CmbVetoComparador" CssClass="borders" runat="server">
                                                                    <asp:ListItem Value="">   </asp:ListItem>
                                                                    <asp:ListItem Value="=">=</asp:ListItem>
                                                                    <asp:ListItem Value=">">></asp:ListItem>
                                                                    <asp:ListItem Value="<"><</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Afecta final</td>
                                                            <td>
                                                                <asp:CheckBox ID="chkAfectaFinal" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:ImageButton ID="ImgGuardarDias" runat="server" ImageUrl="~/Grafix/Guardar.png" OnClientClick="return validar(this);"
                                                        ToolTip="Guardar" ValidationGroup="form" OnClick="ImgGuardarDias_Click" />
                                                    <asp:ImageButton ID="ImgLimpiarDias" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                        ToolTip="Guardar" OnClick="ImgLimpiarDias_Click" />
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
                                                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Button17" PopupControlID="PanelDatosEmpresa"
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
                                <asp:HiddenField ID="HidIndicadorNuevo" runat="server" Value="true" />
                                <asp:HiddenField ID="HidSumaTotal" runat="server" />
                                <asp:HiddenField ID="HidSumaTotalParcial" runat="server" />
                                <asp:HiddenField ID="HidSumaTotalParcialAnio" runat="server" />
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
