using MultithreadingShell.Bussiness.Abstract;
using MultithreadingShell.Bussiness.Concrete;
using MultithreadingShell.DataAccess.Abstract;
using MultithreadingShell.DataAccess.Concrete.Text;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.Bussiness.DependencyResolvers
{
    public class BussinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IResultService>().To<ResultManager>();
            Bind<ICommandService>().To<CommandManager>();
            Bind<IResultDal>().To<TextResultDal>();
            Bind<ICommandDal>().To<TextCommandDal>();
        }
    }
}
