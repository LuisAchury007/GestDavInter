<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Conf_IndicadoresHijos.aspx.cs" Inherits="Conf_IndicadoresHijos" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Indicadores Hijos ::.</title>
    <script language="JavaScript" type="text/JavaScript">


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
        function validar(element) {
            if (isNaN(parseInt(document.forms[0].txtPeso.value))) {
                parseInt(document.forms[0].txtPeso.value = 0)

            }

            if (document.forms[0].txtPeso.value < 0 || document.forms[0].txtPeso.value > 100) {
                alert('el Valor de los pesos debe estar entre 1 y 100');
                parseInt(document.forms[0].txtPeso.focus)
                return false;
            }

            if (document.forms[0].txtPesoParcial.value == '') {
                parseInt(document.forms[0].txtPesoParcial.value = 0)
            }

            if (document.forms[0].txtPesoParcial.value < 0 || document.forms[0].txtPesoParcial.value > 100) {
                alert('el Valor de los pesos debe estar entre 1 y 100');
                parseInt(document.forms[0].txtPesoParcial.focus)
                return false;
            }

            if (document.forms[0].txtPesoParcialAnio.value < 0 || document.forms[0].txtPesoParcialAnio.value > 100) {
                alert('el Valor de los pesos Anuales debe estar entre 1 y 100');
                parseInt(document.forms[0].txtPesoParcialAnio.focus)
                return false;
            }

            if (document.forms[0].txtDesTecho.value == '') {
                parseInt(document.forms[0].txtDesTecho.value = 0)
            }



            if (document.forms[0].txtDesPiso.value == '') {
                parseInt(document.forms[0].txtDesPiso.value = 0)
            }

            if (document.forms[0].txtPesoParcialAnio.value == '') {
                parseInt(document.forms[0].txtPesoParcialAnio.value = 0)
            }


            return true;
        }
    </script>
    <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/bts.js"></script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
        <div>
            <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">

                <tr>
                    <td valign="top">
                        <asp:Panel ID="Panel1" runat="server">
                            <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
                                <tr>
                                    <td valign="top" class="titulo01">Configuración Indicadores (Hijos)</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <br />
                                                    <div class="divBord">
                                                    <asp:GridView ID="grvIndicadoresHijos" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                                                        EmptyDataText="No Hay Registros" DataKeyNames="IdIndicador,IdModelo" OnRowCommand="grvIndicadoresHijos_RowCommand" OnRowDataBound="grvIndicadoresHijos_RowDataBound">
                                                        <Columns>
                                                            <asp:BoundField DataField="Indicador" HeaderText="Indicador" SortExpression="AlturaMora">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                   <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Peso" HeaderText="Peso" SortExpression="Peso" DataFormatString="{0:p}">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                   <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PesoParcial" HeaderText="PesoParcial" SortExpression="PesoParcial" DataFormatString="{0:p}">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                   <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PesoParcialAnio" HeaderText="Peso Parcial Año" SortExpression="PesoParcialAnio" DataFormatString="{0:p}">
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
                                                            <asp:BoundField DataField="Mantener" HeaderText="Valor Mantener" SortExpression="Mantener">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                   <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="orden" HeaderText="Orden" SortExpression="orden">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                   <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FechaSistema" HeaderText="Fecha de Creacion" SortExpression="FechaSistema">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                   <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Estado">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkActivo" runat="server" Enabled="False" />
                                                                </ItemTemplate>
                                                                   <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
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
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                        </div>
                                                    <br />

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="style1" style="width: 600px" border="0">
                                                        <tr>
                                                           <td class="tablaEncabezadoOp" colspan="2">Ingreso/Modificacion Indicadores Modelo</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Nombre Indicador</td>
                                                            <td>
                                                                <asp:TextBox ID="txtNomIndicador" CssClass="borders" runat="server" Visible="true" Width="150px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Tipo de dato</td>
                                                            <td>
                                                                <asp:DropDownList ID="CmbIndicadores" CssClass="borders" runat="server" Width="120px" OnSelectedIndexChanged="CmbIndicadores_SelectedIndexChanged" AutoPostBack="True">
                                                                    <asp:ListItem Value="-1">--Seleccione--</asp:ListItem>
                                                                    <asp:ListItem Value="1">Sector</asp:ListItem>
                                                                    <asp:ListItem Value="2">Año anterior</asp:ListItem>
                                                                    <asp:ListItem Value="3">Valor fijo</asp:ListItem>
                                                                </asp:DropDownList>
                                                                &nbsp;&nbsp;
                                                                  <asp:TextBox ID="txtValorFijo" CssClass="borders" runat="server" Visible="false"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" Enabled="True" TargetControlID="txtValorFijo" ValidChars="," FilterType="Custom, Numbers"></cc1:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Activo</td>
                                                            <td>
                                                                <asp:CheckBox ID="ChkEstado" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Orden</td>
                                                            <td>
                                                                <asp:TextBox ID="txtOrden" CssClass="borders" runat="server"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtOrden" FilterType="Numbers" Enabled="True">
                                                                </cc1:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Valor Mantener</td>
                                                            <td>
                                                                <asp:TextBox ID="TxtMantener" CssClass="borders"  runat="server"></asp:TextBox>
                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TxtMantener" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </cc1:FilteredTextBoxExtender>
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
                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtPeso" FilterType="Numbers" Enabled="True">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="tablaItem">Parcial</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPesoParcial" CssClass="borders" runat="server" TabIndex="220" Width="100px"></asp:TextBox>

                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPesoParcial" FilterType="Numbers" Enabled="True">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="tablaItem">Parcial Año</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtPesoParcialAnio" CssClass="borders" runat="server" TabIndex="220" Width="100px"></asp:TextBox>
                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtPesoParcialAnio" FilterType="Numbers" Enabled="True">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>


                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Desviación</td>
                                                            <td>
                                                                <table>
                                                                    <tr>
                                                                        <td class="tablaItem">Techo</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDesTecho" CssClass="borders" runat="server" TabIndex="220" Width="100px"></asp:TextBox>
                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDesTecho" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="tablaItem">Piso</td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtDesPiso" CssClass="borders" runat="server" TabIndex="220" Width="100px"></asp:TextBox>
                                                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDesPiso" FilterType="Custom, Numbers" ValidChars=",-" Enabled="True">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:ImageButton ID="ImgGuardarDias" runat="server" ImageUrl="~/Grafix/Guardar.png" OnClientClick="return validar(this);"
                                                                    ToolTip="Guardar" ValidationGroup="form" OnClick="ImgGuardarDias_Click" />
                                                                <asp:ImageButton ID="ImgLimpiarDias" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                    ToolTip="Guardar" OnClick="ImgLimpiarDias_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HidIndicadorNuevo" runat="server" Value="true" />
                                <asp:HiddenField ID="HidSumaTotal" runat="server" />
                                <asp:HiddenField ID="HidSumaTotalParcial" runat="server" />
                                <asp:HiddenField ID="HidSumaTotalParcialAnual" runat="server" />
                                <asp:HiddenField ID="HidIdIndicador" runat="server" />
                            </table>
                        </asp:Panel>
                    </td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
