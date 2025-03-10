<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredActualizarModelo.aspx.cs" Inherits="CredActualizarModelo" Title="Actualización de modelo" StylesheetTheme="Tema1" Theme="Tema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="4" cellspacing="4" class="areaBordes">
                        <tr>
                            <td valign="top" class="titulo01">Actualizar Modelo</td>
                        </tr>
                        <tr>
                            <td class="tbBord">
                                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                                    <tr>
                                        <td>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Actualizar Modelo" OnClick="Button1_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>




</asp:Content>
