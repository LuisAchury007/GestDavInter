<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="GCCalificacionCualitativa.aspx.cs" Inherits="GCCalificacionCualitativa" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">

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


            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.height = '80%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.width = '90%'; // = anchoActual + 'px';

            altoActual = screen.height * 0.65
            anchoActual = screen.width * 0.94

            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.height = '100%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.width = '100%'; // = anchoActual + 'px';

            var modal = $find('ModalPopupExtender2');  //haciendo referencia al behavior, y NO al id
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "CredEmpresa.aspx?IdSector=" + IdSector + "&NombreSec=" + NombreSec + "&NIT=" + NIT;
            modal.show();
        }
    </script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
        <tr>
            <td valign="top" class="titulo01">Calificacion Cualitativa</td>
        </tr>


        <tr>
            <td valign="top">
                <table width="100%" border="0" cellpadding="10" cellspacing="10" class="areaBordes">
                    <tr>
                        <td class="tbBord" style="height: 51px">&nbsp;
              <asp:Label ID="Label73" runat="server" Text="Ingresar Nit o Nombre de la empresa :"
                  Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;
                            <asp:TextBox ID="txtBuscarEmpresa" CssClass="borders" runat="server"
                                Width="200px"></asp:TextBox>
                            <asp:Button ID="Button18" CssClass="botonDes" runat="server" Text="Buscar"
                                OnClick="Button18_Click" />
                            &nbsp;&nbsp;
                
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 10px">
                            <div class="divBord">
                                <asp:GridView ID="GridEmpresas" CssClass="Grid" runat="server" Width="80%" AllowSorting="True"
                                    AutoGenerateColumns="False" DataKeyNames="NIT"
                                    OnRowCommand="GridEmpresas_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="" SortExpression="RazonSocial">
                                            <ItemTemplate>
                                                <asp:Button ID="btnSeleccionar" CssClass="botonDes" runat="server" Text="Seleccionar" CommandName="Seleccionar" CommandArgument='<%# Eval("NIT") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="NIT" DataField="NIT" SortExpression="NIT">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Razón social" DataField="RazonSocial" SortExpression="RazonSocial">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" SortExpression="Ciudad">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Sector" DataField="Sector" SortExpression="Sector">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbBord">
                            <asp:Label ID="lblTpEncuesta" runat="server" Text="Seleccione la encuesta a realizar:  " Visible="False"
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>

                            &nbsp;<asp:DropDownList ID="CmbCalificacionCualitativa" runat="server" CssClass="borders" AutoPostBack="True" Visible="False" OnSelectedIndexChanged="CmbCalificacionCualitativa_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="PanelEncuesta" runat="server" Visible="False">

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div class="divBord">
                                            <asp:GridView ID="GridEncuesta" CssClass="Grid" runat="server" Width="70%"
                                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="30"
                                                DataKeyNames="IdAgrupacion,IdVariable" OnRowDataBound="GridEncuesta_RowDataBound">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Agrupacion" DataField="Agrupacion" SortExpression="Agrupacion">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="Variable" DataField="Variable" SortExpression="Variable">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Respuesta">
                                                        <ItemTemplate>
                                                            <asp:DropDownList Width="400" runat="server" ID="ddlRespuesta" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlRespuesta_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:Label ID="lblGuardaResp" runat="server" Visible="True"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField HeaderText="Peso" DataField="Peso" SortExpression="Peso">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField HeaderText="VariablePeso" DataField="VariablePeso" SortExpression="VariablePeso">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:GridView ID="GrvSeleccionEncuesta" CssClass="Grid" runat="server" Width="70%"
                                                AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="30"
                                                DataKeyNames="idResptCualitativa" ShowFooter="True">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Agrupacion" DataField="Agrupacion" SortExpression="Agrupacion">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
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

                                        <table border="0" style="width: 200px">
                                            <tr>
                                                <td style="font-weight: 400; color: #00CC00;">
                                                    <asp:Label ID="lblTotPon" runat="server" Text="Total Ponderado" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTotalPonderado" CssClass="borders" runat="server" Height="30px"
                                                        Width="77px" Enabled="false" Style="font-weight: 700" Visible="False"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>


                                    </ContentTemplate>
                                </asp:UpdatePanel>


                                <asp:ImageButton ID="BtnVolver" runat="server" ImageUrl="Grafix/Atras.png" Visible="False" OnClick="BtnVolver_Click" />
                                <asp:ImageButton ID="BtnGuardar" runat="server"
                                    ImageUrl="Grafix/GUARDAR.png" ToolTip="Guardar" OnClick="BtnGuardar_Click" />
                                <asp:ImageButton ID="ImaBotDetalle2" runat="server" ImageUrl="~/Grafix/Editar2.png"
                                    ToolTip="Editar" Visible="False" />
                                <asp:Button ID="Button17" runat="server" Text="Button" CssClass="invisible" />
                                <asp:Label ID="LblTotalPuntaje" runat="server" Text="" Visible="False" aling="Right"></asp:Label>
                                <br />
                                <br />

                                <asp:Label ID="Label2" runat="server" Text="Historico de Encuestas Relacionadas a la Empresa" Visible="False" Style="font-size: large; color: #009900"></asp:Label>
                                <br />
                                <br />
                                <div class="divBord">
                                    <asp:GridView ID="GrvHistoricoEncuestas" CssClass="Grid" runat="server" Width="100%"
                                        AutoGenerateColumns="False" DataKeyNames="IdPonderado" OnRowCommand="GrvHistoricoEncuestas_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="" SortExpression="RazonSocial">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSeleccionar" CssClass="botonDes" runat="server" Text="Seleccionar" CommandName="Seleccionar" CommandArgument='<%# Eval("IdPonderado") %>' />
                                                </ItemTemplate>
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" SortExpression="Descripcion">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="NIT" DataField="NIT" SortExpression="NIT">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Fecha de Creacion" DataField="FechaCreacion" SortExpression="FechaCreacion">
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
                            </asp:Panel>
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
                            <asp:HiddenField ID="HidNombreUsuario" runat="server" />
                            <asp:HiddenField ID="HidSeleccionEncuesta" runat="server" />
                            <asp:HiddenField ID="HIDGridEncuesta" runat="server" />
                            <asp:HiddenField ID="HidEmpresa" runat="server" />
                            <asp:HiddenField ID="HidPonFinal" runat="server" />
                        </td>
                    </tr>

                </table>

            </td>
        </tr>



    </table>

</asp:Content>
