using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.ViewModels
{
    public class LogicalNotVM : LogicalBaseVM
    {
        public LogicalNotVM()
        {
            base.logicalModel = new LogicalNot();
        }
    }
}
