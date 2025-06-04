using Model.Domain;
using Model.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using ViewModel;

namespace View.CustomControls
{
    public class TaskProps : Control
    {
        
        #region TitleText
        // Зависимое свойство
        public static DependencyProperty? TitleTextProperty = 
            DependencyProperty.Register("TitleText", 
                typeof(string), 
                typeof(TaskProps)                
                );
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }
        #endregion

        #region DescriptionText
        // Зависимое свойство
        public static DependencyProperty? DescriptionTextProperty =
            DependencyProperty.Register("DescriptionText",
                typeof(string),
                typeof(TaskProps)                
                );
        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }
        #endregion

        #region ExecutersText
        // Зависимое свойство
        public static DependencyProperty? ExecutersTextProperty =
            DependencyProperty.Register("ExecutersText",
                typeof(string),
                typeof(TaskProps)                
                );
        public string ExecutersText
        {
            get { return (string)GetValue(ExecutersTextProperty); }
            set { SetValue(ExecutersTextProperty, value); }
        }
        #endregion

        #region DateReg
        // Зависимое свойство
        public static DependencyProperty? DateRegProperty =
            DependencyProperty.Register("DateReg",
                typeof(DateTime),
                typeof(TaskProps)                
                );
        public DateTime DateReg
        {
            get { return (DateTime)GetValue(DateRegProperty); }
            set { SetValue(DateRegProperty, value); }
        }
        #endregion

        #region State
        // Зависимое свойство
        public static DependencyProperty? StateProperty =
            DependencyProperty.Register("State",
                typeof(TaskStates),
                typeof(TaskProps)
                );
        public TaskStates State
        {
            get { return (TaskStates)GetValue(DateRegProperty); }
            set { SetValue(DateRegProperty, value); }
        }
        #endregion

        #region PlanCost
        // Зависимое свойство
        public static DependencyProperty? PlanCostProperty =
            DependencyProperty.Register("PlanCost",
                typeof(int),
                typeof(TaskProps)
                );
        public int PlanCost
        {
            get { return (int)GetValue(PlanCostProperty); }
            set { SetValue(PlanCostProperty, value); }
        }
        #endregion

        #region FactTimeExecute
        // Зависимое свойство
        public static DependencyProperty? FactTimeExecuteProperty =
            DependencyProperty.Register("FactTimeExecute",
                typeof(int),
                typeof(TaskProps)
                );
        public int FactTimeExecute
        {
            get { return (int)GetValue(FactTimeExecuteProperty); }
            set { SetValue(FactTimeExecuteProperty, value); }
        }
        #endregion

        #region DateEnd
        // Зависимое свойство
        public static DependencyProperty? DateEndProperty =
            DependencyProperty.Register("DateEnd",
                typeof(DateTime),
                typeof(TaskProps)
                );
        public DateTime DateEnd
        {
            get { return (DateTime)GetValue(DateEndProperty); }
            set { SetValue(DateEndProperty, value); }
        }
        #endregion

        #region FirstButtonCommand
        public static readonly DependencyProperty FirstButtonCommandProperty =
            DependencyProperty.Register(
                "FirstButtonCommand",
                typeof(ICommand),
                typeof(TaskProps));
        public ICommand FirstButtonCommand
        {
            get { return (ICommand)GetValue(FirstButtonCommandProperty); }
            set { SetValue(FirstButtonCommandProperty, value); }
        }
        #endregion

        #region SecondButtonCommand
        public static readonly DependencyProperty SecondButtonCommandProperty =
            DependencyProperty.Register(
                "SecondButtonCommand",
                typeof(ICommand),
                typeof(TaskProps));
        public ICommand SecondButtonCommand
        {
            get { return (ICommand)GetValue(SecondButtonCommandProperty); }
            set { SetValue(SecondButtonCommandProperty, value); }
        }
        #endregion

        static TaskProps()
        {
            DefaultStyleKeyProperty.OverrideMetadata
                (typeof(TaskProps), new System.Windows.FrameworkPropertyMetadata(typeof(TaskProps)));            
        }
       
        public override void OnApplyTemplate()
        {     
            
            base.OnApplyTemplate();
        }
    }
}
