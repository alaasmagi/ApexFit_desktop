using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace ApexFit_desktop_UI
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   
            ApexFit_login login = new ApexFit_login();
            Application.EnableVisualStyles();
            int userId = login.TryLoginWithToken();
            if (userId == 0)
            {
                Application.Run(new ApexFit_login());
            }
            else
            {
                Application.Run(new ApexFit_mainWindow(userId));
            }
        }
        
    }
}
