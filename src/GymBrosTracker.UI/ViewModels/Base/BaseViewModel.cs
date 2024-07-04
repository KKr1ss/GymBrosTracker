using System.ComponentModel;

namespace GymBrosTracker.UI.ViewModels.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
    //public abstract class ViewModelBase : INotifyPropertyChanged
    //{
    //    //#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.
    //    //#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    //    //        public event PropertyChangedEventHandler PropertyChanged;
    //    //#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    //    //#pragma warning restore CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.
    //    //        protected virtual void OnPropertyChanged(string propertyName)
    //    //        {
    //    //            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    //        }
    //}
}
