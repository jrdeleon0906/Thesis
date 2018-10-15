using System;
using System.Text;

namespace Assets.Scripts.Common
{
    public static class StringExtension
    {

        public static string ToStringToUpper(this char _value)
        {
            return _value.ToString().ToUpper();
        }

        public static char CharToUpper (this char _value)
        {
            return Char.ToUpper(_value);
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
