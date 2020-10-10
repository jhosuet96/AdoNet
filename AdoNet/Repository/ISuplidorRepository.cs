using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet
{
    public interface ISuplidorRepository
    {
        DataTable GetAll();
        DataTable Getrnc(string rnc);
        OperationResult Create(Suplidor suplidor);
        OperationResult Update(int EmpresaId, string PersonaRepresentante, string Direccion, string Telefono);

    }
}
