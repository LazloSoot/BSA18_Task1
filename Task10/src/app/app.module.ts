import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';

import { HttpClientModule } from '@angular/common/http';

import { CrewComponent } from './components/crewing/crew/crew.component';
import { PilotComponent } from './components/crewing/pilot/pilot.component';
import { StewardessComponent } from './components/crewing/stewardess/stewardess.component';
import { PlaneComponent } from './components/aircraft/plane/plane.component';
import { PlaneTypeComponent } from './components/aircraft/plane-type/plane-type.component';
import { FlightsComponent } from './components/flightOperations/flight/flight.component';
import { TicketComponent } from './components/flightOperations/ticket/ticket.component';
import { DepartureComponent } from './components/flightOperations/departure/departure.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightsComponent,
    CrewComponent,
    PilotComponent,
    StewardessComponent,
    PlaneComponent,
    PlaneTypeComponent,
    TicketComponent,
    DepartureComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
