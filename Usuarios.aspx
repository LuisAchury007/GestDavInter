<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" Title=".:: Usuarios Sistemas ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="ddl1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE8" />

    <script type="text/javascript" src="js/btst.js"></script>
    <%--<script src="js/jqueryDos.js" type="text/javascript"></script>--%>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td valign="top" class="titulo01">Configuración de usuarios</td>
                    </tr>
                    <tr align="left">
                        <td>
                            <table class="style1" style="width: 700px;" border="0">

                                <tr>
                                    <td style="width: 100%" align="left">
                                        <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td class="tablaItem">Usuario, Nombre o identificación</td>
                                                <td>
                                                    <asp:TextBox ID="txtBuscarUsuario" CssClass="borders" runat="server"
                                                        Width="300px"></asp:TextBox>
                                                    <asp:Button ID="btnBuscarUsuario" runat="server" Text="Buscar" CssClass="botonDes" OnClick="btnBuscarUsuario_Click" />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="margin-left: 40px">
                            <div class="divBord">
                                <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                    OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting"
                                    PagerSettings-Mode="NumericFirstLast" Width="100%"
                                    OnRowCommand="GridLista_RowCommand">
                                    <Columns>
                                        <asp:BoundField DataField="Identificacion" HeaderText="Identificacion" SortExpression="Identificacion">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Celular" HeaderText="Celular" SortExpression="Celular">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Perfil" HeaderText="Perfil" SortExpression="Perfil">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Intentos" HeaderText="Intentos" SortExpression="Intentos">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaCambioPass" HeaderText="FechaCambioPass" SortExpression="FechaCambioPass">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CambiarObligatorio" HeaderText="CambiarObligatorio" SortExpression="CambiarObligatorio">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Estado" HeaderText="Estado del usuario" SortExpression="Estado">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Cambiar Clave">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Reset" CommandArgument='<%# Eval("IdUsuario") %>' ImageUrl="~/Grafix/Security1.png" AlternateText="Cambiar Clave" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Editar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdUsuario") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Eliminar" CommandArgument='<%# Eval("IdUsuario") %>' ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Realmente desea eliminar el Cliente seleccionado?')){return false;}" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerSettings Mode="NumericFirstLast" />
                                </asp:GridView>
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </div>
                        </td>
                    </tr>
                    <tr align="center">
                        <td>
                            <table class="style1" style="width: 600px" border="1">
                                <tr>
                                    <td class="tablaEncabezadoOp" colspan="2" style="border: none;">Ingreso/Modificación Usuarios</td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; border: none;" align="left">
                                        <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Nombre *</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtNombre" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="TxtNombre"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Usuario *</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtUsuario" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="TxtUsuario"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Identificacion *</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtIdentificacion" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="TxtIdentificacion"></asp:RequiredFieldValidator>
                                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="TxtIdentificacion" FilterType="Numbers">
                                                    </cc1:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="height: 28px; width: 120px;">País</td>
                                                <td class="">
                                                    <ddl1:DropDownCheckBoxes ID="ddlPaisesCliente" runat="server" AddJQueryReference="false"
                                                        AutoPostBack="True" CssClass="borders" Height="25px"
                                                        RepeatDirection="Horizontal" Style="right: 86px; width: 280px !important; top: 0px; left: 0px;"
                                                        UseButtons="False" UseSelectAllNode="False">
                                                        <Texts SelectAllNode="Select all" SelectBoxCaption="Seleccione--" />
                                                    </ddl1:DropDownCheckBoxes>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Correo *</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtCorreo" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="TxtCorreo"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtCorreo"
                                                        ValidationGroup="form" ErrorMessage="Correo Electronico no valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Cargo&nbsp; *</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtCargo" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="TxtCargo"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Telefono &nbsp;</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtTelefono" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="TxtTelefono_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="TxtTelefono" FilterType="Numbers">
                                                    </cc1:FilteredTextBoxExtender>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Extension</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtExtension" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="TxtExtension_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="TxtExtension" FilterType="Numbers">
                                                    </cc1:FilteredTextBoxExtender>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Celular </td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="TxtCelular" CssClass="borders" runat="server" Width="404px"></asp:TextBox>
                                                    <cc1:FilteredTextBoxExtender ID="TxtCelular_FilteredTextBoxExtender"
                                                        runat="server" Enabled="True" TargetControlID="TxtCelular" FilterType="Numbers">
                                                    </cc1:FilteredTextBoxExtender>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="width: 120px">Clave *</td>
                                                <td class="tablaValor">
                                                    <asp:TextBox ID="txtClave" CssClass="borders" runat="server" Width="404px" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtClave"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="La Clave debe ser alfanumerica minimo 6 caracteres maximo 9"
                                                        ValidationExpression="[a-zA-Z0-9]{6,9}" ControlToValidate="txtClave" ValidationGroup="form">
                                                    </asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="height: 70px; width: 120px;">Perfil</td>
                                                <td class="tablaValor">
                                                    <asp:DropDownList ID="CmbPerfil" CssClass="borders" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem" style="height: 28px; width: 120px;">Estado del usuario</td>
                                                <td class="tablaValor">
                                                    <asp:DropDownList ID="CmbEstUsuario" CssClass="borders" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td colspan="7" class="tablaCierre">
                                                    <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                        ToolTip="Guardar" ValidationGroup="form" OnClick="ImageButton19_Click" />

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
                    <asp:HiddenField ID="HNuevo" runat="server" />
                    <asp:HiddenField ID="HIdUsuario" runat="server" />

                </table>
            </td>
        </tr>
    </table>
</asp:Content>



