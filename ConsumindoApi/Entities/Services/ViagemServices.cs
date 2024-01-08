using System.Text;
using System.Text.Json;

namespace ConsumindoApi.Entities.Services
{
    internal class ViagemServices
    {        
        public async Task<Viagems> Integracao(int id)
        {
            try
            {                 
                var url = "https://qa1orionbr.cevalogistics.com/WCFOrionMobilityMilkRun/Servicos/SincronizarService.svc/SincronizarCutOff";
                var data = new { Viagem = "0002528460" };
                var json = JsonSerializer.Serialize(data);                
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient())
                {
                    // Conexão com a API
                    var response = await httpClient.PostAsync(url, content);
                   
                    if (response.IsSuccessStatusCode)
                    {                        
                        var jsonString = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(jsonString);
                        var jsonObject = JsonSerializer.Deserialize<Viagems>(jsonString);
                        return jsonObject;
                    }
                    else
                    {
                        throw new HttpRequestException($"Failed to integrate with API: {response.StatusCode}");
                    }
                }                            
            }
            catch (Exception ex)
            {                
                await Console.Out.WriteLineAsync(string.Format("RestHttpClient.SendRequest failed: {0}", ex));
            }
            return null;
        }
    }
}
