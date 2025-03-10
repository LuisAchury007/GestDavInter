<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="GCTipoGarantias.aspx.cs" Title=".:: Gestor Comercial y De Credito ::." Inherits="GCTipoGarantias" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellpadding="10" cellspacing="10" class="areaBordes">

                    <tr>
                        <td class="titulo01" valign="top">
                            <asp:Label ID="Label1" runat="server" Text="TIPO GARANTIAS"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="areaInfo">
                            <table width="100%" border="0" cellspacing="2" cellpadding="1">
                                <tr>
                                    <td>
                                        <div class="divBord">
                                            <asp:GridView ID="GrvTipGarantias" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" EmptyDataText="No Hay Reciprocidades Registradas" Width="100%" DataKeyNames="IdTipGarantia" OnPageIndexChanging="GrvTipGarantias_PageIndexChanging" OnRowCommand="GrvTipGarantias_RowCommand" OnSorting="GrvTipGarantias_Sorting">
                                                <Columns>
                                                    <asp:BoundField DataField="IdTipGarantia" HeaderText="Id Garantia">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TipGarantia" HeaderText="Tipo Garantia">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Factor" HeaderText="Factor">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>


                                                    <asp:TemplateField HeaderText="Editar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImaBotDetalle3" runat="server" CausesValidation="False" CommandName="Editar" CommandArgument='<%# Eval("IdTipGarantia") %>' ImageUrl="~/Grafix/Editar2.png" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Eliminar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Eliminar" CommandArgument='<%# Eval("IdTipGarantia") %>' ImageUrl="~/Grafix/papelera.png" OnClientClick="if(!confirm('¿Realmente desea eliminar este dato?')){return false;}" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td>
                                        <table class="style1" style="width: 600px" border="0">
                                            <tr>
                                                <td class="tablaEncabezadoOp" colspan="2">Ingreso/Modificación tipo garantias</td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Id Garantia</td>
                                                <td>
                                                    <asp:TextBox ID="txtIdTipoGarantia" CssClass="borders" runat="server" TabIndex="180" Width="250px"></asp:TextBox><cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender16" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtIdTipoGarantia" ValidChars="/"></cc1:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="txtIdTipoGarantia"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Tipo Garantia</td>
                                                <td>
                                                    <asp:TextBox ID="txtTipGarantias" runat="server" CssClass="borders" TabIndex="180" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="txtTipGarantias"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Factor</td>
                                                <td>
                                                    <asp:TextBox ID="txtFactor" CssClass="borders" runat="server" TabIndex="180" Width="250px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="form"
                                                        runat="server" ErrorMessage="Este campo es requerido"
                                                        ControlToValidate="txtFactor"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td colspan="2">
                                                    <asp:ImageButton ID="btnGuardaGarantia" runat="server"
                                                        ImageUrl="~/Grafix/Guardar.png"
                                                        ToolTip="Guardar" Visible="True" ValidationGroup="form" OnClick="btnGuardaGarantia_Click" />
                                                    <asp:ImageButton ID="btnVolverGarantia" runat="server"
                                                        ImageUrl="Grafix/Limpiar.png" OnClick="btnVolverGarantia_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HidGarantia" runat="server" />
                                <asp:HiddenField ID="HidGarantias" runat="server" Value="0" />
                                <asp:HiddenField ID="HidFactor" runat="server" Value="0" />

                            </table>

                        </td>
                    </tr>

                </table>
            </td>

        </tr>
    </table>
</asp:Content>
