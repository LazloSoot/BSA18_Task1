using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportUI.Models;
using AirportUI.Models.Interfaces;
using AirportUI.ViewModels;
using AirportUI.ViewModels.Entities;
using AirportUI.Views;
using AirportUI.Views.Entities;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace AirportUI
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            // ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var navigationService = new NavigationService();
      //      navigationService.Configure(nameof(AircraftServiceViewModel), typeof(AircraftServiceView));
            navigationService.Configure(nameof(CrewingServiceViewModel), typeof(CrewingServiceView));
      //      navigationService.Configure(nameof(FlightOperationsServiceViewModel), typeof(FlightOperationsServiceView));

            navigationService.Configure(nameof(CrewViewModel), typeof(CrewView));
            navigationService.Configure(nameof(PilotViewModel), typeof(PilotView));
            navigationService.Configure(nameof(StewardessViewModel), typeof(StewardessView));

    //        navigationService.Configure(nameof(FlightViewModel), typeof(FlightView));
            //navigationService.Configure(nameof(DepartureViewModel), typeof(DepartureView));
            //navigationService.Configure(nameof(TicketViewModel), typeof(TicketView));

            //navigationService.Configure(nameof(PlaneTypeViewModel), typeof(PlaneTypeView));
            //navigationService.Configure(nameof(PlaneViewModel), typeof(PlaneView));

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            //Register your services used here
            //SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();
            SimpleIoc.Default.Register<ICrewingService, CrewingService>();
            //SimpleIoc.Default.Register<IAircraftService, AircraftService>();
            //SimpleIoc.Default.Register<IFlightOperationsService, FlightOperationsService>();

            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
  //          SimpleIoc.Default.Register<AircraftServiceViewModel>();
            SimpleIoc.Default.Register<CrewingServiceViewModel>();
 //           SimpleIoc.Default.Register<FlightOperationsServiceViewModel>();

            SimpleIoc.Default.Register<CrewViewModel>();
            SimpleIoc.Default.Register<PilotViewModel>();
            SimpleIoc.Default.Register<StewardessViewModel>();

            //SimpleIoc.Default.Register<FlightViewModel>();
            //SimpleIoc.Default.Register<DepartureViewModel>();
            //SimpleIoc.Default.Register<TicketViewModel>();

            //SimpleIoc.Default.Register<PlaneTypeViewModel>();
            //SimpleIoc.Default.Register<PlaneViewModel>();
        }

        #region Crewing 

        public CrewingServiceViewModel CrewingVMInstance
        {
            get
            {
                return SimpleIoc.Default.GetInstance<CrewingServiceViewModel>();
            }
        }

        public PilotViewModel PilotVMInstance
        {
            get
            {
                return SimpleIoc.Default.GetInstance<PilotViewModel>();
            }
        }

        public StewardessViewModel StewardessVMInstance
        {
            get
            {
                return SimpleIoc.Default.GetInstance<StewardessViewModel>();
            }
        }

        public CrewViewModel CrewVMInstance
        {
            get
            {
                return SimpleIoc.Default.GetInstance<CrewViewModel>();
            }
        }

        #endregion Crewing

        //#region FlightOperaions

        //public FlightOperationsServiceViewModel FlightOperationsVMInstance
        //{
        //    get
        //    {
        //        return SimpleIoc.Default.GetInstance<FlightOperationsServiceViewModel>();
        //    }
        //}

        //public FlightViewModel FlightVMInstance
        //{
        //    get
        //    {
        //        return SimpleIoc.Default.GetInstance<FlightViewModel>();
        //    }
        //}

        //public DepartureViewModel DepartureVMInstance
        //{
        //    get
        //    {
        //        return SimpleIoc.Default.GetInstance<DepartureViewModel>();
        //    }
        //}

        //public TicketViewModel TicketVMInstance
        //{
        //    get
        //    {
        //        return SimpleIoc.Default.GetInstance<TicketViewModel>();
        //    }
        //}

        //#endregion FligtOperations

        //#region Aircraft

        //public AircraftServiceViewModel AircraftVMInstance
        //{
        //    get
        //    {
        //        return SimpleIoc.Default.GetInstance<AircraftServiceViewModel>();
        //    }
        //}

        //public PlaneViewModel PlaneVMInstance
        //{
        //    get
        //    {
        //        return SimpleIoc.Default.GetInstance<PlaneViewModel>();
        //    }
        //}

        //public PlaneTypeViewModel PlaneTypeVMInstance
        //{
        //    get
        //    {
        //        return SimpleIoc.Default.GetInstance<PlaneTypeViewModel>();
        //    }
        //}

        //#endregion

        // <summary>
        // The cleanup.
        // </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
