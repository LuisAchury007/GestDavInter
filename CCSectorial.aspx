<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="CCSectorial.aspx.cs" Inherits="CCSectorial" StylesheetTheme="Tema1" Theme="Tema1" %>

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
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
        <tr>
            <td valign="top" class="titulo01">Cargue Calificación Sectorial</td>
        </tr>

        <tr>
            <td valign="top">
                <table width="100%" border="0" cellpadding="10" cellspacing="10" class="areaBordes">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 6px; font-family: arial; font-size: 14px;">Archivo: </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                        <asp:Button ID="Button1" runat="server" CssClass="botonDes" Text="Subir Archivo y Validar" OnClick="Button1_Click" OnClientClick="return OpenLoader()" />

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:ListBox ID="ListValidacion" CssClass="borders" runat="server" Visible="false" Width="1097px"></asp:ListBox>
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

