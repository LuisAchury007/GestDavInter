<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_DatosMacros.aspx.cs" Title=".:: Gestor Comercial y De Credito ::." Inherits="Conf_DatosMacros" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/bts.css" rel="stylesheet" />
    <script type="text/javascript">

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

        function validar() {
            if (ctl00_ContentPlaceHolder1_TxtCualitativa.value == "" ||
                ctl00_ContentPlaceHolder1_TxtRestucturado.value == "" ||
                ctl00_ContentPlaceHolder1_TxtLey1116.value == "" ||
                ctl00_ContentPlaceHolder1_TxtListClinton.value == "" ||
                ctl00_ContentPlaceHolder1_TxtValorCastigo.value == "" ||
                ctl00_ContentPlaceHolder1_txtPisoReest.value == "" ||
                ctl00_ContentPlaceHolder1_txtPiso1116.value == "" ||
                ctl00_ContentPlaceHolder1_txtPisoClinton.value == "" ||
                ctl00_ContentPlaceHolder1_txtPisoCastigo.value == "" ||
                ctl00_ContentPlaceHolder1_TxtDisolucion.value == "" ||
                ctl00_ContentPlaceHolder1_TxtPisoDisolucion.value == ""

            ) {
                alert('Debe completar los campos para guardar');
            } else {
                return true;
            }


        }



        /* FIN: Funcion para limitar el textbox comentarios de la pestaña contactos a solo 255 caracteres */
    </script>
    <link href="css/bts.css" rel="stylesheet" />
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%" style="border: tsolid #C0C0C0; background-color: #FFFFFF;">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td valign="top" class="titulo01">
                            <asp:Label ID="lblTituloTblsParam" runat="server">Tablas Paramétricas</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="container">
                                <div class="row">
                                    <div>
                                        <div class="panel-group" id="accordion">
                                            <div class="panel panel-success">
                                                <%--<div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                                            <i class="fa fa-plus"></i>Vetos Globales
                                                        </a>
                                                    </h4>
                                                </div>--%>
                                               <%-- <div id="collapseTwo" class="panel-collapse collapse  <%= macroState %>">--%>
