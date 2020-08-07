using System;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;
namespace CrossyRoadHackV2
{
    class Program
    {
        public static int coins { get; set; }
        static void Main(string[] args)
        {
               foreach (var process in Process.GetProcessesByName("Crossy Road"))
                {
                    process.Kill();
               }
            Console.Title = "Cɾσʂʂყ Rσαԃ Hαƈƙ v2 | By Kye";
            Console.ForegroundColor = ConsoleColor.Green;
            start:  Console.WriteLine("Crossy Road Hack v2 | By Kye");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Type the number of coins you want");
            try
            {
                coins = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                goto start;
            }
            string path1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Yodo1Ltd.CrossyRoad_s3s3f300emkze\RoamingState\latest-save.dat";
            string path2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\Yodo1Ltd.CrossyRoad_s3s3f300emkze\LocalState\CloudBackupSave.dat";
            lineChanger("  \"cc\": " + coins + ",", path1 , 1530);
            lineChanger("  \"cc\": " + coins + ",", path2, 1530);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ");
            Console.WriteLine("Set coins to " + coins);
            Thread.Sleep(500);
            Process.Start("crossyroad-launch://");
            Environment.Exit(0);
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName, Encoding.UTF8);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
