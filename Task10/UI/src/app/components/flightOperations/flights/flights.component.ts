import { Component, OnInit } from '@angular/core';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Flight } from '../../../models/flight';

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.less'],
  providers: [ FlightsOperationsService ]
})
export class FlightsComponent implements OnInit {

  flights: Flight[];

  constructor(private flightOpService: FlightsOperationsService) { }

  ngOnInit() {
    this.loadFlights();
  }

  loadFlights(){
    this.flightOpService.getFlights()
        .subscribe((data: Flight[]) => this.flights = data);
  }

  delete(f: Flight){
    this.flightOpService.deleteFlight(f.id)
        .subscribe(data => this.loadFlights());
  }
  
}
