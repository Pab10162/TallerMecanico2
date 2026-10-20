using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Servicios
{
    /// <summary>
    /// RESPONSABILIDAD: Entregar los textos de la interfaz en el idioma elegido (Singleton con archivos es.json / en.json).
    /// POR QUÉ EXISTE: Evita textos fijos en cada formulario y permite agregar idiomas sin recompilar la lógica.
    /// QUÉ NO HACE: No decide qué idioma usa cada usuario; lo lee de la sesión.
    /// </summary>
    public class Traductor
    {
        #region Datos y estado: lo que la clase recuerda mientras vive

        private static Traductor instancia;

        public Dictionary<string, string> Textos { get; private set; } = new Dictionary<string, string>();

        public string IdiomaActual { get; private set; }

        public event Action CambioIdioma;

        #endregion

        #region Constructores: cómo se crea y qué dependencias recibe

        private Traductor() { }

        #endregion

        #region Operaciones públicas: servicio transversal usado por todas las capas

        public static Traductor GetInstance()
        {
            if (instancia == null)
                instancia = new Traductor();
            return instancia;
        }

        public void CargarIdioma(string idioma)
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Recursos", $"{idioma}.json");
            string json = File.ReadAllText(ruta);
            Textos = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            IdiomaActual = idioma;
            CambioIdioma?.Invoke();
        }

        public string Traducir(string clave)
        {
            return Textos.TryGetValue(clave, out string valor) ? valor : clave;
        }

        #endregion
    }
}