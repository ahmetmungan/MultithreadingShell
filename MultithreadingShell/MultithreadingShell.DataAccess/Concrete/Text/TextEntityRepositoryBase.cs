using MultithreadingShell.DataAccess.Abstract;
using MultithreadingShell.Entities.Abstract;
using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.DataAccess.Concrete.Text
{
    public class TextEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : class, new()
    {
        public void Add(TEntity entity, string path)
        {
            using (StreamWriter context = File.AppendText(path))
            {
                context.WriteLine(entity);
                context.Close();
            }
        }

        public void AddCommand(Command command, string path)
        {
            using (StreamWriter context = File.AppendText(path))
            {
                context.WriteLine("\n*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                context.WriteLine("Command ID: " + command.Id);
                context.WriteLine("Command Date: " + command.Date);
                context.WriteLine("Command Content: " + string.Join(",", command.CommandContent));
                context.Close();
            }
        }

        public void AddResult(Result result, string path)
        {
            using (StreamWriter context = File.AppendText(path))
            {
                context.WriteLine("Result ID: " + result.Id);
                context.WriteLine("Result Content: \n" + result.ResultContent);
                context.WriteLine("Result Running Time: " + result.RunningTime+" saniye");
                context.Close();
            }
        }

        public void DeleteAll(string path)
        {
            File.WriteAllText(path, string.Empty);
        }

        public string GetAll(Expression<Func<TEntity, bool>> filter, string path)
        {
            return File.ReadAllText(path);
        }
    }
}
