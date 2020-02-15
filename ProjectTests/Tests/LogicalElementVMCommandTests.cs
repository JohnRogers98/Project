using System;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;
using Project.ViewModels;

namespace ProjectTests
{
    [TestClass]
    public class LogicalElementVMCommandTests
    {
        [TestMethod]
        public void LogicalSwitchCommandTest()
        {
            SwitchVM sw = new SwitchVM();

            ICommand switchCommand = sw.SwitchingCommand;

            switchCommand.Execute(null);
            Assert.AreEqual(true, sw.Output.SignalValue);

            switchCommand.Execute(null);
            Assert.AreEqual(false, sw.Output.SignalValue);
        }

        [TestMethod]
        public void LogicalAndCommandTest()
        {
            SwitchVM switchOne = new SwitchVM();
            SwitchVM switchTwo = new SwitchVM();
            LogicalBaseVM and = LogicalBaseVM.CreateLogicalAnd();

            ICommand switchingSwitchOne = switchOne.SwitchingCommand;
            switchingSwitchOne.Execute(null);

            ICommand switchingSwitchTwo = switchTwo.SwitchingCommand;
            switchingSwitchTwo.Execute(null);


            ICommand selectSignalCommand = switchOne.SelectOutputCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = and.SelectInputCommand;
            selectSignalCommand.Execute(0);

            selectSignalCommand = and.SelectInputCommand;
            selectSignalCommand.Execute(1);

            selectSignalCommand = switchTwo.SelectOutputCommand;
            selectSignalCommand.Execute(null);

            Assert.AreEqual(true, and.Output.SignalValue);
        }

        [TestMethod]
        public void LogicalOrCommandTest()
        {
            SwitchVM switchOne = new SwitchVM();
            SwitchVM switchTwo = new SwitchVM();
            LogicalBaseVM or = LogicalBaseVM.CreateLogicalOr();

            ICommand switchingSwitchOne = switchOne.SwitchingCommand;
            switchingSwitchOne.Execute(null);

            ICommand selectSignalCommand = switchOne.SelectOutputCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = or.SelectInputCommand;
            selectSignalCommand.Execute(0);

            selectSignalCommand = or.SelectInputCommand;
            selectSignalCommand.Execute(1);

            selectSignalCommand = switchTwo.SelectOutputCommand;
            selectSignalCommand.Execute(null);

            Assert.AreEqual(true, or.Output.SignalValue);
        }

        [TestMethod]
        public void LogicalNotCommandTest()
        {
            SwitchVM switchOne = new SwitchVM();
            LogicalBaseVM not = LogicalBaseVM.CreateLogicalNot();

            ICommand selectSignalCommand = switchOne.SelectOutputCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = not.SelectInputCommand;
            selectSignalCommand.Execute(0);

            Assert.AreEqual(true, not.Output.SignalValue);
        }

        [TestMethod]
        public void SelectSignalValueTest()
        {
            SwitchVM switchOne = new SwitchVM();
            SwitchVM switchTwo = new SwitchVM();
            LogicalBaseVM and = LogicalBaseVM.CreateLogicalAnd();

            ICommand switchingSwitchOne = switchOne.SwitchingCommand;
            switchingSwitchOne.Execute(null);

            ICommand switchingSwitchTwo = switchTwo.SwitchingCommand;
            switchingSwitchTwo.Execute(null);


            ICommand selectSignalCommand = switchOne.SelectOutputCommand;
            selectSignalCommand.Execute(null);
            Assert.AreEqual((Signal)switchOne.Output, SelectSignal.Signal);

            selectSignalCommand = switchTwo.SelectOutputCommand;
            selectSignalCommand.Execute(null);
            Assert.AreEqual((Signal)switchTwo.Output, SelectSignal.Signal);


            selectSignalCommand = and.SelectInputCommand;
            selectSignalCommand.Execute(0);
            Assert.AreEqual(null, SelectSignal.Signal);

            selectSignalCommand = and.SelectInputCommand;
            selectSignalCommand.Execute(1);
            Assert.AreEqual(and.Inputs[1], SelectSignal.Signal);

            selectSignalCommand = switchOne.SelectOutputCommand;
            selectSignalCommand.Execute(null);
            Assert.AreEqual(null, SelectSignal.Signal);
        }
    }
}
