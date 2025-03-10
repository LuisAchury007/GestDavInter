<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_CNivelRiesgo.aspx.cs" Inherits="Inf_CNivelRiesgo" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff" class="areaBordes">
        <tr>
            <td valign="top" class="titulo01">Reporte Niveles de Riesgo</td>
        </tr>

        <tr>
            <td class="areaInfo">
                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                    <tr>
                        <td class="tablaTitulo">&nbsp; &nbsp;Nit:&nbsp
                                     <asp:TextBox ID="TxtNit" CssClass="borders" runat="server" Width="180px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TxtNit_FilteredTextBoxExtender"
                                runat="server" Enabled="True" TargetControlID="TxtNit" FilterType="Numbers">
                            </cc1:FilteredTextBoxExtender>

                            &nbsp;<asp:CheckBox ID="ChkTodosClientes" runat="server" Text="Todos los clientes" />
                            &nbsp;
                                        <asp:Button ID="Button2" runat="server" CssClass="botonDes" Text="Generar" OnClick="Button2_Click" ValidationGroup="form" />
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td class="tbBord">
                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                    <tr>
                        <td colspan="3">Desde:&nbsp
             <asp:TextBox ID="txtFechaI" runat="server" CssClass="borders" Width="90px"></asp:TextBox>
                            &nbsp;<asp:ImageButton runat="Server" ID="ImageButton27" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                            &nbsp;<cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFechaI" PopupButtonID="ImageButton27" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                            Hasta:&nbsp
             <asp:TextBox ID="txtFechaF" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                            &nbsp;<asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                            &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaF" PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>



                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" CssClass="botonDes"
                                Text="Filtrar" />

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table border="0" cellpadding="1" cellspacing="2" width="100%" align="center">
                                <tr>
                                    <td class="areaInfo">
                                        <div class="divBord">
                                            <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                                OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting" PageSize="20"
                                                PagerSettings-Mode="NumericFirstLast" Width="100%">
                                                <Columns>
                                                    <asp:BoundField DataField="NIT9" HeaderText="Nit 9" SortExpression="NIT9">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RazonSocial" HeaderText="Razón social" SortExpression="RazonSocial">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IdNivelRiesgo" HeaderText="Id Nivel de Riesgo" SortExpression="IdNivelRiesgo" ItemStyle-Width="70">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NivelRiego" HeaderText="Nivel de Riesgo" SortExpression="NivelRiego">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ConEspecial" HeaderText="Condiciones Especiales" SortExpression="ConEspecial">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Instancia" HeaderText="Instancia" SortExpression="Instancia">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RESPONSABLE" HeaderText="Responsable" SortExpression="RESPONSABLE">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OBSERVACIONES" HeaderText="Observaciones" SortExpression="OBSERVACIONES">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FECHAACTA" HeaderText="Fecha Acta" SortExpression="FECHAACTA">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Usuario" HeaderText="Usuario que realiza Cargue" SortExpression="Usuario">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FechaCargue" HeaderText="Fecha Cargue" SortExpression="FechaCargue">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <PagerSettings Mode="NumericFirstLast" />
                                            </asp:GridView>
                                             <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        </div>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>


    </table>

</asp:Content>


