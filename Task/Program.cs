using System;
using CalcLib;


namespace Task
{
    class Program
    {
        static int Main(string[] args)
        {
            int result = BankCalculations.CalculateCompoundInterest(new ConsoleInputRetriever());
            switch (result)
            {
                case -1: Console.WriteLine("Input value is not numeric. Exiting..");
                    break;
                case -2: Console.WriteLine("You have no time enough to get the desired sum with such deposit. Exiting..");
                    break;
                case -3: Console.WriteLine("No input was received. Exiting..");
                    break;
                case -4: Console.WriteLine("Calculations reaches infinity. Not able to calculate such values. Exiting..");
                    break;
                case -5: Console.WriteLine("Desired sum is less then deposit. Exiting..");
                    break;
                case -6: Console.WriteLine("The values entered are too small. It is not reasonable to calculate such values. Exiting..");
                    break;
                case -7: Console.WriteLine("Can't calculate the result with the negative values entered. Exiting..");
                    break;
                case -8: Console.WriteLine("Can't calculate the result with one of the input equal to zero. Exiting..");
                    break;
            }
            Console.WriteLine(result);
            Console.ReadLine();
            return result;
        }

    }
}