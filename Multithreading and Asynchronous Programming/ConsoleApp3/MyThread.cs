using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class MyThread
    {
        public void ThreadNumbers()
        {
            // information about thread
            Console.WriteLine("{0} thread is using the method ThreadNumbers", Thread.CurrentThread.Name);
            // output of numbers
            Console.Write("Numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + ", ");
                // delay usage
                Thread.Sleep(3000);
            }
            Console.WriteLine();
        }
    }
}
