using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;

namespace ProjectTests
{
    [TestClass]
    public class LogicalElementTests
    {
        [TestMethod]
        public void WorkLogicalElementAndTest()
        {
            LogicalElementAnd logicalElement = new LogicalElementAnd();
            logicalElement.EntryOne = true;
            logicalElement.EntryTwo = false;

            Boolean returned = logicalElement.ReturnedValue;
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void WorkLogicalElementOrTest()
        {
            LogicalElementOr logicalElement = new LogicalElementOr();
            logicalElement.EntryOne = true;
            logicalElement.EntryTwo = false;

            Boolean returned = logicalElement.ReturnedValue;
            Assert.AreEqual(true, returned);
        }

        [TestMethod]
        public void WorkLogicalElementNotTest()
        {
            LogicalElementNot logicalElement = new LogicalElementNot();
            logicalElement.Entry = true;

            Boolean returned = logicalElement.ReturnedValue;
            Assert.AreEqual(false, returned);
        }
    }
}
