using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace AirportUI.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        protected IDialogService dialogService;
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public BaseViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public ICommand ShowInfoMessageCommand { get; set; }

        public ICommand ShowErrorMessageCommand { get; set; }
        

    }
}
