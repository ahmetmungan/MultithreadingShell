using MultithreadingShell.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.Entities.Concrete
{
    public class Command : IEntity
    {
        public string Id { get; set; }
        public string[] CommandContent { get; set; }
        public DateTime Date { get; set; }
    }
}
