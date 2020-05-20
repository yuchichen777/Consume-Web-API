using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ConsoleApp
{
    public class HttpClient
    {
        private readonly string baseUrl = "http://localhost/api";

        //x-www-form-urlencoded
        public ResponseModel<T> Post()
        {
            var apiUrl = baseUrl + "/Post";

            var dict = new Dictionary<string, string>();
            dict.Add("Key", "Value");
            var client = new HttpClient();
            var response = client.PostAsync(apiUrl, new FormUrlEncodedContent(dict)).Result;
            var jsonString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
        }

        //UrlQuery and Bearer
        public ResponseModel<T> Get(string token)
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd");
            var apiUrl = baseUrl + $"/Get/Query?QueryDate={date}";

            var bearer = "Bearer " + token;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", bearer);
            var response = client.GetAsync(apiUrl).Result;
            var jsonString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
        }

        //Bearer
        public ResponseModel<T> Get(string token)
        {
            var apiUrl = baseUrl + "/Get";

            var bearer = "Bearer " + token;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", bearer);
            var response = client.GetAsync(apiUrl).Result;
            var jsonString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
        }

        //Raw JSON
        public ResponseModel<T> Post(string token)
        {
            var apiUrl = baseUrl + "/Post";
            var bearer = "Bearer " + token;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", bearer);
            var content = new StringContent(
                "[\n" +
                "    {\n" +
                "        \"Id\": \"1\",\n" +
                "        \"Name\": \"Name\",\n" +
                "    }\n" +
                "]", Encoding.UTF8, "application/json");
            var response = client.PostAsync(apiUrl, content).Result;
            var jsonString = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
        }
    }
}

