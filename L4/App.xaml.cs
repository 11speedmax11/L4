using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;

namespace L4
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IContainer container;
        private void RegisterType()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SaveFile>().As<ISaveFile>();
            builder.RegisterType<MainWindow>();
            builder.RegisterType<DataProcessing>().As<IDataProcessing>();
            builder.RegisterType<AddElement>();
            builder.RegisterType<MainWindow>();
            container = builder.Build();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            RegisterType();
            container.Resolve<MainWindow>();
            container.Resolve<AddElement>();
        }
    }
}