<%--                                                    <div class="panel-body">

                                                        <table style="width: 600px" border="0" align="center">

                                                            <tr>
                                                                <td class="tbBord">
                                                                    <table border="0" class="style1" style="width: 600px">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label73" runat="server" Text="Exogenas"
                                                                                    Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label></td>
                                                                            <td>
                                                                                <asp:Label ID="Label6" runat="server" Text="Valor"
                                                                                    Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label7" runat="server" Text="Piso"
                                                                                    Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label></td>


                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">
                                                                                <asp:Label ID="Label1" runat="server" CssClass="boton1" Text="Ley 1116"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="TxtLey1116" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="TxtLey1116" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex2" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="TxtLey1116" ValidationGroup="form" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPiso1116" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                               
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtPiso1116" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex6" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtPiso1116" ValidationGroup="form" />
                                                                            </td>


                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">
                                                                                <asp:Label ID="Label2" runat="server" CssClass="boton1" Text="Lista Clinton"></asp:Label>
                                                                            </td>
                                                                            <td class="style4">
                                                                                <asp:TextBox ID="TxtListClinton" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                               
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="TxtListClinton" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex3" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="TxtListClinton" ValidationGroup="form" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPisoClinton" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                               
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtPisoClinton" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex7" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtPisoClinton" ValidationGroup="form" />
                                                                            </td>


                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">
                                                                                <asp:Label ID="Label3" runat="server" CssClass="boton1" Text="Judicializados"></asp:Label>
                                                                            </td>
                                                                            <td class="style4">
                                                                                <asp:TextBox ID="TxtValorCastigo" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                               
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TxtValorCastigo" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex4" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="TxtValorCastigo" ValidationGroup="form" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPisoCastigo" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                               
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtPisoCastigo" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex8" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtPisoCastigo" ValidationGroup="form" />
                                                                            </td>


                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">
                                                                                <asp:Label ID="Label4" runat="server" CssClass="boton1" Text="Reestructuración"></asp:Label>
                                                                            </td>
                                                                            <td class="style4">
                                                                                <asp:TextBox ID="TxtRestucturado" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                               
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TxtRestucturado" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex1" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="TxtRestucturado" ValidationGroup="form" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtPisoReest" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                               
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtPisoReest" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex5" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtPisoReest" ValidationGroup="form" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>

                                                                            <td class="tablaItem">
                                                                                <asp:Label ID="Label5" runat="server" CssClass="boton1" Text="Disolucion"></asp:Label>
                                                                            </td>
                                                                            <td class="style4">
                                                                                <asp:TextBox ID="TxtDisolucion" CssClass="borders" runat="server" Width="350px" autocomplete="off"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="TxtDisolucion" FilterType="Custom, Numbers" ValidChars="," Enabled="True"></ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="TxtDisolucion" ValidationGroup="form" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="TxtPisoDisolucion" CssClass="borders" runat="server" Width="350px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>

                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" TargetControlID="TxtPisoDisolucion" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="TxtPisoDisolucion" ValidationGroup="form" />
                                                                            </td>

                                                                        </tr>




                                                                    </table>
                                                                    <br />
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td>
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 200px">Meses Cualitativa *</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="TxtCualitativa" CssClass="borders" runat="server" Width="404px" autocomplete="off"></asp:TextBox>
                                                                                
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="TxtCualitativa" FilterType="Custom, Numbers" ValidChars="," Enabled="True"></ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="TxtCualitativa" MinimumValue="0" MaximumValue="100" Type="Integer" Text="El valor debe estar entre 1 y 10!" />
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 200px">EEFF Desactualizados *</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="TxtEFDesactualizados" CssClass="borders" runat="server" Width="404px" autocomplete="off"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender14" runat="server" TargetControlID="TxtEFDesactualizados" FilterType="Custom, Numbers" ValidChars="," Enabled="True"></ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="TxtEFDesactualizados" ValidationGroup="form" />
                                                                            </td>
                                                                        </tr>

                                                                        <tr align="center">
                                                                            <td colspan="7" class="tablaCierre">
                                                                                <asp:ImageButton ID="guardarVetos" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" OnClick="guardarVetos_Click" OnClientClick="if(!validar()){return false;}else{return true;}" />
                                                                                &nbsp;&nbsp;&nbsp;                    
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:HiddenField ID="hdfMCualitativa" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfCrRestucturado" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfLey1116" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfListClinton" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfTRMDia" runat="server" Value="" />
                                                        <asp:HiddenField ID="HidValorCastigo" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfPisoReest" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfPiso1116" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfPisoClinton" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfPisoCastigo" runat="server" Value="" />
                                                    </div>
                                                </div>--%>
                                           <%-- </div>--%>



            <%--                                <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">
                                                            <i class="fa fa-plus"></i>Riesgo por Tamaño
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseThree" class="panel-collapse collapse <%= segmentState %>">
                                                    <div class="panel-body">

                                                        <table class="style1" style="width: 600px" border="0" align="left">
                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 200px">Segmento *</td>
                                                                            <td class="tablaValor">
                                                                                <asp:DropDownList ID="cmbSegmento" CssClass="borders" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbSegmento_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                                <br />
                                                                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator5" Display="Dynamic" ValidationGroup="form1"
                                                                                    runat="server"
                                                                                    ControlToValidate="cmbSegmento"
                                                                                    ErrorMessage="Este campo es requerido"></asp:RequiredFieldValidator>

                                                                                <br />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 200px">Modificar Nombre de Segmento* </td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtSegmento" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="form1"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtSegmento"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 200px">Suma Calificación Final*</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtSumarCFinal" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="form1"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtSumarCFinal"></asp:RequiredFieldValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtSumarCFinal" FilterType="Custom, Numbers" ValidChars="," Enabled="True"></ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txtSumarCFinal" MinimumValue="0" MaximumValue="3" Type="Double" Text="El valor debe estar entre 1 y 3!" />

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 200px">Piso Segmento *</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtPisoSegmento" CssClass="borders" runat="server" Width="404px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ValidationGroup="form"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtPisoSegmento"></asp:RequiredFieldValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtPisoSegmento" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex10" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de un coma" ControlToValidate="txtPisoSegmento" ValidationGroup="form" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="center">
                                                                            <td colspan="7" class="tablaCierre">

                                                                                <asp:ImageButton ID="guardarSegmento" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="form1" OnClick="guardarSegmento_Click" />
                                                                                &nbsp;&nbsp;&nbsp;                    
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:HiddenField ID="hdfSumaCalFAnt" runat="server" Value="" />
                                                        <asp:HiddenField ID="hdfPisoSegmento" runat="server" Value="" />
                                                    </div>
                                                </div>
                                            </div>--%>





