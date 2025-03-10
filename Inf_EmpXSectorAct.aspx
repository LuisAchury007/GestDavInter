<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_EmpXSectorAct.aspx.cs" Inherits="Inf_EmpXSectorAct" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff" class="areaBordes">
        <tr>
            <td valign="top" class="titulo01">Reporte de Empresas por Sector/Actividad </td>
        </tr>


        <tr>
            <td class="tbBord">
                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                    <tr>
                        <td class="tablaTitulo">&nbsp; &nbsp;Seleccionar sector:&nbsp
                                         <asp:DropDownList ID="cmbSectores" runat="server" Height="20px" Width="400px"></asp:DropDownList>
                            &nbsp;&nbsp;<asp:Button ID="Button5" CssClass="botonDes" runat="server" Text="Filtrar" OnClick="Button5_Click" />
                        </td>
                    </tr>

                </table>
            </td>
        </tr>

        <tr>
            <td class="tbBord">
                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                    <tr>
                        <td>
                            <div class="divBord">
                            <asp:GridView ID="grvProyecPendiente" CssClass="Grid"  runat="server" Width="800px" EmptyDataText="No Hay Registros" AllowPaging="True" AllowSorting="True" PagerSettings-Mode="NumericFirstLast"
                                AutoGenerateColumns="False" DataKeyNames="NIT" PageSize="50" OnPageIndexChanging="grvProyecPendiente_PageIndexChanging" OnSorting="Grid_Sorting" OnRowDataBound="grvProyecPendiente_RowDataBound">
                                <Columns>

                                    <asp:BoundField DataField="NIT" HeaderText="NIT" SortExpression="NIT">
                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RazonSocial" HeaderText="Nombre" SortExpression="RazonSocial">
                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                          <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Grupo empresarial">
                                        <ItemTemplate>
                                            <asp:Label ID="lbllGrupoempresarial" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </div>
                        </td>

                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Grafix/Excel.png" OnClick="ImageButton1_Click" />
                            <asp:HiddenField ID="HidTipoBusqueda" runat="server" Value="0" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>



    </table>

</asp:Content>

