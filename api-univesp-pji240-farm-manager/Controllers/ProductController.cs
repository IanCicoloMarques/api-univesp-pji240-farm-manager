using api_univesp_pji240_farm_manager.DTO;
using Microsoft.AspNetCore.Mvc;

namespace api_univesp_pji240_farm_manager.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {

        private static readonly List<ProductDTO> productList = new List<ProductDTO>()
        {
            new ProductDTO { id = 1, Name = "Alface", Price = 4.99M, Image = "https://www.proativaalimentos.com.br/image/cache/catalog/img_prod/1839128[1]-500x500.jpg" },
            new ProductDTO { id = 2, Name = "Rúcula", Price = 3.49M, Image = "https://naturaldaterra.com.br/media/catalog/product/1/3/137546---2114330000000---rucula-org-un.jpg?auto=webp&format=pjpg&width=640&height=800&fit=cover" },
            new ProductDTO { id = 3, Name = "Coentro", Price = 2.99M, Image = "https://cdn.realleve.com.br/media/catalog/product/cache/1/image/1540x1540/9df78eab33525d08d6e5fb8d27136e95/c/o/coentro_verde_1.jpg" },
            new ProductDTO { id = 4, Name = "Almeirão", Price = 5.29M, Image = "https://www.proativaalimentos.com.br/image/cache/catalog/img_prod/almeirao[1]-500x500.jpg" },
            new ProductDTO { id = 5, Name = "Cheiro Verde", Price = 1.79M, Image = "https://coopsp.vtexassets.com/arquivos/ids/221088-800-800?v=637919564317570000&width=800&height=800&aspect=true" },
            new ProductDTO { id = 6, Name = "Brócolis", Price = 6.99M, Image = "https://cptstatic.s3.amazonaws.com/imagens/enviadas/materias/materia28605/plantio-de-brocolis-cursos-cpt.jpg" },
            new ProductDTO { id = 7, Name = "Mandioca", Price = 3.89M, Image = "https://saude.abril.com.br/wp-content/uploads/2016/12/mandioca.jpg?quality=85&strip=info&w=680&h=453&crop=1" },
            new ProductDTO { id = 8, Name = "Maxixe", Price = 2.49M, Image = "https://images.squarespace-cdn.com/content/v1/5b8edfa12714e508f756f481/1538768626826-X7039LAC5CZBCVG4OT2F/maxixe3.jpg?format=500w" },
            new ProductDTO { id = 9, Name = "Quiabo", Price = 4.59M, Image = "https://giassi.vtexassets.com/arquivos/ids/512350-800-auto?v=637995086005470000&width=800&height=auto&aspect=true" }
        };


        public ProductController()
        {
        }


        [HttpGet]
        public List<ProductDTO> GetCustomerList()
        {
            return productList;
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult AddProduct(ProductDTO request)
        {
            productList.Add(request);

            return Ok();

        }

    }
}
