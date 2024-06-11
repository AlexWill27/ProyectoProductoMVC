using MiPrimerAppMVC2.Models;

namespace MiPrimerAppMVC2.Data.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();

        //GetByID
        Task<Producto> GetById(int id);

        //Create

        Task<int> Create(Producto producto);

        //Update

        Task<int> Update(Producto producto);

        //Delete

        Task<bool> DeleteById(int id);

    }
}
