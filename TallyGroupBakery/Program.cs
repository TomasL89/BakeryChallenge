using System;
using System.Collections.Generic;
using System.Linq;
using BakeryChallenge.Models;

namespace BakeryConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Reset();
            var produceOptions = ProduceInfo.AvailableProduceItems;
            var orderCalculator = new OrderCostCalculator();
            var order = new List<Order>();
  
            while (true)
            {
                Console.WriteLine("Please make a choice from the options above");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (string.Equals(input, "q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                if (string.Equals(input, "r", StringComparison.InvariantCultureIgnoreCase))
                {
                    order.Clear();
                    Reset();
                    continue;
                }

                try
                {
                    var optionSelection = int.Parse(input);
                    if (optionSelection >= produceOptions.Count)
                    {
                        Console.WriteLine($"{optionSelection} is not a valid option, please try again");
                        continue;
                    }
                    else
                    {

                        var selectedProduceItem = produceOptions[optionSelection];
                        Console.WriteLine($"You selected {selectedProduceItem.Name}");

                        Console.WriteLine("Please enter the quantity");
                        input = Console.ReadLine();

                        if (string.Equals(input, "q", StringComparison.InvariantCultureIgnoreCase))
                        {
                            break;
                        }

                        if (string.Equals(input, "r", StringComparison.InvariantCultureIgnoreCase))
                        {
                            order.Clear();
                            Reset();
                            continue;
                        }

                        var quantity = int.Parse(input);


                        if (!selectedProduceItem.Packs.Any(q => quantity >= q.Quantity))
                        {
                            Console.WriteLine($"Unable to purchase selected quantity: {quantity} for {selectedProduceItem.Name}");
                            Console.WriteLine("Press enter to try again");
                            Console.ReadKey();
                            order.Clear();
                            Reset();
                            continue;
                        }
                        else
                        {

                            Console.WriteLine();
                            var cart = new Cart
                            {
                                Produce = selectedProduceItem,
                                Quantity = quantity
                            };
                            var result = orderCalculator.Calculate(cart);
                            if (result == null)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Unable to calculate the correct number of packs with a quantity of: {quantity}");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("Please press any key to start again");
                                Console.ReadKey();
                                order.Clear();
                                Reset();
                            }
                            order.Add(result);
                            Console.Write($"{quantity} ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine($"{selectedProduceItem.Code}");
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Press c to view cart");
                            Console.WriteLine("Press a to add another line");
                            Console.WriteLine();
                            input = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(input) && string.Equals(input, "c", StringComparison.InvariantCultureIgnoreCase))
                            {
                                foreach (var orderItem in order)
                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.WriteLine($"{quantity} {selectedProduceItem.Code} ${result.Total}");
                                    var groupedResults = result.Packs.GroupBy(q => q.Quantity);
                                    foreach (var resultItem in groupedResults)
                                    {
                                        Console.WriteLine($"\t {resultItem.Count()} X {resultItem.First().Quantity} ${resultItem.First().Price}");
                                    }
                                }
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (!string.IsNullOrWhiteSpace(input) && string.Equals(input, "a", StringComparison.InvariantCultureIgnoreCase))
                            {
                                continue;   
                            }
                            else
                            {
                                order.Clear();
                                Reset();
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                    order.Clear();
                    continue;
                }
            }
        }

        public static void Reset()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t Welcome to the Bakery");
            Console.WriteLine("\t\t\t By Tomas Leitch");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Type q to quit;");
            Console.WriteLine("Type r to reset");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;

            var produceOptions = ProduceInfo.AvailableProduceItems;

            var optionCount = 0;
            Console.WriteLine("\tProduct Name\t\tProduct Code");
            foreach (var produceItem in produceOptions)
            {
                Console.WriteLine($"{optionCount++}.\t{produceItem.Name}\t\t{produceItem.Code}");
            }

            Console.WriteLine();
            
        }
    }
}
