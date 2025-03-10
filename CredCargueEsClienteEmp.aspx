<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="CredCargueEsClienteEmp.aspx.cs" Inherits="CredCargueEsClienteEmp" Title=".:: Gestor Comercial y De Credito ::." StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="css/bts.css" rel="stylesheet" />

    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%" style="border: tsolid #C0C0C0; background-color: #FFFFFF;">
        <tr>
            <td>
                <div class="container">
                    <div class="row">
                        <div>
                            <div class="panel-group" id="accordion">
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h4 class="panel-title panel-title-adjust">
                                            <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">
                                                <i class="fa fa-plus"></i>Actualizar si la empresa es o no cliente
                                            </a>
                                        </h4>
                                    </div>
                                    <div id="collapseTwo" class="panel-collapse collapse  <%= macroState %>">
                                        <div class="panel-body">
                                            <table class="style1" style="width: 100%" border="0">
                                                <tr>
                                                    <td style="width: 100%" align="left">
                                                        <table class="style1" width="100%" border="0" cellspacing="2" cellpadding="2">
                                                            <tr>
                                                                <td>
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                    <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Subir Archivo y Validar" OnClick="Button1_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:ListBox ID="ListValidacion" CssClass="borders" runat="server" Visible="false" Width="100%"></asp:ListBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton7_Click" Visible="false" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>