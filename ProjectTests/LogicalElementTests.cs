using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;

namespace ProjectTests
{
    [TestClass]
    public class LogicalElementTests
    {
        [TestMethod]
        public void WorkLogicalSwitchTest()
        {
            LogicalSwitch sw = new LogicalSwitch();

            sw.UpdateState();
            Assert.AreEqual(true, sw.Output.OutputSignal);

            sw.UpdateState();

            Assert.AreEqual(false, sw.Output.OutputSignal);
        }

        [TestMethod]
        public void WorkLogicalAndTest()
        {
            LogicalSwitch switchOne = new LogicalSwitch();
            LogicalSwitch switchTwo = new LogicalSwitch();
            LogicalAnd and = new LogicalAnd();

            switchOne.Output.AttachObserver(and.FirstInput);
            switchTwo.Output.AttachObserver(and.SecondInput);

            switchOne.UpdateState();
            Assert.AreEqual(false, and.Output.OutputSignal);

            switchTwo.UpdateState();

            Assert.AreEqual(true, and.Output.OutputSignal);

            switchOne.UpdateState();

            Assert.AreEqual(false, and.Output.OutputSignal);

            switchTwo.UpdateState();

            Assert.AreEqual(false, and.Output.OutputSignal);
        }

        [TestMethod]
        public void WorkLogicalOrTest()
        {
            LogicalSwitch switchOne = new LogicalSwitch();
            LogicalSwitch switchTwo = new LogicalSwitch();
            LogicalOr or = new LogicalOr();

            switchOne.Output.AttachObserver(or.FirstInput);
            switchTwo.Output.AttachObserver(or.SecondInput);

            switchOne.UpdateState();
            Assert.AreEqual(true, or.Output.OutputSignal);

            switchTwo.UpdateState();

            Assert.AreEqual(true, or.Output.OutputSignal);

            switchOne.UpdateState();

            Assert.AreEqual(true, or.Output.OutputSignal);

            switchTwo.UpdateState();

            Assert.AreEqual(false, or.Output.OutputSignal);
        }

        [TestMethod]
        public void WorkLogicalNotTest()
        {
            LogicalSwitch switchOne = new LogicalSwitch();
            LogicalNot not = new LogicalNot();

            switchOne.Output.AttachObserver(not.Input);

            Assert.AreEqual(true, not.Output.OutputSignal);
        }
    }
}
