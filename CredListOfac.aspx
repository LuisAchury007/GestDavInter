<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredListOfac.aspx.cs" Inherits="CredListOfac" Title=".:: Gestor Comercial y De Credito ::." StyleSheetTheme="Tema1" Theme="Tema1" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
 <tr>
<td valign="top" class="titulo01">
    Lista Clinton (OFAC)</td>
</tr>
<tr>
   <td valign="top">
    <table  bgcolor="#ffffff"  style="width: 100%; height: 100%" border="0" cellpadding="6" cellspacing="6"  class="areaBordes">
   
    <tr>
    <td >Descargar ::     
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="~/Grafix/ListaOFAC.jpg" onclick="ImageButton1_Click" 
            ToolTip="Lista Clinton Descargar" />    </td>
    </tr>
    </table>
      </td>
</tr>
 </table>
 </asp:Content>