<%--                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsefour">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Niveles de Riesgo
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapsefour" class="panel-collapse collapse  <%= lvlRiskState %>">
                                                    <div class="panel-body">
                                                        <table style="width: 600px" border="0" align="center">
                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="divBord">
                                                                                    <asp:GridView ID="grNivelRiesgo" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                                                                                        EmptyDataText="No Hay Registros" DataKeyNames="IdNivelRiego" OnRowCommand="grNivelRiesgo_RowCommand">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="IdNivelRiego" HeaderText="Id" SortExpression="IdNivelRiego">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="NivelRiego" HeaderText="Nivel Riesgo" SortExpression="NivelRiego">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />

                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="PisoNivelRiego" HeaderText="Piso Nivel Riesgo" SortExpression="PisoNivelRiego">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Editar" HeaderStyle-Width="50px">
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ImgBtn1" runat="server"
                                                                                                        CommandName="Editar" CommandArgument='<%# Eval("IdNivelRiego") %>'
                                                                                                        ImageUrl="~/Grafix/Editar.png"
                                                                                                        OnClientClick="return true;" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">
                                                                                <asp:Label ID="lblNNombreRiesgo" runat="server" Text="Nivel de Riesgo *"></asp:Label>
                                                                            </td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtNivRiesgo" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="form2"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtNivRiesgo"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">Valor *</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtValRiesgo" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="form2"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtValRiesgo"></asp:RequiredFieldValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtValRiesgo" FilterType="Custom, Numbers" ValidChars="," Enabled="True"></ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RangeValidator ID="RangeValidator8" runat="server" ValidationGroup="form2" ControlToValidate="txtValRiesgo" MinimumValue="0" MaximumValue="3" Type="Double" Text="El valor debe estar entre 1 y 3!" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 200px">Piso Nivel Riesgo *</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtPisoNivRies" CssClass="borders" runat="server" Width="404px" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ValidationGroup="form"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtPisoNivRies"></asp:RequiredFieldValidator>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender15" runat="server" TargetControlID="txtPisoNivRies" FilterType="Custom, Numbers" ValidChars=","
                                                                                    Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RegularExpressionValidator ID="Regex12" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                    ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de un coma" ControlToValidate="txtPisoNivRies" ValidationGroup="form" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">Activo/Inactivo</td>
                                                                            <td class="tablaValor">
                                                                                <asp:CheckBox ID="chkNivelRiesgo" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="center">
                                                                            <td colspan="7" class="tablaCierre">
                                                                                <asp:HiddenField ID="hdfNivRId" runat="server" />
                                                                                <asp:HiddenField ID="hdfNivelRiesgo" runat="server" />
                                                                                <asp:HiddenField ID="hdfValorAnterior" runat="server" Value="" />
                                                                                <asp:HiddenField ID="hdfPisoNivRies" runat="server" Value="" />
                                                                                <asp:HiddenField ID="hdfNivRAct" runat="server" Value="" />
                                                                                <asp:HiddenField ID="hdfNivelRNuevo" runat="server" Value="true" />
                                                                                <asp:ImageButton ID="guardarNivRiesgo" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="form2" OnClick="guardarNivRiesgo_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </div>
                                                </div>
                                            </div>--%>




