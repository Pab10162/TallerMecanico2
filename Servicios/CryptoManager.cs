using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Servicios
{
    /// <summary>
    /// RESPONSABILIDAD: Cifrar contraseñas con SHA-256 para no guardarlas en texto plano.
    /// POR QUÉ EXISTE: Si el algoritmo se cambia (por ejemplo, agregar sal), se toca solo esta clase.
    /// QUÉ NO HACE: No compara ni valida contraseñas. SHA-256 sin sal es suficiente para el alcance del TP, pero no para producción.
    /// </summary>
    public class CryptoManager
    {
        public static string Encriptar(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);

                // Convertir a string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}    
