using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Solution
{
    private readonly int MIN = 6;
    private readonly int MAX = 20;
    private readonly int MAX_REPEATS = 3;
    private List<int> repeats;
    private int lower = 1;
    private int upper = 1;
    private int digit = 1;

    public List<int> BuildListOfRepeats(string password) {
        repeats = new List<int>();
        char current;
        char previous = '\0';
        int number_repeated = 1;
        for (int i = 0; i < password.Length; i++) {
            current = password[i];
            if (current == previous) {
                number_repeated++;
                continue;
            }
            if (number_repeated >= MAX_REPEATS) {
                repeats.Add(number_repeated);
            }
            number_repeated = 1;
            if (char.IsDigit(current)) { digit = 0; }
            if (char.IsLower(current)) { lower = 0; }
            if (char.IsUpper(current)) { upper = 0; }
            previous = current;
        }
        if (number_repeated >= MAX_REPEATS) {
            repeats.Add(number_repeated);
        }
        return repeats;
    }

    private int DetermineEditOrDelete(string password) {
        repeats = repeats.OrderBy(len => len % MAX_REPEATS)
                         .ToList();
        int must_delete = 0;
        int password_length = password.Length;
        while (password_length > MAX && repeats.Any()) {
            --password_length;
            ++must_delete;
            var sequence = repeats[0];
            if (sequence == MAX_REPEATS) {
                repeats.RemoveAt(0);
            } else if (sequence % MAX_REPEATS == 0) {
                repeats.RemoveAt(0);
                repeats.Insert(repeats.Count, sequence - 1);
            } else {
                repeats[0] = sequence - 1;
            }
        }
        if (password_length > MAX) {
            must_delete += password_length - MAX;
        }
        return must_delete;
    }

    private int HandleShortPassword(string password, int len) {
        int must_add = (len < MIN) ? MIN - len : 0;
        int threes = repeats.Sum(a => a / MAX_REPEATS);
        return Math.Max(Math.Max(digit + lower + upper, must_add), threes);
    }

    public int StrongPasswordChecker(string password)
    {
        BuildListOfRepeats(password);
        int len = password.Length;
        if (len < 6) {
            return HandleShortPassword(password, len);
        }
        int deletes = DetermineEditOrDelete(password);
        int repeatInsertsAndReplaces = 0;
        while (repeats.Any()) {
            int count = repeats[0];
            repeats.RemoveAt(0);
            repeatInsertsAndReplaces += count / MAX_REPEATS;
        }
        int requiredInsertsOrReplace = lower + upper + digit;
        return Math.Max(requiredInsertsOrReplace, repeatInsertsAndReplaces) + deletes;
    }
}
