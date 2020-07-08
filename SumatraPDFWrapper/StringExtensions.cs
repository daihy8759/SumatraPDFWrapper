﻿using System;

namespace SumatraPDF
{
    public static class StringExtensions
    {
        public static string Format(this string input, Func<string, string> formatter)
        {
            return string.IsNullOrEmpty(input)
                ? input
                : formatter(input);
        }
    }
}
