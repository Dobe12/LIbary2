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
                    flag = !flag;
                    newString += Char.ToUpper(symbol);
                } else
                {
                    flag = !flag;
                    newString += Char.ToLower(symbol);
                }
            }

            return newString;
        }
    }
}
