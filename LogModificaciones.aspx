<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="LogModificaciones.aspx.cs" Inherits="LogModificaciones" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StyleSheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Log Cargue</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">

                    <tr>
                        <td class="tbBord" colspan="3">Desde:&nbsp
             <asp:TextBox ID="txtFechaI" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                            &nbsp;<asp:ImageButton runat="Server" ID="ImageButton27" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFechaI" PopupButtonID="ImageButton27" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                            &nbsp;Hasta:&nbsp
             <asp:TextBox ID="txtFechaF" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                            &nbsp;<asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                            &nbsp;<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaF" PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                            Usuario
             <asp:DropDownList ID="CmbUsuarios" runat="server" AutoPostBack="True"
                 OnSelectedIndexChanged="CmbUsuarios_SelectedIndexChanged">
             </asp:DropDownList>

                            &nbsp;<asp:Button ID="Button1" CssClass="botonDes" runat="server" OnClick="Button1_Click"
                                Text="Filtrar" />

                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                <asp:GridView ID="GridLista" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="50"
                                    EmptyDataText="No Hay Registros" OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting">
                                    <Columns>
                                        <asp:BoundField DataField="NIT" HeaderText="NIT" SortExpression="NIT">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="RazonSocial">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" SortExpression="Fecha">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Vigencias" DataField="Vigencias" SortExpression="Vigencias">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Parciales" DataField="Parciales" SortExpression="Parciales">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" SortExpression="Nombre">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Usuario" HeaderText="Usuario" SortExpression="Usuario">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Correcto" HeaderText="Correcto" SortExpression="Correcto">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
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

