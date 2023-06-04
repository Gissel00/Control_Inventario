using Control_Inventario.Entidades;
using Control_Inventario.Servicios;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;

namespace Control_Inventario.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductoController:ControllerBase
    {
        IProductosService productosService;

        public ProductoController(IProductosService service)
        {
            productosService = service;
        }

        [HttpGet()]
        public IActionResult Get() { 
            return Ok(productosService.Get()); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            productosService.Save(producto);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Producto producto)
        {
            productosService.Update(id, producto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            productosService.Delete(id);
            return Ok();
        }
    }
}
