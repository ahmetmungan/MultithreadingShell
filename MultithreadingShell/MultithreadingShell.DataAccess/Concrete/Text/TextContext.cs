using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.DataAccess.Concrete.Text
{
    public class TextContext
    {
        public Command Commands { get; set; }
        public Result Results { get; set; }
    }
}
