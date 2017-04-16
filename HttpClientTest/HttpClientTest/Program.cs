using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientTest
{
    class Program
    {
        protected static HttpClient httpClient;
        private static HttpClientHandler handler;
        static void Main(string[] args)
        {
            Init();
            var url = "http://localhost:62967/HttpClient/TestGet?Name=Get";
            var result = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

            List<KeyValuePair<String, String>> paramList = new List<KeyValuePair<String, String>>();
            paramList.Add(new KeyValuePair<string, string>("name", "post"));
            var response = httpClient.PostAsync(new Uri("http://localhost:62967/HttpClient/TestPost"), new FormUrlEncodedContent(paramList)).Result;
            result = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static void Init()
        {
            handler = new HttpClientHandler();

            handler.AllowAutoRedirect = false;



            httpClient = new HttpClient(handler);



            // Limit the max buffer size for the response so we don't get overwhelmed

            httpClient.MaxResponseContentBufferSize = 256000;

            // Add a user-agent header

            httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");

        }
    }
}
