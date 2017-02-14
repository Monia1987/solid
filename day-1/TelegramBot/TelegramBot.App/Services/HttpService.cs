using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TelegramBot.App.Services
{
    public class HttpService
    {
        public virtual async Task<string> GetAsync(string url)
        {
            using (var httpClient = CreateClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(url);
                    return await ReadString(response);
                }
                catch (Exception ex)
                {
                    throw new Exception("HttpService exception", ex);
                }
            }
        }

        protected virtual HttpClient CreateClient(int timeout = 0)
        {
            var httpClient = new HttpClient();
            if (timeout > 0)
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);

            return httpClient;
        }

        protected async Task<string> ReadString(HttpResponseMessage response)
        {
            if (response?.Content == null)
                return string.Empty;

            return await response.Content.ReadAsStringAsync();
        }
    }
}
