using System;

namespace CalcLib
{
    public class ConsoleInputRetriever : InputRetriever
    {
        public override string GetValue()
        {
            return Console.ReadLine();
        }
    }
}