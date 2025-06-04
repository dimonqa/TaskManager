using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain;

namespace ViewModel
{
    public class ViewModelManager
    {
        // SingleTon
        private ViewModelManager() { }
        private static ViewModelManager _instance = new ViewModelManager(); 

        public static ViewModelManager Instance
        {
            get { return _instance; }   
        }

        #region Событие показа вью моделей
        public delegate void ViewModelShowDelegate(ViewModelBase viewModel);
        
        public event ViewModelShowDelegate ViewModelShow;

        public void OnViewModelShow(ViewModelBase viewModel)
        {
            ViewModelShow?.Invoke(viewModel);
        }
        #endregion

        #region Событие сохранения изменений
        public delegate void SaveChangesDelegate(MyTask task);

        public event SaveChangesDelegate SaveChanges;

        public void OnSaveChanges(MyTask task)
        {
            SaveChanges?.Invoke(task);
        }
        #endregion

        #region Событие закрытия окна
        public delegate void CloseDelegate(ViewModelBase viewModel);

        public event CloseDelegate ViewModelClose;

        public void OnWindowClose(ViewModelBase viewModel)
        {
            ViewModelClose?.Invoke(viewModel);
        }
        #endregion

        #region Событие показа сообщения
        public delegate void ShowMessageDelegate(string message);

        public event ShowMessageDelegate ShowMessage;

        public void OnShowMessage(string message)
        {
            ShowMessage?.Invoke(message);
        }
        #endregion
    }
}
