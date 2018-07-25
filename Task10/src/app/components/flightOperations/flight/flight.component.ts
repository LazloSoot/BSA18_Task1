import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
//import { Observable } from 'rxjs/Observable';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Flight } from '../../../models/flight';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.less'],
  providers: [FlightsOperationsService]
})
export class FlightsComponent implements OnInit {

  flight: Flight = new Flight();
  flights: Flight[];
  tableMode: boolean = true; 

  constructor(private flightsService: FlightsOperationsService) { }

  ngOnInit() {
    this.loadFlights();
  }

  loadFlights(){
    this.flightsService.getFlights()
        .subscribe((data: Flight[]) => this.flights = data);
  }

  save(){
    if(this.flight.id == null){
      this.flightsService.createFlight(this.flight)
          .subscribe((data: Flight) => this.flights.push(data));
    }else{
      this.flightsService.updateFlight(this.flight)
          .subscribe(data => this.loadFlights());
    }
    this.cancel();
  }

  editFlight(f: Flight){
    this.flight = f;
  }

  cancel(){
    this.flight = new Flight();
    this.tableMode = true;
  }

  delete(f: Flight){
    this.flightsService.deleteFlight(f.id)
        .subscribe(data => this.loadFlights());
  }
  
  add(){
    this.cancel();
    this.tableMode = false;
  }
}
