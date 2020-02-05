using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class LogicalElementNot : LogicalElementBase
    {
        private Boolean entry;
        public Boolean Entry
        {
            get
            {
                return entry;
            }
            set
            {
                entry = value;
            }
        }

        public override Boolean ReturnedValue
        {
            get
            {
                return !entry;
            }
        }
    }
}
