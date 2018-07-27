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

  selectedFlight: Flight;
  details: boolean = true;

  constructor(private flihtOpService: FlightsOperationsService) { }

  ngOnInit() {
    this.loadFlights();
  }

  loadFlights(){
    this.flihtOpService.getFlights()
        .subscribe((data: Flight[]) => this.flights = data);
  }

  delete(f: Flight){
    this.flihtOpService.deleteFlight(f.id)
        .subscribe(data => this.loadFlights());
  }

  editFlight(flight: Flight){
    debugger;
    this.details = false;
    this.selectedFlight = flight;
  }

  onSelect(flight: Flight){
    debugger;
    this.details = true;
    this.selectedFlight = flight;
  }

  add(){
    this.details = false;
    this.selectedFlight = null;
  }
}
