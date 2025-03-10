<%@ Application Language="C#" %>

<script RunAt="server">


    protected void Application_Start(object sender, EventArgs e)
    {

        System.Net.ServicePointManager.ServerCertificateValidationCallback = CustomCertificateValidator.ValidateCertificate;
    }

    protected void Session_Start(object sender, EventArgs e) { }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
        Response.Headers.Add("Permissions-Policy", "geolocation=(), camera=(), microphone=()");

        System.Net.ServicePointManager.SecurityProtocol =
        System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Ssl3;



        if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
        {
            Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
        + HttpContext.Current.Request.RawUrl);
        }

        if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/grafix"))
        {
            if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/js"))
            {
                if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/css"))
                {
                    if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/app_themes"))
                    {
                        if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/app_browsers"))
                        {
                            if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/bin"))
                            {
                                if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/font"))
                                {
                                    if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/reportes"))
                                    {
                                        if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/archivos"))
                                        {
                                            //Check If it is a new session or not , if not then do the further checks
                                            if (Request.Cookies["ASP.NET_SessionId"] != null && Request.Cookies["ASP.NET_SessionId"].Value != null)
                                            {
                                                string newSessionID = Request.Cookies["ASP.NET_SessionID"].Value;

                                                if (newSessionID.Length <= 100)
                                                {
                                                    //Check the valid length of your Generated Session ID
                                                    if (newSessionID.Length <= 23 && newSessionID.Length > 0)
                                                    {
                                                        //Log the attack details here
                                                        Response.Cookies["TriedTohack"].Value = "True";
                                                        throw new HttpException("Invalid Request");
                                                    }
                                                    if (newSessionID.Length > 28)
                                                    {
                                                        //Genrate Hash key for this User,Browser and machine and match with the Entered NewSessionID
                                                        if (GenerateHashKey() != newSessionID.Substring(24, 28))
                                                        {
                                                            //Log the attack details here
                                                            Response.Cookies["TriedTohack"].Value = "True";
                                                            throw new HttpException("Invalid Request");
                                                        }

                                                        //Use the default one so application will work as usual//ASP.NET_SessionId            
                                                        Request.Cookies["ASP.NET_SessionId"].Value = Request.Cookies["ASP.NET_SessionId"].Value.Substring(0, 24);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    protected void Application_AuthenticateRequest(object sender, EventArgs e) { }

    //protected void Application_Error(object sender, EventArgs e) { }
    protected void Application_PreSendRequestHeaders(object sender, EventArgs e)
    {
        Response.Headers.Add("X-Content-Type-Options", "nosniff");
        Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
        Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    }

    protected void Session_End(object sender, EventArgs e) { }

    protected void Application_EndRequest(object sender, EventArgs e)
    {
        if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/grafix"))
        {
            if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/js"))
            {
                if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/css"))
                {
                    if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/app_themes"))
                    {
                        if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/app_browsers"))
                        {
                            if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/bin"))
                            {
                                if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/font"))
                                {
                                    if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/reportes"))
                                    {
                                        if (!Request.AppRelativeCurrentExecutionFilePath.ToString().ToLower().Contains("/archivos"))
                                        {
                                            if (Request.Cookies["ASP.NET_SessionID"] != null)
                                            {
                                                string tamanio = Request.Cookies["ASP.NET_SessionID"].Value;
                                                if (tamanio.Length <= 100)
                                                {
                                                    if (Response.Cookies["ASP.NET_SessionId"] != null)
                                                    {
                                                        Response.Cookies["ASP.NET_SessionId"].Value = Request.Cookies["ASP.NET_SessionId"].Value + GenerateHashKey();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private string GenerateHashKey()
    {
        StringBuilder myStr = new StringBuilder();
        myStr.Append(Request.Browser.Browser);
        myStr.Append(Request.Browser.Platform);
        myStr.Append(Request.Browser.MajorVersion);
        myStr.Append(Request.Browser.MinorVersion);
        //myStr.Append(Request.LogonUserIdentity.User.Value);
        System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        byte[] hashdata = sha.ComputeHash(Encoding.UTF8.GetBytes(myStr.ToString()));
        return Convert.ToBase64String(hashdata);
    }


    //}

    protected void Application_Error(object sender, EventArgs e)
    {
        Exception objErr = Server.GetLastError().GetBaseException();
        /*System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
        System.Diagnostics.StackFrame sf = st.GetFrame(0);
        string err = "<b>Error en la pagina, dispara el evento Page_Error asfasdbjkasdffjkasfj djkfsdjkl hfwLP</b><hr><br>" +
        "Error in: " + Request.Url.ToString() +
        "\nError Message:" + objErr.Message.ToString() +
        "\nStack Trace:" + objErr.StackTrace.ToString()+        
        "\nStack Trace 2:" + sf.GetMethod();
        System.Diagnostics.EventLog.WriteEntry("Sample_WebApp", err, System.Diagnostics.EventLogEntryType.Error);
        */

        Datos sv = new Datos();
        string InnerMensaje = "";
        string MensajeError = "";
        if (objErr.InnerException != null) { InnerMensaje = objErr.InnerException.ToString(); }
        if (objErr.Message != null) { MensajeError = objErr.Message.ToString(); }
        string nomPagina = "";
        Int32 iduser;

        if (Request.Url.Segments.Length == 2)
        {
            nomPagina = Request.Url.Segments[1].ToString();
        }
        else if (Request.Url.Segments.Length == 3)
        {
            nomPagina = Request.Url.Segments[2].ToString();
        }


        if (Session["IdUsuario"] != null)
        {
            iduser = Convert.ToInt32(Session["IdUsuario"].ToString());
        }
        else
        {
            iduser = 0;
        }
        InnerMensaje = "Pagina: " + nomPagina + " - " + InnerMensaje + " - Seguimiento: " + objErr.StackTrace.ToString();
        sv.InLogErrores(InnerMensaje, MensajeError, iduser);
        //Server.ClearError();
        //Response.Redirect("~/FormError.aspx");
        //additional actions...
    }

</script>
