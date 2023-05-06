using MultithreadingShell.Entities.Abstract;
using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        string GetAll(Expression<Func<T, bool>> filter, string path);
        void Add(T entity, string path);
        void AddCommand(Command command, string path);
        void AddResult(Result result, string path);
        void DeleteAll(string path);
    }
}
