<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CGFormCPE.aspx.cs" Inherits="CGFormCPE" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/jquery.blockUI.js"></script>


    <style type="text/css">
        #notificacion {
            background-color: #F2F2F2;
            background-repeat: no-repeat;
            font-family: Helvetica;
            font-size: 20px;
            line-height: 30px;
            position: absolute;
            text-align: center;
            width: 30%;
            left: 35%;
            top: -30px;
        }

        .usuario {
            background-image: url("grafix/usuario.png");
        }

        .corazon {
            background-image: url("grafix/corazon.png");
        }

        .chat {
            background-image: url("grafix/mailIcon.png");
        }

        .notificar {
            background-color: #59AADA;
            border-radius: 6px;
            border: 1px solid #60B4E5;
            color: #FFFFFF;
            display: block;
            font-size: 30px;
            font-weight: bold;
            letter-spacing: -2px;
            margin: 60px auto;
            padding: 20px;
            text-align: center;
            text-shadow: 1px 1px 0 #145982;
            width: 350px;
            cursor: pointer;
        }

            .notificar:hover {
                background-color: #4a94bf;
            }

        #DivBuscando {
            width: 100%;
            height: 100%;
            overflow: hidden;
            top: 0px;
            left: 0px;
            z-index: 10000;
            text-align: center;
            position: absolute;
            background-color: #FFFFFF;
            opacity: 0.8;
        }
    </style>

    <script type="text/javascript">

        function OpenLoader() {
            $.blockUI({
                message: '<table style="text-align: center; vertical-align: middle; width: 100%; height: 100%;font-family: Arial;font-size: 18px;"><tr><td><font color="#000"> Cargando... <img src="/GestorInternacional/css/images/loader.gif"/></font></td></tr></table>',
                css: {},
                overlayCSS: {
                    backgroundColor: '#FFFFFF',
                    opacity: 0.6,
                    border: '1px solid #000000'
                }
            });
        }
    </script>

    <script type="text/javascript">

        function OpenLoader() {
            $.blockUI({
                message: '<table style="text-align: center; vertical-align: middle; width: 100%; height: 100%;font-family: Arial;font-size: 18px;"><tr><td><font color="#000"> Cargando... <img src="/GestorInternacional/css/images/loader.gif"/></font></td></tr></table>',
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

    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">

        <tr>
            <td valign="top">
                <table width="100%" border="0" cellpadding="10" cellspacing="10" class="areaBordes">
                    <tr>
                        <td valign="top" class="titulo01">Comportamiento De Pago Externo (CPE)</td>
                    </tr>

                    <tr>
                        <td class="tbBord">
                            <table>

                                <tr>
                                    <td style="width: 6px; font-family: arial; font-size: 14px;">Archivo: </td>
                                    <td>

                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:Button ID="Button1" runat="server" CssClass="botonDes" Text="Subir Archivo y Validar" OnClick="Button1_Click" OnClientClick="return OpenLoader()" />
                                    </td>
                                </tr>

                            </table>
                            <table>
                                <tr>
                                    <td colspan="2" style="font-family: arial; font-size: 14px;">
                                        <asp:CheckBox ID="chkForAntiguo" runat="server" Text="Subir Formato antiguo" BackColor="#CCCCCC" />

                                    </td>
                                    <td colspan="2" style="font-family: arial; font-size: 14px;">
                                        <asp:CheckBox ID="chkActivaCalifIndividual" runat="server" AutoPostBack="True" OnCheckedChanged="chkActivaCalifIndividual_CheckedChanged" Text="Calificar empresa manualmente" />
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
                                        <td class="tablaItem">No. Documento </td>
                                        <td>
                                            <asp:TextBox ID="txtNitCalif" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>

                                        </td>
                                        <td class="tablaItem">Valor total comercial</td>
                                        <td>
                                            <asp:TextBox ID="txtSaldoCalif" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                        </td>
                                        <td class="tablaItem">Par. comercial</td>
                                        <td>
                                            <asp:TextBox ID="txtDiasMOraCalif" CssClass="borders" runat="server" Height="20px" Width="100px"></asp:TextBox>
                                        </td>
                                        <td class="tablaItem">Calificación comercial</td>
                                        <td>
                                            <asp:TextBox ID="txtcalif" CssClass="borders" runat="server" Height="20px" Width="121px"></asp:TextBox>

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
                                        <td class="tablaItem">Nombre de la entidad</td>
                                        <td>
                                            <asp:TextBox ID="txtNomEntidad" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                        </td>
                                        <td class="tablaItem">Participación arrastre comercial</td>
                                        <td>
                                            <asp:TextBox ID="txtParArasComercial" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tablaItem">Tipo garantia</td>
                                        <td>
                                            <asp:TextBox ID="txtTipoGarant" CssClass="borders" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                        </td>
                                        <td class="tablaItem">Moneda</td>
                                        <td>
                                            <asp:TextBox ID="txtMoneda" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAgregarempresa" CssClass="botonDes" runat="server" Text="Agregar infromación " OnClientClick="if(!confirm('¿Esta seguro de generar esta información?')){return false;}" OnClick="btnAgregarempresa_Click" />
                                        </td>
                                    </tr>

                                </table>
                                <table border="0" cellpadding="1" cellspacing="2" width="100%" align="center">
                                    <tr>
                                        <td>
                                            <div class="divBord">
                                                <asp:GridView ID="GrvCPIManual" CssClass="Grid" runat="server" AutoGenerateColumns="False" DataKeyNames="IDENTIFICACION" EmptyDataText="No Hay Registros" Height="80px" Width="80%" EnableModelValidation="True">
                                                    <Columns>
                                                        <asp:BoundField DataField="NOMBRE_ENTIDAD" HeaderText="Entidad" SortExpression="NOMBRE_ENTIDAD">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IDENTIFICACION" HeaderText="No. Documento" SortExpression="IDENTIFICACION">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="VAL_TOT_COMERCIAL" HeaderText="Valor Total Comercial" SortExpression="VAL_TOT_COMERCIAL" DataFormatString="{0:C0}">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PAR_COMERCIAL" HeaderText="Par. Comercial" SortExpression="PAR_COMERCIAL">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CAL_COMERCIAL" HeaderText="Calificación comercial" SortExpression="CAL_COMERCIAL">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PERIODO_TRIMESTRE" HeaderText="Año" SortExpression="PERIODO_TRIMESTRE">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="PAR_ARRAS_COMERCIAL" HeaderText="Participación Arrastre Comercial" SortExpression="PAR_ARRAS_COMERCIAL">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TIP_GARANTIA" HeaderText="Tipo Garantias" SortExpression="TIP_GARANTIA">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MONEDA" HeaderText="Moneda" SortExpression="MONEDA">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                        </td>
                                    </tr>
                                </table>

                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td class="tbBord" align="left" style="font-family: arial; font-size: 14px;">
                            <asp:Button ID="btnGeneraCalificacion" CssClass="botonDes" runat="server" Text="Generar Calificación CPE" OnClientClick="return OpenLoader()" OnClick="btnGeneraCalificacion_Click" />
                            <asp:Label ID="Label1" runat="server" Text="Generar calificación de CPE en base a la información cargada anteriormente" ForeColor="#999999"></asp:Label>
                        </td>
                    </tr>

                </table>
            </td>
        </tr>

    </table>
</asp:Content>
