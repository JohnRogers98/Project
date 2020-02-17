using System;
using System.Windows.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;
using Project.ViewModels;

namespace ProjectTests
{
    [TestClass]
    public class SelectSignalObjectTests
    {
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


            ICommand selectSignalCommand = switchOne.SelectSignalCommand;
            selectSignalCommand.Execute(null);
            Assert.AreEqual(switchOne.Output, SelectSignal.Signal);

            selectSignalCommand = switchTwo.SelectSignalCommand;
            selectSignalCommand.Execute(null);
            Assert.AreEqual(switchTwo.Output, SelectSignal.Signal);


            selectSignalCommand = and.SelectSignalCommand;
            selectSignalCommand.Execute(and.InputSignals[0]);
            Assert.AreEqual(null, SelectSignal.Signal);

            selectSignalCommand = and.SelectSignalCommand;
            selectSignalCommand.Execute(and.InputSignals[1]);
            Assert.AreEqual(and.InputSignals[1], SelectSignal.Signal);

            selectSignalCommand = switchOne.SelectSignalCommand;
            selectSignalCommand.Execute(null);
            Assert.AreEqual(null, SelectSignal.Signal);
        }
    }
}
