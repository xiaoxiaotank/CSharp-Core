using System;
using System.Collections;

namespace CSharp.Core.Special.CoreClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestEnvironment();
            TestAppContext();
        }

        static void TestEnvironment()
        {
            Console.WriteLine($"当前应用启动程序的目录：{Environment.CurrentDirectory}");
            Console.WriteLine($"操作系统目录：{Environment.SystemDirectory}");
            Console.WriteLine($"当前用用启动程序路径：{Environment.CommandLine}");

            Console.WriteLine($"电脑名：{Environment.MachineName}");
            Console.WriteLine($"CPU逻辑核心数：{Environment.ProcessorCount}");
            Console.WriteLine($"操作系统版本号：{Environment.OSVersion}");
            Console.WriteLine($"操作系统是否为64位：{Environment.Is64BitOperatingSystem}");
            Console.WriteLine($"当前应用是否为64位：{Environment.Is64BitProcess}");
            Console.WriteLine($"新行：{Environment.NewLine}");

            Console.WriteLine($"当前操作系统登录用户名：{Environment.UserName}");
            Console.WriteLine($"当前应用进程是否运行在用户交互模式下：{Environment.UserInteractive}");
            Console.WriteLine($"当前操作系统登录用户域名：{Environment.UserDomainName}");

            Console.WriteLine($"电脑开机后，共经过了：{Environment.TickCount} ms");
            Console.WriteLine($"当前行代码的StackTrace：{Environment.StackTrace}");
            Console.WriteLine($"当前应用所使用的内存(byte)：{Environment.WorkingSet}");
            Console.WriteLine($"CLR版本：{Environment.Version}");
            Console.WriteLine("电脑中的所有磁盘：");
            foreach (var item in Environment.GetLogicalDrives())
            {
                Console.WriteLine(item);
            }
            foreach (Environment.SpecialFolder item in Enum.GetValues(typeof(Environment.SpecialFolder)))
            {
                Console.WriteLine($"{item}：{Environment.GetFolderPath(item)}");
            }

            Console.WriteLine($"环境变量JAVA_HOME的值：{Environment.GetEnvironmentVariable("JAVA_HOME")}");
            Console.WriteLine("系统所有环境变量：");
            foreach (DictionaryEntry item in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"{item.Key}:{item.Value}");
            }
            //Environment.SetEnvironmentVariable("Home", "any value");
        }

        static void TestAppContext()
        {
            Console.WriteLine($"当前应用启动程序的目录：{AppContext.BaseDirectory}");
            var switchName = "switch 1";
            Console.WriteLine($"{switchName}是否已打开：{(AppContext.TryGetSwitch(switchName, out bool isEnabled) ? isEnabled.ToString() : "未定义")}");
            AppContext.SetSwitch(switchName, true);
            Console.WriteLine($"{switchName}是否已打开：{(AppContext.TryGetSwitch(switchName, out isEnabled) ? isEnabled.ToString() : "未定义")}");
        }
    }
}
