<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_SociosxEm.aspx.cs" Inherits="Inf_SociosxEm" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/jquery.blockUI.js"></script>


    <script language="JavaScript" type="text/JavaScript">

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

    <table width="100%" border="0" cellpadding="4" cellspacing="4" style="background-color: #ffffff" class="areaBordes">
        <tr>
            <td valign="top" class="titulo01">Reporte Socios por Empresa</td>
        </tr>
        <tr>
            <td class="tablaTitulo">&nbsp; &nbsp;Nit:&nbsp
                                     <asp:TextBox ID="TxtNit" CssClass="borders" runat="server" Width="180px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="TxtNit_FilteredTextBoxExtender"
                    runat="server" Enabled="True" TargetControlID="TxtNit" FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
                &nbsp;<asp:CheckBox ID="ChkSociostodos" runat="server" Text="Todos los Socios" />
                &nbsp;
                                        <asp:Button ID="btExportar" runat="server" Text="Generar" CssClass="botonDes" OnClick="btExportar_Click" ValidationGroup="form" />

            </td>
        </tr>

    </table>

</asp:Content>


