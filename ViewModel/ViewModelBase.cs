namespace ViewModel
{
    public abstract class ViewModelBase
    {         
        public event EventHandler Closed;

        public bool IsClosed { get; set; }

        protected virtual bool OnClosing()
        {
            //BL
            return true;
        }
        public void Close()
        {
            if (!IsClosed && OnClosing())
            {
                IsClosed = true;                
                Closed?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}