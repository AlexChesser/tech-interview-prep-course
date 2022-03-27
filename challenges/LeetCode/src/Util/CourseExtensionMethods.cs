using System;
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
        return str.Replace("[", "")
            .Replace("]", "")
            .Split(",")
            .Select(c =>
            {
                if (!int.TryParse(c, out int result))
                {
                    return 0;
                };
                return result;
            })
            .ToArray();
    }



    public static TreeNode ToBinaryTree(this int[] arr)
    {
        TreeNode AddInOrder(int[] arr, TreeNode root, int i)
        {
            // Base case for recursion
            if (i < arr.Length)
            {
                TreeNode temp = new TreeNode(arr[i]);
                root = temp;
                int firstLeaf = 2 * i + 1;
                root.left = (firstLeaf < arr.Length) ? AddInOrder(arr, root.left, 2 * i + 1) : null;
                root.right = (firstLeaf + 1 < arr.Length) ? AddInOrder(arr, root.right, 2 * i + 2) : null;
            }
            return root;
        }
        return AddInOrder(arr, new TreeNode(), 0);
    }

    public static string CommaJoin(this TreeNode tree)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(tree);
        List<int> values = new List<int>();
        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            if (current.left != null) queue.Enqueue(current.left);
            if (current.right != null) queue.Enqueue(current.right);
            values.Add(current.val);
        }
        return values.ToArray().CommaJoin();
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

    public static char[][] ToMultiDimensionalCharArray(this string str)
    {
        Regex rxp = new Regex("\\[([0-9\\.,]+?)\\]", RegexOptions.Compiled);
        List<char[]> n = new List<char[]>();
        foreach (Match match in rxp.Matches(str))
        {
            n.Add(match.Groups[1].ToString().Replace(",", "").ToCharArray());
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