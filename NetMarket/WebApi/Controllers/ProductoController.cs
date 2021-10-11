using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGenericRepository<Producto> _productoRepository;

        public ProductoController(IGenericRepository<Producto> productoRepository)
        {
           _productoRepository = productoRepository;
        }
        //http://localhost:55917/api/Producto/
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos() {
            var productos = await _productoRepository.GetAllAsync();
            if (productos == null)
            {
                //return NotFound(new CodeErrorResponse(404, "El producto no existe"));
                return NotFound();
            }
            return Ok(productos);
        }
        //http://localhost:55917/api/Producto/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<Producto>> GetProducto(int Id) {
            var producto =await _productoRepository.GetByIdAsync(Id);

            if (producto ==null)
            {
                return NotFound();
            }
            return Ok(producto);
        }
    }
}
