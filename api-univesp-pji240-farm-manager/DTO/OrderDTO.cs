namespace api_univesp_pji240_farm_manager.DTO
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public CustomerDTO Customer { get; set; }
        public List<ProductOrderDTO> ProductList { get; set; }
        public DateTime Date { get; set; }
        public bool isPaid { get; set; }
        public decimal Price { get; set; }

        public OrderDTO() { 
            ProductList = new List<ProductOrderDTO>();
        }
    }

    public class ProductOrderDTO
    {
        public int Amount { get; set; }
        public ProductDTO Product { get; set; }
    }
}
