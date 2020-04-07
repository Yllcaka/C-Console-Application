using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Tickets
    {
        static string capitalize(string str)
        {
            return $"{str[0]}".ToUpper() + str.Substring(1, str.Length - 1).ToLower();
        }

        static string paypalId()
        {
            Random payRand = new Random();
            string id = "";
           // string all = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            for (int i = 0; i < 8; i++)
            {
                id += (char)payRand.Next('a','z');
            }

            return id;
        }
        static void totalMessage(int total)
        {
            Console.WriteLine($"The total you have to pay is {total} euro");
            Console.WriteLine($"The payment can be processed through www.paypal.com/buy-tickets/{paypalId()}");
        }

        static void Main(string[] args)
        {
            int price = 0;
            int ticketNr;
            int total = 0;
            int age;
            Random rand = new Random();
            while (true)
            {
                ticketNr = rand.Next(10000000, 99999999);
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter surname: ");
                string surname = Console.ReadLine();
                Console.Write("Enter age: ");
                while (true)
                {
                    try
                    {
                        age= Int32.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.Write("That's not a working number,\nPlease enter a valid age: ");
                    }
                }
                if (age <= 2)
                {
                    Console.WriteLine("Children’s under two years old are not allowed to take this ticket");
                    if (total > 0) totalMessage(total);
                    break;
                }
                if (age > 2 & age < 10) price = 3;
                else if (age > 10 & age < 18) price = 5;
                else price = 7;
            
                total += price;
                Console.WriteLine($"Hello {capitalize(name)} {capitalize(surname)},");
                Console.WriteLine($"Your age should be {age}, The price for this ticket nr.{ticketNr} is {price} euro.");
                Console.Write("If you wanna get more tickets enter \"continue\" else if that's all enter \"exit\" ");
                string answer = Console.ReadLine().ToLower();
                while (answer != "continue" & answer != "exit")
                {
                    Console.Write("Please enter \"continue\" or \"exit\"");
                    answer = Console.ReadLine().ToLower();
                }
                if (answer == "exit")
                {
                    totalMessage(total);
                    break;
                }
                Console.Clear();
            }

            
        }
    }
}