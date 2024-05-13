using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace api_univesp_pji240_farm_manager.DTO
{
    public class CommodityDTO
    {

        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; } 
        public decimal maxPrice { get; set; }
        public decimal minPrice { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<Price> price { get; set; }

        public CommodityDTO() { 
            price = new List<Price>();
        }
        
    }

    public class Price
    {
        public decimal maxDay { get; set; }
        public decimal minDay { get; set; }
        public decimal close {  get; set; }
        public DateTime Date { get; set; }
        public decimal variation { get; set; }

    }

}
