using MultithreadingShell.Bussiness.Abstract;
using MultithreadingShell.DataAccess.Abstract;
using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.Bussiness.Concrete
{
    public class ResultManager : IResultService
    {
        ICommandService _commandService;
        IResultDal _resultDal;
        public ResultManager(IResultDal resultDal)
        {
            _resultDal = resultDal;
        }

        public void AddLogger(string result, string runningTime, ICommandService commandService)
        {
            _commandService = commandService;
            _resultDal.AddResult(new Result
            {
                Id = _commandService.SetId(),
                ResultContent = result,
                RunningTime = runningTime.ToString()
            }, _commandService.SetLoggerPath());
        }

        public List<Result> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
