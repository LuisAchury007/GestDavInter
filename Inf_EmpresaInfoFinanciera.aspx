<%@ Page Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="Inf_EmpresaInfoFinanciera.aspx.cs" Inherits="Inf_EmpresaInfoFinanciera" Title=".:: Gestor Comercial y De Credito ::." Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript" type="text/JavaScript">

        function DatosEmpresaCred(IdSector, NombreSec, NIT) {


            var altoActual;
            var anchoActual;

            altoActual = screen.height * 0.70;
            anchoActual = screen.width * 0.95;

            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.height = '80%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_PanelDatosEmpresa").style.width = '90%'; // = anchoActual + 'px';

            altoActual = screen.height * 0.65
            anchoActual = screen.width * 0.94

            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.height = '100%'; // = altoActual + 'px'; // contiene la altura en pixels de la pantalla
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").style.width = '100%'; // = anchoActual + 'px';

            var modal = $find('ModalPopupExtender2');  //haciendo referencia al behavior, y NO al id
            document.getElementById("ctl00_ContentPlaceHolder1_IframeDatosEmpresa").src = "CredEmpresa.aspx?IdSector=" + IdSector + "&NombreSec=" + NombreSec + "&NIT=" + NIT;
            modal.show();

        }



    </script>
    <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff" class="areaBordes">
        <tr>
            <td valign="top" class="titulo01">.:: Empresas Informacion Financiera Existente ::.</td>
        </tr>
        <tr>
            <td class="areaInfo">
                <table width="100%" border="0" cellspacing="2" cellpadding="2">
                    <tr>
                        <td class="tablaTitulo">Total Registros :: 
            <asp:Label ID="lbTotal" runat="server" Text=""></asp:Label>
                            &nbsp; &nbsp; 
            
                            <asp:Button ID="Button17" runat="server" Text="Button" CssClass="invisible" />
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                    <asp:GridView ID="GridLista" CssClass="Grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="50"
                                        EmptyDataText="No Hay Registros" OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting" DataKeyNames="NIT">
                                        <Columns>
                                            <asp:BoundField DataField="NIT" HeaderText="NIT" SortExpression="NIT">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Nombre" SortExpression="RazonSocial">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="HyperLink1" runat="server"
                                                        NavigateUrl=<%#"javascript:DatosEmpresaCred("+  Eval("IdSector") + ",'" + Eval("Sector") + "','" +  Eval("NIT") + "');"%> Text='<%# Eval("RazonSocial")%>'></asp:HyperLink>
                                                </ItemTemplate>
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Anio" HeaderText="Años" SortExpression="Anio">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                </div>
                                 
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton7_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%">
                            <asp:Panel ID="PanelDatosEmpresa" runat="server" CssClass="ModalPopup" Style="display: none; border-radius: 8px"
                                Width="100%">
                                <div style="width: 100%; height: 100%">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 99%; height: 100%">
                                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="Button17" PopupControlID="PanelDatosEmpresa"
                                            BackgroundCssClass="ModalBackground" BehaviorID="ModalPopupExtender2" CancelControlID="ImageButton1" />
                                        <tr>
                                            <td style="width: 100%; height: 6%" align="right">
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageUrl="~/Grafix/Limpiar.png"
                                                    ToolTip="Cerrar" Width="25px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="width: 100%">
                                                <iframe id="IframeDatosEmpresa" runat="server" width="100%" height="100%" style="border-radius: 8px" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
