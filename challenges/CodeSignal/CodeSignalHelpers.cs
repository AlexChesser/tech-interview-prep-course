#pragma warning disable
using System;
using System.Diagnostics;
using System.IO;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Numerics;

using MySql.Data.MySqlClient;
using Newtonsoft.Json;

public class Solution
{
    public class Answer
    {
        public string Ack()
        {
            return "ack";
        }
    }

    public class AnswerTests
    {

        [Test]
        public void TestToIntArrayExpectFailure()
        {
            string input = "0,1,2,3,4";
            int[] output = input.ToIntArray();
            Assert.IsTrue(output.Length == 6 && output[1] == 1, "don't cry, this test was supposed to fail");
        }

        [Test]
        public void TestToIntArray()
        {
            string input = "0,1,2,3,4,5";
            int[] output = input.ToIntArray();
            Assert.IsTrue(output.Length == 6 && output[1] == 1, "this was supposed to create an array");
        }

        [Test]
        public void Test_Ack()
        {
            Answer a = new Answer();
            Assert.IsTrue(a.Ack() == "ack", "expected ack");
        }

        [Test]
        [TestCase("foo", "bar", "baz", true, 1, 8)]
        [TestCase("foo", "bar", "baz", true, 1, 10)]
        public void Test_TestCase(string param1, string param2, string param3, bool param4, int param5, int param6)
        {
            Assert.IsTrue(param1 == "foo", "expected foo");
            Assert.IsTrue(param2 == "bar", "expected bar");
            Assert.IsTrue(param3 == "baz", "expected baz");
            Assert.IsTrue(param4, "expected true");
            Assert.IsTrue(param5 == 1, "expected (int) 1");
            Assert.IsTrue(param6 % 2 == 0, $"expected {param6} to be an even number");
        }
    }

    public static void Main()
    {
        // get all methods in the assembly
        // check for any that have a TestAttribute (custom)
        // run them all against the answertests class
        // ta-daaahhh!
        MethodInfo[] methods = Assembly.GetExecutingAssembly()
            .GetTypes()
            .SelectMany(t => t.GetMethods())
            .Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0)
            .ToArray();
        AnswerTests at = new AnswerTests();
        foreach (MethodInfo m in methods)
        {
            TestCaseAttribute[] cases = m.GetCustomAttributes(typeof(TestCaseAttribute), false)
                .Select(tca => tca as TestCaseAttribute)
                .ToArray();
            if (cases.Length > 0)
            {
                foreach (TestCaseAttribute c in cases)
                {
                    m.Invoke(at, BindingFlags.Default, null, c.Arguments, null);
                }
            }
            else
            {
                m.Invoke(at, BindingFlags.Default, null, null, null);
            }
        }
    }
}

// normally I prefer to use NUnit or some real testing framework, but since that doesn't seem to 
// be available in codesignal I've written my own little reflection based test runner.
// any method tagged with a [Test] attribute will get executed on run. 
// a more advanced version of this code might actually allow me to call
// my test methods with parameters, but this should be good enough for 
// the purposes of a leetcode. And really this was all just a chance to 
// get familliar with codesignal before encountering it for the first time in a live-interview type situation.
// (update: with a second night to prepare before the pop quiz I added another layer, parameterized unit testing! woo hoo!! I sure hope this winds up being useful)
#region helpers

public static class LeetCodeExtensionMethods
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
}

public static class Assert
{
    public static void IsTrue(bool condition, string failureMessage)
    {
        StackFrame frame = new StackFrame(1, true);
        var caller = frame.GetMethod();
        if (!condition)
        {
            Console.WriteLine($"\n{caller}: 😢 {failureMessage}");
        }
        else
        {
            Console.Write("😂");
        }
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class TestAttribute : Attribute { }

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public class TestCaseAttribute : Attribute
{
    public object?[] Arguments { get; }
    public TestCaseAttribute(params object?[]? arguments)
    {
        if (arguments == null)
        {
            Arguments = new object?[] { null };
        }
        else
        {
            Arguments = arguments;
        }
    }
}

# endregion


