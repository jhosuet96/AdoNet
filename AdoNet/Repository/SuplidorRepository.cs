using AdoNet.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoNet.Repository
{
    class SuplidorRepository : dbConexion, ISuplidorRepository
    {
        public OperationResult Create(Suplidor suplidor)
        {
            try
            {
                using (this.comando = new SqlCommand())
                {
                    this.comando.Connection = this.con;
                    comando.CommandText =
                        "INSERT INTO [dbo].[Suplidor]  ([NombreEmpresa],[PersonaRepresentante],[RNC],[Direccion],[Telefono],[proveedorEstado],[NoproveedorEstado],[Borrar])" +
                        $"VALUES ('{suplidor.NombreEmpresa}','{suplidor.PersonaRepresentante}','{suplidor.RNC}','{suplidor.Direccion}','{suplidor.Telefono}',{suplidor.proveedorEstado},'{suplidor.NoproveedorEstado}',{suplidor.Borrar})";

                    this.con.Open();
                    try
                    {
                        comando.ExecuteNonQuery();
                        return new OperationResult() { Result = true };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult()
                        {
                            Result = false,
                            Message = $"Ha ocurrido un error. { ex.Message }"
                        };
                    }
                }

            }
            catch (SqlException ex)
            {
                return new OperationResult()
                {
                    Result = false,
                    Message = $"Ha ocurrido un error. { ex.Message }"
                };
            }
        }
        public OperationResult Update(int EmpresaId, string PersonaRepresentante, string Direccion, string Telefono)
        {
            try
            {
                if (true)
                {

                }
                this.con.Close();
                using (this.comando = new SqlCommand())
                {
                    this.comando.Connection = this.con;
                    comando.CommandText =
                        $"UPDATE [dbo].[Suplidor] SET [PersonaRepresentante]='{PersonaRepresentante}',[Direccion]='{Direccion}',[Telefono]='{Telefono}'" +
                        $"WHERE EmpresaId ={EmpresaId}";
                    this.con.Open();
                    try
                    {
                        comando.ExecuteNonQuery();
                        return new OperationResult() { Result = true };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult()
                        {
                            Result = false,
                            Message = $"Ha ocurrido un error. { ex.Message }"
                        };
                    }
                }

            }
            catch (SqlException ex)
            {
                return new OperationResult()
                {
                    Result = false,
                    Message = $"Ha ocurrido un error. { ex.Message }"
                };
            }
        }
        public OperationResult Update(int EmpresaId,byte Borrar)
        {
            try
            {
                if (true)
                {

                }
                this.con.Close();
                using (this.comando = new SqlCommand())
                {
                    this.comando.Connection = this.con;
                    comando.CommandText =
                        $"UPDATE [dbo].[Suplidor] SET Borrar= {Borrar}" +
                        $"WHERE EmpresaId ={EmpresaId}";
                    this.con.Open();
                    try
                    {
                        comando.ExecuteNonQuery();
                        return new OperationResult() { Result = true };
                    }
                    catch (Exception ex)
                    {
                        return new OperationResult()
                        {
                            Result = false,
                            Message = $"Ha ocurrido un error. { ex.Message }"
                        };
                    }
                }

            }
            catch (SqlException ex)
            {
                return new OperationResult()
                {
                    Result = false,
                    Message = $"Ha ocurrido un error. { ex.Message }"
                };
            }
        }

        public Suplidor _UpdateSuplidor(Suplidor suplidor)
        {
            Read(See(GetAll()));
            Console.Write("\n\nIngresar RNC de la Empresa.\nRNC:");
            string rnc = Console.ReadLine();
            var _rnc = Getrnc(rnc);
            if (_rnc.DefaultView.Count >0)
            {
                var _see = See(_rnc);
                foreach (var item in _see)
                {
                    suplidor.EmpresaId = item.EmpresaId;
                    suplidor.PersonaRepresentante = item.PersonaRepresentante;
                    suplidor.Direccion = item.Direccion;
                    suplidor.Telefono = item.Telefono;
                    suplidor.Borrar = item.Borrar;
                }

                return new Suplidor
                {
                    EmpresaId = suplidor.EmpresaId,
                    PersonaRepresentante = suplidor.PersonaRepresentante,
                    Direccion = suplidor.Direccion,
                    Telefono = suplidor.Telefono,
                    Borrar = suplidor.Borrar
                };
            }
            else
            {
                return null;
            }
        }

        public DataTable GetAll()
        {
            this.con.Close();

            this.dt = new DataTable();
            using (this.comando = new SqlCommand())
            {
                this.comando.Connection = this.con;
                comando.CommandText = $"SELECT * FROM Suplidor where Borrar = 0";
                this.adapter = new SqlDataAdapter(comando);
                this.con.Open();
                adapter.Fill(dt);
                return dt;
            }
        }

        public DataTable Getrnc(string rnc)
        {
            this.con.Close();
            this.dt = new DataTable();
            using (this.comando = new SqlCommand())
            {
                this.comando.Connection = this.con;
                comando.CommandText = $"SELECT * FROM Suplidor where RNC ='{rnc}'";
                this.adapter = new SqlDataAdapter(comando);
                this.con.Open();
                adapter.Fill(dt);
                return dt;
            }
        }

        public void Read(List<Suplidor> suplidors)
        {
            Console.Clear();
            if (suplidors.Count > 0)//(table.Rows.Count > 0)
            {
                Console.WriteLine("Lista de Suplidores");
                string S = String.Format("|{0,15}|{1,15}|{2,15}|", "Nombre Empresa", "Persona Representante", "RNC");
                Console.Write(S + "\n");
                foreach (var item in suplidors)
                {
                    S = String.Format("|{0,15}|{1,21}|{2,15}|", item.NombreEmpresa, item.PersonaRepresentante, item.RNC);
                    Console.Write(S + "\n");
                }
            }
            else
            {
                Console.WriteLine("No existen registros para mostrar." + "\nPresione enter para volver al menu.");
            }
        }   

        public List<Suplidor> See(DataTable obj)
        {
            byte value;
            SuplidorRepository sRepo = new SuplidorRepository();
            List<Suplidor> suplidors = new List<Suplidor>();
            foreach (DataRow item in obj.Rows)
            {
                if (item[8].ToString()=="false")
                {
                    value = 0;
                }
                else
                {
                    value = 1;
                }
                suplidors.Add(new Suplidor
                {
                    EmpresaId = Convert.ToInt32(item[0].ToString()),
                    NombreEmpresa = (item[1].ToString()),
                    PersonaRepresentante = (item[2].ToString()),
                    RNC = item[3].ToString(),
                    Borrar = value
                });
            }
            return suplidors;
        }
    }
}
