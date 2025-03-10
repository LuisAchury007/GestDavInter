<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Conf_PerfilXPestanas.aspx.cs" Inherits="Conf_PerfilXPestanas" Theme="Tema1" StylesheetTheme="Tema1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript" type="text/JavaScript">

        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

    <script type="text/javascript" src="js/btst.js"></script>
    <script src="js/jqueryDos.js" type="text/javascript"></script>
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Configurar pestañas de la carpeta virtual por perfil</td>
        </tr>

        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td class="tbBord" colspan="3">&nbsp;
            <asp:Label ID="Label1" runat="server" Text="Perfil: "
                Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            <asp:DropDownList ID="CmbPerfil" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="CmbUsuarios_SelectedIndexChanged">
                            </asp:DropDownList>

                            <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="~/Grafix/Guardar.png"
                                ToolTip="Guardar" ValidationGroup="form" OnClick="ImageButton19_Click" />

                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                 <div class="divBord">
                                <asp:GridView ID="GridLista"  CssClass="Grid" runat="server" Width="70%" AutoGenerateColumns="False" AllowPaging="False" AllowSorting="True"
                                    EmptyDataText="No Hay Registros" DataKeyNames="IdPestana" OnSorting="Grid_Sorting">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkHeader" runat="server" onclick="checkAll(this);" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSumar" runat="server"></asp:CheckBox>
                                            </ItemTemplate>
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" SortExpression="Descripcion">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Estado" DataField="Estado" SortExpression="Estado">
                                            <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                    </Columns>
                                </asp:GridView>
                                     </div>
                            </asp:Panel>
                        </td>
                    </tr>


                </table>
            </td>
        </tr>

    </table>
</asp:Content>

