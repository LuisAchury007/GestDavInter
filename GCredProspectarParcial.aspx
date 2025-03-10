<%@ Page Title="" Language="C#" MasterPageFile="~/GCredMaestra.master" AutoEventWireup="true" CodeFile="GCredProspectarParcial.aspx.cs" Inherits="GCredProspectarParcial" Theme="Tema1" StylesheetTheme="Tema1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="JavaScript" type="text/JavaScript">

        function DatosEmpresa(IdSector, NombreSec, NIT) {
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

        function preventMultipleSubmissions() {
            $('#<%=Button1.ClientID %>').prop('disabled', true);
            $('#<%=Button2.ClientID %>').prop('disabled', true);


            div1.style.backgroundColor = "#ffffff6e";
            div1.style.width = "99%";
            div1.style.height = "100%";
            div1.style.top = "0";
            div1.style.position = "fixed";
            div1.style.zIndex = "100001"
            msjLoad.style.zIndex = "1"

            msjLoad.style.visibility = "visible";
            msjLoad.style.top = "40%";
            msjLoad.style.left = "48%";
            msjLoad.style.position = "fixed";

            msjLoad.style.zIndex = "1000"

        }


        function bloqueacontrol() {
            window.onbeforeunload = preventMultipleSubmissions;
        }
    </script>

    <link href="css/bts.css" rel="stylesheet" />
    <div id="div1">
    </div>

    <div id="msjLoad" style="visibility: hidden; position: fixed;" align="center">
        <img src="Grafix/loader.gif" />
    </div>
    <div class="container">
        <div class="row">
            <div>
                <div class="panel-group" id="accordion">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4 class="panel-title panel-title-adjust">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"><i class="fa fa-plus"></i>1-Prospectar </a>
                            </h4>
                        </div>
                        <div id="collapseTwo" class="panel-collapse collapse  <%= macroState %>">
                            <div class="panel-body">
                                <table class="style1" style="width: 900px" border="0">
                                    <tr>
                                        <td style="width: 100%" align="left">
                                            <table class="style1" style="width: 100%" border="0">
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="Button17" runat="server" Text="Button" CssClass="invisible" />
                                                        <asp:TreeView ID="TreeDatos" runat="server" ShowCheckBoxes="Leaf"
                                                            ShowLines="True">
                                                        </asp:TreeView>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td>
                                                        <asp:Label ID="Label73" runat="server" Text="Vigencia: "
                                                            Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label><asp:DropDownList ID="CmbVigencia" CssClass="borders" runat="server"></asp:DropDownList>
                                                        <asp:CheckBox ID="ChckArchivo" runat="server" Text="Utilizar Nit Auxiliar" />
                                                        <asp:Button ID="Button1" runat="server" CssClass="botonDes" OnClick="Button1_Click" Text="Prospectar" OnClientClick="bloqueacontrol();" />
                                                        <asp:Label ID="Message" runat="server" Text=""></asp:Label>

                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4 class="panel-title panel-title-adjust">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree"><i class="fa fa-plus"></i>2-Seleccionar Maximos y minimos </a>
                            </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse  <%= macroState2 %>">
                            <div class="panel-body">
                                <table class="style1" style="width: 900px" border="0">
                                    <tr>
                                        <td>

                                            <asp:Table ID="TableDatos" runat="server">
                                            </asp:Table>
                                            <asp:Button ID="Button2" runat="server" Text="Calcular" CssClass="botonDes"
                                                OnClick="Button2_Click" OnClientClick="bloqueacontrol();" />

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <h4 class="panel-title panel-title-adjust">
                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseFour"><i class="fa fa-plus"></i>3-Listado de Empresas </a>
                            </h4>
                        </div>
                        <div id="collapseFour" class="panel-collapse collapse  <%= macroState3 %>">
                            <div class="panel-body" style="overflow: auto; overflow-y: auto;">
                                <table class="style1" style="width: 900px" border="0">
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="DropDownList1" CssClass="borders" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            </asp:DropDownList>

                                            <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Grafix/Excel.png" OnClick="ImageButton7_Click" />
                                            <div class="divBord">
                                                <asp:GridView ID="GridLista" CssClass="Grid" runat="server" AllowPaging="True"
                                                    AllowSorting="True" AutoGenerateColumns="False"
                                                    EmptyDataText="No Hay Registros" OnPageIndexChanging="Grid_PageIndexChanging"
                                                    OnSorting="Grid_Sorting" PagerSettings-Mode="NumericFirstLast" PageSize="50"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkSumar" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NIT" HeaderText="Nit" SortExpression="NIT">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Razon Social" SortExpression="RazonSocial">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl=<%#"javascript:DatosEmpresa("+  Eval("IdSector") + ",'" + Eval("Sector") + "'," +  Eval("NIT") + ");"%> Text='<%# Eval("RazonSocial") %>'></asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" SortExpression="Ciudad">
                                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerSettings Mode="NumericFirstLast" />
                                                </asp:GridView>
                                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                            </div>
                                            <asp:ListBox ID="ListBox1" runat="server" Visible="False"></asp:ListBox>
                                            <asp:HiddenField ID="HdIndicadores" runat="server" />
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                            <asp:HiddenField ID="HiddenField2" runat="server" />
                                            <asp:HiddenField ID="HdCiudad" runat="server" />
                                            <asp:HiddenField ID="HidContador2" runat="server" Value="0" />
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

