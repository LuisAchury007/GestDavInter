<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_DatosEmpresa.aspx.cs" Inherits="Conf_DatosEmpresa" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <link href="css/bts.css" rel="stylesheet" />
  
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
        <tr>
            <td>
               <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%" bgcolor="#FFFFFF">
                    <tr>
                        <td class="titulo01" valign="top">
                            <asp:Label ID="lblParametrosCPI" runat="server">Configurar parametros asociados a grupo económico</asp:Label>

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
                                                            <i class="fa fa-plus"></i>Configuración de países
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseTwo" class="panel-collapse collapse  <%= macroState %>">
                                                    <div class="panel-body">

                                                        <table style="width: 600px" border="0">
                                                            <tr>
                                                                <td style="width: 100%" align="left">

                                                                    <table>
                                                                        <tr>
                                                                            <td class="tablaItem">
                                                                                <asp:Label ID="Label73" runat="server" Text="Ingrese el País a buscar"
                                                                                    Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBuscarGrupo" CssClass="borders" runat="server"
                                                                                    Width="320px"></asp:TextBox>
                                                                                <asp:Button ID="btnBuscarGEconomico" CssClass="botonDes" runat="server" Text="Buscar" OnClick="btnBuscarGEconomico_Click" />
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <div class="divBord">
                                                                    <asp:GridView ID="grvPaises" CssClass="Grid" runat="server" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False"
                                                                        EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="CodPais" OnRowDataBound="grvPaises_RowDataBound" OnPageIndexChanging="grvPaises_PageIndexChanging" OnSorting="grvPaises_Sorting" OnRowCommand="grvPaises_RowCommand">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="CodPais" HeaderText="Codigo pais" SortExpression="CodPais">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Pais" HeaderText="Pais" SortExpression="Pais">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                 <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>

                                                                            <asp:TemplateField HeaderText="Filial">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkFilial" runat="server" Enabled="False" />
                                                                                </ItemTemplate>
                                                                                 <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Editar">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("CodPais") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                                    </div>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>

                                                                    <asp:HiddenField ID="HidCodPais" runat="server" Value="true" />
                                                                    <asp:HiddenField ID="HidPais" runat="server" Value="true" />
                                                                    <asp:HiddenField ID="HidFilial" runat="server" Value="true" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100%" align="left">

                                                                    <table>
                                                                        <tr align="center">
                                                                            <td>
                                                                                <table class="style1" style="width: 600px" border="0">
                                                                                    <tr>
                                                                                        <td class="tablaItem">Codigo país</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtCodPais" CssClass="borders" runat="server" TabIndex="220" Width="300px"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="ValRespuesta"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtCodPais"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="tablaItem">País</td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txtPais" CssClass="borders" runat="server" TabIndex="220"
                                                                                                Width="300px"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValRespuesta"
                                                                                                runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtPais"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="tablaItem">&nbsp; Filial</td>
                                                                                        <td>
                                                                                            <asp:CheckBox ID="chkFilial" runat="server" />

                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <asp:ImageButton ID="ImgGuardarPais" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                                ToolTip="Guardar" ValidationGroup="ValRespuesta" Style="height: 27px" OnClick="ImgGuardarPais_Click" />
                                                                                            <asp:ImageButton ID="ImgLimpiarPais" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                                ToolTip="Guardar" OnClick="ImgLimpiarPais_Click" />

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
                                                            <i class="fa fa-plus"></i>Configuración tipo de identificación
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseThree" class="panel-collapse collapse <%= segmentState %>">
                                                    <div class="panel-body">

                                                        <table  style="width: 600px" border="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="divBord">
                                                                    <asp:GridView ID="grvTipoIdentificacion" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                                        EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdTipIdentificacion" OnRowCommand="grvTipoIdentificacion_RowCommand">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="IdTipIdentificacion" HeaderText="Id TipIdentificacion" SortExpression="IdTipIdentificacion">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Editar">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdTipIdentificacion") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
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

                                                                    <asp:HiddenField ID="HidIdentificacion" runat="server" Value="true" />
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <table class="style1" style="width: 600px" border="0">
                                                                        <tr>
                                                                            <td class="tablaItem">Codigo identificación</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCodIdentificacion" CssClass="borders" runat="server" TabIndex="220" Width="300px"></asp:TextBox>
                                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtCodIdentificacion" FilterType="Custom, Numbers" Enabled="True">
                                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ValRespuesta2"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtCodIdentificacion"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Identificación</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtIdentificacion" CssClass="borders" runat="server" TabIndex="220" Width="300px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ValRespuesta2"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtIdentificacion"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ImgGuardarTipoIdentificacion" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuesta2" OnClick="ImgGuardarTipoIdentificacion_Click" />
                                                                                <asp:ImageButton ID="ImgLimpiarPeriodo" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                    ToolTip="Guardar" OnClick="ImgLimpiarPeriodo_Click" />

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
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsefour">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Configuración de Bancas
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapsefour" class="panel-collapse collapse  <%= lvlRiskState %>">
                                                    <div class="panel-body">

                                                        <table  style="width: 600px" border="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="divBord">
                                                                    <asp:GridView ID="GriBanca" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                                        EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdSegmento" OnRowCommand="GriBanca_RowCommand">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="IdSegmento" HeaderText="Id TipIdentificacion" SortExpression="IdSegmento">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                 <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="Segmento" HeaderText="Segmento" SortExpression="Segmento">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                 <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Editar">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdSegmento") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
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

                                                                    <asp:HiddenField ID="HidBanca" runat="server" Value="true" />
                                                                    <asp:HiddenField ID="HiValorBanca" runat="server" Value="0" />
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <table class="style1" style="width: 600px" border="0">
                                                                        <tr>
                                                                            <td class="tablaItem">Banca</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtBanca" CssClass="borders" runat="server" TabIndex="220" Width="300px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="ValRespuesta3"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtBanca"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="imgGuardaBanca" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuesta3" OnClick="imgGuardaBanca_Click" />
                                                                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                    ToolTip="Limpiar" OnClick="ImageButton3_Click" />

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>

                                                            <asp:HiddenField ID="HDTipoIdentificacionID" runat="server" Value="true" />
                                                            <asp:HiddenField ID="HCodPaisesID" runat="server" />
                                                            <asp:HiddenField ID="HidTipoBancaID" runat="server" />

                                                        </table>

                                                    </div>
                                                </div>
                                            </div>
                                            <div class="panel panel-success">
                                                <div class="panel-heading">
                                                    <h4 class="panel-title panel-title-adjust">
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapsefive">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Configuración sector límite GE
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapsefive" class="panel-collapse collapse  <%= lvlRiskState2 %>">
                                                    <div class="panel-body">

                                                        <table  style="width: 600px" border="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="divBord">
                                                                    <asp:GridView ID="GrvSectoresGE" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False" OnRowDataBound="GrvSectoresGE_RowDataBound"
                                                                        EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdSectorGE" OnRowCommand="GrvSectoresGE_RowCommand">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="SectorGE" HeaderText="Sector Límite GE" SortExpression="SectorGE">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>

                                                                            <asp:TemplateField HeaderText="Estado">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkEstado" runat="server" Enabled="False" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Editar">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Editar Secotr" CommandArgument='<%# Eval("IdSectorGE") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    </div>
                                                                    <asp:HiddenField ID="HidSectorGE" runat="server" Value="0" />
                                                                    <asp:HiddenField ID="HidSectorGENom" runat="server" Value="0" />
                                                                    <asp:HiddenField ID="HidchkEstadoSector" runat="server" Value="0" />
                                                                </td>

                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <table class="style1" style="width: 600px" border="0">
                                                                        <tr>
                                                                            <td class="tablaItem">Sector Límite GE</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtSectorGE" CssClass="borders" runat="server" TabIndex="220" Width="300px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="ValRespuesta55"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtSectorGE"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Estado</td>
                                                                            <td>
                                                                                <asp:CheckBox ID="chkEstadoSector" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="imgGuardaSectorGE" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuesta55" OnClick="imgGuardaSectorGE_Click" />
                                                                                <asp:ImageButton ID="imgLimpiaSectorGE" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                    ToolTip="Limpiar" OnClick="imgLimpiaSectorGE_Click" />

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
                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseSix">
                                                            <span class="glyphicon glyphicon-triangle-bottom"></span>
                                                            Configuración  razones por la cual componen o no grupo Económico
                                                        </a>
                                                    </h4>
                                                </div>
                                                <div id="collapseSix" class="panel-collapse collapse  <%= lvlRiskState22 %>">
                                                    <div class="panel-body">

                                                        <table  style="width: 600px" border="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="divBord">
                                                                    <asp:GridView ID="GrvParametrosGE" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False" OnRowDataBound="GrvParametrosGE_RowDataBound"
                                                                        EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdParametroGE" OnRowCommand="GrvParametrosGE_RowCommand">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="ParametrosGE" HeaderText="Parametro" SortExpression="ParametrosGE">
                                                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                                                 <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:BoundField>

                                                                            <asp:TemplateField HeaderText="Estado">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkEstado" runat="server" Enabled="False" />
                                                                                </ItemTemplate>
                                                                                 <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Editar">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Editar Secotr" CommandArgument='<%# Eval("IdParametroGE") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                   </div>
                                                                    <asp:HiddenField ID="HiParametroGE" runat="server" Value="0" />
                                                                    <asp:HiddenField ID="HidNomParametroGC" runat="server" Value="0" />
                                                                    <asp:HiddenField ID="HidEstadoParamGE" runat="server" Value="0" />
                                                                </td>

                                                            </tr>
                                                            <tr align="center">
                                                                <td>
                                                                    <table class="style1" style="width: 600px" border="0">
                                                                        <tr>
                                                                            <td class="tablaItem">Parametro</td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtParametroGE" CssClass="borders" runat="server" TabIndex="220" Width="300px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="ValRespuesta66"
                                                                                    runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtParametroGE"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="tablaItem">Estado</td>
                                                                            <td>
                                                                                <asp:CheckBox ID="ChkParamGE" CssClass="borders" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <asp:ImageButton ID="ImgGuardaParamGE" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                                                    ToolTip="Guardar" ValidationGroup="ValRespuesta66" OnClick="ImgGuardaParamGE_Click" />
                                                                                <asp:ImageButton ID="ImgVolverParamGE" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                                                    ToolTip="Limpiar" OnClick="ImgVolverParamGE_Click" />

                                                                            </td>
                                                                        </tr>
                                                                    </table>
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
