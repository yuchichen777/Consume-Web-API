using RestSharp;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://localhost:8000/api/Post");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Key", "Value");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
