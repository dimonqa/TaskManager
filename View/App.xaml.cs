using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using ViewModel.IoC;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Вью менеджер подписывается на события вьюмодели
            ViewModelManager.Instance.ViewModelShow += ViewManager.ViewShow;
            ViewModelManager.Instance.ViewModelClose += ViewManager.ViewClose;
            ViewModelManager.Instance.ShowMessage += ViewManager.ShowMessageUI;

            // Инициализируем IoC - контейнер
            var ninjectKernel = new StandardKernel(new SimpleConfigModule());

            var mainViewModel = ninjectKernel.Get<MainViewModel>();

            ViewModelManager.Instance.OnViewModelShow(mainViewModel);

        }
    }
}
