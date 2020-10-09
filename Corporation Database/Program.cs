using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corporation_Database
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!IOAssociation.isAssociated(".bisytable"))
            {
                IOAssociation.SetAssociation(".bisytable", "Corporation Database.exe", Application.StartupPath + "\\icons\\bisytableicon.ico");
            }
            if (!IOAssociation.isAssociated(".bisyarch"))
            {
                IOAssociation.SetAssociation(".bisyarch", "Corporation Database.exe", Application.StartupPath + "\\icons\\bisyarch.ico");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(args.Length == 0 ? new SplashScreen("NONE") : new SplashScreen(args[0]));
        }
    }
}
