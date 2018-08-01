using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportUI.ViewModels
{
    //public class MainViewModel : BaseViewModel
    //{
    //    private INavigationService _navigationService;
    //    private string selectedPageName;

    //    public MainViewModel(INavigationService navigationService)
    //    {
    //        _navigationService = navigationService;

    //        Title = "Main";
    //        GetPilots = new RelayCommand(getPilots);
    //        Pilots = new ObservableCollection<Pilot>();
    //        getPilots();
    //    }

    //    public string SelectedPageName
    //    {
    //        get { return selectedPageName; }
    //        set
    //        {
    //            selectedPageName = value;

    //            switch (selectedPageName)
    //            {
    //                case ("crewing"):
    //                    {
    //                        _navigationService.NavigateTo(nameof(PilotViewModel));
    //                        break;
    //                    }
    //                case ("aircraft"):
    //                    {
    //                        break;
    //                    }
    //                case ("fligts"):
    //                    {
    //                        break;
    //                    }
    //                default:
    //                    break;
    //            }
    //            if (selectedPilot != null)
    //            {
    //                MessengerInstance.Send(selectedPilot);
    //                _navigationService.NavigateTo(nameof(PilotViewModel));
    //            }

    //            RaisePropertyChanged(() => SelectedPilot);
    //        }
    //    }
    //}
}
