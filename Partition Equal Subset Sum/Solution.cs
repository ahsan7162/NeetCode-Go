using System;
using System.Collections.Generic;

public class Solution{
   public static bool CanPartitionArray(int[] arr) {
      int totalSum = arr.Sum();
        if (totalSum % 2 != 0)
            return false;

        int target = totalSum / 2;
        bool[] dp = new bool[target + 1];
        dp[0] = true;

        foreach (int num in arr) {
            for (int i = target; i >= num; i--) {
                dp[i] = dp[i] || dp[i - num];
            }
        }

        return dp[target];
   }
}