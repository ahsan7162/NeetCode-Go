public class Solution {
    public int[] TwoSum(int[] nums, int target) {
    int[] result = new int[2];
    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];

        int complementIndex = Array.IndexOf(nums, complement, 0, i);
        
        if (complementIndex != -1) {
            result[0] = complementIndex;
            result[1] = i;
            return result;
        }
    }
    return new int[] {};
    }
}