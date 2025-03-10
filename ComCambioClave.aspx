<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="ComCambioClave.aspx.cs" Inherits="ComCambioClave"  Title=".:: Cambiar Clave ::." Theme="Tema1" StyleSheetTheme="Tema1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>.:: Cambio de Clave Obligatorio ::.</title>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button2" method="post">
    <div>
	<table width="100%" border="0" cellspacing="2" cellpadding="2">
            <tr>
              <td colspan="2" class="tablaTitulo"><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
            <tr>
              <td class="tablaItem">
                  Clave Anterior *</td>
              <td class="tablaValor">
                  <asp:TextBox ID="TxtClaveAnt" runat="server"  TextMode="Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="form" 
                      runat="server" ErrorMessage="Este campo es requerido" 
                      ControlToValidate="TxtClaveAnt"></asp:RequiredFieldValidator>
                  </td>
            </tr>
        
            <tr>
              <td class="tablaItem">
                  Nueva Clave *</td>
              <td class="tablaValor">
                  <asp:TextBox ID="TxtClave" runat="server" TextMode="Password"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="form" 
                      runat="server" ErrorMessage="Este campo es requerido" 
                      ControlToValidate="TxtClave"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="La Clave solo debe ser alfanumerica minimo 6 caracteres maximo 9" 
                ValidationExpression="[a-zA-Z0-9]{6,9}"  ControlToValidate="TxtClave" ValidationGroup="form" >
                </asp:RegularExpressionValidator>                      
                  </td>
            </tr>
             <tr>
              <td class="tablaItem">
                  Confirmar Nueva Clave*</td>
              <td class="tablaValor">
                  <asp:TextBox ID="TxtClaveCon" runat="server" TextMode="Password"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="form" 
                      runat="server" ErrorMessage="Este campo es requerido" 
                      ControlToValidate="TxtClaveCon"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="La Clave solo debe ser alfanumerica minimo 6 caracteres maximo 9" 
                ValidationExpression="[a-zA-Z0-9]{6,9}"  ControlToValidate="TxtClaveCon" ValidationGroup="form" >
                </asp:RegularExpressionValidator>                      
                  </td>
            </tr>
            <tr align="center">
            <td colspan="7" class="tablaCierre">
              <asp:Button ID="Button2" runat="server" Text=":: Cambiar Clave ::" 
                    CssClass="boton1" Width="128px" ValidationGroup="form" onclick="Button2_Click" />
                
            </td>
          </tr>
          </table>
 </div>
    </form>
</body>
</html>

    


