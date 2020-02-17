using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTests
{
    public class CreateCollectionFrame
    {
        public static ObservableCollection<LogicalBase> CreateXorShemaFrame()
        {
            LogicalBase or = new LogicalOr();
            LogicalBase andOne = new LogicalAnd();
            LogicalBase not = new LogicalNot();
            LogicalBase andTwo = new LogicalAnd();

            LogicalBase spaceOne = new LogicalSpace();
            LogicalBase spaceTwo = new LogicalSpace();

            or.Outputs[0].AttachObserver(andTwo.Inputs[0]);
            not.Outputs[0].AttachObserver(andTwo.Inputs[1]);

            not.Inputs[0].AttachObservable(andOne.Outputs[0]);

            spaceOne.Outputs[0].AttachObserver(or.Inputs[0]);
            spaceOne.Outputs[0].AttachObserver(andOne.Inputs[0]);

            spaceTwo.Outputs[0].AttachObserver(or.Inputs[1]);
            spaceTwo.Outputs[0].AttachObserver(andOne.Inputs[1]);

            return new ObservableCollection<LogicalBase>()
            {
                or, not, andOne, andTwo, spaceOne, spaceTwo
            };
        } 
    }
}
