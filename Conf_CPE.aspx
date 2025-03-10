<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_CPE.aspx.cs" Inherits="Conf_CPE" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">

        /* INICIO: Funcion para limitar el textbox comentarios de la pestaña contactos a solo 255 caracteres */
        function checkMaxLen(txt, maxLen) {
            try {
                if (txt.value.length > (maxLen - 1)) {
                    var cont = txt.value;
                    txt.value = cont.substring(0, (maxLen - 1));
                    return false;
                };
            } catch (e) {
            }
        }
        /* FIN: Funcion para limitar el textbox comentarios de la pestaña contactos a solo 255 caracteres */

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

        function Actualizaframes(IdSector, NombreSec, NIT) {

            var modal = $find('ModalPopupExtender2');
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "GCredEmpresa.aspx?IdSector=" + IdSector + "&NombreSec=" + NombreSec + "&NIT=" + NIT;
            modal.show();

        }
        function DatosEmpresa(IdSector, NombreSec, NIT) {
            var altoActual;
            var anchoActual;

            altoActual = screen.height * 0.70;
            anchoActual = screen.width * 0.95;


            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.height = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.width = anchoActual + 'px';

            altoActual = screen.height * 0.65
            anchoActual = screen.width * 0.94

            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.height = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.width = anchoActual + 'px';

            var modal = $find('ModalPopupExtender2');  //haciendo referencia al behavior, y NO al id
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "CredEmpresa.aspx?IdSector=" + IdSector + "&NombreSec=" + NombreSec + "&NIT=" + NIT;
            modal.show();
        }
    </script>
 <%--    <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/bts.js"></script>--%>
    <link href="css/bts.css" rel="stylesheet" />

    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%" bgcolor="#FFFFFF">
        <tr>
            <td class="titulo01" valign="top">
                <asp:Label ID="lblParametrosCPE" runat="server">Configurar Parametros CPE</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <div class="container">

                    <div class="row">
                        <div>
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title panel-title-adjust">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                                <i class="fa fa-plus"></i>Calificación
                                            </a>
                                        </h4>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse  <%= macroState %>">
                                        <div class="panel-body">

                                            <table style="width: 600px" border="0">

                                                <tr>
                                                    <td>


                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <div class="divBord">
                                                                        <asp:GridView ID="grvCPECalificacion" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                                            EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdCpECalificacion" OnRowCommand="grvCPECalificacion_RowCommand" OnRowDataBound="grvCPECalificacion_RowDataBound">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Calificacion" HeaderText="Calificación" SortExpression="Calificacion" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:TemplateField HeaderText="Factor">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="TxtFactorCalificacion" autocomplete="off" runat="server" Enabled="False" Width="50px" Style="width: 50px; text-align: right;" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="TxtFactorCalificacion" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="FechaSistema" HeaderText="Fecha de Creación" SortExpression="FechaSistema" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkEstadoRespt" runat="server" Enabled="False" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Piso CPE">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="textPisoCPE" autocomplete="off" runat="server" Enabled="False" Width="50px" Style="width: 50px; text-align: right;" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="textPisoCPE" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Editar">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdCpECalificacion") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <br />

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="LinkGuardaRest" runat="server" Visible="true" OnClick="LinkGuardaRest_Click">Editar Factor Calificación</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkGuardaRestTotal" runat="server" Visible="False" OnClick="LinkGuardaRestTotal_Click">Guardar Factor</asp:LinkButton>
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                    <asp:LinkButton ID="linkEditaPisoCPE" runat="server" Visible="true" OnClick="linkEditaPisoCPE_Click">Editar Piso CPE</asp:LinkButton>
                                                                    <asp:LinkButton ID="linkGuardaPisoCPE" runat="server" Visible="False" OnClick="linkGuardaPisoCPE_Click">Guardar Piso CPE</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <asp:HiddenField ID="HidCalificacion" runat="server" Value="true" />
                                                            <asp:HiddenField ID="HidFactorCPE" runat="server" Value="true" />
                                                            <asp:HiddenField ID="HidEstadoEstadoDias" runat="server" Value="true" />
                                                            <asp:HiddenField ID="hdfPisoCPE" runat="server" Value="true" />
                                                        </table>
                                                        <table>
                                                            <tr align="center">
                                                                <td>
                                                                    <table class="style1" style="width: 600px" border="0">
                                                                        <tr>
                                                                            <td class="tablaItem">Calificación</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCalificacion" CssClass="borders" autocomplete="off" runat="server" TabIndex="220" Width="250px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValRespuesta"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtCalificacion"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Factor</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFactorCPE" CssClass="borders" runat="server" TabIndex="220" autocomplete="off" Width="100px" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ValRespuesta"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtFactorCPE"></asp:RequiredFieldValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFactorCPE" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtFactorCPE" ValidationGroup="ValRespuesta" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Estado</td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkEstadoEstadoDias" runat="server" />

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Piso CPE *</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPisoCPE" CssClass="borders" runat="server" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ValidationGroup="ValRespuesta"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtPisoCPE"></asp:RequiredFieldValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="txtPisoCPE" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex11" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtPisoCPE" ValidationGroup="ValRespuesta" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ImgGuardarCalificacion" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuesta" OnClick="ImgGuardarCalificacion_Click" />
                                                                                <asp:ImageButton ID="ImgLimpiarCalificacion" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                    ToolTip="Guardar" OnClick="ImgLimpiarCalificacion_Click" />

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </td>
                                                </tr>
                                            </table>

                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title panel-title-adjust">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                                                <i class="fa fa-plus"></i>Periodo (Meses)
                                            </a>
                                        </h4>
                                    </div>
                                    <div id="collapseThree" class="panel-collapse collapse <%= segmentState %>">
                                        <div class="panel-body">

                                            <table style="width: 600px" border="0">
                                                <tr>
                                                    <td>

                                                        <table>

                                                            <tr>
                                                                <td>
                                                                    <div class="divBord">
                                                                        <asp:GridView ID="grvCPEPeriodo" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                                            EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdCpEPeriodo" OnRowCommand="grvCPEPeriodo_RowCommand" OnRowDataBound="grvCPEPeriodo_RowDataBound">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Periodo" HeaderText="Periodo" SortExpression="Periodo" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Peso">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="TxtPeriodoPeso" autocomplete="off" runat="server" Enabled="False" Width="50px" onchange="check_cantidad(this);" Style="width: 50px; text-align: right;"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="FactorCPE" HeaderText="Factor" SortExpression="FactorCPE" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>

                                                                                <asp:BoundField DataField="FechaSistema" HeaderText="Fecha de Creación" SortExpression="FechaSistema" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkEstadoRespt" runat="server" Enabled="False" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Editar">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdCpEPeriodo") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>

                                                                    </div>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="LinkActualizaPeso" runat="server" Visible="true" OnClick="LinkActualizaPeso_Click">Editar Pesos de Periodos</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkGuardaPeso" runat="server" Visible="False" OnClick="LinkGuardaPeso_Click">Guardar Pesos</asp:LinkButton>
                                                                    <asp:HiddenField ID="HidPeriodo1" runat="server" Value="true" />
                                                                    <asp:HiddenField ID="HidPeso2" runat="server" Value="true" />
                                                                    <asp:HiddenField ID="HidFactor3" runat="server" Value="true" />
                                                                    <asp:HiddenField ID="HidEstado4" runat="server" Value="true" />
                                                                </td>
                                                            </tr>

                                                        </table>
                                                        <table>
                                                            <tr align="center">
                                                                <td>
                                                                    <table class="style1" style="width: 600px" border="0">
                                                                        <tr>
                                                                            <td class="tablaItem">Periodo</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPeriodo" CssClass="borders" autocomplete="off" runat="server" TabIndex="220" Width="250px" Height="22px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ValRespuesta2"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtPeriodo"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Peso</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPesoCPE" CssClass="borders" runat="server" TabIndex="220" autocomplete="off"
                                                                                    Width="100px"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPesoCPE" FilterType="Custom, Numbers" Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ValRespuesta2"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtPesoCPE"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Estado</td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkEstadoPeriodo" runat="server" />

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ImgGuardarPeriodo" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuesta2" OnClick="ImgGuardarPeriodo_Click" />
                                                                                <asp:ImageButton ID="ImgLimpiarPeriodo" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                    ToolTip="Guardar" OnClick="ImgLimpiarPeriodo_Click" />

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>

                                            </table>
                                            <asp:HiddenField ID="HCalificacionNUevo" runat="server" Value="true" />
                                            <asp:HiddenField ID="HCalificacionID" runat="server" />
                                            <asp:HiddenField ID="HPeriodoNuevo" runat="server" Value="true" />
                                            <asp:HiddenField ID="HPeriodoID" runat="server" />
                                            <asp:HiddenField ID="HdPespCPE" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>




</asp:Content>
