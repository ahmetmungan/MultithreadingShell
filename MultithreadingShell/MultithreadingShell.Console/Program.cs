using MultithreadingShell.Bussiness.Abstract;
using MultithreadingShell.Bussiness.Concrete;
using MultithreadingShell.Bussiness.DependencyResolvers;
using MultithreadingShell.DataAccess.Abstract;
using MultithreadingShell.Entities.Concrete;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        ICommandService _commandService = InstanceFactory.GetInstance<ICommandService>();
        IResultService _resultService = InstanceFactory.GetInstance<IResultService>();

        _commandService.SystemNotification();
        string[] commands;

        while (true)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.Write($"{currentDirectory}>");
            commands = _commandService.CommandDivision(Console.ReadLine());
            _commandService.CheckExiting(commands);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            string result = "";
            result += _commandService.MultihreadingExecuteCommands(commands, ref currentDirectory);
            stopWatch.Stop();
            var runTime = (double)stopWatch.ElapsedMilliseconds / 1000;
            Console.WriteLine($"{result} \n Çalışma süresi: {runTime} saniye \n ");

            if (!result.Contains("Hata!") || result == "")
            {
                _commandService.AddLogger(commands);
                _resultService.AddLogger(result, runTime.ToString(), _commandService);
            }
        }
    }
}
