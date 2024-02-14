using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymApp
{
    static class Program
    { 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
    
        public static bool IsAdmin
        {
            get { return adm; }
            set { adm = value; }
        }

        private static bool adm;

        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
