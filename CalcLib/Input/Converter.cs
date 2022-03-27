using System;
using System.Globalization;

namespace CalcLib
{
    public class Converter
    {
        private static int _decimalPlace = 3;
        private static double _accuracy = 1.0 / Math.Pow(10,_decimalPlace);
        public static double ConvertToDecimalWithCulture(string val, out int code)
        {
            double result = Double.Parse(ReplaceSeparator(val));
            code = 0;
            if (result < 0)
            {
                code = ErrorCodes.NEGATIVE_VALUE_WAS_ENTERED;
                return 0;
            }

            if (result == 0) 
            {   code = ErrorCodes.ZERO_WAS_ENTERED;
                return 0;
            }
            if (result < _accuracy) {
                code = ErrorCodes.CALCULATED_NUMBERS_ARE_TOO_LITTLE;
                return 0;
            }
            return result;
        }

        private static string ReplaceSeparator(string val)
        {
            NumberFormatInfo currentCultureInfo = CultureInfo.CurrentCulture.NumberFormat;
            if (currentCultureInfo.NumberDecimalSeparator == ".")
                val = val.Replace(',', '.');
            else val = val.Replace('.', ',');
            return val;
        }
    }
}