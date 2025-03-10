<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfProteger.aspx.cs" Inherits="ConfProteger" Theme="Tema1" StyleSheetTheme="Tema1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <link rel="shortcut icon" href="Grafix/Gestor.ico"/>
</head>
<body>
    <form id="form1" runat="server" method="post">
    
<table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff">
<tr>
<td valign="top" class="titulo01">Configuraci&oacute;n</td>
</tr>
<tr>
<td valign="top">
  <table width="100%" border="0" cellpadding="10" cellspacing="10" class="areaBordes">
	<tr>
	<td class="areaInfo">
	<table width="100%" border="0" cellspacing="2" cellpadding="2">
            <tr>
              <td colspan="2" class="tablaTitulo">Proteger Web Config </td>
              </tr>
            <tr>
              <td class="tablaItem">
                  Clave De Seguridad</td>
              <td class="tablaValor">
                  <asp:TextBox ID="TxtClaveAnt" runat="server"  TextMode="Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form" 
                      runat="server" ErrorMessage="Este campo es requerido" 
                      ControlToValidate="TxtClaveAnt"></asp:RequiredFieldValidator>
                  </td>
            </tr>
        
            <tr align="center">
            <td colspan="7" class="tablaCierre">
              <asp:Button ID="Button2" runat="server" Text=".:: Proteger ::."  CssClass="boton1" ValidationGroup="form" onclick="Button2_Click" />
                <asp:Button ID="Button3" runat="server" Text=".::  Desproteger ::." 
                    CssClass="boton1" ValidationGroup="form" onclick="Button3_Click" />
                
            </td>
          </tr>
          </table>
  </td>
  </tr>
</table>
</td>
  </tr>
</table>
    
    
    </form>
</body>
</html>
