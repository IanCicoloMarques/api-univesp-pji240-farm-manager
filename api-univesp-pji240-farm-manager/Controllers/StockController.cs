using api_univesp_pji240_farm_manager.Controllers.Response;
using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.Data;
using api_univesp_pji240_farm_manager.Interface.UseCase;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;


namespace api_univesp_pji240_farm_manager.Controllers
{
    [ApiController]
    [Route("stock")]
    public class StockController : ControllerBase
    {

        private readonly MySqlConnection _connection;
        private readonly IDataProductRepository _data;
        private readonly ICommoditySolver _solver;

        public StockController(
                MySqlConnection connection
            ,   IDataProductRepository data
            ,   ICommoditySolver solver)
        {
            _connection = connection;
            _data = data;
            _solver = solver;
        }


        [HttpGet]
        [Route("GetStockList")]
        public List<CommodityList> GetStockList()
        {
            List<CommodityList> response = new List<CommodityList>();
            
            _solver.getCommodityList().ForEach(item => response.Add(new CommodityList()
            {

                name = item.name,
                code = item.code,
                description = item.description,
            }));

            return response;
        }

        [HttpGet]
        [Route("{code}")]
        public CommodityDTO GetStockData(string code)
        {
            return _solver.getCommodityList().First(commodity => commodity.code.Equals(code));
        }
    }
}
