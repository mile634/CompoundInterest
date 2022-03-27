using System;
using System.Globalization;
using System.IO;
using System.Numerics;

namespace CalcLib
{
    public class BankCalculations
    {
        public static int CalculateCompoundInterest(InputRetriever inputStream)
        {//, double Input, double DesiredSum
            bool UserMode = inputStream.GetType().Equals(typeof(ConsoleInputRetriever));

            if (UserMode) Console.WriteLine("Pending for enter of the original amount of money for deposit");
            string s_startSum = inputStream.GetValue();
            if (UserMode) Console.WriteLine("Pending for enter of the desired amount of money");
            string s_finalSum = inputStream.GetValue();

            try
            {
                int code = 0;
                double startSum = Converter.ConvertToDecimalWithCulture(s_startSum, out code);
                if (code != 0) return code;
                double finalSum = Converter.ConvertToDecimalWithCulture(s_finalSum, out code);
                if (code != 0) return code;
                if (finalSum < startSum) return ErrorCodes.DESIRED_SUM_IS_LESS_THEN_DEPOSIT;
                return CalculateYears(startSum,finalSum,UserMode);
            }
            catch (FormatException)
            {
                return ErrorCodes.INPUT_SHOULD_BE_NUMERIC;
            }
            catch (NullReferenceException)
            {
                return ErrorCodes.NO_INPUT_WAS_RECEIVED;
            }
        }

        private static int CalculateYears(double startSum, double finalSum, bool Output)
        {
            const double percent = 0.1f;
            int result = 0;
            
            while (startSum <= finalSum)
            {
                startSum *= 1 + percent;
                result++;
                if (Output) Console.WriteLine("Balance at the end of "+ result + "year: "+ startSum);
                if (Double.IsInfinity(startSum)) return ErrorCodes.CALCULATIONS_REACHES_INFINITY;
                if (result > 50) 
                    return ErrorCodes.DESIRED_SUM_IS_UNREACHABLE;
                
            }

            return result;
        }
    }
}

// Существует формула для начисления сложного процента:
// S=A*(1+R)T
// A- сумма вклада;
// R- процентная ставка;
// T- количество лет;
// S- итоговая сумма
//
//     Необходимо реализовать код на любом языке программирования, который дает ответ на вопрос, на какой период необходимо вложить средства, чтобы при известной ставке в 10% годовых, вложив сумму А, можно было получить сумму S
// Ввод суммы А и желаемой суммы S необходимо реализовать через командную строку.
//
//     Дополнительно, необходимо предоставить 10 тестов (при желании, больше), проверяющих корректность работы данного кода, оформленных на том же языке программирования, что и решение задачи.
