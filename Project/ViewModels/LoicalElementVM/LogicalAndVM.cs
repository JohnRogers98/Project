using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models;

namespace Project.ViewModels
{
    public class LogicalAndVM : LogicalBaseVM
    {
        public LogicalAndVM()
        {
            logicalModel = new LogicalAnd();
        }
    }
}
