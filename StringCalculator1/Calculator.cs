using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator.Core
{
    public class Calculator
    {
        public Calculator()
        {

        }

        public int Add(string numbers)
        {
            if (numbers == "")
            {
                return 0;
            }
            
            int sum = 0;
            List<string> regexVals = new List<string>()
            {
                ",",
                "\n"
            };
            
            if(numbers.StartsWith("//"))
            {
                int i = 2;
                while(numbers.Substring(i, 1) != "\n")
                {
                    regexVals.Add(numbers[i].ToString());
                    i++;
                }
            }
            string[] regexValues = regexVals.ToArray();
            string[] elements = numbers.Split(regexValues, StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in elements )
            {
                Console.WriteLine(element);
            }
            string negativeOutput = "Negatives not allowed: ";
            bool negatives = false;
            foreach (var element in elements)
            {
                int result = 0;
                Int32.TryParse(element, out result);
                if (result < 0)
                {
                    if (negatives == false)
                    {
                        negativeOutput += result.ToString();
                    }
                    else
                    {
                        negativeOutput += "," + result.ToString();
                    }
                    negatives = true;
                }
                else if (result <= 1000)
                {
                    sum += result;
                }
            }
            if (negatives == true)
            {
                throw new Exception(negativeOutput);
            } 
            return sum;
        }
    }
}
