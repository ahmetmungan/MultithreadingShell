using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.Bussiness.Abstract
{
    public interface IResultService
    {
        void AddLogger(string result, string runningTime, ICommandService commandService);
        List<Result> GetAll();
    }
}
