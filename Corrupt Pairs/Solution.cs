using System;
using System.Collections.Generic;

public class Solution{
   public static int[] FindCorruptPair(int[] nums) {
     int n = nums.Length;
        int[] count = new int[n + 1]; // 1-based indexing

        foreach (int num in nums) {
            count[num]++;
        }

        int missing = -1, duplicate = -1;
        for (int i = 1; i <= n; i++) {
            if (count[i] == 0)
                missing = i;
            else if (count[i] == 2)
                duplicate = i;
        }

        return new int[] { missing, duplicate };
   }
}