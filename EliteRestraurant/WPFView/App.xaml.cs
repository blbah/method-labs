using DAccessLayer;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFViewModel;

namespace WPFView
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider sp;

        public App()
        {
            var services = new ServiceCollection();
            services.RegisterDAL();
            services.RegisterBLL();
            services.AddScoped<MainViewModel>();
            sp = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow rw = new MainWindow();
            rw.DataContext = sp.GetService<MainViewModel>();
            rw.Show();
        }
    }
}
