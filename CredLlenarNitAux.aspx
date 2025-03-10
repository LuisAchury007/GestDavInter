<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredLlenarNitAux.aspx.cs" Inherits="CredLlenarNitAux" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StyleSheetTheme="Tema1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
 <tr>
<td valign="top" class="titulo01">
  Llenar Tabla Auxiliar No. Documento</td>
</tr>
        <tr>
            <td>                                
            <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
            <tr>
            <td>
            <asp:FileUpload ID="FileUpload1" runat="server"/>
            <asp:Button ID="Button1" runat="server" CssClass="botonDes" Text="Subir Archvo y Validar" OnClick="Button1_Click" />
            </td>
            </tr>
            </table>
            </td>
            </tr>
     </table>
 </asp:Content>
