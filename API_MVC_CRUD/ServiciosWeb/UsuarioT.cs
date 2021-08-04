using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ServiciosWeb
{
    public class UsuarioT
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string TipoID { get; set; }
        [Required]
        public int Identificación { get; set; }
        [Required]
        [MinLength (5)]
        public string Contrasena { get; set; }
        [Required]
        public string Correo { get; set; }
    }
}
