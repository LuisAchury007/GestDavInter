using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Descripción breve de CustomCertificateValidator
/// </summary>
public class CustomCertificateValidator
{
    public static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        // Realiza tu lógica personalizada de validación aquí
        // Puedes implementar tus propias reglas de confianza y verificación

        // Ejemplo básico: permitir todos los certificados autofirmados
        if (sslPolicyErrors == SslPolicyErrors.None)
        {
            return true; // Certificado válido
        }

        // Si tienes reglas específicas, verifícalas aquí
        // Por ejemplo, puedes comparar el certificado con una lista blanca

        return false; // Certificado no válido
    }
}