using Control_Inventario.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Transactions;

namespace Control_Inventario.Servicios
{
    public class ProductosService : IProductosService
    {
        private readonly InventarioContext _inventarioContext;

        public ProductosService( InventarioContext inventarioContext)
        {
            _inventarioContext = inventarioContext;
        }
        
        public IEnumerable<Producto> Get()
        {
            return _inventarioContext.Productos;
        }

        public async Task Save(Producto producto)
        {
           _inventarioContext.Add(producto);

            await _inventarioContext.SaveChangesAsync();

        }

        public async Task Update(Guid id, Producto producto)
        {
            var productoactual = _inventarioContext.Productos.Find(id);


            if (productoactual != null)
            {
                productoactual.Nombre = producto.Nombre;
                productoactual.Presentacion = producto.Presentacion;
                productoactual.Unidades = producto.Unidades;
                productoactual.LineaProducto = producto.LineaProducto;
                productoactual.Activo = producto.Activo;

                await _inventarioContext.SaveChangesAsync();

            }


        }
        public async Task Delete(Guid id)
        {
            var categoriaACtual = _inventarioContext.Productos.Find(id);

            if (categoriaACtual != null)
            {
                _inventarioContext.Remove(categoriaACtual);
                await _inventarioContext.SaveChangesAsync();

            }
        }

    }

    public interface IProductosService
    {
        IEnumerable<Producto> Get();
        Task Save(Producto producto);
        Task Update(Guid id, Producto producto);
        Task Delete(Guid id);

    }
}
