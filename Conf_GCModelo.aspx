<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_GCModelo.aspx.cs" Inherits="Conf_GCModelo" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">

        <tr>
            <td valign="top">

                <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
                    <tr>
                        <td valign="top" class="titulo01">Crear y modifcar modelos</td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <div class="divBord">
                                        <asp:GridView ID="grvModelo" CssClass="Grid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                            EmptyDataText="No Hay Registros" PageSize="10" DataKeyNames="IdModelo" OnRowCommand="grvModelo_RowCommand" OnRowDataBound="grvModelo_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="PesoCPIPyme" HeaderText="Peso CPI Pyme" SortExpression="PesoCPIPyme" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoFinancieraPyme" HeaderText="Peso Financiera Pyme" SortExpression="PesoFinancieraPyme" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoSectorPyme" HeaderText="Peso Sector Pyme" SortExpression="PesoSectorPyme" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoCualitativaPyme" HeaderText="Peso Cualitativa Pyme" SortExpression="PesoCualitativaPyme" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>


                                                <asp:BoundField DataField="PesoCPIEmpre" HeaderText="Peso CPI Empresarial" SortExpression="PesoCPIEmpre" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoFinancieraEmpre" HeaderText="Peso Financiera Empresarial" SortExpression="PesoFinancieraEmpre" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoSectorEmpre" HeaderText="Peso Sector Empresarial" SortExpression="PesoSectorEmpre" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoCualitativaEmpre" HeaderText="Peso Cualitativa Empresarial" SortExpression="PesoCualitativaEmpre" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="PesoCPICoorpo" HeaderText="Peso CPI Coorporativo" SortExpression="PesoCPICoorpo" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoFinancieraCoorpo" HeaderText="Peso Financiera Coorporativo" SortExpression="PesoFinancieraCoorpo" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoSectorCoorpo" HeaderText="Peso Sector Coorporativo" SortExpression="PesoSectorCoorpo" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PesoCualitativaCoorpo" HeaderText="Peso Cualitativa Coorporativo" SortExpression="PesoCualitativaCoorpo" DataFormatString="{0:p}">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>


                                                <asp:BoundField DataField="FechaSistema" HeaderText="Fecha de Creacion" SortExpression="FechaSistema">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Estado">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkEstadoModelo" runat="server" Enabled="False" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Recalcular Empresas">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Recalcular" runat="server" AlternateText="Recalcular C. Fianaciera" CommandArgument='<%# Eval("IdModelo") %>' CommandName="Recalcular" ImageUrl="~/Grafix/pyg.png" OnClientClick="if(!confirm('¿Realmente Desea Recalcular Todas Las Empresas Que Tienen Esto Modelo?')){return false;}" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Activar/Desactivar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Activar" runat="server" AlternateText="Activar Modelo" CommandArgument='<%# Eval("IdModelo") %>' CommandName="Activar" ImageUrl="~/Grafix/dag.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Modelo" CommandArgument='<%# Eval("IdModelo") %>' CommandName="Editar" ImageUrl="~/Grafix/Editar.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                       </div>

                                    </td>

                                </tr>
                                <tr align="center">
                                    <td>
                                        <table class="style1" style="width: 600px" border="0">
                                            <tr>
                                                <td class="tablaEncabezadoOp" colspan="2">Ingreso/Modificacion Modelos</td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Modelo</td>
                                                <td>
                                                    <asp:TextBox ID="txtModelos" CssClass="borders" runat="server" TabIndex="220" Width="250px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tablaItem">Pesos Pymes</td>
                                                <td>
                                                    <table>

                                                        <tr>
                                                            <td class="tablaItem">CPI</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoCPIPyme" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPesoCPIPyme" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="rango1" runat="server"
                                                                    ControlToValidate="txtPesoCPIPyme"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">financiera</td>
                                                            <td>
                                                                <asp:TextBox ID="txtCFinancieraPyme" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtCFinancieraPyme" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server"
                                                                    ControlToValidate="txtCFinancieraPyme"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Sector</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoSectorPyme" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPesoSectorPyme" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator2" runat="server"
                                                                    ControlToValidate="txtPesoSectorPyme"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Cualitativa</td>
                                                            <td>
                                                                <asp:TextBox ID="PesoCCualitativaPyme" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="PesoCCualitativaPyme" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator3" runat="server"
                                                                    ControlToValidate="PesoCCualitativaPyme"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="tablaItem">Pesos Empresarial</td>
                                                <td>
                                                    <table>

                                                        <tr>
                                                            <td class="tablaItem">CPI</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoCPIEmpre" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtPesoCPIEmpre" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator4" runat="server"
                                                                    ControlToValidate="txtPesoCPIEmpre"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">financiera</td>
                                                            <td>
                                                                <asp:TextBox ID="txtCFinancieraEmpre" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtCFinancieraEmpre" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator5" runat="server"
                                                                    ControlToValidate="txtCFinancieraEmpre"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Sector</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoSectorEmpre" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtPesoSectorEmpre" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator6" runat="server"
                                                                    ControlToValidate="txtPesoSectorEmpre"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Cualitativa</td>
                                                            <td>
                                                                <asp:TextBox ID="PesoCCualitativaEmpre" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="PesoCCualitativaEmpre" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator7" runat="server"
                                                                    ControlToValidate="PesoCCualitativaEmpre"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="tablaItem">Pesos Coorporativa</td>
                                                <td>
                                                    <table>

                                                        <tr>
                                                            <td class="tablaItem">CPI</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoCPICoorpo" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txtPesoCPICoorpo" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator8" runat="server"
                                                                    ControlToValidate="txtPesoCPICoorpo"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">financiera</td>
                                                            <td>
                                                                <asp:TextBox ID="txtCFinancieraCoorpo" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtCFinancieraCoorpo" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator9" runat="server"
                                                                    ControlToValidate="txtCFinancieraCoorpo"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Sector</td>
                                                            <td>
                                                                <asp:TextBox ID="txtPesoSectorCoorpo" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtPesoSectorCoorpo" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator10" runat="server"
                                                                    ControlToValidate="txtPesoSectorCoorpo"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="tablaItem">Cualitativa</td>
                                                            <td>
                                                                <asp:TextBox ID="PesoCCualitativaCoorpo" CssClass="borders" runat="server" TabIndex="220" Width="80px"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="PesoCCualitativaCoorpo" FilterType="Custom, Numbers" ValidChars="," Enabled="True">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:RangeValidator ID="RangeValidator11" runat="server"
                                                                    ControlToValidate="PesoCCualitativaCoorpo"
                                                                    MinimumValue="1"
                                                                    MaximumValue="100"
                                                                    Type="Double"
                                                                    Text="El valor debe estar entre 1 y 100!" />
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="2">
                                                    <asp:ImageButton ID="ImgGuardarDias" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                                        ToolTip="Guardar" OnClick="ImgGuardarDias_Click" />
                                                    <asp:ImageButton ID="ImgLimpiarDias" runat="server" ImageUrl="~/Grafix/Limpiar.png"
                                                        ToolTip="Guardar" OnClick="ImgLimpiarDias_Click" />

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>


                    <asp:HiddenField ID="hidModeloNuevo" runat="server" Value="true" />


                </table>

            </td>
        </tr>

    </table>
</asp:Content>
