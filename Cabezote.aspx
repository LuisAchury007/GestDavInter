<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cabezote.aspx.cs" Inherits="Cabezote" StylesheetTheme="Tema1" Theme="Tema1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script language="JavaScript" type="text/javascript" src="framesettings.js"></script>
    <title>.:: Gestor de Credito ::.</title>
    <link rel="shortcut icon" href="Grafix/Gestor.ico"/>
<script language="javascript" type="text/javascript">


function CambiaFrames(){ 
var valor = document.form1.txtBuscar.value;
document.form1.txtBuscar.value = "";
// Pedimos confirmación
if(valor=="")
{
alert("Debe escribir que desea buscar");
return false;
}
else{
parent.destino.location="CredBuscar.aspx?Buscar=" + valor;
}

}
</script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="ImageButton1" method="post">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 38px">
    <tr>
    <td style="width: 200px; height: 60px; text-align: right;" class="tablaEncabezado01" >
    <asp:Image ID="Image2" runat="server" ImageUrl="~/Grafix/Gestor.png" onClick="A(this.src);"/></td>
    <td style="width: 35%; height: 60px" class="tablaEncabezado01" >
    <asp:Label ID="lbUsuario" runat="server" Text="Label"></asp:Label>
    </td>
     <td style="width: 35%; height: 60px" class="tablaEncabezado01" >
         <asp:TextBox ID="txtBuscar" runat="server"  Width="80%"></asp:TextBox>
         <asp:ImageButton ID="ImageButton1" runat= "server"  ImageUrl="~/Grafix/Lupa.png" 
             onclientclick="CambiaFrames()"  />
    </td>
    <td style="width: 15%; height: 60px; text-align: right;" class="tablaEncabezado01" >
        <a href="Salir.aspx" target='_parent'>
       <img src="grafix/salir.png"alt="Salir del Sistema" width="25" height="25" border="0" align="top" /> 
     </a>
    </td>
    </tr>
    </table>
    </form>
</body>
</html>
