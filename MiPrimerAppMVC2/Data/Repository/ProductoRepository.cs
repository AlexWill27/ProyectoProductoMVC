using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC2.Data.Repository.Interfaces;
using MiPrimerAppMVC2.Models;
using System.Collections.Concurrent;
using System.Diagnostics.Eventing.Reader;

namespace MiPrimerAppMVC2.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly ProductosContext _context;

        public ProductoRepository(ProductosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> GetAll()
        {
            var productos=await _context.Productos.ToListAsync();
            return productos;
        }

        //GetByID

        public async Task<Producto> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            return producto;
        }

        //Create
        public async Task<int> Create(Producto producto)
        {
            producto.FechaDeAlta=DateTime.Now;
            _context.Add(producto);
            return await _context.SaveChangesAsync();
        }

        //Update

        public async Task<int> Update(Producto producto)
        {
            _context.Update(producto);
            return await _context.SaveChangesAsync();
        }


        //Delete

        public async Task<bool> DeleteById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            if (await _context.SaveChangesAsync()>=0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }   



    }
}
