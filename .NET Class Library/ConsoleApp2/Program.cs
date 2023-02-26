using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace ConsoleApp2
{
    internal class Program
    {
        string filePath = "G:\\универ\\3_курс\\ПППИ\\ConsoleApp2\\ConsoleApp2\\bin\\Debug\\people.dat";
        List<Person> people = new List<Person>();

        public void WriteFile()
        {
            try
            {
                // checking if the file already exists
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                FileStream stream = new FileStream(filePath, FileMode.OpenOrCreate,
                FileAccess.Write, FileShare.ReadWrite);
                // creating binary file using BinaryWriter
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    writer.Write("Tom");
                    writer.Write(20);
                    writer.Write("Jack");
                    writer.Write(24);
                    writer.Write("Ann");
                    writer.Write(22);
                    writer.Write("Lilly");
                    writer.Write(19);
                    writer.Write("James");
                    writer.Write(21);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadFile()
        {
            try
            {
                // creating an object of Stream
                FileStream stream = new FileStream(filePath, FileMode.Open,
                FileAccess.Read, FileShare.ReadWrite);
                // creating BinaryReader using Stream object
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();
                        int age = reader.ReadInt32();
                        // according to the read data, a Person object will be
                        // created and added to the list
                        people.Add(new Person(name, age));
                    }
                    foreach (Person person in people)
                    {
                        Console.WriteLine($"Name: {person.Name}\tAge: {person.Age}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            // create and start timer
            Stopwatch stopwatch = Stopwatch.StartNew();

            Program obj = new Program();
            Console.WriteLine("######## People ########");
            obj.WriteFile();
            obj.ReadFile();
            Console.WriteLine("########################\n");
            // stop the timer
            stopwatch.Stop();
            Console.WriteLine("First operation: " + stopwatch.Elapsed);

            Console.WriteLine("\n####################################\n");

            stopwatch.Reset();
            stopwatch.Start();

            Type myType = typeof(Person);

            foreach (MemberInfo member in myType.GetMembers())
            {
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
            }
            
            Console.WriteLine("\n####################################\n");

            stopwatch.Stop();
            Console.WriteLine("Second operation: " + stopwatch.Elapsed);

            Console.WriteLine("\n####################################\n");

            // сreate a secondary thread by passing a ThreadStart delegate
            Thread workerThread = new Thread(new ThreadStart(Print));
            // start secondary thread
            workerThread.Start();

            // Main thread : Print 1 to 10 every 0.2 second.
            // Thread.Sleep method is responsible for making the current thread sleep
            // in milliseconds. During its sleep, a thread does nothing.
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Main thread: {i}");
                Thread.Sleep(200);
            }

            Console.ReadKey();
        }

        static void Print()
        {
            for (int i = 11; i < 20; i++)
            {
                Console.WriteLine($"Worker thread: {i}");
                Thread.Sleep(1000);
            }
            Console.WriteLine("\n####################################\n");
        }
    }
}
