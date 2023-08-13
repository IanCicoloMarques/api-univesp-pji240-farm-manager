using api_univesp_pji240_farm_manager.DTO;
using Microsoft.AspNetCore.Mvc;

namespace api_univesp_pji240_farm_manager.Controllers
{
    [ApiController]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {

        private static readonly List<CustomerDTO> customerList = new List<CustomerDTO>()
        {
            new CustomerDTO { Address = "Rua X, 150", id = 1, Name = "Eduardo", Phone = "11912345678"},
            new CustomerDTO { Address = "Rua Y, 7611", id = 2, Name = "Felipe", Phone = "1275498215"},
            new CustomerDTO { Address = "Rua Z, 885", id = 3, Name = "Graco", Phone = "13975469820"},
            new CustomerDTO { Address = "Rua A, 198", id = 4, Name = "Gustavo", Phone = "14964910235"},
            new CustomerDTO { Address = "Rua B, 10", id = 5, Name = "Ian", Phone = "1641348752"},
            new CustomerDTO { Address = "Rua C, 45", id = 6, Name = "Paulo", Phone = "1879461384"},
            new CustomerDTO { Address = "Rua I, 0", id = 7, Name = "Richard", Phone = "19968743168"},
            new CustomerDTO { Address = "Rua J, 8450", id = 8, Name = "Vittor", Phone = "15946810254"}
        };


        public CustomerController()
        {
        }


        [HttpGet]
        [Route("GetCustomerList")]
        public List<CustomerDTO> GetCustomerList()
        {
            return customerList;
        }

        [HttpPost]
        [Route("RegisterCustomer")]
        public ActionResult RegisterCustomer(CustomerDTO customer)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult RemoveCustomer(int id)
        {
            int id2 = id;
            return Ok();
        }
    }
}
