using AirportUI.Models.Entities;
using AirportUI.Models.Helpers;
using AirportUI.Models.Interfaces;
using AirportUI.ViewModels.Entities;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirportUI.ViewModels
{
    public class CrewingServiceViewModel : BaseViewModel
    {
        private ICrewingService crewingService;
        private INavigationService _navigationService;
        private Pilot selectedPilot;
        private Stewardess selectedStewardess;
        private Crew selectedCrew;

        public CrewingServiceViewModel(INavigationService navigationService, ICrewingService crewingService, IDialogService dialogService)
            :base(dialogService)
        {
            this.crewingService = crewingService;
            _navigationService = navigationService;

            Title = "Crewing service";
            GetPilots = new RelayCommand(getPilots);
            Pilots = new ObservableCollection<Pilot>();
            getPilots();

            GetStewardesses = new RelayCommand(getStewardesses);
            Stewardesses = new ObservableCollection<Stewardess>();
            getStewardesses();

            GetCrews = new RelayCommand(getCrews);
            Crews = new ObservableCollection<Crew>();
            getCrews();

            AddPilot = new RelayCommand(addPilot);
            AddStewardess = new RelayCommand(addStewardess);
            AddCrew = new RelayCommand(addCrew);

            MessengerInstance.Register<TypeEnum>(this, type =>
            {
                switch (type)
                {
                    case TypeEnum.Pilot:
                        getPilots();
                        break;
                    case TypeEnum.Stewardess:
                        getStewardesses();
                        break;
                    case TypeEnum.Crew:
                        getCrews();
                        break;
                    default:
                        break;
                }
            });
        }

        public ObservableCollection<Pilot> Pilots { get; private set; }

        public ObservableCollection<Stewardess> Stewardesses { get; private set; }

        public ObservableCollection<Crew> Crews { get; private set; }

        public Pilot SelectedPilot
        {
            get { return selectedPilot; }
            set
            {
                selectedPilot = value;
                if (selectedPilot != null)
                {
                    _navigationService.NavigateTo(nameof(PilotViewModel));
                    MessengerInstance.Send(selectedPilot);
                }

                RaisePropertyChanged(() => SelectedPilot);
            }
        }

        public Stewardess SelectedStewardess
        {
            get { return selectedStewardess; }
            set
            {
                selectedStewardess = value;
                if (selectedStewardess != null)
                {
                    _navigationService.NavigateTo(nameof(StewardessViewModel));
                    MessengerInstance.Send(selectedStewardess);
                }

                RaisePropertyChanged(() => SelectedStewardess);
            }
        }

        public Crew SelectedCrew
        {
            get { return selectedCrew; }
            set
            {
                selectedCrew = value;
                if (selectedCrew != null)
                {
                    _navigationService.NavigateTo(nameof(CrewViewModel));
                    MessengerInstance.Send(selectedCrew);
                }

                RaisePropertyChanged(() => SelectedCrew);
            }
        }

        public ICommand GetPilots { get; set; }

        public ICommand GetStewardesses { get; set; }

        public ICommand GetCrews { get; set; }

        public ICommand AddCrew { get; set; }

        public ICommand AddPilot { get; set; }

        public ICommand AddStewardess { get; set; }

        private async void getPilots()
        {
            Pilots.Clear();
            foreach (var item in await crewingService.GetAllPilotsInfoAsync(default(CancellationToken)))
            {
                Pilots.Add(item);
            }
        }

        private async void getStewardesses()
        {
            Stewardesses.Clear();
            foreach (var item in await crewingService.GetAllStewardessesInfoAsync(default(CancellationToken)))
            {
                Stewardesses.Add(item);
            }
        }

        private async void getCrews()
        {
            Crews.Clear();
            foreach (var item in await crewingService.GetAllCrewsInfoAsync(default(CancellationToken)))
            {
                Crews.Add(item);
            }
        }

        private void addPilot()
        {
            
                selectedPilot = null;
                    _navigationService.NavigateTo(nameof(PilotViewModel));
                    MessengerInstance.Send(default(object));

                RaisePropertyChanged(() => SelectedPilot);

        }

        private void addStewardess()
        {

            selectedStewardess = null;
            _navigationService.NavigateTo(nameof(StewardessViewModel));
            MessengerInstance.Send(default(object));

            RaisePropertyChanged(() => SelectedStewardess);

        }

        private void addCrew()
        {

            selectedCrew = null;
            _navigationService.NavigateTo(nameof(CrewViewModel));
            MessengerInstance.Send(default(object));

            RaisePropertyChanged(() => SelectedCrew);

        }
    }
}
