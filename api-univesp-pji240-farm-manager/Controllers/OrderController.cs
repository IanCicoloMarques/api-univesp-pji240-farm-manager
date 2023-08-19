using api_univesp_pji240_farm_manager.DTO;
using Microsoft.AspNetCore.Mvc;

namespace api_univesp_pji240_farm_manager.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        ProductDTO Alface = new ProductDTO { id = 1, Name = "Alface", Price = 4.99M, Image = "https://www.proativaalimentos.com.br/image/cache/catalog/img_prod/1839128[1]-500x500.jpg" };
        ProductDTO Rucula = new ProductDTO { id = 2, Name = "Rúcula", Price = 3.49M, Image = "https://naturaldaterra.com.br/media/catalog/product/1/3/137546---2114330000000---rucula-org-un.jpg?auto=webp&format=pjpg&width=640&height=800&fit=cover" };
        ProductDTO Coentro = new ProductDTO { id = 3, Name = "Coentro", Price = 2.99M, Image = "https://cdn.realleve.com.br/media/catalog/product/cache/1/image/1540x1540/9df78eab33525d08d6e5fb8d27136e95/c/o/coentro_verde_1.jpg" };
        ProductDTO Almeirao = new ProductDTO { id = 4, Name = "Almeirão", Price = 5.29M, Image = "https://www.proativaalimentos.com.br/image/cache/catalog/img_prod/almeirao[1]-500x500.jpg" };
        ProductDTO Cheiro = new ProductDTO { id = 5, Name = "Cheiro Verde", Price = 1.79M, Image = "https://coopsp.vtexassets.com/arquivos/ids/221088-800-800?v=637919564317570000&width=800&height=800&aspect=true" };
        ProductDTO Brocolis = new ProductDTO { id = 6, Name = "Brócolis", Price = 6.99M, Image = "https://cptstatic.s3.amazonaws.com/imagens/enviadas/materias/materia28605/plantio-de-brocolis-cursos-cpt.jpg" };
        ProductDTO Mandioca = new ProductDTO { id = 7, Name = "Mandioca", Price = 3.89M, Image = "https://saude.abril.com.br/wp-content/uploads/2016/12/mandioca.jpg?quality=85&strip=info&w=680&h=453&crop=1" };
        ProductDTO Maxixe = new ProductDTO { id = 8, Name = "Maxixe", Price = 2.49M, Image = "https://images.squarespace-cdn.com/content/v1/5b8edfa12714e508f756f481/1538768626826-X7039LAC5CZBCVG4OT2F/maxixe3.jpg?format=500w" };
        ProductDTO Quiabo = new ProductDTO { id = 9, Name = "Quiabo", Price = 4.59M, Image = "https://giassi.vtexassets.com/arquivos/ids/512350-800-auto?v=637995086005470000&width=800&height=auto&aspect=true" };

        CustomerDTO Eduardo = new CustomerDTO { Address = "Rua X, 150", id = 1, Name = "Eduardo", Phone = "11912345678" };
        CustomerDTO Felipe = new CustomerDTO { Address = "Rua Y, 7611", id = 2, Name = "Felipe", Phone = "1275498215" };
        CustomerDTO Graco = new CustomerDTO { Address = "Rua Z, 885", id = 3, Name = "Graco", Phone = "13975469820" };
        CustomerDTO Gustavo = new CustomerDTO { Address = "Rua A, 198", id = 4, Name = "Gustavo", Phone = "14964910235" };
        CustomerDTO Ian = new CustomerDTO { Address = "Rua B, 10", id = 5, Name = "Ian", Phone = "1641348752" };
        CustomerDTO Paulo = new CustomerDTO { Address = "Rua C, 45", id = 6, Name = "Paulo", Phone = "1879461384" };
        CustomerDTO Richard = new CustomerDTO { Address = "Rua I, 0", id = 7, Name = "Richard", Phone = "19968743168" };
        CustomerDTO Vittor = new CustomerDTO { Address = "Rua J, 8450", id = 8, Name = "Vittor", Phone = "15946810254" };

        DateTime dia0 = DateTime.Now.AddDays(-5).Date;
        DateTime dia1 = DateTime.Now.AddDays(-4).Date;
        DateTime dia2 = DateTime.Now.AddDays(-3).Date;
        DateTime dia3 = DateTime.Now.AddDays(-2).Date;
        DateTime dia4 = DateTime.Now.AddDays(-1).Date;
        DateTime dia5 = DateTime.Now.Date;
        DateTime dia6 = DateTime.Now.AddDays(1).Date;
        DateTime dia7 = DateTime.Now.AddDays(2).Date;
        DateTime dia8 = DateTime.Now.AddDays(3).Date;
        DateTime dia9 = DateTime.Now.AddDays(4).Date;
        DateTime dia10 = DateTime.Now.AddDays(5).Date;

        private List<OrderDTO> orderList;


        public OrderController()
        {
            List<ProductOrderDTO> Lista1 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 1, Product = Alface }, new ProductOrderDTO { Amount = 3, Product = Rucula }, new ProductOrderDTO { Amount = 2, Product = Coentro } };
            List<ProductOrderDTO> Lista2 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 4, Product = Almeirao }, new ProductOrderDTO { Amount = 3, Product = Cheiro } };
            List<ProductOrderDTO> Lista3 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 2, Product = Brocolis }, new ProductOrderDTO { Amount = 5, Product = Mandioca } };
            List<ProductOrderDTO> Lista4 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 6, Product = Maxixe }, new ProductOrderDTO { Amount = 7, Product = Quiabo }, new ProductOrderDTO { Amount = 2, Product = Alface } };
            List<ProductOrderDTO> Lista5 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 3, Product = Rucula }, new ProductOrderDTO { Amount = 4, Product = Cheiro } };
            List<ProductOrderDTO> Lista6 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 5, Product = Mandioca }, new ProductOrderDTO { Amount = 4, Product = Brocolis } };
            List<ProductOrderDTO> Lista7 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 2, Product = Maxixe }, new ProductOrderDTO { Amount = 3, Product = Almeirao }, new ProductOrderDTO { Amount = 4, Product = Rucula } };
            List<ProductOrderDTO> Lista8 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 3, Product = Quiabo }, new ProductOrderDTO { Amount = 2, Product = Alface } };
            List<ProductOrderDTO> Lista9 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 1, Product = Brocolis }, new ProductOrderDTO { Amount = 3, Product = Rucula }, new ProductOrderDTO { Amount = 2, Product = Coentro } };
            List<ProductOrderDTO> Lista10 = new List<ProductOrderDTO>() { new ProductOrderDTO { Amount = 2, Product = Mandioca }, new ProductOrderDTO { Amount = 3, Product = Quiabo } };

            OrderDTO order1 = new OrderDTO { Customer = Eduardo, Date = dia1, Id = 1, isPaid = false, Price = 33.87M, ProductList = Lista3 };
            OrderDTO order2 = new OrderDTO { Customer = Felipe, Date = dia9, Id = 2, isPaid = true, Price = 38.58M, ProductList = Lista4 };
            OrderDTO order3 = new OrderDTO { Customer = Graco, Date = dia6, Id = 3, isPaid = true, Price = 47.27M, ProductList = Lista1 };
            OrderDTO order4 = new OrderDTO { Customer = Gustavo, Date = dia4, Id = 4, isPaid = false, Price = 54.82M, ProductList = Lista6 };
            OrderDTO order5 = new OrderDTO { Customer = Ian, Date = dia8, Id = 5, isPaid = false, Price = 29.52M, ProductList = Lista2 };
            OrderDTO order6 = new OrderDTO { Customer = Paulo, Date = dia5, Id = 6, isPaid = true, Price = 45.81M, ProductList = Lista9 };
            OrderDTO order7 = new OrderDTO { Customer = Richard, Date = dia3, Id = 7, isPaid = false, Price = 47.18M, ProductList = Lista10 };
            OrderDTO order8 = new OrderDTO { Customer = Vittor, Date = dia7, Id = 8, isPaid = false, Price = 33.72M, ProductList = Lista5 };
            OrderDTO order9 = new OrderDTO { Customer = Eduardo, Date = dia2, Id = 9, isPaid = true, Price = 31.47M, ProductList = Lista8 };
            OrderDTO order10 = new OrderDTO { Customer = Felipe, Date = dia0, Id = 10, isPaid = false, Price = 26.45M, ProductList = Lista7 };
            OrderDTO order11 = new OrderDTO { Customer = Graco, Date = dia5, Id = 11, isPaid = false, Price = 21.45M, ProductList = Lista6 };
            OrderDTO order12 = new OrderDTO { Customer = Gustavo, Date = dia3, Id = 12, isPaid = true, Price = 18.91M, ProductList = Lista3 };
            OrderDTO order13 = new OrderDTO { Customer = Ian, Date = dia9, Id = 13, isPaid = true, Price = 12.45M, ProductList = Lista8 };
            OrderDTO order14 = new OrderDTO { Customer = Paulo, Date = dia4, Id = 14, isPaid = false, Price = 23.38M, ProductList = Lista7 };
            OrderDTO order15 = new OrderDTO { Customer = Richard, Date = dia6, Id = 15, isPaid = false, Price = 12.05M, ProductList = Lista9 };
            OrderDTO order16 = new OrderDTO { Customer = Vittor, Date = dia1, Id = 16, isPaid = true, Price = 17.66M, ProductList = Lista10 };
            OrderDTO order17 = new OrderDTO { Customer = Eduardo, Date = dia0, Id = 17, isPaid = true, Price = 33.87M, ProductList = Lista3 };
            OrderDTO order18 = new OrderDTO { Customer = Felipe, Date = dia8, Id = 18, isPaid = false, Price = 38.58M, ProductList = Lista4 };
            OrderDTO order19 = new OrderDTO { Customer = Graco, Date = dia7, Id = 19, isPaid = true, Price = 47.27M, ProductList = Lista1 };
            OrderDTO order20 = new OrderDTO { Customer = Gustavo, Date = dia2, Id = 20, isPaid = false, Price = 54.82M, ProductList = Lista6 };

            orderList = new List<OrderDTO>()
            {
                order1, order2, order3, order4, order5,
                order6, order7, order8, order9, order10,
                order11, order12, order13, order14, order15,
                order16, order17, order18, order19, order20
            };

        }


        [HttpGet]
        public List<OrderDTO> GetOrderList()
        {

            return orderList;
        }

        [HttpPost]
        [Route("GetOrderByDate")]
        public List<OrderDTO> SaveOrder(DateTime date)
        {
            List<OrderDTO> response = new List<OrderDTO>();

            response = orderList.FindAll(o => o.Date == date);

            return response;
        }

        [HttpPost]
        [Route("SaveOrder")]
        public ActionResult SaveOrder(OrderDTO request)
        {
            orderList.Add(request);

            return Ok();
        }

    }
}
