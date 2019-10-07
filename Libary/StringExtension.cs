using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTask
{
    public static class StringExtension
    {
        public static string Drunk(this string str)
        {
            bool flag = false;

            string newString = "";

            foreach(char symbol in str.ToCharArray())
            {

                if (flag)
                {
                    newString += Char.ToUpper(symbol);
                }
                else
                {
                    newString += Char.ToLower(symbol);
                }

                flag = !flag;
            }

            return newString;
        }
    }
}
