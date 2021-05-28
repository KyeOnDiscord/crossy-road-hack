using System;
using System.Linq;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
namespace CrossyRoadHack
{
    static class Program
    {
        /// <summary>
        /// Import your dll into resources and paste the following code below.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //https://gist.github.com/kyeondiscord/8b78ad6c21f983342ae0869023d26c8a
            AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender, ResolveEventArgs args)
            {
                string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
                dllName = dllName.Replace(".", "_");
                if (dllName.EndsWith("_resources")) return null;
                ResourceManager rm = new ResourceManager(typeof(Program).Namespace + ".Properties.Resources", Assembly.GetExecutingAssembly());
                byte[] bytes = (byte[])rm.GetObject(dllName);
                return Assembly.Load(bytes);
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
