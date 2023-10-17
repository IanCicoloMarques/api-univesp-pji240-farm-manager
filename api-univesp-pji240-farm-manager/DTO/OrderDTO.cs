namespace api_univesp_pji240_farm_manager.DTO
{
    public class OrderDTO
    {
        public long OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<ProductDTO> ProductList { get; set; }
        public bool isPaid { get; set; }

        public OrderDTO() { 
            ProductList = new List<ProductDTO>();
        }
    }
}
