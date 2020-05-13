using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hardware_Store_Project
{    public struct User
     {
    public string login;
    public string password;
    public string type;
     }
    static class Program
    {
        public static WTFTutorial2Entities6 wftDb = new WTFTutorial2Entities6();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAutohorization());
            
        }
    }
}
