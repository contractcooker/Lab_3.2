using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> priceList = new Dictionary<string, double>();
            ArrayList items = new ArrayList();
            ArrayList prices = new ArrayList();
            string input;
            double sum = 0;
            bool flag = true;

            priceList.Add("Lego Set", 14.99);
            priceList.Add("Video Game", 59.99);
            priceList.Add("TV", 299.99);
            priceList.Add("A/V Receiver", 499.99);
            priceList.Add("Action Figure", 14.99);
            priceList.Add("Bouncy Ball", .99);
            priceList.Add("Bicycle", 199.99);
            priceList.Add("Pogo Stick", 99.99);

            Console.WriteLine("Welcome to the Market!");
            

            do
            {
                Console.WriteLine();
                DisplayTable(priceList);

            
                /**/
                Console.Write("What item would you like to order? ");
                input = Console.ReadLine();
                while (!priceList.ContainsKey(input))
                {
                    Console.WriteLine("Sorry, we don't have those. please try again.");
                    Thread.Sleep(1000);

                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.Clear();
                    DisplayTable(priceList);
                    Console.Write("What item would you like to order? ");
                    input = Console.ReadLine();
                }
                items.Add(input);
                prices.Add(priceList[input]);
                sum += priceList[input];
                Console.WriteLine($"Adding {items[items.Count - 1]} to cart at ${prices[prices.Count - 1]}");
                Console.WriteLine();

                Console.Write("Would you like to order anything else? (y/n) ");
                input = Console.ReadLine();
                
                if (input == "n")
                {
                    Console.WriteLine("Thank you for your order!\nHere's what you got:");
                    for (int i = 0; i < items.Count; i++)
                    {
                        Console.WriteLine($"{items[i]} {prices[i]}");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Average price per item in order was ${sum/items.Count}");
                    flag = false;
                }
                if (input == "y")
                {
                    Console.Clear();
                    Console.WriteLine();
                }
            } while (flag);


        }

        private static void DisplayTable(Dictionary<string, double> priceList)
        {
            var sb = new StringBuilder();
            sb.Append(string.Format("{0,15} {1,10}", "Item", "Price"));
            Console.WriteLine(sb);
            Console.WriteLine("============================");
            foreach (KeyValuePair<string, double> kvPair in priceList)
            {
                Console.WriteLine($"|{kvPair.Key,15} {kvPair.Value,10}|");
            }
            Console.WriteLine("============================");
            Console.WriteLine();
        }
    }
}
