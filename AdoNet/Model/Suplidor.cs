using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet
{
   public class Suplidor
    {
        [Key]
        public int EmpresaId { get; set; }
        public string NombreEmpresa { get; set; }
        public string PersonaRepresentante { get; set; }
        public string RNC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public byte proveedorEstado { get; set; }
        public string NoproveedorEstado { get; set; }
        public  byte Borrar { get; set; }

    }
}
