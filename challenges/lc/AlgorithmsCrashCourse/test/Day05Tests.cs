using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class Day05Tests : TestTemplate
    {



        [Test]
        [TestCase("hello", "olleh")]
        [TestCase("Hannah", "hannaH")]
        [TestCase("A man, a plan, a canal: Panama", "amanaP :lanac a ,nalp a ,nam A")]
        public void _19_Remove_Nth_Node_From_End_of_List(string arr, string expected)
        {
            var s = new _19_Remove_Nth_Node_From_End_of_List.Solution();
            char[] haystack = arr.ToCharArray();
            // s.RemoveNthFromEnd;
            Assert.AreEqual(expected, string.Join("", haystack));
        }

        [Test]

        [TestCase("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
        [TestCase("God Ding", "doG gniD")]
        public void _876_Middle_of_the_Linked_List(string arr, string expected)
        {
            var s = new _876_Middle_of_the_Linked_List.Solution();
            //string result = s.MiddleNode(arr);
            //Assert.AreEqual(expected, result);
        }

    }
}