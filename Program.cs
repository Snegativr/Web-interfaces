using System;
using System.IO;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. 'Lorem ipsum'");
            Console.WriteLine("2. Calculator");
            Console.WriteLine("0. Exit");

            Console.Write("Choose 0 - 2: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter number of words in text: ");
                    int wordCount = int.Parse(Console.ReadLine());
                    DisplayWordsInLoremIpsum(wordCount);
                    break;
                case "2":
                    PerformMathOperation();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Wrong choice. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DisplayWordsInLoremIpsum(int wordCount)
    {
        string loremIpsumText = ReadTextFromFile("C:\\Users\\User\\source\\repos\\ConsoleApp1\\ConsoleApp1\\Lorem.txt");
        string[] words = loremIpsumText.Split(new char[] { ' ', '\t', '\n', '\r' });

        if (wordCount <= words.Length)
        {
            Console.WriteLine($"first {wordCount} words 'Lorem ipsum':");
            for (int i = 0; i < wordCount; i++)
            {
                Console.Write($"{words[i]} ");
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine($"Text 'Lorem ipsum' Contains less words than ({wordCount}).");
        }
    }

    static void PerformMathOperation()
    {
        Console.Write("Enter first number ");
        double number1 = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double number2 = double.Parse(Console.ReadLine());

        Console.Write("Enter math operation (+, -, *, /): ");
        string operation = Console.ReadLine();

        double result;

        switch (operation)
        {
            case "+":
                result = number1 + number2;
                break;
            case "-":
                result = number1 - number2;
                break;
            case "*":
                result = number1 * number2;
                break;
            case "/":
                result = number1 / number2;
                break;
            default:
                Console.WriteLine("\nError.");
                return;
        }
        Console.WriteLine($"Result: {result}");
    }

    static string ReadTextFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        else { return "File not found"; }
            
    }
}
