import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule, MatIconModule, MatToolbarModule, MatButtonModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

import { HttpClientModule } from '@angular/common/http';

import { PilotItemComponent } from './components/crewing/pilots/pilot-item.component';
import { StewardessItemComponent } from './components/crewing/stewardesses/stewardess-item.component';
import { FlightItemComponent } from './components/flightOperations/flights/flight-item.component';
import { AirportComponent } from './components/airport/airport.component';
import { PilotsComponent } from './components/crewing/pilots/pilots.component';
import { StewardessesComponent } from './components/crewing/stewardesses/stewardesses.component';
import { PlanesComponent } from './components/aircraft/planes/planes.component';
import { PlaneTypesComponent } from './components/aircraft/plane-types/plane-types.component';
import { TicketsComponent } from './components/flightOperations/tickets/tickets.component';
import { FlightsComponent } from './components/flightOperations/flights/flights.component';
import { DeparturesComponent } from './components/flightOperations/departures/departures.component';
import { CrewingComponent } from './components/crewing/crewing.component';
import { CrewItemComponent } from './components/crewing/crews/crew-item.component';
import { CrewListComponent } from './components/crewing/crews/crew-list.component';
import { AircraftComponent } from './components/aircraft/aircraft.component';
import { PlaneItemComponent } from './components/aircraft/planes/plane-item.component';
import { PlaneTypeItemComponent } from './components/aircraft/plane-types/plane-type-item.component';
import { TicketItemComponent } from './components/flightOperations/tickets/ticket-item.component';
import { DepartureItemComponent } from './components/flightOperations/departures/departure-item.component';


@NgModule({
  declarations: [
    AppComponent,
    AirportComponent,
    PilotsComponent,
    StewardessesComponent,
    PlanesComponent,
    PlaneTypesComponent,
    TicketsComponent,
    FlightsComponent,
    DeparturesComponent,
    CrewingComponent,
    CrewItemComponent,
    CrewListComponent,
    AircraftComponent,
    PlaneItemComponent,
    PlaneTypeItemComponent,
    StewardessItemComponent,
    PilotItemComponent,
    TicketItemComponent,
    FlightItemComponent,
    DepartureItemComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    FlexLayoutModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
