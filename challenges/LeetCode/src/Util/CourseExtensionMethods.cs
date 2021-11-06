using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class CourseExtensionMethods
{
    public static int[] ToIntArray(this string str)
    {
        if (str.Length == 0)
        {
            return new int[] { };
        }
        return str.Split(",").Select(c => int.Parse(c)).ToArray();
    }

    public static int[][] ToMultiDimensionalArray(this string str)
    {
        Regex rxp = new Regex("\\[([0-9,]+?)\\]", RegexOptions.Compiled);
        List<int[]> n = new List<int[]>();
        foreach (Match match in rxp.Matches(str))
        {
            n.Add(match.Groups[1].ToString().ToIntArray());
        }
        return n.ToArray();
    }

    public static string ToNestedString(this int[][] arr)
    {
        return $"[{string.Join(",", arr.Select(inner => $"[{inner.CommaJoin()}]"))}]";
    }

    public static string CommaJoin(this int[] arr)
    {
        return string.Join(",", arr);
    }

    public static string CommaJoin(this char[] arr)
    {
        return string.Join(",", arr);
    }

}