using System.Data;

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
