using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.ViewModels
{
    public class LogicalOrVM : LogicalBaseVM
    {
        public LogicalOrVM()
        {
            base.logicalModel = new LogicalOr();
        }
    }
}
