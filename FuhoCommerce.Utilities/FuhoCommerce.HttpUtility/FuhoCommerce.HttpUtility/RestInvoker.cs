using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FuhoCommerce.HttpUtility
{
    public class RestInvoker
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RestInvoker> _logger;

        public RestInvoker(HttpClient httpClient, ILogger<RestInvoker> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        private async Task<Uri> GetUri(string serviceUri)
        {
            return new Uri(serviceUri);
        }

        private void AddHeader(Dictionary<string, string> headers)
        {
            foreach (var item in headers)
            {
                if (_httpClient.DefaultRequestHeaders.Contains(item.Key))
                    _httpClient.DefaultRequestHeaders.Remove(item.Key);
                _httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
            }
        }

        public virtual HttpClient GetHttpClient()
        {
            return _httpClient;
        }

        public virtual async Task<TReturnMessage> GetAsync<TReturnMessage>(string fullUrl,
            Dictionary<string, string> headers, string mediaType = "application/json")
        {
            var uri = await GetUri(fullUrl);

            _logger.LogInformation("[INFO] Async GET Uri:" + uri);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

            AddHeader(headers);

            var response = await _httpClient.GetAsync(uri);

            //default is TReturnMessage
            if (!response.IsSuccessStatusCode) return default;

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<byte[]> GetFileAsync<TReturnMessage>(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = await GetUri(fullUrl);

            _logger.LogInformation("[INFO] Async GET File Uri:" + uri);

            _httpClient.DefaultRequestHeaders.Accept.Clear();

            AddHeader(headers);

            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;
            var result = await response.Content.ReadAsByteArrayAsync();
            return result;
        }

        public virtual async Task<TReturnMessage> PostAsync<TReturnMessage>(string fullUrl, string jsonData,
            Dictionary<string, string> headers)
            where TReturnMessage : class, new()
        {
            var uri = await GetUri(fullUrl);
            _logger.LogInformation("[INFO] Async POST Uri:" + uri);

            AddHeader(headers);

            var response = await _httpClient.PostAsync(uri, new StringContent(jsonData, Encoding.UTF8, "application/json"));


            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return await Task.FromResult(new TReturnMessage());
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<TReturnMessage> PostAsync<TReturnMessage>(string fullUrl, HttpContent dataContent,
            Dictionary<string, string> headers)
            where TReturnMessage : class, new()
        {
            var uri = await GetUri(fullUrl);
            _logger.LogInformation("[INFO] Async POST Uri:" + uri);

            AddHeader(headers);
            var response =
                await _httpClient.PostAsync(uri, dataContent);

            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return await Task.FromResult(new TReturnMessage());

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<TReturnMessage> PutAsync<TReturnMessage>(string fullUrl, string jsonStringData,
            Dictionary<string, string> headers = null)
            where TReturnMessage : class, new()
        {
            var uri = await GetUri(fullUrl);
            _logger.LogInformation("[INFO] Async PUT Uri:" + uri);

            AddHeader(headers);

            var response = await _httpClient.PutAsync(uri, new StringContent(jsonStringData, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return await Task.FromResult(new TReturnMessage());

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<TReturnMessage> DeleteAsync<TReturnMessage>(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = await GetUri(fullUrl);
            _logger.LogInformation("[INFO] Async DELETE Uri:" + uri);

            AddHeader(headers);

            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return default;

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<HttpResponseMessage> GetAsync(string fullUrl,
           Dictionary<string, string> headers, string mediaType = "application/json")
        {
            var uri = await GetUri(fullUrl);

            _logger.LogInformation("[INFO] Async GET Uri:" + uri);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));

            AddHeader(headers);

            return await _httpClient.GetAsync(uri);
        }

        public virtual async Task<HttpResponseMessage> GetFileAsync(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = await GetUri(fullUrl);

            _logger.LogInformation("[INFO] Async GET File Uri:" + uri);

            _httpClient.DefaultRequestHeaders.Accept.Clear();

            AddHeader(headers);

            return await _httpClient.GetAsync(uri);
        }

        public virtual async Task<HttpResponseMessage> PostAsync(string fullUrl, string jsonStringData,
            Dictionary<string, string> headers)
        {
            var uri = await GetUri(fullUrl);
            _logger.LogInformation("[INFO] Async POST Uri:" + uri);

            AddHeader(headers);

            return await _httpClient.PostAsync(uri, new StringContent(jsonStringData, Encoding.UTF8, "application/json"));
        }

        public virtual async Task<HttpResponseMessage> PostAsync(string fullUrl, HttpContent dataContent,
            Dictionary<string, string> headers)
        {
            var uri = await GetUri(fullUrl);
            _logger.LogInformation("[INFO] Async POST Uri:" + uri);

            AddHeader(headers);

            return await _httpClient.PostAsync(uri, dataContent);
        }

        public virtual async Task<HttpResponseMessage> PutAsync(string fullUrl, string jsonStringData,
            Dictionary<string, string> headers = null)
        {
            var uri = await GetUri(fullUrl);
            _logger.LogInformation("[INFO] Async PUT Uri:" + uri);

            AddHeader(headers);

            return await _httpClient.PutAsync(uri, new StringContent(jsonStringData, Encoding.UTF8, "application/json"));
        }

        public virtual async Task<HttpResponseMessage> DeleteAsync(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = await GetUri(fullUrl);
            _logger.LogInformation("[INFO] Async DELETE Uri:" + uri);

            AddHeader(headers);

            return await _httpClient.DeleteAsync(uri);
        }
    }
}
