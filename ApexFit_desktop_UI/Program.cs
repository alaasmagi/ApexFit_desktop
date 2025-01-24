using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using DataAccess;
using Domain;


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
            AppDbContextFactory contextFactory = new AppDbContextFactory();
            var dbContext = contextFactory.CreateDbContext();
            ApexFit_login login = new ApexFit_login(dbContext);
            Application.EnableVisualStyles();
            UserMainEntity user = login.TryLoginWithToken();
            if (user == null)
            {
                Application.Run(new ApexFit_login(dbContext));
            }
            else
            {
                Application.Run(new ApexFit_mainWindow(user, dbContext));
            }
        }
        
    }
}
