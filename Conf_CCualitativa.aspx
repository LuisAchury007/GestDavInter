<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Conf_CCualitativa.aspx.cs" Inherits="Conf_CCualitativa" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">

        function validarAgrupacion(element) {
            var cant = document.getElementById("<%=txtPesoAgrupacion.ClientID%>").value;
            if (cant != 0) {
                if (document.getElementById("<%=chkAgrupacion.ClientID%>").checked == false) {

                    confirmar = confirm("¿Desea dejar esta agrupación inactiva? Cuando esta tiene un peso que afecta el 100%");
                    if (confirmar) {
                        // si pulsamos en aceptar
                        return true;
                    }
                    else {
                        // si pulsamos en cancelar
                        return false;
                    }
                }
            }
            return true;
        }

        function validarVariable(element) {
            var cant = document.getElementById("<%=txtPesoVariable.ClientID%>").value;
            if (cant != 0) {
                if (document.getElementById("<%=chkVariable.ClientID%>").checked == false) {

                    confirmar = confirm("¿Desea dejar esta variable inactiva? Cuando esta tiene un peso que afecta el 100%");
                    if (confirmar) {
                        // si pulsamos en aceptar
                        return true;
                    }
                    else {
                        // si pulsamos en cancelar
                        return false;
                    }
                }
            }
            return true;
        }

        function validarRespuesta(element) {
            var cant = document.getElementById("<%=txtFactor.ClientID%>").value;
            if (cant != 0) {
                if (document.getElementById("<%=chkEstadoRespuesta.ClientID%>").checked == false) {

                    confirmar = confirm("¿Desea dejar esta respuesta inactiva? Cuando esta tiene un peso que afecta el 100%");
                    if (confirmar) {
                        // si pulsamos en aceptar
                        return true;
                    }
                    else {
                        // si pulsamos en cancelar
                        return false;
                    }
                }
            }
            return true;
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

        function Actualizaframes(IdSector, NombreSec, NIT) {
            // document.getElementById("ctl00_ContentPlaceHolder1_FrameContenido").src = "GCredEmpresa.aspx?IdSector=" + IdSector + "&NombreSec=" + NombreSec + "&NIT=" + NIT;

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

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" class="areaBordes" bgcolor="#FFFFFF">
        <tr>

            <td class="titulo01" valign="top">
                <asp:Label ID="lblParametrosCCualitativa" runat="server">Configurar Calificación Cualitativa</asp:Label>
            </td>
        </tr>
        <tr>
            <td valign="top" style="width: 100%; height: 100%">
                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                    <cc1:TabPanel runat="server" HeaderText="Encuesta Cualitativa" ID="TabPanel1">
                        <ContentTemplate>
                            <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                <tr>
                                    <td class="areaNIT">
                                        <asp:Label ID="lblAccion" runat="server" alling="Center"
                                            Text="Encuesta cualitativa" ForeColor="#000099"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td valign="top" style="height: 10px">
                                        <div class="divBord">
                                            <asp:GridView ID="GridEncCualitativa" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                                                EmptyDataText="No Hay Registros" Width="100%" PageSize="50" DataKeyNames="IdEncCualitativa"
                                                OnRowCommand="GridEncCualitativa_RowCommand" OnRowDataBound="GridEncCualitativa_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField DataField="NomCualitativa" HeaderText="Nombre" SortExpression="NomCualitativa">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DescCualitativa" HeaderText="Descripción" SortExpression="DescCualitativa">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creación" SortExpression="FechaCreacion">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Activo">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkEstadoEncuesta" runat="server" Enabled="False" />

                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Editar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdEncCualitativa") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        <table class="style1" style="width: 600px" border="0">
                                            <tr>
                                                <td valign="top" class="tablaEncabezadoOp">
                                                    <asp:Label ID="Label73" runat="server" Text="Ingreso/Modificacion Encuestas"
                                                        Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 100%" align="left">
                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                        <tr>
                                                            <td class="tablaItem">Nombre del la encuesta</td>
                                                            <td>
                                                                <asp:TextBox ID="txtNombre" CssClass="borders" runat="server" TabIndex="220" Width="350px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ValEncuesta"
                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtNombre"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Descripción</td>
                                                            <td>
                                                                <asp:TextBox ID="txtDescripción" CssClass="borders" runat="server" TabIndex="220"
                                                                    Width="350px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValEncuesta"
                                                                        runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtDescripción"></asp:RequiredFieldValidator></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Activo</td>
                                                            <td>
                                                                <asp:CheckBox ID="chkEstado" runat="server" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:ImageButton ID="ImgGuardarEncuesta" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                    ToolTip="Guardar" ValidationGroup="ValEncuesta" OnClick="BtnGuardaEncuesta_Click" OnClientClick="if(!confirm('¿Realmente Desea Guardar Esta Encuesta?')){return false;}" /><asp:ImageButton ID="ImgLimpiar" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                        ToolTip="Limpiar" OnClick="ImgLimpiar_Click" /></td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <asp:HiddenField ID="HidNombre1" runat="server" Value="true" />
                                            <asp:HiddenField ID="HidDescripcion2" runat="server" Value="true" />
                                            <asp:HiddenField ID="HidEstacoEncuesta3" runat="server" Value="true" />
                                        </table>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HEncuestaNueva" runat="server" Value="true" />
                                <asp:HiddenField ID="HEncuestaID" runat="server" />
                            </table>
                        </ContentTemplate>

                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="Agrupaciones" ID="TabPanel5">
                        <ContentTemplate>
                            <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                <tr>
                                    <td class="areaNIT">
                                        <asp:Label ID="Label4" runat="server" alling="Center"
                                            Text="Agrupaciones" ForeColor="#000099"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                        <asp:Label ID="Label1" runat="server" Text="Encuesta ::"
                                            Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList CssClass="borders" ID="CmbEncuesta" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="CmbEncuesta_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlAgrupaciones" runat="server" Visible="False">
                                            <table width="100%" border="0" cellpadding="10" cellspacing="10">
                                                <tr>
                                                    <td valign="top" style="height: 10px">
                                                        <div class="divBord">
                                                            <asp:GridView CssClass="Grid" ID="GridAgrupaciones" runat="server" AutoGenerateColumns="False"
                                                                EmptyDataText="No Hay Registros" Width="100%" PageSize="50" DataKeyNames="IdAgrupacion"
                                                                OnRowCommand="GridAgrupaciones_RowCommand" OnRowDataBound="GridAgrupaciones_RowDataBound">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Agrupacion" HeaderText="Agrupación" SortExpression="Agrupacion">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Peso">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Txtpeso" runat="server" Enabled="False" Width="50px" onchange="check_cantidad(this);"></asp:TextBox><asp:Label ID="lblGuardaResp" runat="server" Visible="True"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creación" SortExpression="FechaCreacion">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Activo">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkEstadoAgru" runat="server" Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Editar">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar cliente" CommandArgument='<%# Eval("IdAgrupacion") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerSettings Mode="NumericFirstLast" />
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="LinkBtnAgrupacion" runat="server"
                                                            OnClick="LinkBtnAgrupacion_Click" Visible="False">Editar Pesos de Agruapciones</asp:LinkButton><asp:LinkButton ID="LinkBGuardar" runat="server"
                                                                OnClick="LinkBGuardar_Click" Visible="False">Guardar Pesos</asp:LinkButton></td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <table class="style1" style="width: 600px" border="0">
                                                            <tr>
                                                                <td valign="top" class="tablaEncabezadoOp">Ingreso/Modificacion agrupaciones</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%" align="left">
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem">Agrupación</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtAgrupacion" CssClass="borders" runat="server" TabIndex="220" Width="350px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ValAgrupacion"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtAgrupacion"></asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Peso</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPesoAgrupacion" CssClass="borders" runat="server" TabIndex="220"
                                                                                    Width="50px"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPesoAgrupacion" FilterType="Custom, Numbers" ValidChars="." Enabled="True"></cc1:FilteredTextBoxExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="ValAgrupacion"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtPesoAgrupacion"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">&nbsp; Activo</td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkAgrupacion" runat="server" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ImgGuardarAgrupacion" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValAgrupacion" OnClick="ImgGuardarAgrupacion_Click" OnClientClick="return validarAgrupacion(this);" /><asp:ImageButton ID="ImgLimpiarAgrupacion" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                        ToolTip="Guardar" OnClick="ImgLimpiarAgrupacion_Click" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <asp:HiddenField ID="HidAgrupacion1" runat="server" Value="true" />
                                                            <asp:HiddenField ID="HidPesoAgrupacion2" runat="server" Value="true" />
                                                            <asp:HiddenField ID="HiddchkAgrupacion3" runat="server" Value="true" />
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HAgrupacionNuevo" runat="server" Value="true" />
                                <asp:HiddenField ID="HAgrupacionID" runat="server" />
                                <asp:HiddenField ID="HidAgrupacionPeso" runat="server" />
                            </table>
                        </ContentTemplate>

                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" HeaderText="Variables" ID="TabPanel7">
                        <ContentTemplate>
                            <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                <tr>
                                    <td class="areaNIT">
                                        <asp:Label ID="Label5" runat="server" alling="Center"
                                            Text="Variables" ForeColor="#000099"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                        <asp:Label ID="Label2" runat="server" Text="Agrupacion ::"
                                            Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="CmbAgrupacion" CssClass="borders" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="CmbAgrupacion_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlVariables" runat="server" Visible="False">
                                            <table width="100%" border="0" cellpadding="10" cellspacing="10">
                                                <tr>
                                                    <td valign="top" style="height: 10px">
                                                        <div class="divBord">
                                                            <asp:GridView CssClass="Grid" ID="GridVariables" runat="server" AutoGenerateColumns="False"
                                                                EmptyDataText="No Hay Registros" Width="100%" PageSize="50" DataKeyNames="IdVariable"
                                                                OnRowCommand="GridVariables_RowCommand" OnRowDataBound="GridVariables_RowDataBound">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Variable" HeaderText="Variable" SortExpression="Variable">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Peso">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TxtpesoVar" runat="server" Enabled="False" Width="50px" onchange="check_cantidad(this);"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creacion" SortExpression="FechaCreacion">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Activo">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkEstadoVar" runat="server" Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Editar">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdVariable") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerSettings Mode="NumericFirstLast" />
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="LinkBGuardarPesoVariable" runat="server" OnClick="LinkBGuardarPesoVariable_Click" Visible="False">Editar Pesos de Variables</asp:LinkButton><asp:LinkButton ID="LinkBGuardarPesoTotal" runat="server" OnClick="LinkBGuardarPesoTotal_Click" Visible="False">Guardar Pesos</asp:LinkButton></td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <table class="style1" style="width: 600px" border="0">
                                                            <tr>
                                                                <td valign="top" class="tablaEncabezadoOp">Ingreso/Modificacion variables</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%" align="left">
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem">Variable</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtVAriable" CssClass="borders" runat="server" TabIndex="220" Width="350px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ValVariable"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtVAriable"></asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Peso</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPesoVariable" CssClass="borders" runat="server" TabIndex="220"
                                                                                    Width="50px"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPesoVariable" FilterType="Custom, Numbers" ValidChars="." Enabled="True"></cc1:FilteredTextBoxExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="ValVariable"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtPesoVariable"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">&nbsp; Activo</td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkVariable" runat="server" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ImgButtonVariable" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValVariable" OnClick="ImgButtonVariable_Click" OnClientClick="return validarVariable(this);" /><asp:ImageButton ID="ImgLimpiaVariable" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                        ToolTip="Guardar" OnClick="ImgLimpiaVariable_Click" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <asp:HiddenField ID="HidVAriable1" runat="server" Value="true" />
                                                            <asp:HiddenField ID="HidPesoVariable2" runat="server" />
                                                            <asp:HiddenField ID="HidchkVariable" runat="server" />
                                                        </table>
                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="HVariableNUeva" runat="server" Value="true" />
                            <asp:HiddenField ID="HVariableID" runat="server" />
                            <asp:HiddenField ID="HidPesoVariable" runat="server" />
                        </ContentTemplate>

                    </cc1:TabPanel>



                    <cc1:TabPanel runat="server" HeaderText="Respuestas" ID="TabPanel2">
                        <ContentTemplate>
                            <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                <tr>
                                    <td class="areaNIT">
                                        <asp:Label ID="Label6" runat="server" alling="Center"
                                            Text="Respuestas" ForeColor="#000099"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;
                                        <asp:Label ID="Label3" runat="server" Text="Variable ::"
                                            Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="CmbVariables" CssClass="borders" runat="server" AutoPostBack="True"
                                            OnSelectedIndexChanged="CmbVariables_SelectedIndexChanged">
                                        </asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlRespuestas" runat="server" Visible="False">
                                            <table width="100%" border="0" cellpadding="10" cellspacing="10">
                                                <tr>
                                                    <td valign="top" style="height: 10px">
                                                        <div class="divBord">
                                                            <asp:GridView CssClass="Grid" ID="GridRespuestas" runat="server" AutoGenerateColumns="False"
                                                                EmptyDataText="No Hay Registros" Width="100%" PageSize="50" DataKeyNames="IdRespuesta"
                                                                OnRowCommand="GridRespuestas_RowCommand" OnRowDataBound="GridRespuestas_RowDataBound">
                                                                <Columns>
                                                                    <asp:BoundField DataField="Respuesta" HeaderText="Respuesta" SortExpression="Respuesta">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Factor">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="TxtpesoRespuesta" runat="server" Enabled="False" Width="50px" onchange="check_cantidad(this);"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de creación" SortExpression="FechaCreacion">
                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Activo">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="chkEstadoRespt" runat="server" Enabled="False" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Editar">
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar cliente" CommandArgument='<%# Eval("IdRespuesta") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerSettings Mode="NumericFirstLast" />
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:LinkButton ID="LinkGuardaRest" runat="server" Visible="False" OnClick="LinkGuardaRest_Click">Editar Pesos de Respuestas</asp:LinkButton><asp:LinkButton ID="LinkGuardaRestTotal" runat="server" Visible="False" OnClick="LinkGuardaRestTotal_Click">Guardar Pesos</asp:LinkButton></td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <table class="style1" style="width: 600px" border="0">
                                                            <tr>
                                                                <td valign="top" class="tablaEncabezadoOp">Ingreso/Modificacion Respuestas</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%" align="left">
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem">Respuesta</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtRespuesta" CssClass="borders" runat="server" TabIndex="220" Width="350px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ValRespuesta"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtRespuesta"></asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Factor</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtFactor" CssClass="borders" runat="server" TabIndex="220"
                                                                                    Width="50px"></asp:TextBox>
                                                                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtFactor" FilterType="Custom, Numbers" ValidChars="." Enabled="True"></cc1:FilteredTextBoxExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="ValRespuesta"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtFactor"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Activo</td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkEstadoRespuesta" runat="server" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ImgGuardarRespuesta" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuesta" OnClick="ImgGuardarRespuesta_Click" OnClientClick="return validarRespuesta(this);" /><asp:ImageButton ID="ImgLimpiarRespuesta" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                        ToolTip="Guardar" OnClick="ImgLimpiarRespuesta_Click" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:HiddenField ID="HidRespuesta1" runat="server" Value="true" />
                                                        <asp:HiddenField ID="HidFactor2" runat="server" />
                                                        <asp:HiddenField ID="HidEstadoRespuesta3" runat="server" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HRespuestaNueva" runat="server" Value="true" />
                                <asp:HiddenField ID="HRespuestaID" runat="server" />
                                <asp:HiddenField ID="HiDPeso" runat="server" Value="true" />
                            </table>
                        </ContentTemplate>

                    </cc1:TabPanel>






                </cc1:TabContainer>
            </td>
        </tr>



    </table>

</asp:Content>
