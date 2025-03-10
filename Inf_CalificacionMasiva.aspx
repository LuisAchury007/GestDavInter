<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_CalificacionMasiva.aspx.cs" Inherits="Inf_CalificacionMasiva" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Informe calificacion Masiva</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">

                    <tr>
                        <td class="tbBord" colspan="3">Desde:&nbsp
             <asp:TextBox ID="txtFechaI" runat="server" CssClass="borders" Width="90px"></asp:TextBox>
                            &nbsp;<asp:ImageButton runat="Server" ID="ImageButton27" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                            &nbsp;<cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFechaI" PopupButtonID="ImageButton27" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                            Hasta:&nbsp
             <asp:TextBox ID="txtFechaF" runat="server" CssClass="borders" Width="90px"></asp:TextBox>
                            &nbsp;<asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                            &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaF" PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>



                            <asp:Button ID="Button1" CssClass="botonDes" runat="server" OnClick="Button1_Click"
                                Text="Filtrar" />

                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                <asp:GridView ID="GridLista" runat="server" CssClass="Grid" AllowPaging="True" AllowSorting="True"
                                    AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                    OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting"
                                    PagerSettings-Mode="NumericFirstLast" Width="100%"
                                    OnRowCommand="GridLista_RowCommand" PageSize="50">
                                    <Columns>
                                        <asp:BoundField HeaderText="Fecha" DataField="FechaSistema" SortExpression="FechaSistema">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Estado" DataField="NombreEstado" SortExpression="NombreEstado">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Usuario" DataField="Usuario" SortExpression="Usuario">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Log de Proceso">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="log" CommandArgument='<%# Eval("IdProceso") %>' ImageUrl="~/Grafix/Security1.png" AlternateText="Ver log Procesos" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Calificacion Final">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="Editar" runat="server" AlternateText="Ver Calificacion" CommandArgument='<%# Eval("IdProceso") %>' CommandName="CFinal" ImageUrl="~/Grafix/Editar.png" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                    </div>
                            </asp:Panel>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Grafix/Excel.png"
                                OnClick="ImageButton1_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


</asp:Content>

