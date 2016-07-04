using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Top_Clock {
    static class Program {

        static void Reset() {
            RegistryKey Software = Registry.CurrentUser.OpenSubKey("Software", true);
            try { Software.DeleteSubKey("TopClock"); } catch { }
            Software.Close();
        }
        
        [STAThread]
        static void Main(string[] args) {
            if (args.Contains("-reset")) Reset();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
