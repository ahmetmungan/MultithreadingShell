using MultithreadingShell.DataAccess.Abstract;
using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.DataAccess.Concrete.Text
{
    public class TextResultDal : TextEntityRepositoryBase<Result, TextContext>, IResultDal
    {
    }
}
