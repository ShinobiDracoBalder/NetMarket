using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Errors;

namespace WebApi.Controllers
{
    public class ProductoController : BaseApiController
    {
        private readonly IGenericRepository<Producto> _productoRepository;
        private readonly IMapper _mapper;

        public ProductoController(IGenericRepository<Producto> productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }
        //http://localhost:55917/api/Producto/
        [HttpGet]
        public async Task<ActionResult<List<ProductoDto>>> GetProductos(ProductoSpecificationParams productoParams)
        {
            ProductoWithCategoriaAndMarcaSpecification spec = new ProductoWithCategoriaAndMarcaSpecification(productoParams);
            IReadOnlyList<Producto> productos = await _productoRepository.GetAllWithSpec(spec);
            if (productos == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
                //return NotFound();
            }
            return Ok(_mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos));
        }
        //http://localhost:55917/api/Producto/1
        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int Id)
        {
            //spec = debe de incluir la logica de las condicion  de la consulta y  tambien las relaciones entre las
            // entidades  y las relaciones entre producto  , marcas y  categoria
            ProductoWithCategoriaAndMarcaSpecification spec = new ProductoWithCategoriaAndMarcaSpecification(Id);
            Producto producto = await _productoRepository.GetByIdWithSpec(spec);

            if (producto == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }
            //return _mapper.Map<Producto, ProductoDto>(producto);
            return Ok(_mapper.Map<Producto, ProductoDto>(producto));
        }
    }
}
