// https://api.coindesk.com/v1/bpi/currentprice.json

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PricingApp
{
    public class BitcoinPrice 
    {
        const string BitcoinServiceUrl = "https://api.coindesk.com/v1/bpi/currentprice.json";
        private static readonly HttpClient client = new HttpClient();

        public async Task<CurrentPrice> GetPriceAsync()
        {
            string json = await RequestJsonAsync();
            CurrentPrice price = new CurrentPrice();

            using (var doc = JsonDocument.Parse(json)) 
            {
                decimal usd;
                doc.RootElement.GetProperty("bpi").GetProperty("USD")
                    .GetProperty("rate_float").TryGetDecimal(out usd);
                price.USD = usd;
                
                var isoString = doc.RootElement.GetProperty("time").GetProperty("updatedISO")
                    .GetString();
                price.Updated = DateTime.Parse(isoString);
            }

            return price;
        }

        private async Task<string> RequestJsonAsync()
        {
            // string filename = "currentprice.json";
            //  File.ReadAllText(filename);
            string json = await client.GetStringAsync(BitcoinServiceUrl);
            return json;
        }
    }

    public class CurrentPrice
    {
        public DateTime Updated { get; set; }
        public decimal USD { get; set; }
    }
}
