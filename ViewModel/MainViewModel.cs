using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData;
using DynamicData.Binding;
using Model.DAL;
using Model.Domain;
using Model.States;
using Ninject;
using ViewModel.IoC;

namespace ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // Инициализируем IoC - контейнер здесь
        // потому что все дочерние вьюмодели будут инициализироваться отсюда
        // в связи с тем, что все изменения в базе будут производится с помощью
        // дочерних окон, их вью модели должны знать о репозитории,
        // а так как репозиторий создется IoC-контейнером в синглтоне
        // то принятно решенеие: запихивать в каждую создаваемую вью модель
        // репозиторий с помощью IoC-контейнера
        StandardKernel ninjectKernel = new StandardKernel(new SimpleConfigModule());

        private IRepository<MyTask> _repository { get; }

        public ObservableCollection<MyTask> Tasks { get; set; } = new ObservableCollection<MyTask> { };
        

        public MyTask SelectedTask { get; set; }
        public MainViewModel(IRepository<MyTask> repo)
        {
            _repository = repo;
            InitObserveTasks();
            SelectedTask = Tasks.FirstOrDefault();
        }               

        public void InitObserveTasks()
        {
            var TasksFromDB = _repository.GetAll();
            
            foreach (var task in TasksFromDB)
            {
                Tasks.Add(task);
            }
        }


        public MyCommand CreateNew
        {
            get
            {
                return
                    new MyCommand(_ =>
                    {
                        // Получим дочернюю вью модель с помощью IoC (и получим репозиторий)
                        var createNewViewModel = ninjectKernel.Get<CreateNewViewModel>();

                        // подсунем дочерней вью модеи родительскую
                        // чтобы она добавила в Tasks новую задачу 
                        // и на UI перересовалась стек панель
                        createNewViewModel.ParentViewModel = this;

                        ViewModelManager.Instance.OnViewModelShow(createNewViewModel);
                    }
                    );
            }
        }

        public MyCommand OpenEdite
        {
            get
            {
                return
                    new MyCommand(_ => 
                        {
                            // Получим дочернюю вью модель с помощью IoC (и получим репозиторий)
                            var editeViewModel = ninjectKernel.Get<EditeViewModel>();

                            // Инициализируем в дочерней вью модели редактируемую задачу
                            editeViewModel.InitEditTaskProps(SelectedTask);
                        
                            editeViewModel.ParentViewModel = this;

                            ViewModelManager.Instance.OnViewModelShow(editeViewModel);

                            // new ChildViewModel(SelectedTask);                            
                            // TODO CloneHelper 1:57 Видео № 22                           
                        }
                    );
            }
        }
        
        public MyCommand DeleteTask
        {
            get
            {
                return
                    new MyCommand(_ =>
                    {
                        _repository.Delete(SelectedTask);

                        Tasks.Remove(SelectedTask);

                        // Кинем ивент на UI чтобы отобразить пользователю
                        // об успешном выполнении операции
                        ViewModelManager.Instance.OnShowMessage("Задача успешно удалена!");
                    }
                    );
            }
        }
        public MyCommand SetStateInProgress
        {
            get
            {
                return
                    new MyCommand(_ =>
                    {
                        SelectedTask.State = TaskStates.Выполняется;

                        _repository.Update(SelectedTask);                        

                        // Кинем ивент на UI чтобы отобразить пользователю
                        // об успешном выполнении операции
                        ViewModelManager.Instance.OnShowMessage("Задача принята в работу!");
                    }
                    );
            }
        }
        public MyCommand SetStateStopped
        {
            get
            {
                return
                    new MyCommand(_ =>
                    {
                        SelectedTask.State = TaskStates.Приостановлена;

                        _repository.Update(SelectedTask);

                        // Кинем ивент на UI чтобы отобразить пользователю
                        // об успешном выполнении операции
                        ViewModelManager.Instance.OnShowMessage("Выполнение задачи приостановлено!");
                    }
                    );
            }
        }
        public MyCommand SetStateCompleted
        {
            get
            {
                return
                    new MyCommand(_ =>
                    {
                        switch (SelectedTask.State)
                        {
                            case TaskStates.Выполняется or TaskStates.Приостановлена:
                                SelectedTask.State = TaskStates.Завершена;
                                SelectedTask.DateEnd =
                                            DateTime.Today.AddHours(DateTime.Now.Hour)
                                            .AddMinutes(DateTime.Now.Minute)
                                            .AddSeconds(DateTime.Now.Second);
                                _repository.Update(SelectedTask);
                                ViewModelManager.Instance.OnShowMessage("Задача успешно выполнена!");
                                break;
                            default:
                                ViewModelManager.Instance.OnShowMessage("Задача не может быть выполнена!");
                                break;
                        }               

                    }
                    );
            }
        }
    }
}
