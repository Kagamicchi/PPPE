using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Add(object obj)
        {
            if (obj is Params)
            {
                Console.WriteLine("Add() method thread ID: " + Thread.CurrentThread.ManagedThreadId);
                Params pr = (Params)obj;
                Console.WriteLine("{0} + {1} = {2}", pr.a, pr.b, pr.a + pr.b);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main thread. ID: " + Thread.CurrentThread.ManagedThreadId);

            Params pm = new Params(10, 10);
            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(pm);

            // delay
            Thread.Sleep(5);

            Console.WriteLine("\n#######################\n");
            Console.Write("How many threads to use (1 or 2)? ");
            string number = Console.ReadLine();

            Thread mythread = Thread.CurrentThread;
            mythread.Name = "Primary";

            // output the information about thread
            Console.WriteLine("--> {0} main thread", Thread.CurrentThread.Name);
            MyThread mt = new MyThread();

            switch (number)
            {
                case "1":
                    mt.ThreadNumbers();
                    break;
                case "2":
                    // create a thread
                    Thread backgroundThread = new Thread(new ThreadStart(mt.ThreadNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                default:
                    Console.WriteLine("using 1 thread");
                    goto case "1";
            }
            MessageBox.Show("Message ...", "Working in a different thread");
            
            Console.WriteLine("\n#######################\n");
            callMethod();

            Console.ReadLine();
        }

        public static async void callMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
    }
}
