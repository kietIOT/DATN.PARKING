using DATN.PARKING.DLL;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace DATN.PARKING.API
{
    public interface IHttpUtils
    {
        Task<T> PostAsync<T>(string url, object content,
                                        string accesstoken = "",
                                        Dictionary<string, string> contentHeader = null);
        Task<T> PutAsync<T>(string url, object content);
        Task<T> DeleteAsync<T>(string url, object content);
        Task<T> GetAsync<T>(string url, object content,
                                        string token = "",
                                        Dictionary<string, string> contentHeader = null);
    }
    public class HttpUtils : IHttpUtils
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string HttpClientName = "TTOS";

        public HttpUtils(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<T> PostAsync<T>(string url,
                                         object content,
                                         string accesstoken = "",
                                         Dictionary<string, string> contentHeader = null)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(HttpClientName);
                HttpResponseMessage response;
                if (!string.IsNullOrEmpty(accesstoken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accesstoken);
                }
                if (!contentHeader.IsNullOrEmpty())
                {
                    foreach (var item in contentHeader)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value ?? string.Empty);
                    }
                }
                if (content == null)
                {
                    response = await client.PostAsync(url, null);
                }
                else
                {
                    response = await client.PostAsync(url, new StringContent(JsonUtils<object>.ToJson(content), Encoding.UTF8, "application/json"));
                }

                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(res, JsonSettings);
                }

                return default;


            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> PutAsync<T>(string url, object content)
        {

            var client = _httpClientFactory.CreateClient(HttpClientName);
            HttpResponseMessage response;
            if (content == null)
            {
                response = await client.PostAsync(url, null);
            }
            else
            {
                response = await client.PutAsync(url, new StringContent(JsonUtils<object>.ToJson(content), Encoding.UTF8, "application/json"));
            }

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(res, JsonSettings);
            }

            return default;

        }

        public async Task<T> DeleteAsync<T>(string url, object content)
        {

            var client = _httpClientFactory.CreateClient(HttpClientName);
            HttpResponseMessage response;
            if (content == null)
            {
                response = await client.DeleteAsync(url);
            }
            else
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(url),
                    Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")
                };
                response = await client.SendAsync(request);
            }

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(res, JsonSettings);
            }

            return default;

        }

        public async Task<T> GetAsync<T>(string url,
                                        object content,
                                        string token = "",
                                        Dictionary<string, string> contentHeader = null)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(HttpClientName);
                if (!token.IsNullOrEmpty())
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                if (!contentHeader.IsNullOrEmpty())
                {
                    foreach (var item in contentHeader)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value ?? string.Empty);
                    }
                }
                var response = await client.GetAsync(BuildQueryPath(url, content));
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(res, JsonSettings);

                }

                return default;

            }
            catch
            {
                return default;
            }

        }

        private string BuildQueryPath(string url, object obj)
        {
            try
            {
                if (obj == null)
                {
                    return url;
                }

                StringBuilder builder = new StringBuilder();
                string condition = "?";
                builder.Append(url);
                Type type = obj.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(type.GetProperties());

                foreach (PropertyInfo prop in props)
                {
                    var name = prop.Name;
                    var value = prop.GetValue(obj, null)
                                    .ToString();

                    builder.Append($"{condition}{name}={value}");
                    condition = "&";
                }

                return builder.ToString();

            }
            catch
            {
                return null;
            }

        }

        private readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}

