<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_CFinalGeneradas.aspx.cs" Inherits="Inf_CFinalGeneradas" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Calificacion Final Generadas</td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td>Periodos&nbsp;
                         <asp:DropDownList ID="CmbPeriodos" CssClass="borders" runat="server"></asp:DropDownList>
                            &nbsp;
                            <asp:Button ID="Button1" CssClass="botonDes" runat="server" Text="Generar Archivo" OnClick="Button1_Click" />
                        </td>

                    </tr>
                </table>
            </td>
        </tr>
    </table>


</asp:Content>

