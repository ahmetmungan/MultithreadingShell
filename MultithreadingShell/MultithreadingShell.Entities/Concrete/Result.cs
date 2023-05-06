using MultithreadingShell.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.Entities.Concrete
{
    public class Result : IEntity
    {
        public string Id { get; set; }
        public string ResultContent { get; set; }
        public string RunningTime { get; set; }
    }
}
