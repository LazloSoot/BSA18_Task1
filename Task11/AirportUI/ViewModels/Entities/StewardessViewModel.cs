using AirportUI.Models.Entities;
using AirportUI.Models.Helpers;
using AirportUI.Models.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;

namespace AirportUI.ViewModels.Entities
{
    public class StewardessViewModel : EntityViewModel
    {
        private Stewardess _model;
        private Stewardess edittedModel;
        private INavigationService _navigationService;
        private ICrewingService crewingService;

        public StewardessViewModel(INavigationService navigationService,ICrewingService crewingService, IDialogService dialogService)
            :base(dialogService)
        {
            _model = new Stewardess();
            edittedModel = new Stewardess();
            _navigationService = navigationService;
            this.crewingService = crewingService;

            Title = "Stewardess Details";

            GoBackCommand = new RelayCommand(goBack);

            MessengerInstance.Register<Stewardess>(this, s =>
            {
                _model = s;
                edittedModel = s.Clone();
                RaisePropertyChanged(() => Name);
                RaisePropertyChanged(() => SurName);
                RaisePropertyChanged(() => BirthDate);
                RaisePropertyChanged(() => Id);
            });
        }

        public string Name
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

        public string SurName
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

        public long Id => _model.Id;

        public ICommand GoBackCommand { get; set; }

        protected async override void delete()
        {
            if (!await crewingService.TryDismissStewardessAsync(this._model.Id))
                await dialogService.ShowError("Remove failed", "Error", "ok", () => { });
            else
            {
                MessengerInstance.Send(TypeEnum.Stewardess);
                await dialogService.ShowMessage("Removing successful", "Success", "ok", () => { goBack(); });
            }
        }

        protected async override void save()
        {
            if (await crewingService.UpdateStewardessInfoAsync(this._model.Id, edittedModel) == null)
                await dialogService.ShowError("Update failed", "Error", "ok", () => { });
            else
            {
                MessengerInstance.Send(TypeEnum.Stewardess);
                await dialogService.ShowMessage("Update successful", "Success", "ok", () => { goBack(); });
            }
        }

        private void goBack()
        {
            _navigationService.GoBack();
        }
    }

}
