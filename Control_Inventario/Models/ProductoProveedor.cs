using System.Text.Json.Serialization;
using System.Threading;

namespace Control_Inventario.Models
{
    public class ProductoProveedor
    {
        public Guid ProductoId { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Pedido_Proveedor>? Pedidos_Proveedores { get; set; }
    }
}
