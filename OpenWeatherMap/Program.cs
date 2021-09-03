using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMap
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please enter your API key.");
            var api_key = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter your city.");
                var city_name = Console.ReadLine();
                var weatherURL = $" http://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={api_key}";

                var response = client.GetStringAsync(weatherURL).Result;
                var formatterResponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formatterResponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to look up another city? Please type Yes or No");
                var response1 = Console.ReadLine();
                if (response1.ToLower() == "no" )
                {
                    Console.WriteLine("Thank you and have a great day.");
                    break;
                }


            }
           
           
        }
    }
}
