<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CredCalificacionMasiva.aspx.cs" Inherits="CredCalificacionMasiva" StylesheetTheme="Tema1" Theme="Tema1" %>

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
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Calificación Masiva</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                            <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Subir archivo y validar" OnClick="Button1_Click" OnClientClick="return OpenLoader()" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top" class="titulo01">
                <asp:Button runat="server" Text="Procesar" CssClass="botonDes" OnClick="Unnamed1_Click" />
            </td>
        </tr>
    </table>

</asp:Content>

