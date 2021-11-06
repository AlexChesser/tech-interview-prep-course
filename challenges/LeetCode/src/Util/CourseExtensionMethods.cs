using System.Linq;

public static class CourseExtensionMethods
{
    public static int[] ToIntArray(this string str)
    {
        return str.Split(",").Select(c => int.Parse(c)).ToArray();
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