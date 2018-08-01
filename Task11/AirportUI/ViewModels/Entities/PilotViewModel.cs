using AirportUI.Models.Entities;
using AirportUI.Models.Helpers;
using AirportUI.Models.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;

namespace AirportUI.ViewModels.Entities
{
    public class PilotViewModel : EntityViewModel
    {
        private Pilot _model;
        private Pilot edittedModel;
        private INavigationService _navigationService;
        private ICrewingService crewingService;

        public PilotViewModel(INavigationService navigationService, ICrewingService crewingService,IDialogService dialogService)
            :base(dialogService)
        {
            _model = new Pilot();
            edittedModel = new Pilot();
            _navigationService = navigationService;
            this.crewingService = crewingService;

            Title = "Pilot Details";

            GoBackCommand = new RelayCommand(goBack);

            MessengerInstance.Register<Pilot>(this, pilot =>
            {
                _model = pilot != null ?  pilot : new Pilot();
                edittedModel = pilot != null ? pilot.Copy() : new Pilot();
                Mode = pilot == null ? "Add" : "Save";
                RaisePropertyChanged(() => FirstName);
                RaisePropertyChanged(() => LastName);
                RaisePropertyChanged(() => BirthDate);
                RaisePropertyChanged(() => Id);
                RaisePropertyChanged(() => Exp);
            });
        }

        public string Mode { get; private set; } = "Add";
        public string FirstName
        {
            get
            {
                return _model.FirstName;
            }
            set
            {
                this.edittedModel.FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _model.LastName;
            }
            set
            {
                this.edittedModel.LastName = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _model.BirthDate;
            }
            set
            {
                this.edittedModel.BirthDate = value;
            }
        }

        public int Exp
        {
            get
            {
                return _model.Exp;
            }
            set
            {
                this.edittedModel.Exp = value;
            }
        }
        

        public long Id => _model.Id;

        public ICommand GoBackCommand { get; set; }

        protected async override void delete()
        {
            if (!await crewingService.TryDismissPilotAsync(this.Id))
                await dialogService.ShowError("Remove failed", "Error", "ok", () => { });
            else
            {
                MessengerInstance.Send(TypeEnum.Pilot);
                await dialogService.ShowMessage("Removing successful", "Success", "ok", () => { goBack(); });
            }
        }

        protected async override void save()
        {
            if (await crewingService.UpdatePilotInfoAsync(this._model.Id, edittedModel) == null)
                await dialogService.ShowError("Update failed", "Error", "ok", () => { });
            else
            {
                MessengerInstance.Send(TypeEnum.Pilot);
                await dialogService.ShowMessage("Update successful", "Success", "ok", () => { goBack(); });
            }
        }

        private void goBack()
        {
            _navigationService.GoBack();
        }
    }
}
