using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cable cable1 = new Cable("Hoco", 1.1, 'A', 3, 435, false);
            cable1.Show();
            cable1.DisplayCableType();
            cable1.Speed();

            Console.Write("\n");

            Cable cable2 = new Cable("Cablexpert", 2.0, 'A', 4.5, 135, true);
            cable2.Show();
            Console.WriteLine("In stock: " + cable2.inStock + "\n");

            Cable cable3 = new Cable("Hoco", 3.0, 'C', 2, 268, false);
            cable3.Show();
            cable3.DisplayCableType();
            cable3.Speed();
            Console.WriteLine("Converted in US: $" + cable3.ShowPriceInUS());
            Console.WriteLine("In stock: " + cable1.inStock);

            Console.WriteLine("\n###################################\n");

            Type myType = typeof(Cable);

            foreach (MemberInfo member in myType.GetMembers(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"{member.DeclaringType} {member.MemberType} {member.Name}");
            }

            Console.WriteLine("\n###################################\n");

            TypeInfo typeInfo = typeof(Cable).GetTypeInfo();
            IEnumerable<FieldInfo> fieldsList = typeInfo.DeclaredFields;
            IEnumerable<MethodInfo> methodsList = typeInfo.DeclaredMethods;

            StringBuilder sb = new StringBuilder();

            sb.Append("### Fields: ###");
            foreach (FieldInfo fieldInfo in fieldsList)
            {

                sb.Append("\n" + fieldInfo.DeclaringType.Name + ": " + fieldInfo.Name);
            }
            sb.Append("\n### Methods: ###");
            foreach (MethodInfo methodsInfo in methodsList)
            {
                sb.Append("\n" + methodsInfo.DeclaringType.Name + ": " + methodsInfo.Name);
            }

            Console.WriteLine(sb.ToString());

            Console.WriteLine($"\n### Information about {cable2.title} USB {cable2.standard.ToString("0.0")} cable: ###\n");

            MethodInfo methodInfo = typeInfo.GetMethod("Speed");
            var result = methodInfo.Invoke(cable2, null);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
