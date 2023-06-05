
using Control_Inventario.Models;
using Microsoft.AspNetCore.Mvc;

namespace Control_Inventario.Services
{
    public class Pedido_ProveedorService:IPedido_ProveedorService
    {
        Context context;
        public Pedido_ProveedorService(Context db ) 
        {
            context= db; 
        }

        public IEnumerable<Pedido_Proveedor> Get()
        {
            return context.PedidosProveedores;
        }
        public async Task Save(Pedido_Proveedor pedido_Proveedor)
        {
            context.Add(pedido_Proveedor);
            await context.SaveChangesAsync();
        }
        public async Task Update(Pedido_Proveedor pedido_Proveedor, Guid id)
        {
            var pedidoActual=context.PedidosProveedores.Find(id);
            if (pedidoActual != null)
            {
                pedidoActual.PedidosProveedorId = pedido_Proveedor.PedidosProveedorId;
                pedidoActual.Encabezado = pedido_Proveedor.Encabezado;
                pedidoActual.Detalle = pedido_Proveedor.Detalle;
                pedidoActual.NombreProveedor = pedido_Proveedor.NombreProveedor;
                pedidoActual.ProductoId = pedido_Proveedor.ProductoId;
                pedidoActual.Cantidad = pedido_Proveedor.Cantidad;
                pedidoActual.Fecha = pedido_Proveedor.Fecha;
                pedidoActual.Estado = pedido_Proveedor.Estado;
                await context.SaveChangesAsync();
            }
            
          

        }

        public async Task Datele(Guid id)
        {
            var pedidoActual = context.PedidosProveedores.Find(id);
            if(pedidoActual != null)
            {
                context.Remove(pedidoActual);   
                await context.SaveChangesAsync();
            }
        }
    }

    public interface IPedido_ProveedorService
    {
        IEnumerable<Pedido_Proveedor> Get();
        Task Save(Pedido_Proveedor pedido_Proveedor);
        Task Update(Pedido_Proveedor pedido_Proveedor, Guid id);
        Task Datele(Guid id);

    }
}
