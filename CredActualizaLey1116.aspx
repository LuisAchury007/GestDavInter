<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/GCredMaestra.master" CodeFile="CredActualizaLey1116.aspx.cs" Inherits="CredActualizaLey1116" Title=".:: Gestor Comercial y De Credito ::." StyleSheetTheme="Tema1" Theme="Tema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
         <tr>
        <td valign="top" class="titulo01">
         Actualizar Ley 1116</td>
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

