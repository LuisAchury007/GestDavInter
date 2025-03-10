<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_CPI.aspx.cs" Inherits="Conf_CPI" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

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
                alert('Introduce solo valores numericos o Decimales con (,)');
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

    <%-- <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/bts.js"></script>--%>
    <link href="css/bts.css" rel="stylesheet" />

    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%" style="border: tsolid #C0C0C0; background-color: #FFFFFF;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td valign="top" class="titulo01">
                            <asp:Label ID="lblParametrosCPI" runat="server">Configurar Parametros CPI</asp:Label>
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
                                                            <i class="fa fa-plus"></i>Factor Días de Mora
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseTwo" class="panel-collapse collapse  <%= macroState %>">
                                                    <div class="panel-body">
                                                        <table style="width: 600px" border="0">
                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <div class="divBord">
                                                                                                <asp:GridView ID="grvCPIDiasMora" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                                                                    EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdCpIDiasMora" OnRowDataBound="grvCPIDiasMora_RowDataBound" OnRowCommand="grvCPIDiasMora_RowCommand">
                                                                                                    <Columns>
                                                                                                        <asp:BoundField DataField="AlturaMora" HeaderText="Altura Mora" SortExpression="AlturaMora" ItemStyle-HorizontalAlign="Center">
                                                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:BoundField DataField="VAlturaMora" HeaderText="Valor Altura Mora" SortExpression="VAlturaMora" ItemStyle-HorizontalAlign="Center">
                                                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="Factor">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:TextBox ID="TxtFactorMora" autocomplete="off" runat="server" Enabled="False" Width="50px" onkeyup="return checkMaxLen(this,7)" Style="width: 50px; text-align: right;"></asp:TextBox>
                                                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="TxtFactorMora" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:BoundField DataField="FechaSistema" HeaderText="Fecha de Creacion" SortExpression="FechaSistema" ItemStyle-HorizontalAlign="Center">
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
                                                                                                                <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdCpIDiasMora") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
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
                                                                                            <asp:LinkButton ID="LinkGuardaRest" runat="server" Visible="true" OnClick="LinkGuardaRest_Click">Editar Factor de Dias</asp:LinkButton>
                                                                                            <asp:LinkButton ID="LinkGuardaRestTotal" runat="server" Visible="False" OnClick="LinkGuardaRestTotal_Click" ValidationGroup="uno">Guardar Factor</asp:LinkButton>
                                                                                            <asp:HiddenField ID="HidAlturaMora" runat="server" Value="true" />
                                                                                            <asp:HiddenField ID="HidValturaMora" runat="server" Value="true" />
                                                                                            <asp:HiddenField ID="HidFactorCPI" runat="server" Value="true" />
                                                                                            <asp:HiddenField ID="HidEstadoDias" runat="server" Value="true" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table>
                                                                                    <tr align="center">
                                                                                        <td>
                                                                                            <table class="style1" style="width: 600px" border="0">
                                                                                                <tr>
                                                                                                    <td class="tablaItem">Altura Mora</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtAlturaMora" CssClass="borders" runat="server" TabIndex="220" autocomplete="off" Width="250px"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ValRespuesta"
                                                                                                            runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtAlturaMora"></asp:RequiredFieldValidator>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="tablaItem">Valor Altura Mora</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtValturaMora" CssClass="borders" runat="server" TabIndex="220" autocomplete="off"
                                                                                                            Width="100px"></asp:TextBox>
                                                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtValturaMora" FilterType="Custom, Numbers" Enabled="True">
                                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValRespuesta"
                                                                                                            runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtValturaMora"></asp:RequiredFieldValidator>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="tablaItem">Factor</td>
                                                                                                    <td>
                                                                                                        <asp:TextBox ID="txtFactorCPI" CssClass="borders" runat="server" TabIndex="220" autocomplete="off" onkeyup="return checkMaxLen(this,7)"
                                                                                                            Width="100px"></asp:TextBox>
                                                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFactorCPI" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ValRespuesta"
                                                                                                            runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtFactorCPI"></asp:RequiredFieldValidator>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                                            ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtFactorCPI" ValidationGroup="ValRespuesta" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="tablaItem">&nbsp; Estado</td>
                                                                                                    <td>
                                                                                                        <asp:CheckBox ID="chkEstadoEstadoDias" runat="server" />

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                        <asp:ImageButton ID="ImgGuardarDias" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                                            ToolTip="Guardar" ValidationGroup="ValRespuesta" OnClick="ImgGuardarDias_Click" Style="height: 27px" />
                                                                                                        <asp:ImageButton ID="ImgLimpiarDias" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                                            ToolTip="Cancelar" OnClick="ImgLimpiarDias_Click" />

                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
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

                                                                                    <asp:GridView ID="grvCCIPeriodo" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                                                        EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdCpIPeriodo" OnRowDataBound="grvCCIPeriodo_RowDataBound" OnRowCommand="grvCCIPeriodo_RowCommand">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="Periodo" HeaderText="Periodo" SortExpression="Periodo" ItemStyle-HorizontalAlign="Center">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Peso">
                                                                                                <ItemTemplate>
                                                                                                    <asp:TextBox ID="TxtPeriodoPeso" runat="server" Enabled="False" autocomplete="off" Width="50px" onchange="check_cantidad(this);" Style="width: 50px; text-align: right;"></asp:TextBox>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="Factor" HeaderText="Factor" SortExpression="Factor">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>

                                                                                            <asp:BoundField DataField="FechaSistema" HeaderText="Fecha de Creacion" SortExpression="FechaSistema" ItemStyle-HorizontalAlign="Center">
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
                                                                                                    <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdCpIPeriodo") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
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
                                                                                <asp:HiddenField ID="HidPeriodo" runat="server" Value="true" />
                                                                                <asp:HiddenField ID="HidPesoCPI2" runat="server" Value="true" />
                                                                                <asp:HiddenField ID="HidFactorCPI2" runat="server" Value="true" />
                                                                                <asp:HiddenField ID="HidEstadoCPI2" runat="server" Value="true" />
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
                                                                                            <asp:TextBox ID="txtPeriodo" CssClass="borders" runat="server" TabIndex="220" autocomplete="off" Width="250px"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ValRespuesta2"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtPeriodo"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">Peso</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtPesoCPI" CssClass="borders" runat="server" TabIndex="220" autocomplete="off"
                                                                                                Width="100px"></asp:TextBox>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPesoCPI" FilterType="Custom, Numbers" Enabled="True">
                                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ValRespuesta2"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtPesoCPI"></asp:RequiredFieldValidator>
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
                                                                                                ToolTip="Cancelar" OnClick="ImgLimpiarPeriodo_Click" />

                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <br />

                                                                </td>
                                                            </tr>

                                                        </table>
                                                        <asp:HiddenField ID="hdfSumaCalFAnt" runat="server" Value="" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsefour">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Factor Calificación SARC
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapsefour" class="panel-collapse collapse  <%= lvlRiskState %>">
                                                    <div class="panel-body">

                                                        <table  style="width: 600px" border="0">
                                                            <tr>
                                                                <td>

                                                                    <table>

                                                                        <tr>
                                                                            <td>
                                                                                <div class="divBord">
                                                                                    <asp:GridView ID="grvRegla" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                                                                                        EmptyDataText="No Hay Registros" DataKeyNames="IdReglaCpI" OnRowCommand="grvRegla_RowCommand" OnRowDataBound="grvRegla_RowDataBound">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="Letra" HeaderText="Calificación SARC" SortExpression="Letra" ItemStyle-HorizontalAlign="Center">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Calificacion" HeaderText="Vector mes" SortExpression="Calificacion" ItemStyle-HorizontalAlign="Center">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>

                                                                                            <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" ItemStyle-HorizontalAlign="Center">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="PisoCPI" HeaderText="Piso CPI" ItemStyle-HorizontalAlign="Center">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Estado" ItemStyle-HorizontalAlign="Center">
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="chkEstadoRegla" runat="server" Enabled="False" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Editar">
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdReglaCpI") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
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
                                                                                <asp:HiddenField ID="HidCalSARC" runat="server" Value="true" />
                                                                                <asp:HiddenField ID="HidCalfVector" runat="server" Value="true" />
                                                                                <asp:HiddenField ID="HidPisoCPI" runat="server" Value="true" />
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                    <table>
                                                                        <tr align="center">
                                                                            <td>
                                                                                <table class="style1" style="width: 600px" border="0">
                                                                                    <tr>
                                                                                        <td class="tablaItem">Calificación SARC</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtCalSARC" CssClass="borders" autocomplete="off" runat="server" TabIndex="220" Width="150px"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="ValRespuesta3"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtCalSARC"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="tablaItem">Vector mes</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtCalfVector" CssClass="borders" runat="server" TabIndex="220"
                                                                                                Width="150px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtCalfVector" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="ValRespuesta3"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtCalfVector"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                                ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtCalfVector" ValidationGroup="ValRespuesta3" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">Valor</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtVarableCfinal" CssClass="borders" autocomplete="off" runat="server" TabIndex="220" Width="150px" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtVarableCfinal" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="ValRespuesta3"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtVarableCfinal"></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                                ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtVarableCfinal" ValidationGroup="ValRespuesta3" />
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="tablaItem">Piso CPI *</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtPisoCPI" CssClass="borders" runat="server" autocomplete="off" onkeyup="return checkMaxLen(this,7)" TabIndex="220" Width="150px"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ValidationGroup="ValRespuesta3"
                                                                                                runat="server" ErrorMessage="Este campo es requerido"
                                                                                                ControlToValidate="txtPisoCPI"></asp:RequiredFieldValidator>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtPisoCPI" FilterType="Custom, Numbers" ValidChars=","
                                                                                                Enabled="True">
                                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                                            <asp:RegularExpressionValidator ID="Regex9" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                                ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtPisoCPI" ValidationGroup="ValRespuesta3" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">Estado</td>
                                                                                        <td>
                                                                                            <asp:CheckBox ID="ChkEstadoRegla" runat="server" />

                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:ImageButton ID="btnGuardaRegla" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                                ToolTip="Guardar" ValidationGroup="ValRespuesta3" OnClick="btnGuardaRegla_Click" />
                                                                                            <asp:ImageButton ID="btnDelRegla" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                                ToolTip="Cancelar" OnClick="btnDelRegla_Click" />
                                                                                            <asp:HiddenField ID="HidIdRegla" runat="server" />
                                                                                        </td>
                                                                                    </tr>

                                                                                    <asp:HiddenField ID="HDiasMOraNUevo" runat="server" Value="true" />
                                                                                    <asp:HiddenField ID="HDiasMoraID" runat="server" />
                                                                                    <asp:HiddenField ID="HdPespCPI" runat="server" />
                                                                                    <asp:HiddenField ID="HPeriodoNuevo" runat="server" Value="true" />
                                                                                    <asp:HiddenField ID="HPeriodoID" runat="server" />
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <br />

                                                                </td>
                                                            </tr>

                                                        </table>

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

            </td>
        </tr>
    </table>

</asp:Content>
