using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BaseConverterAPI.Controllers
{
    public class ConverterController : ApiController
    {
        private static char[] dictionary = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        private static int CharValid(char c, int basein)
        {
            for (int i = 0; i < basein; i++)
                if (c == dictionary[i])
                    return i;
            return -1;
        }

        private static bool BaseValid(int b)
        {
            if (b > 1 && b < dictionary.Length + 1)
                return true;
            else
                return false;
        }

        private static int IntPow(int nBase, int nExpo)
        {
            if (nExpo == 0) return 1; if (nExpo == 1) return nBase;
            if (nBase == 0) return 0; if (nBase == 1) return 1;

            int y = nBase;
            for (int i = 2; i <= nExpo; i++)
            {
                y *= nBase;
            }
            return y;
        }

        [HttpGet]
        public string Converter(int basein, string input, int baseout)
        {
            if (!BaseValid(basein))
                return null;
            if (!BaseValid(baseout))
                return null;
            string output = "", inputFormatted = input.ToUpper();
            long dec = 0;
            int expo = inputFormatted.Length - 1, valueNum;

            foreach (char c in inputFormatted)
            {
                valueNum = CharValid(c, basein);
                if (valueNum < 0)
                    return null;
                else
                    dec += valueNum * IntPow(basein, expo);
                expo--;
            }

            do
            {
                if (dec % baseout == 0)
                    output = "0" + output;
                else
                    output = dictionary[dec % baseout] + output;
                dec /= baseout;
            } while (dec != 0);

            return output;
        }
    }
}
