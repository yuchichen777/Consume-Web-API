using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class RestSharpApiService : IApiService
    {
        private readonly string baseUrl = "http://localhost:8000/api";

        //x-www-form-urlencoded
        public ResponseModel<T> Post()
        {
            var apiUrl = baseUrl + "/Post";
            var client = new RestClient(apiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Key", "Value");
            IRestResponse response = client.Execute(request);

            var jsonString = response.Content;

            return JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
        }

        public ResponseModel<T> Get(string token)
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd");
            var apiUrl = baseUrl + $"/Get?QueryDate={date}";

            var bearer = "Bearer " + token;

            var client = new RestClient(apiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", bearer);
            IRestResponse response = client.Execute(request);
            var jsonString = response.Content;

            return JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
        }

        public ResponseModel<T> Get(string token)
        {
            var apiUrl = baseUrl + "/Get";

            var bearer = "Bearer " + token;

            var client = new RestClient(apiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", bearer);
            IRestResponse response = client.Execute(request);
            var jsonString = response.Content;

            return JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
        }

        public ResponseModel<T> Post(string token)
        {
            var apiUrl = baseUrl + "/Post";
            var bearer = "Bearer " + token;

            var client = new RestClient(apiUrl);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            request.AddHeader("Authorization", bearer);
            request.AddParameter(
                "application/json; charset=utf-8",
                "[\n" +
                "    {\n" +
                "        \"Id\": \"1\",\n" +
                "        \"Name\": \"Name\",\n" +
                "    }\n" +
                "]", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var jsonString = response.Content;

            return JsonConvert.DeserializeObject<ResponseModel<T>>(jsonString);
        }
    }
}
