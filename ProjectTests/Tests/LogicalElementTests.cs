using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;

namespace ProjectTests
{
    [TestClass]
    public class LogicalElementTests
    {
        [TestMethod]
        public void LogicalSwitchWorkTest()
        {
            LogicalSwitch sw = new LogicalSwitch();

            sw.Switching();
            Assert.AreEqual(true, sw.Output.SignalValue);

            sw.Switching();

            Assert.AreEqual(false, sw.Output.SignalValue);
        }

        [TestMethod]
        public void LogicalAndWorkTest()
        {
            LogicalSwitch switchOne = new LogicalSwitch();
            LogicalSwitch switchTwo = new LogicalSwitch();
            LogicalBase and = new LogicalAnd();

            switchOne.Output.AttachObserver(and.Inputs[0]);
            switchTwo.Output.AttachObserver(and.Inputs[1]);

            Assert.AreEqual(false, and.Output.SignalValue);

            switchOne.Switching();
            Assert.AreEqual(false, and.Output.SignalValue);

            switchTwo.Switching();
            Assert.AreEqual(true, and.Output.SignalValue);

            switchOne.Switching();
            Assert.AreEqual(false, and.Output.SignalValue);

            switchTwo.Switching();
            Assert.AreEqual(false, and.Output.SignalValue);
        }

        [TestMethod]
        public void LogicalOrWorkTest()
        {
            LogicalSwitch switchOne = new LogicalSwitch();
            LogicalSwitch switchTwo = new LogicalSwitch();
            LogicalBase or = new LogicalOr();

            switchOne.Output.AttachObserver(or.Inputs[0]);
            switchTwo.Output.AttachObserver(or.Inputs[1]);

            switchOne.Switching();
            Assert.AreEqual(true, or.Output.SignalValue);

            switchTwo.Switching();
            Assert.AreEqual(true, or.Output.SignalValue);

            switchOne.Switching();
            Assert.AreEqual(true, or.Output.SignalValue);

            switchTwo.Switching();

            Assert.AreEqual(false, or.Output.SignalValue);
        }

        [TestMethod]
        public void LogicalNotWorkTest()
        {
            LogicalSwitch switchOne = new LogicalSwitch();
            LogicalNot not = new LogicalNot();

            switchOne.Output.AttachObserver(not.Inputs[0]);

            Assert.AreEqual(true, not.Output.SignalValue);
        }
    }
}
