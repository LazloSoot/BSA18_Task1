using AirportUI.Models.Entities;
using AirportUI.Models.Helpers;
using AirportUI.Models.Interfaces;
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
    public class CrewViewModel : EntityViewModel
    {
        private Crew _model;
        private Crew edittedModel;
        private INavigationService _navigationService;
        private ICrewingService crewingService;

        public CrewViewModel(INavigationService navigationService, ICrewingService crewingService, IDialogService dialogService)
            :base(dialogService)
        {
            _model = new Crew();
            edittedModel = new Crew();
            _navigationService = navigationService;
            this.crewingService = crewingService;

            Title = "Crew Details";

            GoBackCommand = new RelayCommand(goBack);

            MessengerInstance.Register<Crew>(this, crew =>
            {
                _model = crew;
                edittedModel = crew.Clone();
                RaisePropertyChanged(() => Pilot);
                RaisePropertyChanged(() => Stewardesses);
            });
        }

        public long Pilot
        {
            get => _model.Pilot;
            set => edittedModel.Pilot = value;
        }

        public IEnumerable<long> Stewardesses
        {
            get => _model.Stewardesses;
            set
            {
                if (value != null && value.Count() > 1)
                    edittedModel.Stewardesses = value;
                else
                    dialogService.ShowError("Update failed, value can not be null and stewardess count have to be greater than 1", "Error", "ok", () => { });
            }
        }
        public long Id => _model.Id;

        public ICommand GoBackCommand { get; set; }

        protected async override void delete()
        {
            if (!await crewingService.TryDeleteCrewAsync(this._model.Id))
                await dialogService.ShowError("Remove failed", "Error", "ok", () => { });
            else
            {
                MessengerInstance.Send(TypeEnum.Crew);
                await dialogService.ShowMessage("Removing successful", "Success", "ok", () => { goBack(); });
            }
        }

        protected async override void save()
        {
            if (await crewingService.ReformCrewAsync(this._model.Id, edittedModel) == null)
                await dialogService.ShowError("Update failed", "Error", "ok", () => { });
            else
            {
                MessengerInstance.Send(TypeEnum.Crew);
                await dialogService.ShowMessage("Update successful", "Success", "ok", () => { goBack(); });
            }
        }

        private void goBack()
        {
            _navigationService.GoBack();
        }
    }
}
