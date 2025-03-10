<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_AuditoriaProcesos.aspx.cs" Inherits="Inf_AuditoriaProcesos " Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        var cal1;

        function pageLoad() {
            cal1 = $find("calendar1");

            modifyCalDelegates(cal1);
        }

        function modifyCalDelegates(cal) {
            //we need to modify the original delegate of the month cell.
            cal._cell$delegates = {
                mouseover: Function.createDelegate(cal, cal._cell_onmouseover),
                mouseout: Function.createDelegate(cal, cal._cell_onmouseout),

                click: Function.createDelegate(cal, function (e) {
                    /// <summary>
                    /// Handles the click event of a cell
                    /// </summary>
                    /// <param name="e" type="Sys.UI.DomEvent">The arguments for the event</param>

                    e.stopPropagation();
                    e.preventDefault();

                    if (!cal._enabled) return;

                    var target = e.target;
                    var visibleDate = cal._getEffectiveVisibleDate();
                    Sys.UI.DomElement.removeCssClass(target.parentNode, "ajax__calendar_hover");
                    switch (target.mode) {
                        case "prev":
                        case "next":
                            cal._switchMonth(target.date);
                            break;
                        case "title":
                            switch (cal._mode) {
                                case "days": cal._switchMode("months"); break;
                                case "months": cal._switchMode("years"); break;
                            }
                            break;
                        case "month":
                            //if the mode is month, then stop switching to day mode.
                            if (target.month == visibleDate.getMonth()) {
                                //this._switchMode("days");
                            } else {
                                cal._visibleDate = target.date;
                                //this._switchMode("days");
                            }
                            cal.set_selectedDate(target.date);
                            cal._switchMonth(target.date);
                            cal._blur.post(true);
                            cal.raiseDateSelectionChanged();
                            break;
                        case "year":
                            if (target.date.getFullYear() == visibleDate.getFullYear()) {
                                cal._switchMode("months");
                            } else {
                                cal._visibleDate = target.date;
                                cal._switchMode("months");
                            }
                            break;

                        //                case "day":
                        //                    this.set_selectedDate(target.date);
                        //                    this._switchMonth(target.date);
                        //                    this._blur.post(true);
                        //                    this.raiseDateSelectionChanged();
                        //                    break;
                        case "today":
                            cal.set_selectedDate(target.date);
                            cal._switchMonth(target.date);
                            cal._blur.post(true);
                            cal.raiseDateSelectionChanged();
                            break;
                    }
                })
            }
        }

        function onCalendarShown(sender, args) {
            //set the default mode to month
            sender._switchMode("months", true);
            changeCellHandlers(cal1);
        }

        function changeCellHandlers(cal) {
            if (cal._monthsBody) {
                //remove the old handler of each month body.
                for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                    var row = cal._monthsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        $common.removeHandlers(row.cells[j].firstChild, cal._cell$delegates);
                    }
                }
                //add the new handler of each month body.
                for (var i = 0; i < cal._monthsBody.rows.length; i++) {
                    var row = cal._monthsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        $addHandlers(row.cells[j].firstChild, cal._cell$delegates);
                    }
                }
            }
        }


        function onCalendarHidden(sender, args) {
            if (sender.get_selectedDate()) {
                if (cal1.get_selectedDate() && cal2.get_selectedDate() && cal1.get_selectedDate() > cal2.get_selectedDate()) {
                    alert('The "From" Date should smaller than the "To" Date, please reselect!');
                    sender.show();
                    return;
                }
                //get the final date
                var finalDate = new Date(sender.get_selectedDate());
                var selectedMonth = finalDate.getMonth();
                finalDate.setDate(1);
                if (sender == cal2) {
                    // set the calender2's default date as the last day
                    finalDate.setMonth(selectedMonth + 1);
                    finalDate = new Date(finalDate - 1);
                }
                //set the date to the TextBox
                sender.get_element().value = finalDate.format(sender._format);
            }
        }
    </script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>




    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Auditorias Procesos</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td style="font-family: arial; font-size: 14px; width: 250px;" colspan="1">Desde:&nbsp

                            <asp:TextBox ID="txtFechaI" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                            &nbsp;<asp:ImageButton runat="Server" ID="ImageButton27" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" />
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFechaI" PopupButtonID="ImageButton27" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                        </td>
                        <td style="font-family: arial; font-size: 14px; width: 250px;" colspan="1">Hasta:&nbsp

                            <asp:TextBox ID="txtFechaF" CssClass="borders" runat="server" Width="90px"></asp:TextBox>
                            &nbsp;<asp:ImageButton runat="Server" ID="ImageButton2" ImageUrl="~/Grafix/Calendar_scheduleHS.png" AlternateText="Click para mostrar calendario" Height="16px" />
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaF" PopupButtonID="ImageButton2" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                        </td>
                        <td colspan="1" style="font-family: arial; font-size: 14px; width: 325px;">Opcion de Menú:&nbsp
                            <asp:DropDownList ID="cmbModulos" CssClass="borders" runat="server" AutoPostBack="True" Width="200" OnSelectedIndexChanged="cmbModulos_SelectedIndexChanged">
                            </asp:DropDownList>
                            <br />

                        </td>
                        <td colspan="1">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Grafix/Excel.png"
                                OnClick="ImageButton1_Click" ValidationGroup="form1" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table border="0" cellpadding="1" cellspacing="2" width="100%" align="center">
                                <tr>
                                    <td class="areaInfo">
                                        <div class="divBord">
                                            <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" EmptyDataText="No Hay Registros"
                                                OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting" PageSize="20"
                                                PagerSettings-Mode="NumericFirstLast" Width="100%">

                                                <Columns>
                                                    <asp:BoundField DataField="OPCIONAPLICATIVO" HeaderText="Opción Aplicativo" SortExpression="OPCIONAPLICATIVO" ItemStyle-Width="200">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                         <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="USUARIO" HeaderText="Usuario" SortExpression="USUARIO">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                         <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FECHA" HeaderText="Fecha Modificación" SortExpression="FECHA">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                         <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TIPOMODIFICACION" HeaderText="Tipo Modificación" SortExpression="TIPOMODIFICACION">
                                                        <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                         <ItemStyle HorizontalAlign="Left" />
                                                    </asp:BoundField>
                                                    <%--   <asp:BoundField DataField="DIRECCIONIP" Visible="false" HeaderText="Dirección IP" SortExpression="DIRECCIONIP">
                                                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Left" />
                                                </asp:BoundField>--%>
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

