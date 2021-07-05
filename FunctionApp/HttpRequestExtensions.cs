using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FunctionApp
{
    public static class HttpRequestExtensions
    {
        public static async Task<T> ParsePostBody<T>(this HttpRequest req) where T : class
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            return JsonConvert.DeserializeObject<T>(requestBody);
        }
    }
}
