using System.ComponentModel.DataAnnotations;

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
