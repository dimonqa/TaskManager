using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData;
using Model.DAL;
using Model.Domain;
using Model.States;

namespace ViewModel
{
    // Вью моедь для редактирования задач
    public class EditeViewModel : ViewModelBase 
    {
        public ICommand SaveChanges { get; private set; }
        public ICommand CloseWindow { get; private set; }
        public ViewModelBase ParentViewModel { get; set; }

        public int Id { get; set; }

        #region Свойства для привязки
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Executers { get; set; }
        public DateTime? DateReg { get; set; }
        public TaskStates? State { get; set; }
        public int? PlanCost { get; set; }
        public int? FactTimeExecute { get; set; } 
        public DateTime? DateEnd { get; set; }

        #endregion

        private IRepository<MyTask> _repository { get; }

        // для IoC
        public EditeViewModel(IRepository<MyTask> repo)
        {
            _repository = repo;

            SaveChanges = new MyCommand(Save);
            CloseWindow = new MyCommand(Close);
        }

        public void InitEditTaskProps(MyTask task)
        {
            Id = task.Id;
            Title = task.Title;
            Description = task.Description;
            Executers = task.Executers;
            State = task.State;
            DateReg = task.DateReg;
            PlanCost = task.PlanCost;
            FactTimeExecute = task.FactTimeExecute;
            DateEnd = task.DateEnd;
        }

        
        void Save(object obj)
        {
            MyTask task = new MyTask() 
            { 
                Id = this.Id, 
                Title = this.Title, 
                Description = this.Description,
                Executers = this.Executers,
                PlanCost = this.PlanCost,
                State = this.State,
                DateReg = this.DateReg
            };

            if (ParentViewModel is MainViewModel mainViewModel)
            {
                _repository.Update(task);

                mainViewModel.Tasks.Replace(mainViewModel.SelectedTask, task);

                mainViewModel.SelectedTask = task;

                ViewModelManager.Instance.OnWindowClose(this);
            }
        }

        void Close(object obj)
        {
            ViewModelManager.Instance.OnWindowClose(this);
        }
    }
}
