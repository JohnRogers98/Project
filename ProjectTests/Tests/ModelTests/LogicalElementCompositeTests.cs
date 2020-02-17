using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ProjectTests
{
    [TestClass]
    public class LogicalElementCompositeTest
    {
        [TestMethod]
        public void CompositeXORTest()
        {
            ObservableCollection<LogicalBase> xorInternalCollectionFrame = 
                CreateCollectionFrame.CreateXorShemaFrame();

            LogicalShema xor = new LogicalShema(xorInternalCollectionFrame);
            Assert.AreEqual(2, xor.Inputs.Count);
            Assert.AreEqual(1, xor.Outputs.Count);
            Assert.AreEqual(false, xor.Outputs[0].SignalValue);

            Switch switchOne = new Switch();
            Switch switchTwo = new Switch();

            switchOne.Output.AttachObserver(xor.Inputs[0]);
            switchTwo.Output.AttachObserver(xor.Inputs[1]);


            switchOne.Switching();
            Assert.AreEqual(true, xor.Outputs[0].SignalValue);

            switchTwo.Switching();
            Assert.AreEqual(false, xor.Outputs[0].SignalValue);
        }
    }
}
