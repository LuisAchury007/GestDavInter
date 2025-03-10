<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_SectoresIndicadores.aspx.cs" Inherits="Inf_SectoresIndicadores" Theme="Tema1" StylesheetTheme="Tema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table width="100%" border="0" cellpadding="6" cellspacing="6" class="areaBordes">
        <tr class="areaInfo">
            <td class="tablaItem">Sector</td>
            <td class="tablaValor">
                <asp:DropDownList ID="cmbSector" class="borders" runat="server" OnSelectedIndexChanged="cmbSector_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td class="tablaItem">Vigencia</td>
            <td class="tablaValor">
                <asp:DropDownList ID="CmbVigencia" class="borders" runat="server" OnSelectedIndexChanged="CmbVigencia_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="CmbAgregado" class="borders" runat="server" AutoPostBack="True"
                    OnSelectedIndexChanged="CmbAgregado_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="False">Suma</asp:ListItem>
                    <asp:ListItem Value="True">Promedio</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tablaValor">
                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png"
                    OnClick="ImageButton7_Click" />
            </td>
        </tr>
        <tr>
            <td class="tbBord" colspan="6">
                <div class="divBord">
                    <asp:GridView ID="GridLista" CssClass="Grid" runat="server" EmptyDataText="No Hay Registros" Width="100%">
                        <Columns>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td></td>
        </tr>
    </table>


</asp:Content>

