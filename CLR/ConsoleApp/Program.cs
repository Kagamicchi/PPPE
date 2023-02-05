using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        private static double Area(int a, int b, int c)
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        private static void ReadMyFile()
        {
            string text;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("G:\\testfile.txt");
                //Read all text from file
                text = sr.ReadToEnd();
                if (text != null)
                {
                    string[] textMass = text.Split(' ');
                    string Output = "";
                    Console.Write("N = ");
                    int n = Convert.ToInt32(Console.ReadLine());
                    if (n <= textMass.Length)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Output += textMass[i] + " ";
                        }
                        Console.WriteLine(Output);
                    }
                    else
                    {
                        Console.WriteLine("Error! 'N' cannot be more than total count of words in the text!");
                    }
                }
                else
                {
                    Console.WriteLine("File is empty.");
                }
                //Close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1 to start and 0 to end");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number == 1)
            {
                Console.WriteLine("\nYou can choose one of functions:\n1 - output the number of words which you input\n2 - calculate the area\n");
                int function = Convert.ToInt32(Console.ReadLine());
                if (function == 1)
                {
                    ReadMyFile();

                    Console.ReadKey();
                }
                else if (function == 2)
                {
                    int a, b, c;

                    Console.Write("Enter А: ");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter B: ");
                    b = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter C: ");
                    c = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Heron's area is {0:0.00}", Area(a, b, c));

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Error! Data are not correct!");
                }
            }
            else if (number == 0)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Error! Data are not correct!");
            }
        }
    }
}