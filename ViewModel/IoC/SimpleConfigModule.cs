using Microsoft.SqlServer.Server;
using Model.DAL;
using Model.Domain;
using Ninject.Modules;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.IoC
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            // Соответствие репозитория           
            Bind<IRepository<MyTask>>().To<EFRepository<MyTask>>().InSingletonScope();

            Bind<MainViewModel>().ToSelf().InSingletonScope();
            Bind<EditeViewModel>().ToSelf().InSingletonScope();
            Bind<CreateNewViewModel>().ToSelf().InSingletonScope();

        }
    }
}
