using System;
using System.Collections.ObjectModel;
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
            SwitchVM switchOne = new SwitchVM();

            ICommand switchCommand = switchOne.SwitchingCommand;

            switchCommand.Execute(null);
            Assert.AreEqual(true, switchOne.Output.SignalValue);

            switchCommand.Execute(null);
            Assert.AreEqual(false, switchOne.Output.SignalValue);
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

            ICommand selectSignalCommand = switchOne.SelectSignalCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = and.SelectSignalCommand;
            selectSignalCommand.Execute(and.InputSignals[0]);

            selectSignalCommand = and.SelectSignalCommand;
            selectSignalCommand.Execute(and.InputSignals[1]);

            selectSignalCommand = switchTwo.SelectSignalCommand;
            selectSignalCommand.Execute(null);

            Assert.AreEqual(true, and.OutputSignals[0].SignalValue);
        }

        [TestMethod]
        public void LogicalOrCommandTest()
        {
            SwitchVM switchOne = new SwitchVM();
            SwitchVM switchTwo = new SwitchVM();
            LogicalBaseVM or = LogicalBaseVM.CreateLogicalOr();

            ICommand switchingSwitchOne = switchOne.SwitchingCommand;
            switchingSwitchOne.Execute(null);

            ICommand selectSignalCommand = switchOne.SelectSignalCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = or.SelectSignalCommand;
            selectSignalCommand.Execute(or.InputSignals[0]);

            selectSignalCommand = or.SelectSignalCommand;
            selectSignalCommand.Execute(or.InputSignals[1]);

            selectSignalCommand = switchTwo.SelectSignalCommand;
            selectSignalCommand.Execute(null);

            Assert.AreEqual(true, or.OutputSignals[0].SignalValue);
        }

        [TestMethod]
        public void LogicalNotCommandTest()
        {
            SwitchVM switchOne = new SwitchVM();
            LogicalBaseVM not = LogicalBaseVM.CreateLogicalNot();

            ICommand selectSignalCommand = switchOne.SelectSignalCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = not.SelectSignalCommand;
            selectSignalCommand.Execute(not.InputSignals[0]);

            Assert.AreEqual(true, not.OutputSignals[0].SignalValue);
        }

        [TestMethod]
        public void LogicalSpaceCommandTest()
        {
            SwitchVM switchOne = new SwitchVM();
            LogicalBaseVM space = LogicalBaseVM.CreateLogicalSpace();

            ICommand switchingSwitchOne = switchOne.SwitchingCommand;

            ICommand selectSignalCommand = switchOne.SelectSignalCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = space.SelectSignalCommand;
            selectSignalCommand.Execute(space.InputSignals[0]);

            switchingSwitchOne.Execute(null);
            Assert.AreEqual(true, space.OutputSignals[0].SignalValue);
        }

        [TestMethod]
        public void LogicalXorShemaCommandTest()
        {
            ObservableCollection<LogicalBase> xorInternalCollectionFrame =
                CreateCollectionFrame.CreateXorShemaFrame();

            LogicalBaseVM xor = LogicalBaseVM.CreateLogicalShema(xorInternalCollectionFrame);

            SwitchVM switchOne = new SwitchVM();
            SwitchVM switchTwo = new SwitchVM();

            ICommand switchingSwitchOne = switchOne.SwitchingCommand;
            switchingSwitchOne.Execute(null);

            ICommand switchingSwitchTwo = switchOne.SwitchingCommand;
            switchingSwitchOne.Execute(null);

            ICommand selectSignalCommand = switchOne.SelectSignalCommand;
            selectSignalCommand.Execute(null);

            selectSignalCommand = xor.SelectSignalCommand;
            selectSignalCommand.Execute(xor.InputSignals[0]);

            selectSignalCommand = xor.SelectSignalCommand;
            selectSignalCommand.Execute(xor.InputSignals[1]);

            selectSignalCommand = switchTwo.SelectSignalCommand;
            selectSignalCommand.Execute(null);

            Assert.AreEqual(false, xor.OutputSignals[0].SignalValue);

            switchingSwitchOne.Execute(null);
            Assert.AreEqual(true, xor.OutputSignals[0].SignalValue);
        }
    }
}
