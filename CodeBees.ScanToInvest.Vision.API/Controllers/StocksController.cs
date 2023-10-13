using CodeBees.ScanToInvest.Vision.API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeBees.ScanToInvest.Vision.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        static string apiKey = "jQxoa2Zulrr6NKCkd0pjXz4i_fJPmeOs";
        static string endpoint = "https://api.polygon.io/v3/reference/tickers";

        static HttpClient client = new HttpClient();

        // GET api/<StocksController>/Apple Inc.
        [HttpGet("{search}")]
        public async Task<string> GetStocks(string search)
        {
            StocksResponse? result = null;
            HttpResponseMessage response = await client.GetAsync(String.Format("{0}?search={1}&active=true&apiKey={2}", endpoint, search, apiKey));
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<StocksResponse>();
            }
            else return response.StatusCode.ToString();

            return result != null && result.Results.Any() ? result.Results[0].Ticker : "Stock not found.";
        }

        // GET api/<StocksController>/AAPL
        [HttpGet("details/{ticker}")]
        public async Task<StockDetailResponse?> GetStockDetails(string ticker)
        {
            StockDetailResponse? result = null;
            HttpResponseMessage response = await client.GetAsync(String.Format("{0}/{1}?apiKey={2}", endpoint, ticker, apiKey));
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadFromJsonAsync<StockDetailResponse>();
            }

            return result;
        }

    }
}
