using System;

namespace AdoNet.Service
{
    public class Util
    {

        public Suplidor SuplidorCreate(Suplidor suplidor)
        {
            string valor;
            Random r = new Random();
            var Noproveedor = r.Next(1, 999999999);

            Console.Write("Nombre de empresa: ");
            suplidor.NombreEmpresa = Console.ReadLine();

            Console.Write("Persona Representante: ");
            suplidor.PersonaRepresentante = Console.ReadLine();

            Console.Write("RNC: ");
            suplidor.RNC = Console.ReadLine();

            Console.Write("Direccion: ");
            suplidor.Direccion = Console.ReadLine();

            Console.Write("Telefono: ");
            suplidor.Telefono = Console.ReadLine();

            Console.Write("Es Proveedor de estado: (Si o No)? ");
            valor = Console.ReadLine();

            Console.Clear();

            if (valor.ToLower() == "si")
            {
                suplidor.proveedorEstado = 0;
                suplidor.NoproveedorEstado = Noproveedor.ToString();
                suplidor.Borrar = 0;
                Console.Clear();
                return suplidor;
            }
            else
            {
                suplidor.proveedorEstado = 0;
                suplidor.NoproveedorEstado = "null";
                suplidor.Borrar = 0;
                return suplidor;
            }
        }

        public Suplidor SuplidorActualizar(int _EmpresaId, string PersonaRepresentante, string Direccion, string Telefono)
        {
            Console.Write("Esta seguro que desea autualizar este registro?\nPresione 'S' para cotinuar de lo contrario pulse cualquier tecla: ");
            string value = Console.ReadLine();
            if (value.ToLower() =="s")
            {
                Console.Clear();
                Console.WriteLine("Ingrese los datos a Actualizar\n");
                Console.Write("Persona Representante: ");
                PersonaRepresentante = Console.ReadLine();

                Console.Write("Direccion: ");
                Direccion = Console.ReadLine();

                Console.Write("Telefono: ");
                Telefono = Console.ReadLine();
                return new Suplidor
                {
                    EmpresaId=_EmpresaId,
                    PersonaRepresentante = PersonaRepresentante,
                    Direccion = Direccion,
                    Telefono = Telefono
                };
            }
            else
            {
                Console.Clear();
                return null;
            }
           
        }

        public Suplidor BorrarSuplidor(int _EmpresaId)
        {
            Console.Write("Esta seguro que desea borrar este registro?\nPresione 'S' para cotinuar de lo contrario pulse cualquier tecla: ");
            string value = Console.ReadLine();
            if (value.ToLower() == "s")
            {
                Console.Clear(); return new Suplidor
                {
                    EmpresaId = _EmpresaId,
                    Borrar = 1
                };
            }
            else
            {
                Console.Clear();
                return null;            
            }
        }

    }
}
