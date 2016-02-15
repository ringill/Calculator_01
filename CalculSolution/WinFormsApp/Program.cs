using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinFu.IoC;
using Logger.Abstract;
using Logger.Concrete;
using Microsoft.Practices.Unity;

namespace WinFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region LinFu
            
            //создаем LinFu IoC контейнер
            var container = new ServiceContainer();
            //настраиваем контейнер
            container.LoadFrom(AppDomain.CurrentDomain.BaseDirectory, "Logger.dll");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Для хранилища SQL Server
            Application.Run(new Form1(container.GetService<ISqlRepository>()));

            //Для хранилища XML файл
            //Application.Run(new Form1(container.GetService<IXmlRepository>()));

            #endregion

            #region Unity

            ////создаем IoC Unity
            //IUnityContainer container = new UnityContainer();
            
            ////Для хранилища SQL Server
            //container.RegisterType(typeof(IRepository), typeof(EFRepository));
            
            ////Для хранилища XML файл
            //container.RegisterType(typeof(IRepository), typeof(XmlRepository));

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(container.Resolve<Form1>());

            #endregion
        }
    }

    
}
