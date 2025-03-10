<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredInformeCalCartera.aspx.cs" Inherits="CredInformeCalCartera" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="ddl1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">
        <%--     function OnContactSelected(source, eventArgs) {
            document.getElementById("<%= txtEmpre.ClientID %>").value = eventArgs.get_value();
        }--%>
        function preventMultipleSubmissions() {
            $('#<%=Button2.ClientID %>').prop('disabled', true);


            div1.style.backgroundColor = "#ffffff6e";
            div1.style.width = "99%";
            div1.style.height = "100%";
            div1.style.top = "0";
            div1.style.position = "fixed";
            div1.style.zIndex = "100001"
            msjLoad.style.zIndex = "1"

            msjLoad.style.visibility = "visible";
            msjLoad.style.top = "40%";
            msjLoad.style.left = "48%";
            msjLoad.style.position = "fixed";

            msjLoad.style.zIndex = "1000"

        }


        function bloqueacontrol() {
            window.onbeforeunload = preventMultipleSubmissions;
        }

        function validar22(element) {
            confirmar = confirm("Este proceso puede tardar varios minutos debido a la cantidad de cleintes que puedan existir.\n ¿Desea Continuar?");
            if (confirmar) {
                // si pulsamos en aceptar
                return true;
            }
            else {
                // si pulsamos en cancelar
                return false;
            }


            return true;
        }
    </script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <div id="div1">
    </div>


    <div id="msjLoad" style="visibility: hidden; position: fixed;" align="center">
        <img src="Grafix/loader.gif" />
    </div>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Reporte Calificación de Cartera </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td>&nbsp;<asp:CheckBox ID="chkAuxiliar" runat="server" Text="Consultar Auxiliar" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                            <asp:Button ID="Button2" CssClass="botonDes" runat="server" Text="Buscar" ValidationGroup="form" OnClick="Button2_Click" OnClientClick="return validar22(this);" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <asp:Label ID="lblMensaje" Font-Names="Arial" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>


