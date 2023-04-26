using ConsoleApp5;
using System;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        WeatherClient client = new WeatherClient("6c11600ef34d6ec35dca53889584a453");

        Console.WriteLine("##### Mykolaiv: #####\n");
        WeatherModel result1 = await client.Get();

        result1.PrintResult();

        Console.WriteLine("\n##### Nizhyn: #####\n");

        WeatherModel result2 = await client.Post("Nizhyn");

        result2.PrintResult();

        Console.ReadLine();
    }
}