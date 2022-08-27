using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VRC_Cleaner
{
    internal class Program
    {
        public static string VRChat_C = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow")}\\VRChat";
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cache Path: " + VRChat_C);

            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "VRChat Cache Cleaner By Scrim";

            Console.WriteLine("Press ANY KEY to clear VRC Cache:");
            Console.ReadKey();

            Console.WriteLine("Locating VRChat cache...");
            if (Directory.Exists(VRChat_C))
            {
                Console.WriteLine("VRChat cache found!");
                Console.WriteLine("Deleting...");
                Directory.Delete(VRChat_C, true);

                if (!Directory.Exists(VRChat_C))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Succesfully deleted!");
                    Console.WriteLine("Quiting...");
                    Thread.Sleep(5000);
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Err2();
                }
            }
            else
            {
                Err1();
            }
        }

        public static void Err1()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("VRChat cache not found!");
            Console.WriteLine("Reverting and Quiting task...");
            Thread.Sleep(5000);
            Process.GetCurrentProcess().Kill();
        }

        public static void Err2()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Failed to delete cache :(");
            Console.WriteLine("Try again!");
            Thread.Sleep(5000);
            Process.GetCurrentProcess().Kill();
        }
    }
}
