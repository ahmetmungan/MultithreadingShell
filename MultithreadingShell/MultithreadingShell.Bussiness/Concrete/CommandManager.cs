using MultithreadingShell.Bussiness.Abstract;
using MultithreadingShell.DataAccess.Abstract;
using MultithreadingShell.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using MultithreadingShell.Bussiness.DependencyResolvers;
using System.Collections.Concurrent;

namespace MultithreadingShell.Bussiness.Concrete
{
    public class CommandManager : ICommandService
    {
        ICommandDal _commandDal;
        private string shellTypeArgument;
        private string shellStartingCommand;
        private IResultService _resultService = InstanceFactory.GetInstance<IResultService>();

        public CommandManager(ICommandDal commandDal)
        {
            _commandDal = commandDal;
        }

        public List<Command> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SetShellType(string command)
        {
            if (command == "bash")
            {
                shellTypeArgument = "bash.exe";
                shellStartingCommand = "-c ";
                Console.Title = "Multithreading Bash";
            }
            else if (command == "cmd")
            {
                shellTypeArgument = "cmd.exe";
                shellStartingCommand = "/c ";
                Console.Title = "Multithreading Command Prompt";
            }
            else Console.WriteLine("Hata!");
        }

        public void CheckExiting(string[] commands)
        {

            if (commands.Contains("exit"))
            {
                Environment.Exit(0);
            }
        }

        public void SystemNotification()
        {
            Console.Title = "Multithreading Shell";
            Console.WriteLine("*** Sistem Bilgilendirmesi ***\n");
            int workerThreads, completionPortThreads;
            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            Console.WriteLine("Kullanılabilir maksimum thread sayısı: " + workerThreads);
            Console.WriteLine("Kullanılabilir maksimum thread sayısı (I/O portları): " + completionPortThreads);
            Console.WriteLine("Kullanılabilir maksimum core sayısı: " + Environment.ProcessorCount);
            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Öncelikle shell tipini belirleyiniz! (cmd / bash)");
            //Console.ResetColor();
            Console.WriteLine("\n*** Sistem Bilgilendirmesi ***\n\n");
            Directory.SetCurrentDirectory(@"C:\");
        }

        public string[] CommandDivision(string command)
        {
            if (command.Contains(";"))
            {
                return command.Split(new[] { ";" },
                    StringSplitOptions.RemoveEmptyEntries)
                              .Select(c => c.Trim())
                              .ToArray();
            }
            else if (command.Contains("&"))
            {
                return command.Split(new[] { "&" },
                    StringSplitOptions.RemoveEmptyEntries)
                              .Select(c => c.Trim())
                              .ToArray();
            }
            else
            {
                return new string[] { command.Trim() };
            }
        }

        public string SetId()
        {
            string idPrefix = shellTypeArgument.Substring(0, shellTypeArgument.Length - 4).ToUpper();
            Guid guid = Guid.NewGuid();
            string idPostfix = guid.ToString();
            return idPrefix + "-" + idPostfix;
        }

        public string SetLoggerPath()
        {
            return @"C:\Users\Ahmet Mungan\Desktop\root\deneme\" + shellTypeArgument.Substring(0, shellTypeArgument.Length - 4).ToUpper() + "Logger.txt";
        }

        public void AddLogger(string[] commands)
        {
            _commandDal.AddCommand(new Command
            {
                Id = SetId(),
                CommandContent = commands,
                Date = DateTime.Now
            }, SetLoggerPath());
        }

        public string ExecuteCommand(string command)
        {
            try
            {
                if (shellTypeArgument == "bash.exe")
                {
                    command = "'" + command + "'";
                    StringBuilder result = new StringBuilder();
                    ProcessStartInfo startInfo = new ProcessStartInfo(shellTypeArgument, shellStartingCommand + command);
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;
                    //startInfo.RedirectStandardError = true;
                    Process process = Process.Start(startInfo);
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string output = reader.ReadToEnd();
                        result.Append(output);
                    }
                    return result.ToString();
                }
                else if (shellTypeArgument == "cmd.exe")
                {
                    StringBuilder result = new StringBuilder();
                    ProcessStartInfo startInfo = new ProcessStartInfo(shellTypeArgument, shellStartingCommand + command);
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardOutput = true;
                    //startInfo.RedirectStandardError = true;
                    Process process = Process.Start(startInfo);
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string output = reader.ReadToEnd();
                        result.Append(output);
                    }
                    return result.ToString();
                }
                else return "Hata! Öncelikle shell tipini belirleyiniz! (cmd / bash)\n";
            }
            catch (Exception)
            {
                return $"Hata! Öncelikle shell tipini belirleyiniz! (cmd / bash)\n";
            }
        }

        public string MultihreadingExecuteCommands(string[] commands, ref string currentDirectory)
        {
            if (commands.Length > Environment.ProcessorCount)
            {
                Console.WriteLine("Dikkat! Performanslı çalışabilecek çoklu iş parçacığı sayısının üstündesiniz!\n-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-\n");
            }

            StringBuilder[] results = new StringBuilder[commands.Length];
            Thread[] threads = new Thread[commands.Length];
            for (int i = 0; i < commands.Length; i++)
            {
                if (commands[i].StartsWith("cd "))
                {
                    string directory = commands[i].Substring(3);
                    try
                    {
                        Directory.SetCurrentDirectory(directory);
                        currentDirectory = Directory.GetCurrentDirectory();
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message + "\n";
                    }
                    return string.Empty;
                }
                if (commands[i] == "bash" || commands[i] == "cmd")
                {
                    SetShellType(commands[i]);
                    return commands[i] + " komut istemine geçildi.";
                }
                int index = i;
                results[i] = new StringBuilder();
                threads[i] = new Thread(() => results[index].Append(ExecuteCommand(commands[index])));
                threads[i].Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            StringBuilder finalResult = new StringBuilder();
            for (int i = 0; i < commands.Length; i++)
            {
                finalResult.Append(results[i].ToString());
            }

            return finalResult.ToString();
        }
    }
}
