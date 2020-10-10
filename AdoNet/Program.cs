using AdoNet.Repository;
using AdoNet.Service;
using Microsoft.JScript;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet
{
    class Program
    {
        //OperationResult operation = new OperationResult();
        static void Main(string[] args)
        {
            Suplidor _suplidor = new Suplidor();
            bool valid = false;
            int option = 0;
            OperationResult operation = new OperationResult();
            // int option =Convert.ToInt32(Console.ReadLine()); 
            while (valid == false)
            {
                Console.Clear();
                Console.WriteLine("Administracion Suplidor");
                Console.WriteLine("**************Menu*************\n\n1- Crear Suplidor\n2- Buscar Suplidor\n3- Buscar por RNC\n4- Actualizar Suplidor\n5- Borrar Suplidor\n6- Salir");
                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out option) && option <= 6)
                {
                    if (option ==1)
                    {
                        Console.Clear();
                        Console.WriteLine("Crear Suplidor\n");
                        Console.WriteLine(Agregar(_suplidor).Message + "\n\nPresione enter para volver al menu.");
                        Console.ReadLine();
                    }
                    else if (option ==2)
                    {
                        Console.Clear();
                        Console.WriteLine("Lista de Suplidores\n");
                        BuscarALL();
                        Console.WriteLine("\n\nPresione enter para volver al menu.");
                        Console.ReadLine();
                    }
                    else if (option == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Busqueda de Suplidores por RNC\n");
                        Console.Write("Ingrese RNC: ");
                        string s = Console.ReadLine();
                        BuscarRNC(s);
                        Console.WriteLine("\n\nPresione enter para volver al menu.");
                        Console.ReadLine();
                    }
                    else if (option == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Actualizar Suplidor\n");
                        Console.WriteLine(Actualizar().Message + "\n\nPresione enter para volver al menu.");
                        Console.ReadLine();
                    }
                    else if (option == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Borrar Suplidor\n");
                        Console.WriteLine(Borrar(_suplidor).Message + "\n\nPresione enter para volver al menu.");
                        Console.ReadLine();
                    }
                    else
                    {
                        valid = true;
                    }
                }                
            }            
        }

        public static OperationResult Borrar(Suplidor suplido)
        {
            SuplidorRepository sRepo = new SuplidorRepository();
            Util util = new Util();

            var obj = sRepo._UpdateSuplidor(suplido);
            if (obj != null)
            {
                obj = util.BorrarSuplidor(obj.EmpresaId);
                if (sRepo.Update(obj.EmpresaId,obj.Borrar).Result == true)
                {
                    return new OperationResult
                    {
                        Result = true,
                        Message = "Registro Borrado!!!"

                    };

                }
                else
                {
                    Console.Clear();
                    return new OperationResult
                    {
                        Result = false,
                        Message = "Error al Borrar Suplidor"
                    };
                }
            }
            else
            {
                Console.Clear();
                return new OperationResult
                {
                    Result = false,
                    Message = "Error al Borrar Suplidor"
                };
            }
        }

        public static OperationResult Agregar(Suplidor suplidor)
        {
            SuplidorRepository sRepo = new SuplidorRepository();
            Util util = new Util();

            util.SuplidorCreate(suplidor);
            if (suplidor != null)
            {
                if (sRepo.Create(suplidor).Result == true)
                {
                    return new OperationResult
                    {
                        Data = suplidor,
                        Result = true,
                        Message = "Registro insertado!!!"
                    };                    
                }
                else
                {
                    return new OperationResult
                    {
                        Result = false,
                        Message = "Error Agregando Suplidor"
                    };
                }
            }
            else
            {
                return new OperationResult
                {
                    Result = false,
                    Message = "Error Agregando Suplidor"
                };
            }

        }
        public static OperationResult Actualizar()
        {
            Suplidor _suplidor = new Suplidor();
            SuplidorRepository sRepo = new SuplidorRepository();
            Util util = new Util();
            var obj = sRepo._UpdateSuplidor(_suplidor);
            if (obj != null)
            {
                obj = util.SuplidorActualizar(obj.EmpresaId, obj.PersonaRepresentante, obj.Direccion, obj.Telefono);

                if (sRepo.Update(obj.EmpresaId, obj.PersonaRepresentante, obj.Direccion, obj.Telefono).Result == true)
                {
                    return new OperationResult
                    {
                        Result = true,
                        Message = "Registro Actualizado!!!"

                    };

                }
                else
                {
                    Console.Clear();
                    return new OperationResult
                    {
                        Result = false,
                        Message = "Error Actualizando Suplidor"
                    };
                }
            }
            else
            {
                return new OperationResult
                {
                    Result = false,
                    Message = "Error Actualizando Suplidor"
                };
            }

        }

   
        public static void BuscarRNC(string rnc)
        {
            SuplidorRepository sRepo = new SuplidorRepository();
            sRepo.Read(sRepo.See(sRepo.Getrnc(rnc)));
        }
        public static void BuscarALL()
        {
            SuplidorRepository sRepo = new SuplidorRepository();
            sRepo.Read(sRepo.See(sRepo.GetAll()));


        }

    }


   

   
}
