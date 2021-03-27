using BertoniMiniproyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BertoniMiniproyecto.Data
{
    public static class HttpDataProvider
    {
        public static async Task<IEnumerable<T>> GetAsync<T>(string address)
        {
            using var httpProvider = new HttpClient();

            try
            {
                var response = await httpProvider.GetAsync(address);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string resultString = await response.Content.ReadAsStringAsync();
                    IEnumerable<T> result = JsonConvert.DeserializeObject<IEnumerable<T>>(resultString);
                    return result;
                }
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
