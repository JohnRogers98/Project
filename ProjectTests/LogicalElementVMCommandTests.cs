using System;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.ViewModels;

namespace ProjectTests
{
    [TestClass]
    public class LogicalElementVMCommandTests
    {
        [TestMethod]
        public void LogicalSwitchCommandTest()
        {
            LogicalSwitchVM sw = new LogicalSwitchVM();

            ICommand switchCommand = sw.SwitchingCommand;

            switchCommand.Execute(null);
            Assert.AreEqual(true, sw.OutputSignal);

            switchCommand.Execute(null);
            Assert.AreEqual(false, sw.OutputSignal);
        }

        [TestMethod]
        public void LogicalAndCommandTest()
        {
            LogicalSwitchVM switchOne = new LogicalSwitchVM();
            LogicalSwitchVM switchTwo = new LogicalSwitchVM();
            LogicalBaseVM and = new LogicalAndVM();

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

            Assert.AreEqual(true, and.OutputSignal);
        }

        [TestMethod]
        public void LogicalOrCommandTest()
        {
            LogicalSwitchVM switchOne = new LogicalSwitchVM();
            LogicalSwitchVM switchTwo = new LogicalSwitchVM();
            LogicalBaseVM or = new LogicalOrVM();

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

            Assert.AreEqual(true, or.OutputSignal);
        }

        [TestMethod]
        public void LogicalNotCommandTest()
        {
            LogicalSwitchVM switchOne = new LogicalSwitchVM();
            LogicalBaseVM not = new LogicalNotVM();

            ICommand selectSignalCommand = switchOne.SelectOutputCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = not.SelectInputCommand;
            selectSignalCommand.Execute(0);

            Assert.AreEqual(true, not.OutputSignal);
        }
    }
}
