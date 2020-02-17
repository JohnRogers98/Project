using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;

namespace ProjectTests
{
    [TestClass]
    public class LogicalElementTests
    {
        [TestMethod]
        public void SwitchWorkTest()
        {
            Switch switchOne = new Switch();

            switchOne.Switching();
            Assert.AreEqual(true, switchOne.Output.SignalValue);

            switchOne.Switching();
            Assert.AreEqual(false, switchOne.Output.SignalValue);
        }

        [TestMethod]
        public void LogicalSpaceWorkTest()
        {
            LogicalBase space = new LogicalSpace();
            Switch switchOne = new Switch();

            space.Inputs[0].AttachObservable(switchOne.Output);
            Assert.AreEqual(false, space.Outputs[0].SignalValue);

            switchOne.Switching();
            Assert.AreEqual(true, space.Outputs[0].SignalValue);
        }

        [TestMethod]
        public void LogicalAndWorkTest()
        {
            Switch switchOne = new Switch();
            Switch switchTwo = new Switch();
            LogicalBase and = new LogicalAnd();

            switchOne.Output.AttachObserver(and.Inputs[0]);
            switchTwo.Output.AttachObserver(and.Inputs[1]);

            Assert.AreEqual(false, and.Outputs[0].SignalValue);

            switchOne.Switching();
            Assert.AreEqual(false, and.Outputs[0].SignalValue);

            switchTwo.Switching();
            Assert.AreEqual(true, and.Outputs[0].SignalValue);

            switchOne.Switching();
            Assert.AreEqual(false, and.Outputs[0].SignalValue);

            switchTwo.Switching();
            Assert.AreEqual(false, and.Outputs[0].SignalValue);
        }

        [TestMethod]
        public void CreatingMultiInputsElementAnd()
        {
            LogicalBase and = new LogicalAnd(3);

            Switch switchOne = new Switch();
            Switch switchTwo = new Switch();
            Switch switchThree = new Switch();

            and.Inputs[0].AttachObservable(switchOne.Output);
            and.Inputs[1].AttachObservable(switchTwo.Output);
            and.Inputs[2].AttachObservable(switchThree.Output);

            switchOne.Switching();
            switchTwo.Switching();
            Assert.AreEqual(false, and.Outputs[0].SignalValue);

            switchThree.Switching();
            Assert.AreEqual(true, and.Outputs[0].SignalValue);
        }

        [TestMethod]
        public void LogicalOrWorkTest()
        {
            Switch switchOne = new Switch();
            Switch switchTwo = new Switch();
            LogicalBase or = new LogicalOr();

            switchOne.Output.AttachObserver(or.Inputs[0]);
            switchTwo.Output.AttachObserver(or.Inputs[1]);

            switchOne.Switching();
            Assert.AreEqual(true, or.Outputs[0].SignalValue);

            switchTwo.Switching();
            Assert.AreEqual(true, or.Outputs[0].SignalValue);

            switchOne.Switching();
            Assert.AreEqual(true, or.Outputs[0].SignalValue);

            switchTwo.Switching();
            Assert.AreEqual(false, or.Outputs[0].SignalValue);
        }

        [TestMethod]
        public void CreatingMultiInputsElementOr()
        {
            LogicalBase or = new LogicalOr(3);

            Switch switchOne = new Switch();
            Switch switchTwo = new Switch();
            Switch switchThree = new Switch();

            or.Inputs[0].AttachObservable(switchOne.Output);
            or.Inputs[1].AttachObservable(switchTwo.Output);
            or.Inputs[2].AttachObservable(switchThree.Output);

            switchOne.Switching();
            Assert.AreEqual(true, or.Outputs[0].SignalValue);
        }

        [TestMethod]
        public void LogicalNotWorkTest()
        {
            Switch switchOne = new Switch();
            LogicalBase not = new LogicalNot();

            switchOne.Output.AttachObserver(not.Inputs[0]);
            Assert.AreEqual(true, not.Outputs[0].SignalValue);
        }
    }
}
