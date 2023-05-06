using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.DataAccess.Abstract
{
    public interface ICommandDal : IEntityRepository<Command>
    {
    }
}
