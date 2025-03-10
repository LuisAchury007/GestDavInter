using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;
using System.ServiceModel;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de Correo
/// </summary>
public class Correo
{
    private char[] delimiterDestinos = { ';' };
    List<string> Archivo = new List<string>();
   
    public Correo()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }




    public string EnviarMail(string asunto, string texto, string para, List<string> ArchivoPedido_ = null)
    {
        try
        {
            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress(ConfigurationManager.AppSettings["correo"]); //new MailAddress("sc@gestorcc.com");

            string[] arr;
            arr = para.Split(delimiterDestinos);

            for (int i = 0; i < arr.Length - 1; i++)
            {
                mensaje.To.Add(arr[i].ToString());
            }
            Archivo = ArchivoPedido_;

            
            mensaje.Subject = asunto;
            mensaje.Priority = MailPriority.Normal;
            //si viene archivo a adjuntar
            //realizamos un recorrido por todos los adjuntos enviados en la lista
            //la lista se llena con direcciones fisicas, por ejemplo: c:/pato.txt
            if (Archivo != null)
            {
                //agregado de archivo
                foreach (string archivo in Archivo)
                {
                    //comprobamos si existe el archivo y lo agregamos a los adjuntos
                    if (System.IO.File.Exists(@archivo))
                        mensaje.Attachments.Add(new Attachment(@archivo));

                }
            }
            mensaje.IsBodyHtml = true;
            mensaje.Body = texto;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["Host"];  //"smtp.gmail.com";
            //solo gmail
            smtp.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["EnableSsl"]);  //true;
            // fin
            if (Boolean.Parse(ConfigurationManager.AppSettings["Credenciales"]))
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["correo"], ConfigurationManager.AppSettings["Clave"]); //new System.Net.NetworkCredential("sc@gestorcc.com", "mundial2010@");

            smtp.Send(mensaje);
            return "Los Mensaje fueron enviado con exito";
        }
        catch (Exception ex)
        {
           
               MailMessage mensaje = new MailMessage();

                //Configuración del Mensaje

                mensaje.From = new MailAddress(ConfigurationManager.AppSettings["correo"]);
                string[] arr;
                arr = para.Split(delimiterDestinos);

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    mensaje.To.Add(arr[i].ToString());
                }
                //Especificamos a quien enviaremos el Email, no es necesario que sea Gmail, puede ser cualquier otro proveedor
                Archivo = ArchivoPedido_;

                mensaje.Subject = asunto;
                mensaje.Priority = System.Net.Mail.MailPriority.Normal;
                //si viene archivo a adjuntar
                //realizamos un recorrido por todos los adjuntos enviados en la lista
                //la lista se llena con direcciones fisicas, por ejemplo: c:/pato.txt
                if (Archivo != null)
                {
                    //agregado de archivo
                    foreach (string archivo in Archivo)
                    {
                        //comprobamos si existe el archivo y lo agregamos a los adjuntos
                        if (System.IO.File.Exists(@archivo))
                            mensaje.Attachments.Add(new Attachment(@archivo));

                    }
                }
                mensaje.IsBodyHtml = true;
                mensaje.Body = texto;
                mensaje.BodyEncoding = System.Text.Encoding.UTF8;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["HostRespaldo"];
               // smtp.Port = 993;

                smtp.EnableSsl = Boolean.Parse(ConfigurationManager.AppSettings["EnableSsl"]);  //true;;

                if (Boolean.Parse(ConfigurationManager.AppSettings["Credenciales"]))
                    smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["correo"], ConfigurationManager.AppSettings["Clave"]); //new System.Net.NetworkCredential("sc@gestorcc.com", "mundial2010@");
        
                smtp.Send(mensaje);
                return "Los Mensaje fueron enviado con exito";

          
        }
                
      
    }

}