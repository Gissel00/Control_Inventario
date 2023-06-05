using Control_Inventario.Models;
using Control_Inventario.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Control_Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pedido_ProveedorController : ControllerBase
    {
        IPedido_ProveedorService _service;
        Context dbcontext;
        public Pedido_ProveedorController(IPedido_ProveedorService service, Context dbcontext)
        {
            _service = service;
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            dbcontext.Database.EnsureCreated();

            return Ok();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }
        [HttpPost]
        public IActionResult Post([FromBody] Pedido_Proveedor pedido_Proveedor)
        {
            _service.Save(pedido_Proveedor);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Pedido_Proveedor pedido_Proveedor,Guid id)
        {
            _service.Update(pedido_Proveedor, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Datele(id);
            return Ok();
        }
    }
}
