using System;
using System.Linq;
using System.Collections.Generic;

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
                if(char.IsWhiteSpace(check)){
                    continue;
                }
                if(i == s.Length - 1 && (!char.IsNumber(check) || check == ZERO) ){
                    return 0;   
                }
                if(check == ZERO && !char.IsNumber(s[i+1])){
                    return 0;
                }
                if(check == ZERO){
                    continue;
                }
                if(check == '-'){
                    if(!char.IsNumber(s[i+1])){
                        return 0;
                    }
                    IsNegative = true;
                    continue;
                }
                if(check == '+' ){
                    if(!char.IsNumber(s[i+1])){
                        return 0;
                    }
                    continue;
                }
                if(check < ZERO || check > NINE){
                    return 0;
                }
            }
            if(char.IsNumber(check)){
                digits.Add(check);
                if(digits.Count > 10){
                    return IsNegative ? int.MinValue : int.MaxValue; 
                }
                continue;
            }
            break;
        }
        if(digits.Count == 0){
            return 0;
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
