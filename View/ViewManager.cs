using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ViewModel;

namespace View
{
    public class ViewManager
    {
        // Справочник соответствия
        private static readonly Dictionary<Type, Type> mapping = new Dictionary<Type, Type>
        {
            {typeof(MainViewModel), typeof(MainWindow) },
            {typeof(EditeViewModel), typeof(EditeWindow) },
            {typeof(CreateNewViewModel), typeof(CreateNewWindow) },
        };

        // Справочник открытых вью моделей и вьюх
        private static readonly Dictionary<ViewModelBase, Window> openViewModel
            = new Dictionary<ViewModelBase, Window>();
         
        public static void ViewShow(ViewModelBase viewModel)
        {
            //todo
            if (openViewModel.ContainsKey(viewModel))
            {
                MessageBox.Show("Нельзя!!!");
            }

            Type typeViewModel = viewModel.GetType();


            if (mapping.ContainsKey(typeViewModel))
            {
                Type typeView = mapping[typeViewModel];

                Window window = (Window)Activator.CreateInstance(typeView); // new ChildWindow

                window.DataContext = viewModel;
                window.Show();

                openViewModel.Add(viewModel, window);
            }
        }

        public static void ViewClose(ViewModelBase viewModel)
        {
            // Найдем соответствющее нашей вью модели окно
            if(openViewModel.ContainsKey(viewModel))
            {

                Window window = openViewModel[viewModel];

                // Благочестиво попоросим диспетчер закрыть наше окно
                Dispatcher disp = Dispatcher.CurrentDispatcher;

                disp.BeginInvoke(() => {
                                        window.Close();
                                        // А также удалим из справочнка нашу 
                                        // запись об открытом окне
                                        openViewModel.Remove(viewModel);
                                        });               
            }
        }

        public static void ShowMessageUI(string message)
        {
            MessageBox.Show(message);
        }
    }
}

