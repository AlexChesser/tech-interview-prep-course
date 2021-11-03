using System;

public class Solution {
    public int RemoveDuplicates(int[] nums) {
        if(nums == null || nums.Length == 0){
            return 0;
        } else if(nums.Length == 1){
            return 1;
        }
        int unique = 1;
        for(int i = 0; i < nums.Length - 1; i++){
            if(nums[i] != nums[i+1]){
                nums[unique++] = nums[i+1];
            }
        }
        return unique;   
    }
}
