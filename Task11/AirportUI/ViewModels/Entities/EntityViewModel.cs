using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirportUI.ViewModels.Entities
{
    public abstract class EntityViewModel : BaseViewModel
    {
        public EntityViewModel(IDialogService dialogService)
            :base(dialogService)
        {
            DeleteCommand = new RelayCommand(delete);
            SaveCommand = new RelayCommand(save);
        }

        public event EventHandler OnDelete;

        public ICommand DeleteCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        protected abstract void delete();

        protected abstract void save();
    }
}
