using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models;

namespace ProjectTests
{
    [TestClass]
    public class SignalTests
    {
        [TestMethod]
        public void ObserverAttachObservableTest()
        {
            IObserver input = new Input();

            IObservable outputOne = new Output();
            IObservable outputTwo = new Output();

            input.AttachObservable(outputOne);
            Assert.AreEqual(outputOne, input.Observable);
            Assert.AreEqual(true, input.IsObservable);

            input.AttachObservable(outputOne);
            Assert.AreEqual(outputOne, input.Observable);
            Assert.AreEqual(true, input.IsObservable);

            Assert.AreEqual(false, input.AttachObservable(outputTwo));
            Assert.AreEqual(outputOne, input.Observable);
            Assert.AreEqual(true, input.IsObservable);
        }

        [TestMethod]
        public void ObserverDetachObservableTest()
        {
            IObserver input = new Input();

            IObservable output = new Output();

            input.AttachObservable(output);
            Assert.AreEqual(1, output.ObserverCount);

            input.DetachObservable();
            Assert.AreEqual(null, input.Observable);
            Assert.AreEqual(false, input.IsObservable);
            Assert.AreEqual(0, output.ObserverCount);
        }

        [TestMethod]
        public void ObservableAttachObserverTest()
        {
            IObservable output = new Output();
            Assert.AreEqual(0, output.ObserverCount);

            IObserver inputOne = new Input();
            IObserver inputTwo = new Input();

            output.AttachObserver(inputOne);
            Assert.AreEqual(1, output.ObserverCount);
            Assert.AreEqual(output, inputOne.Observable);

            output.AttachObserver(inputOne);
            Assert.AreEqual(1, output.ObserverCount);
            Assert.AreEqual(output, inputOne.Observable);

            output.AttachObserver(inputTwo);
            Assert.AreEqual(2, output.ObserverCount);
            Assert.AreEqual(output, inputTwo.Observable);
        }

        [TestMethod]
        public void ObservableDetachObserverTest()
        {
            IObservable output = new Output();
            Assert.AreEqual(0, output.ObserverCount);

            IObserver input = new Input();

            output.AttachObserver(input);
            Assert.AreEqual(1, output.ObserverCount);
            Assert.AreEqual(output, input.Observable);

            output.DetachObserver(input);
            Assert.AreEqual(0, output.ObserverCount);
            Assert.AreEqual(null, input.Observable);
        }

        [TestMethod]
        public void ShemaInputTest()
        {
            Output externalOutput = new Output();
            Input internalShemaInput = new Input();

            IObserver shemaInput = new ShemaInput(internalShemaInput);
            shemaInput.AttachObservable(externalOutput);

            externalOutput.SignalValue = true;
            externalOutput.NotifyAllObservers();
            Assert.AreEqual(true, internalShemaInput.SignalValue);

            externalOutput.SignalValue = false;
            externalOutput.NotifyAllObservers();
            Assert.AreEqual(false, internalShemaInput.SignalValue);
        }

        [TestMethod]
        public void ShemaOutputTest()
        {
            Output internalShemaOutput = new Output();
            Input externInput = new Input();

            ShemaOutput shemaOutput = new ShemaOutput(internalShemaOutput);            
            shemaOutput.AttachObserver(externInput);


            internalShemaOutput.SignalValue = true;
            internalShemaOutput.NotifyAllObservers();
            Assert.AreEqual(true, externInput.SignalValue);

            internalShemaOutput.SignalValue = false;
            internalShemaOutput.NotifyAllObservers();
            Assert.AreEqual(false, externInput.SignalValue);
        }
    }
}
