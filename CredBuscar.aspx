<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CredBuscar.aspx.cs" Inherits="CredBuscar" Theme="Tema1" StyleSheetTheme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.:: Gestor de Credito Buscador ::</title>
    <link rel="shortcut icon" href="Grafix/Gestor.ico"/>
      <script type="text/javascript" src="js/jqueryUno.js"></script>
    <script type="text/javascript" src="js/bts.js"></script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
	
	<tr> <td> <asp:Button ID="Button3" runat="server" Text="Copiar" CssClass="botonDes" /> </td></tr>
	<tr>
    <td valign="top">
        <div class="divBord">
        <asp:GridView ID="GridEmpresas" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="False" AllowSorting="False" DataKeyNames="nit"  >
        <Columns>
        <asp:TemplateField>
            <ItemTemplate>
            <asp:CheckBox ID="chkSumar" runat="server" />
            </ItemTemplate>
              <ItemStyle HorizontalAlign="Center" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Empresa" SortExpression="RazonSocial" >
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%#Eval("IdSector", "~/CredEmpresa.aspx?IdSector={0}") +  Eval("Sector", "&NombreSec={0}") + Eval("NIT", "&NIT={0}") %>' Text='<%#Eval("RazonSocial")%>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
              <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
             <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" SortExpression="Ciudad" >
                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Sector" DataField="Sector" SortExpression="Sector" >
                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            </Columns>
        </asp:GridView>
            </div>
        </td>
	</tr>
	
	
	
	<tr>
    <td valign="top">
         <div class="divBord">
        <asp:GridView ID="GridAccionistas" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="False" AllowSorting="False" DataKeyNames="nit" >
        <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                <asp:CheckBox ID="chkSumar" runat="server" />
                </ItemTemplate>
                   <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Empresa" SortExpression="RazonSocial" >
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" 
                        NavigateUrl='<%#Eval("IdSector", "~/CredEmpresa.aspx?IdSector={0}") +  Eval("Sector", "&NombreSec={0}") + Eval("NIT", "&NIT={0}") %>' Text='<%#Eval("RazonSocial")%>'></asp:HyperLink>
                    </ItemTemplate>
                    <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
             <asp:BoundField HeaderText="Ciudad" DataField="Ciudad" SortExpression="Ciudad" >
                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField HeaderText="Ejecutivo" DataField="Nombre" SortExpression="Nombre" >
                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                  <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
             <asp:BoundField HeaderText="Tipo" DataField="Tipo" SortExpression="Tipo" >
                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                   <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            </Columns>
        </asp:GridView>
             </div>
        </td>
	</tr>
	
	        <tr>
 <td>
  <asp:Panel ID="Panel4" runat="server"  CssClass="ModalPopup" Style="display: none" >
            <asp:Panel ID="Panel5" runat="server" Style="cursor: move;background-color:#DDDDDD;border:solid 1px Gray;color:Black">
                <div>
                    <p>Seleccione el Sector al que desea Copiar :</p>
                </div>
            </asp:Panel>
                <div>
                    <p>
                        <asp:TreeView ID="MisSectores" runat="server" ShowCheckBoxes="Leaf">
                        
                        </asp:TreeView>
                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" 
                        TargetControlID="Button3"
                        PopupControlID="Panel4" 
                        BackgroundCssClass="ModalBackground" 
                         />
                    </p>
                     <p style="text-align: center;">
                        <asp:Button ID="OkButton" runat="server" Text="Copiar" OnClick="OkButton_Click" />
                        <asp:Button ID="CancelButton" runat="server" Text="Cancel" />
                    </p>
                </div>
        </asp:Panel>
  </td>
 </tr>
	
	  
	  
	  
</table>
    </div>
    </form>
</body>
</html>
