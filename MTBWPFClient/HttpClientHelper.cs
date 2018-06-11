using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BookServiceClientApp
{
    public abstract class HttpClientHelper<T>
        where T : class
    {
        protected Uri _baseAddress;

        public HttpClientHelper(string baseAddress)
        {
            if (baseAddress == null) throw new ArgumentNullException(nameof(baseAddress));
            _baseAddress = new Uri(baseAddress);
        }

        //sync
        public virtual IEnumerable<T> GetAll(string requestUri)
        {
            string json = GetInternal(requestUri);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }

        public T Get(string requestUri)
        {
            string json =  GetInternal(requestUri);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private string GetInternal(string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                client.GetAsync(requestUri).ContinueWith(
                    (requestTask) =>
                    {

                        HttpResponseMessage response = requestTask.Result;
                        WriteLine($"status from GET {response.StatusCode}");

                        response.EnsureSuccessStatusCode();

                        return response.Content.ReadAsStringAsync();
                    });

                return "";
            }
        }

        public T Post(string uri, T item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                string json = JsonConvert.SerializeObject(item);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                client.PostAsync(uri, content).ContinueWith(
                    (requestTask) =>
                    {
                        HttpResponseMessage response = requestTask.Result;
                        WriteLine($"status from POST {response.StatusCode}");
                        response.EnsureSuccessStatusCode();
                        WriteLine($"added resource at {response.Headers.Location}");
                        response.Content.ReadAsStringAsync().ContinueWith(
                          (task) =>
                          {
                              json = task.Result;
                              return JsonConvert.DeserializeObject<T>(json);
                          });
                    });

                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public void Put(string uri, T item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                string json = JsonConvert.SerializeObject(item);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                client.PutAsync(uri, content).ContinueWith(
                    (requestTask) =>
                    {
                        HttpResponseMessage response = requestTask.Result;
                        WriteLine($"status from PUT {response.StatusCode}");
                        response.EnsureSuccessStatusCode();
                    });

            }
        }

        public void Delete(string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                client.DeleteAsync(uri).ContinueWith(
                    (requestTask) =>
                    {
                        HttpResponseMessage response = requestTask.Result;
                        WriteLine($"status from DELETE {response.StatusCode}");
                        response.EnsureSuccessStatusCode();
                    });
            }
        }

        //async
        public async virtual Task<IEnumerable<T>> GetAllAsync(string requestUri)
        {
            string json = await GetInternalAsync(requestUri);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }

        public async Task<T> GetAsync(string requestUri)
        {
            string json = await GetInternalAsync(requestUri);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private async Task<string> GetInternalAsync(string requestUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                HttpResponseMessage resp = await client.GetAsync(requestUri);
                WriteLine($"status from GET {resp.StatusCode}");
                resp.EnsureSuccessStatusCode();
                return await resp.Content.ReadAsStringAsync();
            }
        }

        public async Task<T> PostAsync(string uri, T item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                string json = JsonConvert.SerializeObject(item);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await client.PostAsync(uri, content);
                WriteLine($"status from POST {resp.StatusCode}");
                resp.EnsureSuccessStatusCode();
                WriteLine($"added resource at {resp.Headers.Location}");

                json = await resp.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public async Task PutAsync(string uri, T item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                string json = JsonConvert.SerializeObject(item);
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await client.PutAsync(uri, content);
                WriteLine($"status from PUT {resp.StatusCode}");
                resp.EnsureSuccessStatusCode();
            }
        }

        public async Task DeleteAsync(string uri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _baseAddress;
                HttpResponseMessage resp = await client.DeleteAsync(uri);
                WriteLine($"status from DELETE {resp.StatusCode}");
                resp.EnsureSuccessStatusCode();
            }
        }
    }
}
