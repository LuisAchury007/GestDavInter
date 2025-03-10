<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_CFinalPublicadas.aspx.cs" Inherits="Inf_CFinalPublicadas" StylesheetTheme="Tema1" Theme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff" class="areaBordes">
        <tr>
            <td valign="top" class="titulo01">Reporte C. Final Publicada</td>
        </tr>
        <tr>
            <td class="tbBord">
                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                    <tr>
                        <td class="">&nbsp; &nbsp;Nit:&nbsp
                                     <asp:TextBox ID="TxtNit" CssClass="borders" runat="server" Width="180px"></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="TxtNit_FilteredTextBoxExtender"
                                runat="server" Enabled="True" TargetControlID="TxtNit" FilterType="Numbers">
                            </cc1:FilteredTextBoxExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ValidationGroup="form"
                                runat="server" ErrorMessage="Este campo es requerido"
                                ControlToValidate="TxtNit"></asp:RequiredFieldValidator>
                            &nbsp;&nbsp;
                                        <asp:Button ID="Button2" runat="server" Text="Generar" CssClass="botonDes" OnClick="Button2_Click" ValidationGroup="form" />
                            &nbsp;&nbsp;
                                        <asp:Button ID="Button3" runat="server" Text="Con Auditoria" CssClass="botonDes" OnClick="Button3_Click" ValidationGroup="form" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

        <tr>
            <td class="tbBord">
                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                    <tr>
                        <td>Periodos
                                        <asp:DropDownList ID="CmbPeriodos" CssClass="borders" runat="server"></asp:DropDownList>
                            &nbsp;&nbsp;
                                        <asp:Button ID="Button1" runat="server" Text="Generar" CssClass="botonDes" OnClick="Button1_Click" />
                            &nbsp;&nbsp;
                                        <asp:Button ID="Button4" runat="server" Text="Con Auditoria" CssClass="botonDes" OnClick="Button4_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>


    </table>

</asp:Content>

