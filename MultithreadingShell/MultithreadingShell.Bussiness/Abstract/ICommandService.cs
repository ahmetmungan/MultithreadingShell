using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingShell.Bussiness.Abstract
{
    public interface ICommandService
    {
        List<Command> GetAll();
        string SetLoggerPath();
        void AddLogger(string[] commands);
        string ExecuteCommand(string command);
        string MultihreadingExecuteCommands(string[] commands, ref string currentDirectory);
        void SetShellType(string command);
        void CheckExiting(string[] commands);
        void SystemNotification();
        string[] CommandDivision(string command);
        string SetId();
        
        //string MultithreadingExecute(string[] commands, ref string currentDirectory);
    }
}
