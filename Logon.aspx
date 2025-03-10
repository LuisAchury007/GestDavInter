<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logon.aspx.cs" Inherits="Logon" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>.:: Gestor Comercial y de Credito ::.</title>
    <link rel="shortcut icon" href="Grafix/Gestor.ico" />
    <meta name="description" content="Custom Login Form Styling with CSS3" />
    <meta name="keywords" content="css3, login, form, custom, input, submit, button, html5, placeholder" />
    <meta name="author" content="Codrops" />
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <script src="js/modCust.js"></script>
    <script src="js/aes.js" type="text/javascript"></script>
    <!--[if lte IE 7]><style>.main{display:none;} .support-note .note-ie{display:block;}</style><![endif]-->
    <style>
        @import url(https://fonts.googleapis.com/css?family=Raleway:400,700);

        body {
            background: #7f9b4e url(Grafix/NewLogo4.jpg) no-repeat center top;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            background-size: cover;
        }

        .container > header h1,
        .container > header h2 {
            color: #000;
            text-shadow: 0 1px 1px rgba(0,0,0,0.7);
        }
    </style>
    <script type="text/javascript">
        var a = "";
        var c = 0;
        function SubmitsEncry() {
            var hztnke = document.getElementById("<%=ET3202.ClientID %>").value.trim();
            var fcult = document.getElementById("<%=sdkl.ClientID %>").value.trim();
            var _werc3u8qw3r = "pāşšŵōřđ";
            var _2sd8xa46 = "gf46QNTj2b9evDxaPBKyAVhcXFpdRzqrLEutU83kYG7wmJnMiZWICH";
            var Dc3u8q = "";

            for (i = 0; i < 10; i++) {
                Dc3u8q += _2sd8xa46.charAt(Math.floor(Math.random() * _2sd8xa46.length));
            }

            if (hztnke != "" && fcult != "") {
                var blaHK = Aes.Ctr.encrypt(hztnke, _werc3u8qw3r, 256);

                document.getElementById("<%=xmjgl.ClientID %>").value = blaHK;
                var tvnkfg = Aes.Ctr.encrypt(fcult, _werc3u8qw3r, 256);
                document.getElementById("<%=tzwqk.ClientID %>").value = tvnkfg;
                var j49EIt = Aes.Ctr.encrypt(fcult, _werc3u8qw3r, 256);
                document.getElementById("<%=ET3202.ClientID %>").value = " ";
            }

            document.getElementById("<%=sdkl.ClientID %>").value = "";
        }

        function Submit() {
            var _fg5t = Y123CV05.value;
            var _bn8k = "pāşšŵōřđ";

            if (event.keyCode > 46 && event.keyCode < 91) {
                var j49EIt = Aes.Ctr.encrypt(_fg5t, _bn8k, 256);
                a = j49EIt;
                document.getElementById("<%=sdkl.ClientID %>").value += event.key;
                c++;
                if (c > 5) {
                    Y123CV05.value = a;
                }
            } else if (event.keyCode > 93 && event.keyCode < 112) {
                var j49EIt = Aes.Ctr.encrypt(_fg5t, _bn8k, 256);

                a = j49EIt;
                document.getElementById("<%=sdkl.ClientID %>").value += event.key;
                c++;
                if (c > 5) {
                    Y123CV05.value = a;
                }
            } else if (event.keyCode > 93 && event.keyCode < 112) {
                var j49EIt = Aes.Ctr.encrypt(_fg5t, _bn8k, 256);

                a = j49EIt;
                document.getElementById("<%=sdkl.ClientID %>").value += event.key;
                c++;
                if (c > 5) {
                    Y123CV05.value = a;
                }
            } else if (event.keyCode == 46 || event.keyCode == 8) {
                a = "";
                c = 0;
                document.getElementById("<%=sdkl.ClientID %>").value = "";
                Y123CV05.value = "";
            }
        }

        window.onload = function () {
            var myInput = document.getElementById('Y123CV05');
            myInput.onpaste = function (e) {
                e.preventDefault();
                alert("Esta acción está prohibida");
            }

            myInput.oncopy = function (e) {
                e.preventDefault();
                alert("Esta acción está prohibida");
            }
        }
    </script>

</head>
<body>

    <div class="container">
        <!-- Codrops top bar -->
        <!--/ Codrops top bar -->
        <header>			
				
			<%--	<h2>Cuenta Personal de Gestor Comercial y de Crédito</h2>
				<div class="support-note">
					<span class="note-ie">Sorry, only modern browsers.</span>
				</div>		--%>		
			</header>
        <section class="main">
               <form autocomplete="off" method="post" id="form1" name="login_form" class="form-4" runat="server">
                    <cc1:ToolkitScriptManager runat="Server" ID="ScriptManager1" />
                   <h1><img src="Grafix/title.png" width="293" height="111"></h1>
				    <p>
				        <label for="login">Usuario</label>
				        <asp:TextBox ID="ET3202" runat="server" placeholder="Usuario"  autocomplete="off" required></asp:TextBox>
                        
				    </p>
				    <p>
				        <label for="password">Contraseña</label>
				        <%--<asp:TextBox ID="Y123CV05" runat="server" TextMode="Password" placeholder="Clave" autocomplete="off" ></asp:TextBox>--%>
                        <input id="Y123CV05" type="password" placeholder="Clave" autocomplete="off" onkeydown="javascript:return Submit();" />
				    </p>
				    <p>
				        <asp:Button ID="Button1" runat="server" Text="Ingresar" OnClientClick="return SubmitsEncry();" onclick="BtnIniciarSesion_Click" ></asp:Button>
				    </p>      
                        <asp:HiddenField ID="xmjgl" runat="server" />
                        <asp:HiddenField ID="tzwqk" runat="server" />
                        <asp:HiddenField ID="sdkl" runat="server" />
                     <asp:Button ID="Button17" runat="server" Text="" CssClass="invisible" Style="visibility: hidden"  />
						<asp:Panel ID="Panel1" runat="server" CssClass="ModalPopup" Style="display: none" >
                    <div>
                        <p>
                           <br /><br /><br />
                            <table width="400px"  border="0" cellpadding="4" cellspacing="4" bgcolor="#ffffff" style="border-radius: 10px;">
                                <tr>
                                    <td valign="top" align="center" class="titulo01">
                                        <asp:Label ID="Label1" runat="server" Text="Seleccione Pais"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellpadding="2" cellspacing="2">
                                            <tr>
                                                <td align="center" class="tablaDescribe">
                                                    <asp:DropDownList ID="cmbPais" runat="server">
                                                    </asp:DropDownList>
                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="Button17" PopupControlID="Panel1" 
                                                    BackgroundCssClass="backpopup"   />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:Button ID="OkButton" runat="server" Text="Asignar" OnClick="OkButton_Click" />            
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </p>
                    </div>
                </asp:Panel>
				</form>
				     <p>
				        <br /><br /><br /><br />
                        <left><img src="Grafix/LogoDavivienda.png"></left>
				    </p> ​
			</section>
    </div>

</body>
</html>
