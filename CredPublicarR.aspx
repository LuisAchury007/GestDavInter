<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CredPublicarR.aspx.cs" Inherits="CredPublicarR" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/jquery.blockUI.js"></script>


    <script type="text/javascript">

        function OpenLoader() {
            $.blockUI({
                message: '<table style="text-align: center; vertical-align: middle; width: 100%; height: 100%;font-family: Arial;font-size: 18px;"><tr><td><font color="#000"> Cargando... <img src="/GestorInternacional/css/images/loader.gif"/></font></td></tr></table>',
                css: {},
                overlayCSS: {
                    backgroundColor: '#FFFFFF',
                    opacity: 0.6,
                    border: '1px solid #000000'
                }
            });
        }
    </script>

    <table bgcolor="#ffffff" border="0" cellpadding="4" class="areaBordes" cellspacing="4" width="100%">
        <tr>
            <td class="titulo01" valign="top">Publicar R</td>
        </tr>

        <tr>
            <td class="tbBord">   <asp:Label ID="Label73" runat="server" Text="Archivo: "
	 Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                &nbsp;
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Subir Archivo y Validar" OnClick="Button1_Click" OnClientClick="return OpenLoader()" />
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <asp:ListBox ID="ListValidacion" CssClass="borders" runat="server" Visible="false" Width="1097px"></asp:ListBox>
            </td>
        </tr>

    </table>

</asp:Content>

