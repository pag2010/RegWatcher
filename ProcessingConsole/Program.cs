using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProcessingConsole
{
    class Program
    {
        private static HttpClient httpClient;
        private static CookieContainer cookieContainer = new CookieContainer();
        private static Uri baseAddress = new Uri("https://localhost:44325/");
        static async Task Main(string[] args)
        {
            var clients = 100;
            var requests = 1;
            var TList = new List<Task>();
            httpClient = new HttpClient();
            for (int i = 0; i < clients; i++)
            {
                var t = Request(i, requests);
                TList.Add(t);
                Console.WriteLine($"{i} клиент пошел");
            }
            await Task.WhenAll(TList);
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        public static async Task Request(int client, int N)
        {
            for (int i = 0; i < N; i++)
            {
                try
                {
                    var start = DateTimeOffset.Now;
                    var res = await httpClient.GetAsync("https://localhost:44325/api/document/loadbyid?documentId=1");
                    var end = DateTimeOffset.Now;
                    Console.WriteLine($"{client} получил {i}/{N} ответ за {(end-start).TotalMilliseconds} ms");
                }
                catch
                {
                    Console.WriteLine($"*** {client} не получил {i}/{N} ответ");
                }
            }
        }
    }
}
