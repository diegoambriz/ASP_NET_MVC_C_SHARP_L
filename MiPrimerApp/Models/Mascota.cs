using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiPrimerApp.Models
{
    public class Mascota
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Descripcion { get; set; }
        public string CorreoContacto { get; set; }
        public bool Adoptada { get; set; }
    }

}