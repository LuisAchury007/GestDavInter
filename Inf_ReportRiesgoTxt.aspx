<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_ReportRiesgoTxt.aspx.cs" Inherits="Inf_ReportRiesgoTxt" StylesheetTheme="Tema1" Theme="Tema1" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff" class="areaBordes">
        <tr>
            <td valign="top" class="titulo01">Reporte TXT</td>
        </tr>
        <tr>
                        <td class="areaInfo">
                            <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                <tr>
                                    <td class="tablaTitulo">

                                        <asp:DropDownList ID="cmbReportes"  CssClass="borders" runat="server"
                                            OnSelectedIndexChanged="cmbReportes_SelectedIndexChanged"
                                            AutoPostBack="True">
                                            <asp:ListItem Value="1">Accionistas</asp:ListItem>
                                            <asp:ListItem Value="2">Balances Anuales</asp:ListItem>
                                            <asp:ListItem Value="3">Indicadores Anuales</asp:ListItem>
                                            <asp:ListItem Value="4">Balances Parciales</asp:ListItem>
                                            <asp:ListItem Value="5">Indicadores Parciales</asp:ListItem>
                                            <asp:ListItem Value="6">Originación</asp:ListItem>
                                            <asp:ListItem Value="7">Niveles de riesgo</asp:ListItem>
                                            <asp:ListItem Value="8">R y Nivel</asp:ListItem>

                                        </asp:DropDownList>
                                        &nbsp;<asp:Label ID="Lanio" runat="server" Text="Año ::" Visible="False"></asp:Label>
                                        &nbsp;<asp:DropDownList ID="cmbanio" runat="server"  CssClass="borders" Visible="False">
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:Button ID="Button2" runat="server"  CssClass="botonDes" Text="Generar" 
                                            OnClick="Button1_Click" />
                                        &nbsp;
                                         <asp:Label ID="lblDesde" runat="server" Text="Desde" Visible="false"></asp:Label>
                                        &nbsp
             <asp:TextBox ID="txtFechaI" runat="server" Width="90px" Visible="false"></asp:TextBox>
                                        &nbsp;<asp:ImageButton runat="Server" ID="ImageButton27" Visible="false" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                                        &nbsp;<cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFechaI" PopupButtonID="ImageButton27" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                         <asp:Label ID="lblHasta" runat="server" Text="Hasta" Visible="false"></asp:Label>&nbsp
             <asp:TextBox ID="txtFechaF" runat="server" Width="90px" Visible="false"></asp:TextBox>
                                        &nbsp;<asp:ImageButton runat="Server" ID="ImageButton2" Visible="false" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaF" PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

    </table>

</asp:Content>
