using api_univesp_pji240_farm_manager.DTO;
using api_univesp_pji240_farm_manager.Interface.UseCase;
using CsvHelper;
using System.Globalization;

namespace api_univesp_pji240_farm_manager.UseCase
{
    public class CommoditySolver : ICommoditySolver
    {
        private List<CommodityDTO> commodityList { get; set; }

        public CommoditySolver() {
        
            commodityList = new List<CommodityDTO>();
            LoadCommodityFile();
        }

        public List<CommodityDTO> getCommodityList()
        {
            return this.commodityList;
        }

        public void LoadCommodityFile()
        {
            List<CommodityDTO> commoditiesList = new List<CommodityDTO>();

            string[] filePaths = Directory.GetFiles("../csv", "*_*.csv");

            foreach (string file in filePaths)
            {
                FileStream readFile = new FileStream(file, FileMode.Open);

                StreamReader sr = new StreamReader(readFile);
                using CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture);

                List<StockDTO> records = csv.GetRecords<StockDTO>().ToList();

                CommodityDTO commodity = new CommodityDTO();

                commodity.name = records.First().name;
                commodity.description = records.First().description;
                commodity.code = records.First().code;

                commodity.minPrice = records.Min(price => price.close);
                commodity.maxPrice = records.Max(price => price.close);

                commodity.startDate = records.Min(price => price.Date);
                commodity.endDate = records.Max(price => price.Date);

                foreach (StockDTO data in records)
                {
                    Price dataPoint = new Price()
                    {
                        maxDay = data.maxDay,
                        minDay = data.minDay,
                        close = data.close,
                        Date = data.Date,
                        variation = Normalize(data.close, commodity.minPrice, commodity.maxPrice)
                    };

                    commodity.price.Add(dataPoint);
                }


                commoditiesList.Add(commodity);

            }

            this.commodityList = commoditiesList;
        }

        private decimal Normalize(decimal precoDia, decimal precoMinimo, decimal precoMaximo, decimal normalizacaoMin = -1, decimal normalizacaoMax = 1)
        {
            return (((precoDia - precoMinimo) / (precoMaximo- precoMinimo)) * (normalizacaoMax - normalizacaoMin)) + normalizacaoMin;
        }


    }
}
