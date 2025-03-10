<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CredNewSector.aspx.cs" Inherits="CredNewSector" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">

        function check_VerifCampo(element) {
            var cant = element.value;
            if (cant == '') {
                document.getElementById(element.id).value = "0";
            }

        }

        function check_cantidad(element) {
            var cant = element.value;
            if (isNaN(cant)) {
                alert('Introduce solo valores numericos o Decimales con (.)');
                document.getElementById(element.id).value = "0";
            }
        }




        return true;
    }






    </script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
        <tr>
            <td>
                <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
                    <tr>
                        <td class="titulo01" valign="top">
                            <asp:Label ID="lblSectores" runat="server" Text="Administrar Sectores"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tbBord" colspan="3">
                            <asp:Label ID="Label73" runat="server" Text="Buscar Sector: "
                                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp; &nbsp;
            <asp:TextBox ID="txtBuscar" runat="server" CssClass="borders" Width="368px"></asp:TextBox>

                            &nbsp;<asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Buscar" OnClick="Button1_Click" />

                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%" align="left">
                            <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                <tr>
                                    <td>
                                        <div class="divBord">
                                            <asp:GridView ID="grvSectores" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="IdSector" EmptyDataText="No Hay Registros"
                                                OnRowCommand="grvSectores_RowCommand" OnPageIndexChanging="grvSectores_PageIndexChanging" OnSorting="grvSectores_Sorting">
                                                <Columns>
                                                    <asp:BoundField DataField="IdSector" HeaderText="Cod Sector" SortExpression="IdSector">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sector" HeaderText="Sector" SortExpression="Sector">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Macrosector" HeaderText="Macrosector" SortExpression="Macrosector">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ManoFacturero" HeaderText="ManuFacturero" SortExpression="ManoFacturero">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CIIUDefault" HeaderText="CIIU default" SortExpression="CIIUDefault">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Cuenta" HeaderText="Cuenta" SortExpression="Cuenta">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ValorPyme" HeaderText="Valor Pyme" SortExpression="ValorPyme" DataFormatString="{0:c}">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ValorEmpresarial" HeaderText="Valor Empresarial" SortExpression="ValorEmpresarial" DataFormatString="{0:c}">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ValorCoorporativo" HeaderText="Valor Corporativo" SortExpression="ValorCoorporativo" DataFormatString="{0:c}">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Modelo" HeaderText="Modelo" SortExpression="Modelo">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Factor" HeaderText="Factor" SortExpression="Factor">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha Actualizacion" SortExpression="FechaActualizacion">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NomCualitativa" HeaderText="Formulario Cualitativo" SortExpression="NomCualitativa">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Editar">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Editar" runat="server" AlternateText="Editar Cliente" CommandArgument='<%# Eval("IdSector") %>' CommandName="Editar" CausesValidation="false" ImageUrl="~/Grafix/Editar.png" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>
                                             <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr align="center">
                        <td class="tbBord">
                            <table class="style1" style="width: 600px" border="0">
                                <tr>
                                    <td class="tablaEncabezadoOp" colspan="2">Ingreso datos sectores</td>
                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Codigo Sector</td>
                                    <td class="tablaValor">
                                        <asp:TextBox ID="txtCodSector" CssClass="borders" runat="server" Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtCodSector"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="Filteredtextboxextender4" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="txtCodSector">
                                        </cc1:FilteredTextBoxExtender>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Sector</td>
                                    <td class="tablaValor">
                                        <asp:TextBox ID="txtSector" CssClass="borders" runat="server" Width="350px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtSector"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="tablaItem" style="width: 120px">Manufacturero</td>
                                    <td class="tablaValor">
                                        <asp:CheckBox ID="chkManofacturero" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">CIIU Default</td>
                                    <td class="tablaValor">
                                        <asp:TextBox ID="txtCiiuDefault" CssClass="borders" runat="server" Width="250px"></asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtCiiuDefault" FilterType="Custom, Numbers" Enabled="True">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Cuenta</td>
                                    <td class="tablaValor">
                                        <asp:DropDownList ID="cmbCuenta" CssClass="borders" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Valor Pyme</td>
                                    <td class="tablaValor">
                                        <asp:TextBox ID="txtValotPyme" CssClass="borders" runat="server" Width="250px">0</asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="Filteredtextboxextender1" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="txtValotPyme">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Valor Empresarial</td>
                                    <td class="tablaValor">
                                        <asp:TextBox ID="txtValorEmp" CssClass="borders" runat="server" Width="250px">0</asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="Filteredtextboxextender2" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="txtValorEmp">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Valor Coorporativo</td>
                                    <td class="tablaValor">
                                        <asp:TextBox ID="txtValorCoorp" CssClass="borders" runat="server" Width="250px">0</asp:TextBox>
                                        <cc1:FilteredTextBoxExtender ID="Filteredtextboxextender3" runat="server"
                                            Enabled="True" FilterType="Numbers" TargetControlID="txtValorCoorp">
                                        </cc1:FilteredTextBoxExtender>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Modelo</td>
                                    <td class="tablaValor">
                                        <asp:DropDownList ID="CmbModelo" CssClass="borders" runat="server"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Factor</td>
                                    <td class="tablaValor">
                                        <asp:TextBox ID="txtFactor" CssClass="borders" runat="server" onchange="check_cantidad(this);" Width="250px"></asp:TextBox>                                      
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="form" runat="server" ErrorMessage="Este campo es requerido" ControlToValidate="txtFactor"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="tablaItem" style="width: 120px">Formulario Cualitativo</td>
                                    <td class="tablaValor">
                                        <asp:DropDownList ID="CmbCalificacionCualitativa" CssClass="borders" runat="server" Visible="true"></asp:DropDownList>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ImageButton ID="ImageButton19" runat="server" OnClientClick="return validar(this);" ImageUrl="~/Grafix/Guardar.png"
                                            ToolTip="Guardar" ValidationGroup="form" OnClick="ImageButton19_Click" />
                                        &nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton20" runat="server" CausesValidation="False"
                    ImageUrl="~/Grafix/Limpiar.png" ToolTip="Cancelar" OnClick="ImageButton20_Click" />
                                    </td>
                                </tr>
                                <asp:HiddenField ID="HidSectores" runat="server" />
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