<%--                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Condiciones Especiales
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseSix" class="panel-collapse collapse  <%= lvlRiskState9 %>">
                                                    <div class="panel-body">
                                                        <table style="width: 600px" border="0" align="center">
                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="divBord">
                                                                                    <asp:GridView ID="grCondicionEsp" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                                                                                        EmptyDataText="No Hay Registros" DataKeyNames="IdConEspecial" OnRowCommand="grCondicionEsp_RowCommand">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="IdConEspecial" HeaderText="Id" SortExpression="IdConEspecial" Visible="true">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="ConEspecial" HeaderText="Condición especial" SortExpression="ConEspecial">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Editar" HeaderStyle-Width="50px">
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ImgBtn1" runat="server"
                                                                                                        CommandName="Editar" CommandArgument='<%# Eval("IdConEspecial") %>'
                                                                                                        ImageUrl="~/Grafix/Editar.png"
                                                                                                        OnClientClick="return true;" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">Condición Especial</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtCondEspecial" runat="server" CssClass="borders" Width="404px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="ValRespuestaCondicion"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtCondEspecial"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">Activo/Inactivo</td>
                                                                            <td class="tablaValor">
                                                                                <asp:CheckBox ID="chkCondEspecial" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:HiddenField ID="hdfCondId" runat="server" />
                                                                                <asp:HiddenField ID="hdfCondEsp" runat="server" />
                                                                                <asp:HiddenField ID="hdfCondAct" runat="server" />
                                                                                <asp:HiddenField ID="hdfCondNueva" runat="server" Value="true" />
                                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuestaCondicion" OnClick="ImageButton1_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>--%>



<%--                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Instancias
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseSeven" class="panel-collapse collapse  <%= lvlRiskState10 %>">
                                                    <div class="panel-body">
                                                        <table style="width: 600px" border="0" align="center">
                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="divBord">
                                                                                    <asp:GridView CssClass="Grid" ID="GridInstancia" runat="server" AutoGenerateColumns="False"
                                                                                        EmptyDataText="No Hay Registros" DataKeyNames="IdInstancia" OnRowCommand="GridInstancia_RowCommand">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="IdInstancia" HeaderText="Id" SortExpression="IdInstancia" Visible="true">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Instancia" HeaderText="Instancia" SortExpression="Instancia">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Editar" HeaderStyle-Width="50px">
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ImgBtn1" runat="server"
                                                                                                        CommandName="Editar" CommandArgument='<%# Eval("IdInstancia") %>'
                                                                                                        ImageUrl="~/Grafix/Editar.png"
                                                                                                        OnClientClick="return true;" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">Instancia</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtInstancia" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ValidationGroup="ValRespuestaInwstancia"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtInstancia"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">Activo/Inactivo</td>
                                                                            <td class="tablaValor">
                                                                                <asp:CheckBox ID="chkInstancia" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:HiddenField ID="hdfInstId" runat="server" />
                                                                                <asp:HiddenField ID="hdfInstancia" runat="server" />
                                                                                <asp:HiddenField ID="hdfInstAct" runat="server" />
                                                                                <asp:HiddenField ID="hdfInstNueva" runat="server" Value="true" />
                                                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuestaInwstancia" OnClick="ImageButton2_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>--%>


<%--                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseeinght">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Responsables
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseeinght" class="panel-collapse collapse  <%= lvlRiskState11 %>">
                                                    <div class="panel-body">
                                                        <table style="width: 600px" border="0" align="center">
                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="divBord">
                                                                                    <asp:GridView ID="grvResponsables" CssClass="Grid" runat="server" AutoGenerateColumns="False"
                                                                                        EmptyDataText="No Hay Registros" DataKeyNames="IdResponsable" OnRowCommand="grvResponsables_RowCommand">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="IdResponsable" HeaderText="Id" SortExpression="IdResponsable" Visible="true">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Responsable" HeaderText="Responsable" SortExpression="Responsable">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:BoundField DataField="Activo" HeaderText="Activo" SortExpression="Activo">
                                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:BoundField>
                                                                                            <asp:TemplateField HeaderText="Editar" HeaderStyle-Width="50px">
                                                                                                <ItemTemplate>
                                                                                                    <asp:ImageButton ID="ImgBtn1" runat="server"
                                                                                                        CommandName="Editar" CommandArgument='<%# Eval("IdResponsable") %>'
                                                                                                        ImageUrl="~/Grafix/Editar.png"
                                                                                                        OnClientClick="return true;" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">Responsable</td>
                                                                            <td class="tablaValor">
                                                                                <asp:TextBox ID="txtResponsable" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ValidationGroup="ValRespuestaResponsable"
                                                                                    runat="server" ErrorMessage="Este campo es requerido"
                                                                                    ControlToValidate="txtResponsable"></asp:RequiredFieldValidator>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">Activo/Inactivo</td>
                                                                            <td class="tablaValor">
                                                                                <asp:CheckBox ID="chkResponsable" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:HiddenField ID="hdfRespId" runat="server" />
                                                                                <asp:HiddenField ID="hdfResponsable" runat="server" />
                                                                                <asp:HiddenField ID="hdfRespAct" runat="server" />
                                                                                <asp:HiddenField ID="hdfRespNueva" runat="server" Value="true" />
                                                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuestaResponsable" OnClick="ImageButton3_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>--%>




