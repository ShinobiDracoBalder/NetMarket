using Core.Entities;

namespace Core.Specifications
{
    public class ProductoWithCategoriaAndMarcaSpecification : BaseSpecification<Producto>
    {
        public ProductoWithCategoriaAndMarcaSpecification(ProductoSpecificationParams productoParams)
            :base(x => (!productoParams.Marca.HasValue || x.MarcaId == productoParams.Marca) &&
                        (!productoParams.Categoria.HasValue || x.CategoriaId == productoParams.Categoria)
            )
        {
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
            //AddOrderBy(p => p.Nombre);
            if (!string.IsNullOrEmpty(productoParams.Sort))
            {
                switch (productoParams.Sort)
                {
                    case "nombreAsc":
                        AddOrderBy(p => p.Nombre);
                        break;
                    case "nombreDesc":
                        AddOrderByDescending(p => p.Nombre);
                        break;
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDescending(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    default:
                        AddOrderBy(p => p.Nombre);
                        break;
                }
            }
        }
        public ProductoWithCategoriaAndMarcaSpecification(int id): base(x => x.Id == id){
            AddInclude(p => p.Categoria);
            AddInclude(p => p.Marca);
        }
    }
}
