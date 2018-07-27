import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//import { ROOT_URL, aicraft_URL, airport_URL, crewing_URL, flightOp_URL } from './models/config';
import { CrewingComponent } from './components/crewing/crewing.component';
import { CrewListComponent } from './components/crewing/crews/crew-list.component';
import { CrewItemComponent } from './components/crewing/crews/crew-item.component';
import { PilotsComponent } from './components/crewing/pilots/pilots.component';
import { PilotItemComponent } from './components/crewing/pilots/pilot-item.component';
import { StewardessesComponent } from './components/crewing/stewardesses/stewardesses.component';
import { StewardessItemComponent } from './components/crewing/stewardesses/stewardess-item.component';

import { AirportComponent } from './components/airport/airport.component';

import { AircraftComponent } from './components/aircraft/aircraft.component';
import { PlanesComponent } from './components/aircraft/planes/planes.component';
import { PlaneItemComponent } from './components/aircraft/planes/plane-item.component';
import { PlaneTypesComponent } from './components/aircraft/plane-types/plane-types.component';
import { PlaneTypeItemComponent } from './components/aircraft/plane-types/plane-type-item.component';

import { FlightsComponent } from './components/flightOperations/flights/flights.component';
import { FlightComponent } from './components/flightOperations/flight/flight.component';
import { DeparturesComponent } from './components/flightOperations/departures/departures.component';
import { DepartureComponent } from './components/flightOperations/departure/departure.component';
import { TicketsComponent } from './components/flightOperations/tickets/tickets.component';
import { TicketComponent } from './components/flightOperations/ticket/ticket.component';

const routes: Routes = [
  {
    path: '',
    component: AirportComponent
  },
  {
    path: 'crews',
    component: CrewingComponent,
    children: [
      {
        path:'',
        component: CrewListComponent
      },
      {
        path: 'pilots',
        pathMatch: 'full',
        component: PilotsComponent
      },
      {
        path: 'pilots/:id',
        pathMatch: 'full',
        component: PilotItemComponent
      },
      {
        path: 'stewardesses',
        pathMatch: 'full',
        component: StewardessesComponent
      },
      {
        path: 'stewardesses/:id',
        pathMatch: 'full',
        component: StewardessItemComponent
      },
      {
        path:':id',
        component: CrewItemComponent
      }]
  },
  {
    path: 'flights',
    component: FlightsComponent,
    children: [
      {
        path: 'departures',
        pathMatch: 'full',
        component: DeparturesComponent
      },
      {
        path: 'departures/:id',
        pathMatch: 'full',
        component: DepartureComponent
      },
      {
        path: 'tickets',
        pathMatch: 'full',
        component: TicketsComponent
      },
      {
        path: 'tickets/:id',
        pathMatch: 'full',
        component: TicketComponent
      },
      {
        path: ':id',
        component: FlightComponent
      }]
  },
  {
    path: 'planes',
    component: AircraftComponent,
    children: [
      {
        path: '',
        component: PlanesComponent
      },
      {
        path: 'types',
        pathMatch: 'full',
        component: PlaneTypesComponent
      },
      {
        path: 'types/:id',
        pathMatch: 'full',
        component: PlaneTypeItemComponent
      },
      {
        path: ':id',
        component: PlaneItemComponent
      }]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
