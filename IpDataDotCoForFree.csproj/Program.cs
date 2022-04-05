using Leaf.xNet;
using System;

namespace IpDataDotCoForFree.csproj
{
    internal class Program
    {
        static string apiKey = "eca677b284b3bac29eb72f5e496aa9047f26543605efe99ff2ce35c9";
        static void Main(string[] args)
        {
            Console.Write("IP: ");
            string ip = Console.ReadLine();
            Console.Clear();
            using (HttpRequest req = new HttpRequest())
            {
                req.IgnoreProtocolErrors = true;
                req.AddHeader("Accept", "*/*");
                req.AddHeader("Accept-Language", "fr,en-US;q=0.9,en;q=0.8");
                req.AddHeader("Sec-Fetch-Dest", "script");
                req.AddHeader("Sec-Fetch-Mode", "no-cors");
                req.AddHeader("Sec-Fetch-Sode", "same-site");
                req.AddHeader("Sec-GPC", "1");
                //qQ29va2ll-1d
                req.AddHeader("Referer", "https://ipdata.co/");
                req.AddHeader("Referrer-Policy", "strict-origin-when-cross-origin");
                req.AddHeader("User-Agent", "HelloWorld");

                var res = req.Get(String.Format("https://api.ipdata.co/{0}?api-key={1}", ip, apiKey));

                if (res.StatusCode == HttpStatusCode.TooManyRequests)
                    Console.WriteLine("Rate Limited");
                else
                    Console.WriteLine(res.ToString());

                req.Close();
            }
            Console.ReadLine();
        }
    }
}