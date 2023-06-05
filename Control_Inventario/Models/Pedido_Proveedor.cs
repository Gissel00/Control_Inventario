using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Control_Inventario.Models
{
    public class Pedido_Proveedor
    {
        public Guid PedidosProveedorId { get; set; }
        public Guid ProductoId { get; set; }
        public string Encabezado { get; set; } 
        public string Detalle { get; set; }
        public string NombreProveedor { get;set; }

        [Range(1,int.MaxValue,ErrorMessage ="La cantidad tiene que ser mayor a cero")]
        public int Cantidad { get; set;}
        public DateTime Fecha { get; set;}
        public bool Estado { get; set;}
        public virtual ProductoProveedor? ProductoProveedor { get; set; }

    }
}
