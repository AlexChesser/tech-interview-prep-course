using System;
using System.Linq;
using System.Collections.Generic;


// 1. Read in and ignore any leading whitespace.
// 2. Check if the next character (if not already at the end of the string) is '-' or '+'. Read this character in if it is either. This determines if the final result is negative or positive respectively. Assume the result is positive if neither is present.
// 3. Read in next the characters until the next non-digit charcter or the end of the input is reached. The rest of the string is ignored.
// 4. Convert these digits into an integer (i.e. "123" -> 123, "0032" -> 32). If no digits were read, then the integer is 0. Change the sign as necessary (from step 2).
// 5. If the integer is out of the 32-bit signed integer range [-231, 231 - 1], then clamp the integer so that it remains in the range. Specifically, integers less than -231 should be clamped to -231, and integers greater than 231 - 1 should be clamped to 231 - 1.
// [-2147483648 to 2147483647].
// 6. Return the integer as the final result.


public class Solution {
    const string MIN_VALUE = "2147483648";
    const string MAX_VALUE = "2147483647";
    const int ZERO = 48;
    const int NINE = 57;

    public int MyAtoi(string s) {
        if(s.Length == 0){
            return 0;
        }
        char check;
        bool IsNegative = false;
        List<char> digits = new List<char>();;
        for(int i = 0; i < s.Length; i++){
            check = s[i];
            if(digits.Count == 0){
                if(char.IsWhiteSpace(check) || check == '+'){
                    continue;
                }
                if(check == '-'){
                    IsNegative = true;
                    continue;
                }
                if(check < ZERO || check > NINE){
                    return 0;
                }
            }
            if(char.IsNumber(check)){
                digits.Add(check);
                continue;
            }
            break;
        }
        if(digits.Count <= 10){
            try{
                return int.Parse(string.Join(null, digits)) * (IsNegative ? -1 : 1);
            } catch {

            }
        }
        return IsNegative ? int.MinValue : int.MaxValue;
    }
}
