<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/GCredMaestra.master" CodeFile="Inf_PerfilUsuarios.aspx.cs" Inherits="Inf_PerfilUsuarios" StylesheetTheme="Tema1" Theme="Tema1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table border="0" cellpadding="4" cellspacing="4" class="areaBordes" width="100%">
        <tr>
            <td valign="top" class="titulo01">Usuario Por Perfil</td>
        </tr>

        <tr>
            <td>
                <table width="100%" border="0" cellpadding="4" cellspacing="4" bgcolor="#FFFFFF">
                    <tr>
                        <td class="tbBord" colspan="3">&nbsp;
              <asp:Label ID="Label73" runat="server" Text="Perfil: "
                  Font-Names="Arial" Font-Size="12px" Font-Bold="True"></asp:Label>
                            &nbsp;<asp:DropDownList ID="CmbPerfil" CssClass="borders" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="CmbUsuarios_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp; &nbsp;
            &nbsp; &nbsp; 
                        </td>
                    </tr>

                    <tr>
                        <td valign="top">
                            <asp:Panel ID="Panel3" runat="server">
                                <div class="divBord">
                                    <asp:GridView ID="GridLista" runat="server" Width="100%" CssClass="Grid" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="50"
                                        EmptyDataText="No Hay Registros" OnPageIndexChanging="Grid_PageIndexChanging" OnSorting="Grid_Sorting">
                                        <Columns>
                                            <asp:BoundField HeaderText="Usuario" DataField="Usuario" SortExpression="Usuario">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" SortExpression="Nombre">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Correo" HeaderText="Correo" SortExpression="Correo">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Extension" HeaderText="Extension" SortExpression="Extension">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Celular" HeaderText="Celular" SortExpression="Celular">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Estado" HeaderText="Estado usuario" SortExpression="Estado">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CambiarObligatorio" HeaderText="CambiarObligatorio" SortExpression="CambiarObligatorio">
                                                <HeaderStyle Font-Bold="True" Font-Italic="True" HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Perfil" HeaderText="Perfil" SortExpression="Perfil">
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
                        <td valign="top">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Grafix/Excel.png"
                                OnClick="ImageButton1_Click" />
                        </td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</asp:Content>

