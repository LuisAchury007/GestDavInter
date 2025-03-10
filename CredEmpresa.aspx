<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CredEmpresa.aspx.cs" Inherits="BencEmpresa" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.:: Página sin título ::.</title>
    <style type="text/css">
        .esconder {
            display: none;
        }
    </style>

    <script type="text/javascript">

        function CambioGrafica() {
            var grafica1 = document.getElementById("Chart1");
            //var grafica2 = document.getElementById("Chart2");
            var grafica3 = document.getElementById("Chart3");

            if (cmbTipoGrafica.value == 1) {
                //grafica2.classList.add("esconder");
                grafica3.classList.add("esconder");
                grafica1.classList.remove("esconder");
                /*}
                else if (cmbTipoGrafica.value == 2) {
                    grafica1.classList.add("esconder");
                    grafica3.classList.add("esconder");
                    grafica2.classList.remove("esconder");*/
            } else if (cmbTipoGrafica.value == 3) {
                grafica1.classList.add("esconder");
                //grafica2.classList.add("esconder");
                grafica3.classList.remove("esconder");
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server" method="post">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
        <div>
            <table bgcolor="#ffffff" style="width: 100%; height: 100%" border="0" cellpadding="6" cellspacing="6">
                <tr>
                    <td class="titulo01">&nbsp;<asp:Label ID="lbRazon" runat="server" Text="Label"></asp:Label>
                        &nbsp;
                        <asp:ImageButton
                            ID="ImageButton25" runat="server" ImageUrl="~/Grafix/Download.png" OnClick="ImageButton25_Click" />
                        &nbsp;
                        <asp:DropDownList ID="cmbDivisa" runat="server" OnSelectedIndexChanged="cmbDivisa_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td valign="top" style="width: 100%; height: 100%">
                        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
                            <cc1:TabPanel runat="server" HeaderText="Información Empresa" ID="TabPanel1">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="areaNIT">
                                                <asp:Label ID="lbConcordato" runat="server" Text="Empresa En Concordato" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <%-- <td class="tablaItem" style="width: 200px">Grupo económico</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lblGEconomico" runat="server"></asp:Label></td>--%>
                                                        <td class="tablaItem" style="width: 200px">Sigla</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbSigla" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <%-- <tr>
                                                        <td class="tablaItem" style="width: 200px">Direcci&oacute;n</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbDireccion" runat="server"></asp:Label></td>
                                                        <td class="tablaItem" style="width: 200px">Tel&eacute;fono(s)</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbTelefono" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Fax</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbFax" runat="server" Text="Label"></asp:Label></td>
                                                        <td class="tablaItem" style="width: 200px">Apartado A&eacute;reo</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbApartado" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Ciudad</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbCiudad" runat="server" Text="Label"></asp:Label></td>
                                                        <td class="tablaItem" style="width: 200px">Sector</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbSector" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Correo Electr&oacute;nico</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbCorreo" runat="server"></asp:Label></td>
                                                        <td class="tablaItem" style="width: 200px">Web Site</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbWebsite" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td class="tablaItem">Lista Clinton </td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbListaClin" runat="server" Text="Label"></asp:Label></td>
                                                        <td class="tablaItem">Fecha Consulta </td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbFechaClinto" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>--%>
                                                    <%-- <tr>
                                                        <td class="tablaItem">Ley1116 </td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbLey1116" runat="server" Text="Label"></asp:Label></td>
                                                        <td class="tablaItem">Fecha Consulta </td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbFechaLey" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>--%>
                                                    <%--   <tr>
                                                        <td class="tablaItem">Importador</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbImportador" runat="server" Text="Label"></asp:Label></td>
                                                        <td class="tablaItem">Exportador </td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbExportador" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>--%>
                                                    <tr>
                                                        <%--<td class="tablaItem">Credito de Reestructuración</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbCreReest" runat="server" Text="Label"></asp:Label></td>--%>

                                                        <td class="tablaItem">Es cliente</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lblEsCliente" runat="server" Text="Label"></asp:Label></td>
                                                        <td class="tablaItem"></td>


                                                    </tr>

                                                    <%-- <tr>
                                                        <td class="tablaItem">Fecha publicación R</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lblFechaUltR" runat="server" Text="Label"></asp:Label></td>
                                                        <td class="tablaItem">R publicada </td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbVRPublicada" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>--%>
                                                    <%--  <tr>
                                                        <td class="tablaItem">EEFF</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lblEEFF" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>--%>
                                                    <%-- <tr>
                                                         <td class="tablaItem">Nivel Riesgo</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbNivRiesgo" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Representante Legal</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbRepresentante" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Cargo</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbCargo" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Revisor Fiscal</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbRevisor" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Tipo Sociedad</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbTipoSociedad" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Fecha de Fundaci&oacute;n</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbFundacion" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Objeto Social</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbObjeto" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Numero Matricula</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbNumMatricula" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Ciiu</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbCiiu" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tablaItem" style="width: 200px">Fuente Información</td>
                                                        <td class="tablaValor">
                                                            <asp:Label ID="lbFuente" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label73" runat="server" Text="Ejecutivos y Juntas "
                                                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label><asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton7_Click" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridEjecutivos" CssClass="Grid" runat="server"
                                                                    AutoGenerateColumns="False" EmptyDataText="No Hay Registros" Height="120px" Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Documento" HeaderText="Documento" SortExpression="Documento">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" Text="Accionistas "
                                                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton1_Click" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridAccionistas" CssClass="Grid" runat="server" AutoGenerateColumns="False" EmptyDataText="No Hay Registros" Height="120px" Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="nombre" HeaderText="Socio" SortExpression="nombre">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Participacion" HeaderText="Participacion" SortExpression="Participacion">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="cedula" HeaderText="Documento" SortExpression="cedula">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>



                                </ContentTemplate>



                            </cc1:TabPanel>
                            <%--  <cc1:TabPanel runat="server" HeaderText="C. Cualitativa" ID="TabCualitativa" Visible="false">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tablaEncabezadoOp">
                                                <asp:Label ID="Label7" runat="server" Text="Calificación Cualitativa" ForeColor="White"></asp:Label>


                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="areaInfo">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblTpEncuesta" runat="server" Text="Seleccione la encuesta a Revisar  "></asp:Label>


                                                            <asp:DropDownList ID="CmbCalificacionCualitativa" CssClass="borders" runat="server" OnSelectedIndexChanged="CmbCalificacionCualitativa_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>


                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <asp:Panel ID="PanelEncuesta" runat="server" Visible="False">
                                                                <asp:Label ID="Label2" runat="server"
                                                                    Text="Historico de Encuestas Relacionadas a la Empresa" Style="color: #00CC00; font-size: medium"></asp:Label>


                                                                <br />
                                                                <br />
                                                                <div class="divBord">
                                                                    <asp:GridView ID="GrvHistoricoEncuestas" CssClass="Grid" runat="server" Width="100%"
                                                                        AutoGenerateColumns="False" DataKeyNames="IdPonderado" EmptyDataText="No Hay Registros" OnRowCommand="GrvHistoricoEncuestas_RowCommand">
                                                                        <Columns>
                                                                            <asp:TemplateField SortExpression="RazonSocial">
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btnSeleccionar" CssClass="botonDes" runat="server" Text="Seleccionar" CommandName="Seleccionar" CommandArgument='<%# Eval("IdPonderado") %>' />



                                                                                </ItemTemplate>

                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />

                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" SortExpression="Descripcion">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />

                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="NIT" DataField="NIT" SortExpression="NIT">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />

                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Fecha de Creacion" DataField="FechaCreacion" SortExpression="FechaCreacion">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />

                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Ponderación" DataField="Ponderado" SortExpression="Ponderado">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />

                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="Usurario que Realizo la encuesta" DataField="Usuario" SortExpression="Usuario">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />

                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                        </Columns>
                                                                    </asp:GridView>



                                                                </div>
                                                                <asp:Button ID="Button17" runat="server" CssClass="invisible" Text="Button" />


                                                                <br />
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server"
                                                                    UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <div class="divBord">
                                                                            <asp:GridView ID="GrvSeleccionEncuesta" CssClass="Grid" runat="server" Width="70%"
                                                                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="30"
                                                                                DataKeyNames="idResptCualitativa" ShowFooter="True" OnRowDataBound="GrvSeleccionEncuesta_RowDataBound" Visible="False">
                                                                                <Columns>
                                                                                    <asp:BoundField HeaderText="Agrupacion" DataField="Agrupacion" SortExpression="Agrupacion">
                                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="Variable" DataField="Variable" SortExpression="Variable">
                                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="Respuesta" DataField="Respuesta" SortExpression="Respuesta">
                                                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </div>
                                                                        <table border="0" style="width: 220px">
                                                                            <tr>
                                                                                <td style="font-weight: 400; color: #00CC00;">
                                                                                    <asp:Label ID="lblTotPon" runat="server" Text="Total Ponderado" Visible="False"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtTotalPonderado" runat="server" Height="30px"
                                                                                        Width="77px" Enabled="false" CssClass="borders" Style="font-weight: 700" Visible="False"></asp:TextBox></td>
                                                                            </tr>
                                                                        </table>



                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <asp:ImageButton ID="ImageButton22" runat="server"
                                                                    ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton22_Click1" Visible="False" />

                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </cc1:TabPanel>--%>
                            <%--<cc1:TabPanel runat="server" HeaderText="CPI" ID="TabCPI" Visible="false">
                                <HeaderTemplate>
                                    CPI
                                </HeaderTemplate>

                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tablaEncabezadoOp">
                                                <asp:Label ID="Label1" runat="server" Text="Información referente a la calificación CPI"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tbBord">

                                                <div class="divBord">
                                                    <asp:GridView ID="GridView1" CssClass="Grid" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCpInterno" EmptyDataText="No hay calificaciones registradas" Width="80%" OnRowDataBound="GridView1_RowDataBound1">
                                                        <Columns>
                                                            <asp:BoundField DataField="TotalVectorMes" HeaderText="Vector mes">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PondDiasMora" HeaderText="Promedio dias de mora">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SaldoTotal" HeaderText="Saldos de cartera" DataFormatString="{0:C0}">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CalifCPI" HeaderText="Calificación CPI">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Calificacion" HeaderText="Calificación">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Garantia">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGarantia" runat="server" Text=""></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="CalGtia" HeaderText="Cubrimiento  garantia" DataFormatString="{0:p}">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Anio_Mes" HeaderText="Periodo">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <asp:ImageButton ID="ImageButton99" runat="server"
                                                    ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton99_Click" /></td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </cc1:TabPanel>--%>
                            <%--<cc1:TabPanel runat="server" HeaderText="CPE" ID="TabCPE" Visible="false">
                                <HeaderTemplate>CPE  </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tablaEncabezadoOp">
                                                <asp:Label ID="Label8" runat="server" Text="Información referente a la califiación CPE"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="tbBord">
                                                <div class="divBord">
                                                    <asp:GridView ID="GridViewCPE1" CssClass="Grid" runat="server" AutoGenerateColumns="False" DataKeyNames="IdCpExterno" EmptyDataText="No hay calificaciones registradas" Width="80%">
                                                        <Columns>
                                                            <asp:BoundField DataField="TotalVectorMes" HeaderText="Vector mes">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SaldoTotal" HeaderText="Saldos endeudamiento" DataFormatString="{0:C0}">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CalifCPE" HeaderText="Calificación CPE">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Anio_Mes" HeaderText="Periodo">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Calificacion" HeaderText="Peor letra">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PorcLetra" HeaderText="Participación letra">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FechaSistema" HeaderText="Fecha de cargue">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Usuario" HeaderText="Usuario que realizo cargue">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <asp:ImageButton ID="ImageButton15" runat="server"
                                                    ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton15_Click" /></td>
                                        </tr>

                                    </table>
                                </ContentTemplate>
                            </cc1:TabPanel>--%>
                            <%-- <cc1:TabPanel runat="server" HeaderText="C. Final" ID="TabPanel4" Visible="false">
                                <HeaderTemplate>Calificación Final </HeaderTemplate>
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tablaEncabezadoOp">
                                                <asp:Label ID="Label5" runat="server" Text="Información referente a la calificación Final"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tbBord">
                                                <div class="divBord">
                                                    <asp:GridView ID="GridViewCFinal" CssClass="Grid" runat="server" AutoGenerateColumns="False" DataKeyNames="Anio_Mes" EmptyDataText="No hay calificaciones registradas" Width="80%">
                                                        <Columns>
                                                            <asp:BoundField DataField="Anio_Mes" HeaderText="Periodo">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="RFinal" HeaderText="R Final">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Usuario" HeaderText="Usuario">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FechaSistema" HeaderText="FechaSistema">
                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <asp:ImageButton ID="ImageButton9" runat="server"
                                                    ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton16_Click" /></td>
                                        </tr>
                                        <tr>
                                            <td class="tablaEncabezadoOp">
                                                <asp:Label ID="Label3" runat="server" Text="Reporte Calificación Final"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">

                                                                <asp:GridView ID="gvCalFinal" CssClass="Grid" runat="server" AutoGenerateColumns="False" DataKeyNames="Anio_Mes,RAnual,RParciales,RParcialAnual"
                                                                    EmptyDataText="No hay calificaciones registradas" Width="80%"
                                                                    OnRowCommand="gvCalFinal_RowCommand">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Anio_Mes" HeaderText="Periodo">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField CommandName="Select_RAnual" DataTextField="RAnual"
                                                                            HeaderText="RA">
                                                                            <ControlStyle Font-Italic="True" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:ButtonField>
                                                                        <asp:BoundField DataField="AnioFinanAnual" HeaderText="EEFF">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField CommandName="Select_RParciales" DataTextField="RParciales"
                                                                            HeaderText="RPP">
                                                                            <ControlStyle Font-Italic="True" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:ButtonField>
                                                                        <asp:BoundField DataField="AnioFinanParcial" HeaderText="EEFF">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField CommandName="Select_RParcialAnual" DataTextField="RParcialAnual"
                                                                            HeaderText="RPA">
                                                                            <ControlStyle Font-Italic="True" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:ButtonField>
                                                                        <asp:BoundField DataField="AnioFinanParcialAnual" HeaderText="EEFF">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="RAnualConG" HeaderText="RAG">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="RParcialesConG" HeaderText="RPPG">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="RParcialAnualConG" HeaderText="RPAG">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="RFinal" HeaderText="RPUB">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="AnioRFinal" HeaderText="EEFF">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                    </table>



                                </ContentTemplate>



                            </cc1:TabPanel>--%>
                            <cc1:TabPanel runat="server" HeaderText="Indicadores" ID="TabPanel5" Visible="false">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridIndicadores" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%"></asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton3_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>



                                </ContentTemplate>



                            </cc1:TabPanel>
                            <cc1:TabPanel runat="server" HeaderText="Balance/PyG" ID="TabPanel7" Visible="false">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridBalance" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%" OnRowDataBound="GridBalance_RowDataBound"></asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton5_Click" />
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridAuditado" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%" AutoGenerateColumns="false">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Anio" HeaderText="Añio" >
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>                                                                        
                                                                        <asp:BoundField DataField="Auditado" HeaderText="Auditado" DataFormatString="">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="areaInfo">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GridPyG" runat="server" EmptyDataText="No Hay Registros" Width="100%"></asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton6_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </cc1:TabPanel>
                            <cc1:TabPanel runat="server" HeaderText="Parcial" ID="TabPanel2" Visible="false">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tbBord">

                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridBalanceParcial" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%"></asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton2_Click" /></td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridAuditadoPar" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%" AutoGenerateColumns="false">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Anio" HeaderText="Añio" >
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>                                                                        
                                                                        <asp:BoundField DataField="Auditado" HeaderText="Auditado" DataFormatString="">
                                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="areaInfo">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GridPyGParcial" runat="server" EmptyDataText="No Hay Registros" Width="100%"></asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton4_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </cc1:TabPanel>
                            <cc1:TabPanel runat="server" HeaderText="Ind. Parciales " ID="TabPanel8" Visible="false">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridCuentaAnualiza" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%"></asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton11_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridIndParcial" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%"></asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton3_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>





                                </ContentTemplate>



                            </cc1:TabPanel>
                            <cc1:TabPanel runat="server" HeaderText="Auditoría" ID="TabPanel3" Visible="false">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tablaEncabezadoOp">
                                                <asp:Label ID="Label4" runat="server" Text="Auditoria"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">

                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridAuditoria" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%"></asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton8_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </cc1:TabPanel>
                            <%--   <cc1:TabPanel runat="server" HeaderText="C. Financiera" ID="TabPanel6" Visible="false">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellpadding="6" cellspacing="6">
                                        <tr>
                                            <td class="tablaEncabezadoOp">
                                                <asp:Label ID="Label9" runat="server" Text="Calificación financiera"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tbBord">
                                                <table width="100%" border="0" cellspacing="2" cellpadding="1">

                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridCFinanciera" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%"></asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="tbBord">
                                                <table width="50%" border="0" cellspacing="2" cellpadding="1">
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="CmbCFinan" CssClass="borders" runat="server" OnSelectedIndexChanged="CmbCFinan_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                            <asp:ImageButton ID="imgBtnGrafica" runat="server" CausesValidation="False" ImageUrl="~/Grafix/GraficaBarras.png" Width="25" Height="25" ToolTip="Ver Grafica" OnClick="imgBtnGrafica_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div class="divBord">
                                                                <asp:GridView ID="GridCFinancieraDetalle" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%"
                                                                    OnRowCreated="GridCFinancieraDetalle_RowCreated">
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </cc1:TabPanel>--%>
                            <cc1:TabPanel runat="server" HeaderText="Cargue Hist" ID="TabPanel18">
                                <ContentTemplate>

                                    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridCargues" runat="server" AutoGenerateColumns="False" EmptyDataText="No Hay Archivos" Width="100%" OnRowCommand="GridArchivos_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Nombre Archivo">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="VerArchivoCargues" CommandArgument='<%# Eval("NombreArchivo")  %>' Text='<%# Eval("NombreArchivo") %>'> </asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Nombre" HeaderText="Usuario">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </cc1:TabPanel>

                        </cc1:TabContainer>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="Panel4" runat="server" Style="left: 0% !important; top: 0% !important;">
                            <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="LinkButton1"
                                PopupControlID="Panel4" CancelControlID="BtnCerrar" BackgroundCssClass="ModalBackground" DynamicServicePath="" Enabled="True" />
                            <asp:Panel ID="Panel5" runat="server" Style="border-radius: 5px; background-color: #DDDDDD; border: solid 1px Gray; color: Black" Height="337">
                                <div align="center" style="height: 33px;">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <div align="left">
                                                    <asp:Label ID="lblTipoGrafica" runat="server" Text="Gráfica" Font-Names="Arial" Font-Bold="true"></asp:Label>
                                                    <asp:DropDownList runat="server" ID="cmbTipoGrafica" CssClass="borders">
                                                        <asp:ListItem Text="Calificación R" Value="1" Selected="True"></asp:ListItem>
                                                        <%--<asp:ListItem Text="Detalle Cuantitativa" Value="2"></asp:ListItem>--%>
                                                        <asp:ListItem Text="Detalle Mandatorias y Exogenas" Value="3"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </td>
                                            <td>
                                                <div align="right">
                                                    <asp:ImageButton ID="BtnCerrar" runat="server" CausesValidation="False" ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cerrar" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div align="center">
                                    <asp:Chart ID="Chart1" runat="server" Width="675px" Visible="true">
                                        <Series>
                                            <asp:Series Name="Series1" ChartArea="ChartArea1" YValuesPerPoint="2"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                                <AxisX LineColor="Transparent">
                                                </AxisX>
                                                <AxisX2 LineWidth="0">
                                                </AxisX2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <BorderSkin BorderDashStyle="Solid" />
                                    </asp:Chart>
                                    <asp:Chart ID="Chart3" runat="server" Width="675px" Visible="true" CssClass="esconder">
                                        <Series>
                                            <asp:Series Name="Series1" ChartArea="ChartArea1" YValuesPerPoint="2"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                                <AxisX LineColor="Transparent">
                                                </AxisX>
                                                <AxisX2 LineWidth="0">
                                                </AxisX2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <BorderSkin BorderDashStyle="Solid" />
                                    </asp:Chart>
                                </div>
                            </asp:Panel>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Panel ID="PanelCuant" runat="server" Style="left: 0% !important; top: 0% !important;">
                            <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="LinkButton1"
                                PopupControlID="PanelCuant" CancelControlID="BtnCerrarCuant" BackgroundCssClass="ModalBackground" DynamicServicePath="" Enabled="True" />
                            <asp:Panel ID="Panel2" runat="server" Style="border-radius: 5px; background-color: #DDDDDD; border: solid 1px Gray; color: Black" Height="337">
                                <div align="center" style="height: 33px;">
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                <div align="right">
                                                    <asp:ImageButton ID="BtnCerrarCuant" runat="server" CausesValidation="False" ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cerrar" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div align="center">
                                    <asp:Chart ID="Chart2" runat="server" Width="675px" Visible="true">
                                        <Series>
                                            <asp:Series Name="Series1" ChartArea="ChartArea1" YValuesPerPoint="2"></asp:Series>
                                        </Series>
                                        <ChartAreas>
                                            <asp:ChartArea Name="ChartArea1">
                                                <AxisX LineColor="Transparent">
                                                </AxisX>
                                                <AxisX2 LineWidth="0">
                                                </AxisX2>
                                            </asp:ChartArea>
                                        </ChartAreas>
                                        <BorderSkin BorderDashStyle="Solid" />
                                    </asp:Chart>
                                </div>
                            </asp:Panel>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>




