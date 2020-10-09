using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corporation_Database
{
    class IOAssociation
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void SHChangeNotify(uint wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);
        public static bool isAssociated(string caption)
        {
            return (Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + caption, false) == null);
        }

        public static void SetAssociation(string format, string appName, string iconPath)
        {
            RegistryKey fileReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\" + format);
            RegistryKey appReg = Registry.CurrentUser.CreateSubKey("Software\\Classes\\Applications\\" + appName);
            RegistryKey appAssoc = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\" + format);

            fileReg.CreateSubKey("DefaultIcon").SetValue("", iconPath);
            fileReg.CreateSubKey("PerceivedType").SetValue("", "Text");

            appReg.CreateSubKey("shell\\edit\\command").SetValue("", "\"" + Application.ExecutablePath + "\" %1");
            appReg.CreateSubKey("DefaultIcon").SetValue("", iconPath);

            appAssoc.CreateSubKey("UserChoice").SetValue("Progid", "Applications\\" + appName);
            SHChangeNotify(0x08000000, 0x0000, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
