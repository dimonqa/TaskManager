using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Model.States;
using ReactiveUI;

namespace Model.Domain
{
    public class MyTask : IDomainObject, INotifyPropertyChanged
    {        
        public MyTask() { }
        // Для EF
        public int Id { get; set; }

        private string _title;
        public string Title 
        {
            get { return _title; }
            set
            {           
                _title = value;
                OnPropertyChanged();
            }
        }
        public string Description { get; set; }
        public string? Executers { get; set; }
        public DateTime? DateReg { get; set; }        
        public TaskStates? State { get; set; }
        public int? PlanCost { get; set; }
        public int? FactTimeExecute { get; set; }
        public DateTime? DateEnd { get; set; }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public override string ToString() => Title;        

    }
}