<%--                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsefive">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            TRM del dia
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapsefive" class="panel-collapse collapse  <%= lvlRiskState2 %>">
                                                    <div class="panel-body">

                                                        <table style="width: 600px" border="0">
                                                            <tr>
                                                                <td class="tbBord">
                                                                    <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                                        <tr>
                                                                            <td class="tablaItem" style="width: 215px">TRM *</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtTRM" CssClass="borders" runat="server" TabIndex="220" Width="250px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="ValRespuestaTRM"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtTRM"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>


                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ImgGuardarTRM" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuestaTRM" OnClick="ImgGuardarTRM_Click" />


                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </div>
                                                </div>
                                            </div>--%>



<%--                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsenine">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Parametros R
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapsenine" class="panel-collapse collapse  <%= RParameters %>">
                                                    <div class="panel-body">
                                                        <table style="width: 600px" border="0" align="center">

                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <div class="divBord">
                                                                        <asp:GridView ID="GridParametrosR" CssClass="Grid" runat="server" AllowPaging="false" AllowSorting="false"
                                                                            AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                                                            OnRowCommand="GridParametrosR_RowCommand">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="R" HeaderText="R" HeaderStyle-Width="40px">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Piso" HeaderText="Piso" HeaderStyle-Width="50px">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Techo" HeaderText="Techo" HeaderStyle-Width="50px">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Editar" HeaderStyle-Width="50px">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgBtn1" runat="server"
                                                                                            CommandName="Editar" CommandArgument='<%# Eval("R") %>'
                                                                                            ImageUrl="~/Grafix/Editar.png"
                                                                                            OnClientClick="return true;" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="50px">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgBtn2" runat="server" CausesValidation="False"
                                                                                            CommandName="Eliminar" CommandArgument='<%# Eval("R") %>'
                                                                                            ImageUrl="~/Grafix/papelera.png"
                                                                                            OnClientClick="if(!confirm('¿Realmente desea eliminar el Cliente seleccionado?')){return false;}" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                                <td></td>
                                                            </tr>

                                                            <tr align="center">
                                                                <td>
                                                                    <table class="style1" border="0">
                                                                        <tr>
                                                                            <td valign="top" class="tablaEncabezadoOp">Ingreso/Modificación R</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table class="style1" border="0" cellspacing="2" cellpadding="2">
                                                                                    <tr>
                                                                                        <td class="tablaItem">R *</td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:TextBox ID="txtR" CssClass="borders" runat="server" autocomplete="off" onkeyup="return checkMaxLen(this,5)"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfvTxtR" ValidationGroup="ParamR"
                                                                                                runat="server" ErrorMessage="Este campo es requerido"
                                                                                                ControlToValidate="txtR"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">Piso *</td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:TextBox ID="txtPiso" CssClass="borders" runat="server" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfvTxtPiso" ValidationGroup="ParamR"
                                                                                                runat="server" ErrorMessage="Este campo es requerido"
                                                                                                ControlToValidate="txtPiso"></asp:RequiredFieldValidator>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="fteTxtPiso" runat="server" TargetControlID="txtPiso" FilterType="Custom, Numbers" ValidChars=","
                                                                                                Enabled="True">
                                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                                ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtPiso" ValidationGroup="ParamR" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">Techo *</td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:TextBox ID="txtTecho" CssClass="borders" runat="server" autocomplete="off" onkeyup="return checkMaxLen(this,7)"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfvTxtTecho" ValidationGroup="ParamR"
                                                                                                runat="server" ErrorMessage="Este campo es requerido"
                                                                                                ControlToValidate="txtTecho"></asp:RequiredFieldValidator>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="fteTxtTecho" runat="server" TargetControlID="txtTecho" FilterType="Custom, Numbers" ValidChars=","
                                                                                                Enabled="True">
                                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationExpression="\d+\,\d{4}"
                                                                                                ErrorMessage="Se debe ingresar 1 entero y 4 decimales acompañados de una coma" ControlToValidate="txtTecho" ValidationGroup="ParamR" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem"></td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                                ToolTip="Guardar" ValidationGroup="ParamR" OnClick="ImageButton19_Click" />
                                                                                            <asp:ImageButton ID="ImageButton20" runat="server" CausesValidation="False"
                                                                                                ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cancelar" OnClick="ImageButton20_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <asp:HiddenField ID="HRNueva" runat="server" Value="true" />
                                                            <asp:HiddenField ID="hdfR" runat="server" />
                                                            <asp:HiddenField ID="hdfRPiso" runat="server" />
                                                            <asp:HiddenField ID="hdfRTecho" runat="server" />
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>--%>




                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse10">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Divisas
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapse10" class="panel-collapse collapse  <%= ForExchange %>">
                                                    <div class="panel-body">
                                                        <table style="width: 600px" border="0" align="center">

                                                            <tr>
                                                                <td style="width: 100%" align="center">
                                                                    <div class="divBord">
                                                                        <asp:GridView ID="GridDivisas" CssClass="Grid" runat="server" AllowPaging="false" AllowSorting="false"
                                                                            AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                                                            OnRowCommand="GridDivisas_RowCommand">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="IdDivisa" HeaderText="Id Divisa" HeaderStyle-Width="40px">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Codigo" HeaderText="Código" HeaderStyle-Width="50px">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="coduiaf" HeaderText="Código UIAF" HeaderStyle-Width="50px">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="divisa" HeaderText="Divisa" HeaderStyle-Width="50px">
                                                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Editar" HeaderStyle-Width="50px">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgBtn1" runat="server"
                                                                                            CommandName="Editar" CommandArgument='<%# Eval("IdDivisa") %>'
                                                                                            ImageUrl="~/Grafix/Editar.png"
                                                                                            OnClientClick="return true;" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="50px">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="ImgBtn2" runat="server" CausesValidation="False"
                                                                                            CommandName="Eliminar" CommandArgument='<%# Eval("IdDivisa") %>'
                                                                                            ImageUrl="~/Grafix/papelera.png"
                                                                                            OnClientClick="if(!confirm('¿Realmente desea eliminar la divisa seleccionada?')){return false;}" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                                <td></td>
                                                            </tr>

                                                            <tr align="center">
                                                                <td>
                                                                    <table class="style1" border="0">
                                                                        <tr>
                                                                            <td valign="top" class="tablaEncabezadoOp">Ingreso/Modificación Divisa</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table class="style1" border="0" cellspacing="2" cellpadding="2">
                                                                                    <tr>
                                                                                        <td class="tablaItem">Id Divisa *</td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:TextBox ID="txtIdDiv" CssClass="borders" runat="server" autocomplete="off" MaxLength="15"></asp:TextBox>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="ftetxtIdDiv" runat="server" TargetControlID="txtIdDiv" FilterType="Numbers"
                                                                                                Enabled="True">
                                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                                            <asp:RequiredFieldValidator ID="rfvtxtIdDiv" ValidationGroup="Div"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtIdDiv"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">Código *</td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:TextBox ID="txtCodDiv" CssClass="borders" runat="server" autocomplete="off" MaxLength="10"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfvtxtCodDiv" ValidationGroup="Div"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtCodDiv"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">Código UIAF *</td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:TextBox ID="txtCodUiafDiv" CssClass="borders" runat="server" autocomplete="off" MaxLength="15"></asp:TextBox>
                                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="ftetxtCodUiafDiv" runat="server" TargetControlID="txtCodUiafDiv" FilterType="Numbers"
                                                                                                Enabled="True">
                                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                                            <asp:RequiredFieldValidator ID="rfvtxtCodUiafDiv" ValidationGroup="Div"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtCodUiafDiv"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">Divisa *</td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:TextBox ID="txtDescDiv" CssClass="borders" runat="server" autocomplete="off" MaxLength="50"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="rfvtxtDescDiv" ValidationGroup="Div"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtDescDiv"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem"></td>
                                                                                        <td class="tablaValor">
                                                                                            <asp:ImageButton ID="imgBtnGuardaDiv" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                                ToolTip="Guardar" ValidationGroup="Div" OnClick="imgBtnGuardaDiv_Click" />
                                                                                            <asp:ImageButton ID="imgBtnClearDiv" runat="server" CausesValidation="False"
                                                                                                ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cancelar" OnClick="imgBtnClearDiv_Click" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <asp:HiddenField ID="hdfDivNew" runat="server" Value="true" />
                                                            <asp:HiddenField ID="hdfDiv" runat="server" />
                                                            <asp:HiddenField ID="hdfIdDiv" runat="server" />
                                                            <asp:HiddenField ID="hdfCodDiv" runat="server" />
                                                            <asp:HiddenField ID="hdfCodUiafDiv" runat="server" />
                                                            <asp:HiddenField ID="hdfDescDiv" runat="server" />
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse11">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Conversión Divisa
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapse11" class="panel-collapse collapse  <%= ConvForExchange %>">
                                                    <div class="panel-body">
                                                        <table style="width: 600px" border="0" align="center">
                                                            <tr>
                                                                <td valign="top" colspan="3" class="tablaEncabezadoOp">Ingreso/Modificación Conversión Divisas</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem">Periodo *</td>
                                                                <td class="tablaValor">
                                                                    <asp:TextBox ID="txtPeriodoDiv" CssClass="borders" runat="server" autocomplete="off" MaxLength="6"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftetxtPeriodoDiv" runat="server" TargetControlID="txtPeriodoDiv" FilterType="Numbers"
                                                                        Enabled="True">
                                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                                    <asp:RequiredFieldValidator ID="rfvtxtPeriodoDiv" ValidationGroup="ConvDiv"
                                                                        runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtPeriodoDiv"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td class="tablaValor">
                                                                    <asp:Button ID="btnBuscaConv" runat="server" CssClass="botonDes" Text="Buscar"
                                                                        ToolTip="Buscar" ValidationGroup="ConvDiv" OnClick="btnBuscaConv_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%" align="center" colspan="3">
                                                                    <div class="divBord">
                                                                        <asp:GridView ID="GridConvxDivisa" runat="server" AutoGenerateColumns="False"
                                                                            ShowFooter="True" DataKeyNames="IdDivisa,Anio" EmptyDataText="No hay información registrada"
                                                                            Width="100%" OnRowDataBound="GridConvxDivisa_RowDataBound" OnRowCommand="GridConvxDivisa_RowCommand">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="divisa" HeaderText="Divisa" HeaderStyle-Width="60%">
                                                                                    <HeaderStyle Font-Bold="True" HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:BoundField>
                                                                                <asp:TemplateField HeaderText="Conversión">
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtConversion" autocomplete="off" runat="server" Height="20px" Enabled="False" MaxLength="17"
                                                                                            Width="80%" Style="text-align: right;"></asp:TextBox>
                                                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftetxtConversion" runat="server"
                                                                                            TargetControlID="txtConversion" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                                        </ajaxToolkit:FilteredTextBoxExtender>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Eliminar" HeaderStyle-Width="50px">
                                                                                    <ItemTemplate>
                                                                                        <asp:ImageButton ID="imgBtnEliminaConv" runat="server" CausesValidation="False"
                                                                                            CommandName="Eliminar" CommandArgument='<%# Eval("IdDivisa") %>'
                                                                                            ImageUrl="~/Grafix/papelera.png"
                                                                                            OnClientClick="if(!confirm('¿Realmente desea eliminar la conversión seleccionada?')){return false;}" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tablaItem"></td>
                                                                <td class="tablaValor" colspan="2">
                                                                    <asp:ImageButton ID="imgBtnGuardaConDiv" runat="server" ImageUrl="~/Grafix/Guardar.png" Visible="false"
                                                                        ToolTip="Guardar" ValidationGroup="ConvDiv" OnClick="imgBtnGuardaConDiv_Click" />
                                                                    <asp:ImageButton ID="imgBtnClearConDiv" runat="server" CausesValidation="False" Visible="false"
                                                                        ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cancelar" OnClick="imgBtnClearConDiv_Click" />
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

