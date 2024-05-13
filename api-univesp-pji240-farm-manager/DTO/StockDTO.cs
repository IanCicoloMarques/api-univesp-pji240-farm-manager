using CsvHelper.Configuration.Attributes;

namespace api_univesp_pji240_farm_manager.DTO
{
    public class StockDTO
    {
        [Name("Código")]
        public string code { get; set; }
        [Name("Ativo")]
        public string name { get; set; }
        [Name("Descrição")]
        public string description { get; set; }

        [Name("Máximo do dia")]
        public decimal maxDay { get; set; }
        [Name("Mínimo do dia")]
        public decimal minDay { get; set; }
        [Name("Preço de fechamento ajustado")]
        public decimal close {  get; set; }
        [Name("Data")]
        public DateTime Date { get; set; }

    }
}
