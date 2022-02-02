using System;
using System.Text.RegularExpressions;


public static class СRegex
{
    public static void GetValues() { }
    public static void GetValues(string content, string pattern, Action<string, int, int> action)
    {
        int count_ = 0;
        MatchCollection mc = Regex.Matches(content, pattern);
        foreach (Match item in mc)
        {
            action(item.Value, mc.Count, count_);
            count_++;
        }
    }
}

