using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

namespace ConsoleApp5
{
    public class WeatherModel
    {
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public WeatherResultRoot Result { get; set; }
        public string Error { get; set; }

        public void PrintResult()
        {
            Console.WriteLine($"\n# # # Error: {this.Error} # # #");
            Console.WriteLine($"# # # Message: {this.Message} # # #");
            Console.WriteLine($"# # # StatusCode: {this.StatusCode} # # #\n");

            if (this.Error == null)
            {
                Console.WriteLine("##### Coordinates: #####");
                Console.WriteLine($"longitude: {this.Result.coord.lon}\tlatitude: {this.Result.coord.lat}");
                Console.WriteLine("\n##### Weather: #####");
                Console.WriteLine($"id: {this.Result.weather[0].id}\tmain: {this.Result.weather[0].main}");
                Console.WriteLine($"description: {this.Result.weather[0].description}\ticon: {this.Result.weather[0].icon}");
                Console.WriteLine($"\nbase: {this.Result.@base}");
                Console.WriteLine("\n##### Main: #####");
                Console.WriteLine($"temperature: {this.Result.main.temp}\tfeels_like: {this.Result.main.feels_like}");
                Console.WriteLine($"minimum temperature: {this.Result.main.temp_min}\tmaximum temperature: {this.Result.main.temp_max}");
                Console.WriteLine($"pressure: {this.Result.main.pressure}\thumidity: { this.Result.main.humidity}");
                Console.WriteLine($"visibility: {this.Result.visibility}");
                Console.WriteLine("\n##### Wind: #####");
                Console.WriteLine($"speed: {this.Result.wind.speed}\tdegree: {this.Result.wind.deg}");
                Console.WriteLine($"gust: {this.Result.wind.gust}");
                Console.WriteLine($"clouds.all: {this.Result.clouds.all}");
                Console.WriteLine($"dt: {this.Result.dt}");
                Console.WriteLine("\n##### Sys #####");
                Console.WriteLine($"type: {this.Result.sys.type}\tid: {this.Result.sys.id}");
                Console.WriteLine($"country: {this.Result.sys.country}\tsunrise: {this.Result.sys.sunrise}");
                Console.WriteLine($"sunset: {this.Result.sys.sunset}");
                Console.WriteLine($"\ntimezone: {this.Result.timezone}");
                Console.WriteLine($"id: {this.Result.id}");
                Console.WriteLine($"name: {this.Result.name}");
                Console.WriteLine($"cod: {this.Result.cod}");
            }
        }
    }

    public class WeatherClient
    {

        private readonly string key;
        private readonly HttpClient client;
        private WeatherModel Weathermodel;

        public WeatherClient(string key)
        {
            this.client = new HttpClient();
            this.key = key;
        }

        public async Task<WeatherModel> Get()
        {
            string city = "Mykolaiv";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric" + $"&appid={this.key}";

            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync($"{url}");
                string json = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                WeatherResultRoot weatherData = JsonSerializer.Deserialize<WeatherResultRoot>(json);

                return new WeatherModel
                {
                    Message = "The data are successfully obtained!",
                    StatusCode = responseMessage.StatusCode,
                    Result = weatherData,
                    Error = null
                };
            }
            catch (Exception e)
            {
                return new WeatherModel
                {
                    Message = "Error! The data are not obtained.",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Result = null,
                    Error = e.Message
                };
            }
        }

        public async Task<WeatherModel> Post(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric" + $"&appid={this.key}";
            Dictionary<string, string> requestData = new Dictionary<string, string>() { { "city", city } };
            try
            {
                FormUrlEncodedContent requestBody = new FormUrlEncodedContent(requestData);
                HttpResponseMessage responseMessage = await client.PostAsync(url, requestBody);
                string json = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(json);
                WeatherResultRoot weatherData = JsonSerializer.Deserialize<WeatherResultRoot>(json);

                return new WeatherModel
                {
                    Message = "The data are successfully obtained!",
                    StatusCode = responseMessage.StatusCode,
                    Result = weatherData,
                    Error = null
                };
            }
            catch (Exception e)
            {
                return new WeatherModel
                {
                    Message = "Error! The data are not obtained.",
                    StatusCode = HttpStatusCode.InternalServerError,
                    Result = null,
                    Error = e.Message
                };
            }
        }
    }
}
