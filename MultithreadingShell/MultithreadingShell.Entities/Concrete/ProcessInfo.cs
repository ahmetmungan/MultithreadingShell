using MultithreadingShell.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.Entities.Concrete
{
    public class ProcessInfo : IEntity
    {
        public string FileName { get; set; }
        public string Arguments { get; set; }
        public bool UseShellExecute { get; set; }
        public bool RedirectStandardOutput { get; set; }
    }
}
