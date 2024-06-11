using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC2.Models;

namespace MiPrimerAppMVC2.Data
{
    public class ProductosContext : DbContext
    {
        //Conexión a la Base de Datos:
        //: base(options): Llama al constructor de la clase base (DbContext) con el parámetro options. Esto es necesario para
        //que DbContext pueda configurar la conexión a la base de datos utilizando las opciones proporcionadas (como la cadena
        //de conexión, el proveedor de la base de datos, etc.).

        //El constructor de ProductosContext se utiliza para configurar y conectar el contexto a la base de datos utilizando
        //las opciones proporcionadas.
        public ProductosContext(DbContextOptions<ProductosContext> options) : base(options)
        {




        }

        //Mapeo de Tablas: Las propiedades DbSet<Producto> y DbSet<Usuario> permiten que Entity Framework Core realice el mapeo
        //de las clases Producto y Usuario a las correspondientes tablas en la base de datos. Esto facilita las operaciones CRUD
        //(crear, leer, actualizar, eliminar) en estas tablas.



        //public DbSet<Producto> Productos { get; set; }: Define una propiedad Productos de tipo DbSet<Producto>.
        //Un DbSet representa una colección de todas las entidades en el contexto, o que pueden ser consultadas desde la
        //base de datos. En términos simples, cada DbSet corresponde a una tabla en la base de datos.
        public DbSet<Producto> Productos { get; set; }


        //public DbSet<Usuario> Usuarios { get; set; }: Define una propiedad Usuarios de tipo DbSet<Usuario>. Similarmente,
        //esta propiedad corresponde a otra tabla en la base de datos.
        public DbSet<Usuario> Usuarios { get; set; }


        // Configuración del modelo utilizando OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Precio)
                      .HasPrecision(18, 2); // Configura la precisión y escala para el campo Precio
            });

            base.OnModelCreating(modelBuilder);
        }






    }
}
