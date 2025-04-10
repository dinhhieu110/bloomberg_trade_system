using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using server.dtos.stock;
using server.interfaces;
using server.mappers;
using server.models;

namespace server.services
{
  public class FMPService : IFMPService
  {
    private HttpClient _httpClient;
    private IConfiguration _config;
    public FMPService(HttpClient httpClient, IConfiguration config)
    {
      _httpClient = httpClient;
      _config = config;
    }

    public async Task<Stock> FindStockBySymbolAsync(string symbol)
    {
      try
      {
        var result = await _httpClient.GetAsync($"https://financialmodelingprep.com/api/v3/profile/ma?apikey=A4INuO1JsvFRUNmYXOVl47G0iFtEEXki");
             result.EnsureSuccessStatusCode(); // Throws if not 2xx status code

        if (result.IsSuccessStatusCode)
        {
          var content = await result.Content.ReadAsStringAsync();
          var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
          var stock = tasks[0];
          if (stock != null)
          {
            return stock.MapFMPStockToAPI();
          }
          return null;
        }
        return null;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
  }
}
