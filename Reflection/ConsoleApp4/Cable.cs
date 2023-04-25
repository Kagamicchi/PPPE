using System;

namespace ConsoleApp4
{
    internal class Cable
    {
        public string title;
        public double standard;
        public double length;
        public bool inStock;
        private char type = 'A';
        private int price;

        public Cable() { }

        public Cable(string title, double standard, char type, double length, int price, bool inStock)
        {
            this.title = title;
            this.standard = standard;
            this.type = type;
            this.length = length;
            this.price = price;
            this.inStock = inStock;
        }

        private double ConvertToUS()
        {
            return price /= 40;
        }

        public double ShowPriceInUS()
        {
            return ConvertToUS();
        }

        public void DisplayCableType()
        {
            Console.Write("This is a cabel Type-" + type);
            if (type == 'A')
            {
                Console.WriteLine(". It is placed on the side of the main unit");
            } else if (type == 'B')
            {
                Console.WriteLine(". It is located on the side of the peripheral device");
            } else if (type == 'C')
            {
                Console.WriteLine(". It has contacts arranged in a mirror (2x12),\nthanks to which any position of the plug for connection with the gadget");
            } else
            {
                Console.WriteLine("Error! Type is not correct or does not exist!");
            }
        }

        public void Show()
        {
            Console.WriteLine("##### Cabel USB {0} #####\nTitle: {1}\tLength: {2} m\nPrice: {3} UAN", standard.ToString("0.0"), title, length, price);
        }

        public void Speed()
        {
            if (standard == 1.0)
            {
                Console.WriteLine("Speed: up to 1,5 Mbps\tSpecification: Low-Speed");
            } else if (standard == 1.1)
            {
                Console.WriteLine("Speed: up to 12 Mbps\tSpecification: Full-Speed");
            } else if (standard == 2.0)
            {
                Console.WriteLine("Speed: up to 480 Mbps\tSpecification: High-Speed");
            } else if (standard == 3.0 || standard == 3.1 || standard == 3.2)
            {
                Console.WriteLine("Speed: up to 5 Gbps\tSpecification: Super-Speed");
            } else
            {
                Console.WriteLine("Error! This standard is not correct or does not exist.");
            }
        }
    }
}
