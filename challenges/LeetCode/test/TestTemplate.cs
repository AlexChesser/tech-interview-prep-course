using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace test
{
    public class TestTemplate
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [OneTimeTearDown]
        public void OneTimeTearDow()
        {
            Trace.Flush();
        }

        [SetUp]
        public void Setup()
        {
        }

    }
}