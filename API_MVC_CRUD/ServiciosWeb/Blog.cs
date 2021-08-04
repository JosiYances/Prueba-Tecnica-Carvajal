using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosWeb
{
    [DataContract]
    public class Blog
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }
        [DataMember]
        public string TipoID { get; set; }
        [DataMember]
        public int Identificación { get; set; }
        [DataMember]
        public string Contrasena { get; set; }
        [DataMember]
        public string Correo { get; set; }        
    }
}
