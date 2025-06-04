using Model.States;
using Model.DAL;
using Model.Domain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class CreateNewViewModel : ViewModelBase
    {
        public ICommand AddTask { get; private set; }
        public ICommand CloseWindow { get; private set; }
        
        private IRepository<MyTask> _repository { get; }        

        public ViewModelBase ParentViewModel { get; set; }

        #region Свойства для привязки
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Executers { get; set; }
        public DateTime? DateReg { get; set; }
        public TaskStates? State { get; set; }
        public int? PlanCost { get; set; }
        public int? FactTimeExecute { get; set; }
        public DateTime? DateEnd { get; set; }

        #endregion


        // для IoC
        public CreateNewViewModel(IRepository<MyTask> repo)
        {
            _repository = repo;
  
            AddTask = new MyCommand(Add);
            CloseWindow = new MyCommand(Close);
        }

        
        void Add(object obj)
        {
            MyTask task = new MyTask()
            {
                Title = this.Title,
                Description = this.Description,
                State = TaskStates.Назначена,   // Кодим на русском :)
                Executers = this.Executers,                
                DateReg = DateTime.Today.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second),
                PlanCost = this.PlanCost              
            };

            if (ParentViewModel is MainViewModel mainViewModel)
            {
                _repository.Add(task);

                mainViewModel.Tasks.Add(task);

                // Это не работает, ровно также как и mainViewModel.SelectedTask = task
                mainViewModel.SelectedTask = mainViewModel.Tasks.Last();

                // После добавления новой задачи
                // Очистим текущие значения, чтобы 
                // после повторного добавления эти значения
                // не передавались вновь на контролы
                // так как у нас все вью моедил в единственном
                // экземпляре Singleton, создаются один раз
                // с помощью IoC
                ClearCurrValues();

                ViewModelManager.Instance.OnWindowClose(this);
            }                    
        }

        private void ClearCurrValues()
        {
            Title = null;
            Description = null;
            State = null;
            Executers = null;
            DateReg = null;
            PlanCost = null;           
        }

        void Close(object obj)
        {
            ViewModelManager.Instance.OnWindowClose(this);
        }

    }
}
