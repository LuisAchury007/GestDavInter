<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CGFormCPI.aspx.cs" Inherits="CGFormCPI" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/jquery.blockUI.js"></script>


    <script language="JavaScript" type="text/JavaScript">
        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = "abcde";
            especiales = "8-37-39-46";

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial) {
                return false;
            }
        }

        function OpenLoader() {
            $.blockUI({
                message: '<table style="text-align: center; vertical-align: middle; width: 100%; height: 100%;font-family: Arial;font-size: 18px;"><tr><td><font color="#000"> Cargando... <img src="/GestorInternacional/Grafix/loader.gif"/></font></td></tr></table>',
                css: {},
                overlayCSS: {
                    backgroundColor: '#FFFFFF',
                    opacity: 0.6,
                    border: '1px solid #000000'
                }
            });
        }
    </script>
    <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/bts.js"></script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">


        <tr>
            <td valign="top">
                <table width="100%" border="0" cellpadding="10" cellspacing="10" class="areaBordes">
                    <tr>
                        <td valign="top" class="titulo01">Comportamiento De Pago Interno (CPI)</td>
                    </tr>
                    <tr>
                        <td class="tbBord">
                            <table>
                                <tr>
                                    <td style="width: 6px; font-family: arial; font-size: 14px;">Archivo: </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Subir Archivo y Validar" OnClick="Button1_Click" OnClientClick="return OpenLoader()" />

                                    </td>
                                </tr>


                                <tr>
                                    <td colspan="2">
                                        <asp:ListBox ID="ListValidacion" CssClass="borders" runat="server" Visible="false" Width="1097px"></asp:ListBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2" style="font-family: arial; font-size: 14px;">
                                        <br />
                                        <asp:CheckBox ID="chkActivaCalifIndividual" runat="server" AutoPostBack="True" Text="Calificar empresa manualmente" OnCheckedChanged="chkActivaCalifIndividual_CheckedChanged" />
                                    </td>

                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbBord">
                            <asp:Panel ID="PanelCalifManual" runat="server" Visible="False">

                                <table border="0" cellpadding="1" cellspacing="2" width="100%">
                                    <tr>
                                        <td class="tablaItem">No. Documento</td>
                                        <td>
                                            <asp:TextBox ID="txtNitCalif" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtNitCalif" FilterType="Custom, Numbers" Enabled="True">
                                            </ajaxToolkit:FilteredTextBoxExtender>

                                        </td>
                                        <td class="tablaItem">Valor de la exposición</td>
                                        <td>
                                            <asp:TextBox ID="txtSaldoCalif" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtSaldoCalif" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td class="tablaItem">Días mora</td>
                                        <td>
                                            <asp:TextBox ID="txtDiasMOraCalif" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDiasMOraCalif" FilterType="Custom, Numbers" Enabled="True">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td class="tablaItem">Calificación SARC del cliente</td>
                                        <td>
                                            <asp:TextBox ID="txtcalif" CssClass="borders" runat="server" Height="20px" onkeypress="return soloLetras(event)" Width="121px"></asp:TextBox>


                                        </td>
                                    </tr>
                                    <tr>

                                        <td class="tablaItem">Año</td>
                                        <td>
                                            <asp:DropDownList ID="CmbAnioCalif" CssClass="borders" runat="server" Width="120px">
                                                <asp:ListItem Value="-1">--Seleccione--</asp:ListItem>
                                                <asp:ListItem Value="1">2016</asp:ListItem>
                                                <asp:ListItem Value="2">2017</asp:ListItem>
                                                <asp:ListItem Value="3">2018</asp:ListItem>
                                                <asp:ListItem Value="4">2019</asp:ListItem>
                                                <asp:ListItem Value="5">2016</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="tablaItem">Mes</td>
                                        <td>
                                            <asp:DropDownList ID="cmbMescalif" CssClass="borders" runat="server" Width="120px">
                                                <asp:ListItem Value="-1">--Seleccione--</asp:ListItem>
                                                <asp:ListItem Value="1">01</asp:ListItem>
                                                <asp:ListItem Value="2">02</asp:ListItem>
                                                <asp:ListItem Value="3">03</asp:ListItem>
                                                <asp:ListItem Value="4">04</asp:ListItem>
                                                <asp:ListItem Value="5">05</asp:ListItem>
                                                <asp:ListItem Value="6">06</asp:ListItem>
                                                <asp:ListItem Value="7">07</asp:ListItem>
                                                <asp:ListItem Value="8">08</asp:ListItem>
                                                <asp:ListItem Value="9">09</asp:ListItem>
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                <asp:ListItem Value="12">12</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="tablaItem">Marca de reestructurado</td>
                                        <td>
                                            <asp:TextBox ID="txtReessCalif" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                        </td>
                                        <td class="tablaItem">Tipo de Garantía</td>
                                        <td>
                                            <asp:DropDownList ID="CmbTipoGarnat" CssClass="borders" runat="server" Width="200px">
                                            </asp:DropDownList>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td class="tablaItem">Porcentaje de Cubrimiento de la Garantía</td>
                                        <td>
                                            <asp:TextBox ID="txtCGtiaCalif" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtCGtiaCalif" FilterType="Custom,Numbers" ValidChars="." Enabled="True">
                                            </ajaxToolkit:FilteredTextBoxExtender>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAgregarempresa" runat="server" Text="Agregar infromación " OnClientClick="if(!confirm('¿Esta seguro de generar esta información?')){return false;}" CssClass="botonDes" OnClick="btnAgregarempresa_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="1" cellspacing="2" width="100%" align="center">
                                    <tr>
                                        <td>
                                            <div class="divBord">
                                                <asp:GridView ID="GrvCPIManual" CssClass="Grid" runat="server" AutoGenerateColumns="False" DataKeyNames="IDSINDIGIT" EmptyDataText="No Hay Registros" Height="80px" Width="80%" EnableModelValidation="True">
                                                    <Columns>
                                                        <asp:BoundField DataField="IDSINDIGIT" HeaderText="No. Documento" SortExpression="IDSINDIGIT">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SALDOCAP" HeaderText="Valor de la exposición" SortExpression="SALDOCAP" DataFormatString="{0:C0}">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="DIASMORA" HeaderText="Días mora" SortExpression="DIASMORA">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CALIF" HeaderText="Calificación" SortExpression="CALIF">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ANIO_MES" HeaderText="Año" SortExpression="ANIO_MES">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <br />

                                        </td>
                                    </tr>
                                </table>

                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td class="tbBord" align="left" style="font-family: arial; font-size: 14px;">
                            <asp:Button ID="btnGeneraCalificacion" runat="server" Text="Generar Calificación CPI" OnClick="btnGeneraCalificacion_Click" CssClass="botonDes" OnClientClick="return OpenLoader()" />
                            <asp:Label ID="Label1" runat="server" Text="Generar calificación de CPI en base a la información cargada anteriormente" ForeColor="#999999"></asp:Label>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>

    </table>
</asp:Content>
