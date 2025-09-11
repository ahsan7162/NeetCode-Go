using System;
using System.Collections.Generic;

public class Solution
{
    public static IList<string> FindRepeatedDnaSequences(string s)
    {
        var seen = new HashSet<string>();
        var repeated = new HashSet<string>();
        
        for (int i = 0; i <= s.Length - 10; i++) {
            string substring = s.Substring(i, 10);
            if (seen.Contains(substring)) {
                repeated.Add(substring);
            } else {
                seen.Add(substring);
            }
        }
        
        return new List<string>(repeated);
    }
}