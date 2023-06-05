using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Control_Inventario.Models
{
    public class Context: DbContext
    {
        public DbSet<Pedido_Proveedor> PedidosProveedores { get; set; }
        public DbSet<ProductoProveedor> ProductosProveedores { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<ProductoProveedor> productoProveedorInit = new List<ProductoProveedor>();
            productoProveedorInit.Add(new ProductoProveedor()
            {
                ProductoId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
                Nombre = "Jarabe"
            });

            modelBuilder.Entity<ProductoProveedor>(productoProveedor =>
            {
                productoProveedor.ToTable("ProductoProveedor");
                productoProveedor.HasKey(p => p.ProductoId);

                productoProveedor.Property(p => p.Nombre);

                    
                productoProveedor.HasData(productoProveedorInit);
            });


            List<Pedido_Proveedor> pedidosProveedorInit = new List<Pedido_Proveedor>();

            pedidosProveedorInit.Add(new Pedido_Proveedor() 
            { PedidosProveedorId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), 
            Encabezado="Pedido A ",
            Detalle = "Pedido de Medicamentos Para el Corazon",
            NombreProveedor="FixHard",
            ProductoId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"),
            Cantidad=3,
            Fecha=DateTime.Now,
            Estado=false});;

            modelBuilder.Entity<Pedido_Proveedor>(pedidoProveedor =>
            {
                pedidoProveedor.ToTable("Pedido_Proveedor");
                pedidoProveedor.HasKey(p => p.PedidosProveedorId);
                pedidoProveedor.HasOne(p => p.ProductoProveedor).WithMany(p => p.Pedidos_Proveedores).HasForeignKey(p => p.ProductoId);
                pedidoProveedor.Property(p => p.Detalle).IsRequired().HasMaxLength(150);
                pedidoProveedor.Property(p => p.Cantidad).IsRequired().HasPrecision(1,10000);
                pedidoProveedor.Property(p=>p.Fecha).IsRequired();
                pedidoProveedor.Property(p => p.Estado);
                    

                pedidoProveedor.HasData(pedidosProveedorInit);
            });

        }

    }
}
