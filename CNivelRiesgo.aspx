<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CNivelRiesgo.aspx.cs" Inherits="CNivelRiesgo" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/jquery.blockUI.js"></script>

    <style type="text/css">
        .textoAlineado
        {
            padding-top: 18px;
            padding-left: 5px;
            padding-right: 10px;
        }
    </style>

    <script type="text/javascript">

        function OpenLoader() {
            $.blockUI({
                message: '<table style="text-align: center; vertical-align: middle; width: 100%; height: 100%;font-family: Arial;font-size: 18px;"><tr><td><font color="#000"> Cargando... <img src="/../css/images/loader.gif"/></font></td></tr></table>',
                css: {},
                overlayCSS: {
                    backgroundColor: '#FFFFFF',
                    opacity: 0.6,
                    border: '1px solid #000000'
                }
            });
        }
    </script>
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table bgcolor="#ffffff" border="0" cellpadding="4" cellspacing="4" width="100%" class="areaBordes">
        <tr>
            <td class="titulo01" valign="top">
                <asp:Label ID="lblTituloCNRiesgo" runat="server">Cargue Nivel de Riesgo</asp:Label>

            </td>
        </tr>
        <tr>
            <td class="tbBord">
                <table border="0" cellpadding="4" cellspacing="4" width="100%">
                    <tr>
                        <td style="width: 6px; font-family: arial; font-size: 14px;">Archivo: </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="btnSubirValid" CssClass="botonDes" runat="server" Text="Subir Archivo y Validar" OnClick="btnSubirValid_Click" OnClientClick="return OpenLoader()" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ListBox ID="ListValidacion" CssClass="borders" runat="server" Visible="false" Width="1097px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="font-family: arial; font-size: 14px;">
                            <asp:LinkButton runat="server" ID="lnkExportarErrores" Text="Exportar Errores" Visible="false" OnClick="lnkExportarErrores_Click"></asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="font-family: arial; font-size: 14px;">
                            <asp:CheckBox ID="chkActivaNRiesgoManual" runat="server" AutoPostBack="True" OnCheckedChanged="chkActivaNRiesgoManual_CheckedChanged" Text="Ingresar Niveles de Riesgo Manualmente" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
             <td class="tbBord">
                <asp:Panel ID="PanelNRiesgoManual" runat="server" Visible="False">
                    <table border="0" cellpadding="1" cellspacing="2">
                        <%--<tr style="height: 50px;">
                            <td class="tablaItem textoAlineado">Fecha</td>
                            <td>
                                <asp:TextBox ID="txtFechaNRi" runat="server" Width="90px"></asp:TextBox>
                                <asp:ImageButton runat="Server" ID="ImageButton27" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFechaNRi" PopupButtonID="ImageButton27" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="form1"
                                    runat="server" ErrorMessage="Este campo es requerido"
                                    ControlToValidate="txtFechaNRi"></asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>
                        <tr style="height: 25px;">
                            <td class="tablaItem textoAlineado">NIT 9</td>
                            <td>
                                <asp:TextBox ID="txtNitNRi" CssClass="borders" AutoPostBack="True" runat="server" Height="20px" Width="200px" OnTextChanged="txtNitNRi_TextChanged"></asp:TextBox><br />
                                <asp:Label runat="server">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form1"
                                        runat="server" ErrorMessage="Este campo es requerido"
                                        ControlToValidate="txtNitNRi"></asp:RequiredFieldValidator>
                                </asp:Label>
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtNitNRi" FilterType="Custom, Numbers" ValidChars="," Enabled="True"></cc1:FilteredTextBoxExtender>

                            </td>
                            <td class="tablaItem textoAlineado">Nivel de Riesgo</td>
                            <td>
                                <asp:DropDownList CssClass="borders" ID="cmbNivRiesgo" runat="server" Width="200px">
                                </asp:DropDownList><br />
                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator3" Display="Dynamic" ValidationGroup="form1"
                                    runat="server"
                                    ControlToValidate="cmbNivRiesgo"
                                    ErrorMessage="Este campo es requerido"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tablaItem textoAlineado">Condiciones Especiales</td>
                            <td>
                                <asp:DropDownList ID="CmbCondicionEspecial" CssClass="borders" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator6" Display="Dynamic" ValidationGroup="form1"
                                    runat="server"
                                    ControlToValidate="CmbCondicionEspecial"
                                    ErrorMessage="Este campo es requerido"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr style="height: 50px;">
                            <td class="tablaItem textoAlineado">Instancia</td>
                            <td>
                                <asp:DropDownList CssClass="borders" ID="CmbInstancia" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator4" Display="Dynamic" ValidationGroup="form1"
                                    runat="server"
                                    ControlToValidate="CmbInstancia"
                                    ErrorMessage="Este campo es requerido"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tablaItem textoAlineado">Responsable</td>
                            <td>
                                <asp:DropDownList ID="CmbResponsable" CssClass="borders" runat="server"></asp:DropDownList>
                                <asp:RequiredFieldValidator InitialValue="-1" ID="RequiredFieldValidator5" Display="Dynamic" ValidationGroup="form1"
                                    runat="server"
                                    ControlToValidate="CmbResponsable"
                                    ErrorMessage="Este campo es requerido"></asp:RequiredFieldValidator>
                            </td>
                            <td class="tablaItem textoAlineado">Fecha Acta</td>
                            <td>
                                <asp:TextBox ID="txtFecActaNRi" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                                <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFecActaNRi" PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td class="tablaItem textoAlineado">Observaciones</td>
                            <td colspan="5">
                                <asp:TextBox ID="txtObsNRi" CssClass="borders" runat="server" Height="95px" TextMode="MultiLine" Width="851px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="height: 25px;">
                            <td>
                                <asp:Button ID="btnGuardarNRi" runat="server" Text="Guardar" ValidationGroup="form1" CssClass="botonDes" OnClientClick="if(!confirm('¿Esta seguro de guardar esta información?')){return false;}" OnClick="btnGuardarNRi_Click" />
                            </td>
                        </tr>

                    </table>
                    <br />
                    <table>
                        <tr>
                            <td>
                                <div class="divBord">
                                <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" EmptyDataText="No Hay Registros" Visible="false"
                                    OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting" PageSize="20"
                                    PagerSettings-Mode="NumericFirstLast" Width="100%">
                                    <Columns>
                                        <asp:BoundField DataField="NIT9" HeaderText="Nit 9" SortExpression="NIT9">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RazonSocial" HeaderText="Razón social" SortExpression="RazonSocial">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IdNivelRiesgo" HeaderText="Id Nivel de Riesgo" SortExpression="IdNivelRiesgo" ItemStyle-Width="70">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="NivelRiego" HeaderText="Nivel de Riesgo" SortExpression="NivelRiego">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ConEspecial" HeaderText="Condiciones Especiales" SortExpression="ConEspecial">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Instancia" HeaderText="Instancia" SortExpression="Instancia">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RESPONSABLE" HeaderText="Responsable" SortExpression="RESPONSABLE">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="OBSERVACIONES" HeaderText="Observaciones" SortExpression="OBSERVACIONES">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FECHAACTA" HeaderText="Fecha Acta" SortExpression="FECHAACTA">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario que realiza Cargue" SortExpression="Usuario">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaCargue" HeaderText="Fecha Cargue" SortExpression="FechaCargue">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" />
                                </asp:GridView>
                                     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

