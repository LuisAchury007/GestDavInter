<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_ReportCCualitativa.aspx.cs" Inherits="Inf_ReportCCualitativa" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">
        function OnContactSelected(source, eventArgs) {
            document.getElementById("<%= txtEmpre.ClientID %>").value = eventArgs.get_value();
        }

        var ddlEmp = parent.document.getElementById('ctl00_ContentPlaceHolder1_ddlEmpresas_sl');
        if (ddlEmp != null) { ddlEmp.style.width = 504; }

        var ddlOp = parent.document.getElementById('ctl00_ContentPlaceHolder1_ddlOpciones_sl');
        if (ddlOp != null) { ddlOp.style.width = 180; }
    </script>

    <style type="text/css">
        .comboFuente {
            font-family: Arial;
            font-size: 11px;
        }
    </style>
    <link href="css/bts.css" rel="stylesheet" />

    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff" class="areaBordes">
        <tr>
            <td valign="top" class="titulo01">Reporte Calificación Cualitativa</td>
        </tr>
        <tr>
            <td>
                <div class="container">
                    <div class="row">
                        <div>
                            <div id="accordion" class="panel-group">
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title panel-title-adjust"><a data-parent="#accordion" data-toggle="collapse" href="#collapseOne"><i class="fa fa-plus"></i>Calificación cualitativa por empresa o grupo económico </a></h4>
                                    </div>
                                    <div id="collapseOne" class="panel-collapse collapse  <%= macroState1 %>">
                                        <div class="panel-body" style="overflow: auto; overflow-y: auto; height: 400px">
                                            <table border="0" class="style1" style="width: 1150px">

                                                <tr>
                                                    <td class="tablaTitulo">Empresa:&nbsp
                                                                                <asp:TextBox ID="txtEmpre" CssClass="borders" runat="server" placeholder="Busqueda Empresas: " Width="500px"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="20"
                                                            EnableCaching="False" MinimumPrefixLength="1" OnClientItemSelected="OnContactSelected" ServiceMethod="SearchClients"
                                                            TargetControlID="txtEmpre" DelimiterCharacters="" Enabled="True" ServicePath="">
                                                        </cc1:AutoCompleteExtender>
                                                        &nbsp;&nbsp;
                                                                                <asp:CheckBox ID="chkTodosActas" runat="server" Text="Todas las Empresas" AutoPostBack="True" OnCheckedChanged="chkTodosActas_CheckedChanged" />
                                                        &nbsp; &nbsp;<br />
                                                        <br />
                                                        Tipo de Encuesta:&nbsp
                                                                                <asp:DropDownList ID="CmbCalificacionCualitativa" CssClass="borders" runat="server">
                                                                                </asp:DropDownList>
                                                        &nbsp; Desde:&nbsp
                                                                                <asp:TextBox ID="txtFechaI" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                                                        <asp:ImageButton runat="Server" ID="ImageButton27" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFechaI" PopupButtonID="ImageButton27" Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>

                                                        Hasta:&nbsp
                                                                                <asp:TextBox ID="txtFechaF" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                                                        <asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaF" PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>


                                                        &nbsp;
            

            
		    <asp:Button ID="Button5" runat="server" Text="Filtrar" CssClass="botonDes" OnClick="Button5_Click" />
                                                    </td>

                                                </tr>

                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title panel-title-adjust"><a data-parent="#accordion" data-toggle="collapse" href="#collapseTwo"><i class="fa fa-plus"></i>Calificación cualitativa por Fecha </a></h4>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse  <%= macroState2 %>">
                                        <div class="panel-body" style="overflow: auto; overflow-y: auto; height: 400px">
                                            <table border="0" class="style1" style="width: 1150px">

                                                <tr>
                                                    <td class="tablaTitulo">&nbsp; Desde:&nbsp
                                                                                <asp:TextBox ID="txtFechaInicial" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                                                        <asp:ImageButton runat="Server" ID="imgFechaIni" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaInicial" PopupButtonID="imgFechaIni" Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                        Hasta:&nbsp
                                                                                <asp:TextBox ID="txtxFechaFinal" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                                                        <asp:ImageButton runat="Server" ID="ImgFechaFin" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtxFechaFinal" PopupButtonID="ImgFechaFin" Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                        &nbsp;
                                                                    		    <asp:Button ID="BtnBuscaCualitativa" CssClass="botonDes" runat="server" Text="Filtrar" OnClick="BtnBuscaCualitativa_Click" />
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

</asp:Content>
