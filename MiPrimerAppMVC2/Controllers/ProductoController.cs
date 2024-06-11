using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC2.Data;
using MiPrimerAppMVC2.Data.Repository.Interfaces;
using MiPrimerAppMVC2.Models;

namespace MiPrimerAppMVC2.Controllers
{
    public class ProductoController : Controller
    {
        //private readonly ProductosContext? _context;: Declara una variable de solo lectura para almacenar el contexto
        //de la base de datos.
        private readonly ProductosContext? _context;

        private readonly IProductoRepository _productoRepository;





        //public ProductoController(ProductosContext context): Constructor que recibe una instancia de ProductosContext
        //(inyectado por el contenedor de dependencias) y lo asigna a _context.Esto permite al controlador acceder a la base
        //de datos.

        //public ProductoController(ProductosContext context)
        //{

        //    _context = context;

        //}

        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        //Acción Index

        //public async Task<IActionResult> Index(): Método que maneja solicitudes GET a Producto/Index.
        public async Task<IActionResult>  Index()
        {
            //var productos = GetData();


            //var productos = await _context.Productos.ToListAsync();: Recupera todos los productos de la base de datos de forma
            //asíncrona y los almacena en la variable productos.
            
            //var productos = await _context.Productos.ToListAsync();

            var productos= await _productoRepository.GetAll();




            //return View(productos);: Devuelve la vista Index junto con la lista de productos.
            return View(productos);
        }

        public IActionResult Inicio()
        {
            return View();
        }



        // GET :    localhost:puerto/Producto/Create
        public IActionResult Create()
        {
            return View();
        }



        //POST :  localhost:puerto/Producto/Create
        //[HttpPost]: Atributo que indica que este método maneja solicitudes POST.

        [HttpPost]


        //public async Task<IActionResult> Create(Producto producto): Método que maneja solicitudes POST a Producto/Create, recibe
        //un objeto Producto que contiene los datos enviados por el formulario.
        public async Task<IActionResult>  Create(Producto producto)
        {
            //if (ModelState.IsValid): Verifica si el modelo es válido, es decir, si pasa todas las validaciones definidas en el
            //modelo Producto.
            if (ModelState.IsValid)
            {
                //Agregar logica para grabar en la BD
                //_context.Add(producto);: Agrega el nuevo producto al contexto de la base de datos.

                //producto.FechaDeAlta=DateTime.Now;
                //_context.Add(producto);

                //await _context.SaveChangesAsync();: Guarda los cambios en la base de datos de forma asíncrona.

                //await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));: Redirige al usuario a la acción Index después de guardar el producto.


                var result = await _productoRepository.Create(producto);
                if (result<0)
                {
                    ViewBag.ErrorMessage = "Error al guardar los datos";
                    return View(producto);
                }


                return RedirectToAction(nameof(Index));
            }
            ViewBag.ErrorMessage = "Modelo No válido";
            //return View(producto);: Si el modelo no es válido, retorna la vista Create con el modelo para que el usuario
            //pueda corregir los errores.
            return View(producto);



        }



        // GET :    localhost:puerto/Producto/Edit/id

        [HttpGet]

        public async Task<IActionResult> Edit(int id) 
        {
            if (id==0)
            {
                return NotFound();
            }    

            //var producto = await _context.Productos.FindAsync(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id==id);  

            var producto = await _productoRepository.GetById(id);



            if(producto==null) 
            {
                return NotFound();               
            }

            return View(producto);


        }


          //POST :  localhost:puerto/Producto/Edit/id
           
          [HttpPost]

          public async Task<IActionResult> Edit(int id,Producto producto)
          {
            if(id != producto.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid) 
            {
                // Actualizar la fecha de alta a la fecha actual
                //producto.FechaDeAlta = DateTime.Now;

                
                
                    //_context.Update(producto);
                    //await _context.SaveChangesAsync();

                   var result= await _productoRepository.Update(producto);

                    if (result <0)
                    {
                        ViewBag.ErrorMessage = "Error al guardar los datos";
                        return View(producto);
                    }


                
           
                
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = "Modelo No valido";
            }
           
            return View(producto);

          }

        //private bool ProductoExists(int id)
        //{
        //    return (_context.Productos?.Any(e => e.Id == id)).GetValueOrDefault();
        //}







        // GET :    localhost:puerto/Producto/Delete/id

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

           // var producto= await _context.Productos.FindAsync(id);

            var producto = await _productoRepository.GetById(id);

            if(producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }



        //POST :  localhost:puerto/Producto/Delete/id

        [HttpPost,ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirm(int id)
        {


            //var producto = await _context.Productos.FindAsync(id);


            //  _context.Productos.Remove(producto);
            //await _context.SaveChangesAsync();

            var result = await _productoRepository.DeleteById(id);

            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.ErrorMessage = "Error al borrar el producto";
                return View();
            }

           

            
        }





        public List<Producto> GetData()
        {

            List<Producto> productos = new List<Producto>();

            productos.Add(new Producto { Id = 1, Nombre = "Cafe", Descripcion = "Cafe en grano", Precio = 201.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 2, Nombre = "Cafe colombiano", Descripcion = "Cafe en grano colombiano", Precio = 230.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 3, Nombre = "Cafe sumatra", Descripcion = "Cafe en grano tipo sumatra", Precio = 250.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 4, Nombre = "Cafe molido", Descripcion = "Cafe molido fino", Precio = 300.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 5, Nombre = "Cafe molido", Descripcion = "Cafe molido medio", Precio = 400.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 6, Nombre = "Leche de almendras", Descripcion = "Leche de almendras", Precio = 50.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 7, Nombre = "Leche", Descripcion = "Leche de vaca", Precio = 40.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });
            productos.Add(new Producto { Id = 8, Nombre = "Botella de agua", Descripcion = "Botella de agua de 500 mL", Precio = 10.00m, Activo = true, FechaDeAlta = DateTime.Now.AddDays(-1) });

            return productos;

        }










    }
}
