using System;
using System.Collections.Generic;

public class Solution
{
    public static int FindJudge(int n, int[][] trust)
    {
        if (n == 1 && trust.Length == 0)
            return 1; // Special case: only one person and no trust relationships

        int[] trustScore = new int[n + 1]; // 1-indexed

        foreach (var t in trust) {
            int a = t[0];
            int b = t[1];
            trustScore[a]--; // a trusts someone
            trustScore[b]++; // b is trusted by someone
        }

        for (int i = 1; i <= n; i++) {
            if (trustScore[i] == n - 1)
                return i;
        }

        return -1;
    }
}