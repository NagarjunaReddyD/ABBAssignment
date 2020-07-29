using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using BLBookStore;
using DLBookStore;
using InterfaceBookStore;

namespace TwinkleBookStore
{

   
    static class Program
    {
        public static IUnityContainer container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           

          

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new FrmLogin());
        }
        public static void Bootstrap()
        {

            // Create the container as usual.
            container = new UnityContainer();

            // Register your types, for instance:
            container.RegisterType<BLLogin>();
            container.RegisterType<ILogin, DLLogin>();
            container.RegisterType<BLRole>();
            container.RegisterType<IRole, DLRole>();
            container.RegisterType<BLUserRole>();
            container.RegisterType<IUserRole, DLUserRole>();
            container.RegisterType<BLItem>();
            container.RegisterType<IItem, DLItem>();
            container.RegisterType<BLUserItem>();
            container.RegisterType<IUserItem, DLUserItem>();
            // Optionally verify the container.

        }
    }
}
