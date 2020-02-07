using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;

namespace ProjectTests
{
    [TestClass]
    public class LogicalElementTests
    {
        [TestMethod]
        public void WorkLogicalAndTest()
        {
            LogicalAnd and = new LogicalAnd();
            and.firstInput.Signal = true;
            and.secondInput.Signal = false;

            Boolean returned = and.OutputSignal;
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void WorkLogicalOrTest()
        {
            LogicalOr or = new LogicalOr();
            or.firstInput.Signal = true;

            Boolean returned = or.OutputSignal;
            Assert.AreEqual(true, returned);
        }

        [TestMethod]
        public void WorkLogicalNotTest()
        {
            LogicalNot not = new LogicalNot();
            not.input.Signal = true;

            Boolean returned = not.OutputSignal;
            Assert.AreEqual(false, returned);
        }

        [TestMethod]
        public void EventReturnedSignalLogicalNotTest()
        {
            LogicalNot not1 = new LogicalNot();
            LogicalNot not2 = new LogicalNot();

            not2.input.SubscribeOnEntranceSignal(not1);

            not1.input.Signal = true;
            Boolean returned = not2.OutputSignal;

            Assert.AreEqual(true, returned);
        }

        [TestMethod]
        public void EventReturnedSignalAndOrAndTest()
        {
            LogicalAnd logicalAnd1 = new LogicalAnd();
            LogicalOr logicalOr2 = new LogicalOr();
            LogicalAnd logicalAnd3 = new LogicalAnd();

            logicalAnd3.firstInput.SubscribeOnEntranceSignal(logicalAnd1);
            logicalAnd3.secondInput.SubscribeOnEntranceSignal(logicalOr2);

            logicalAnd1.firstInput.Signal= true;
            logicalAnd1.secondInput.Signal= true;

            Assert.AreEqual(false, logicalAnd3.OutputSignal);

            logicalOr2.firstInput.Signal = true;
            logicalOr2.secondInput.Signal = false;

            Assert.AreEqual(true, logicalAnd3.OutputSignal);
        }
    }
}
