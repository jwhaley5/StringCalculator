using System;

namespace StringCalculator.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            int number = calc.Add("//;\n1;2");
            Console.WriteLine("Number is: " + number);
            Console.WriteLine("Hello World!");
        }
    }
}
