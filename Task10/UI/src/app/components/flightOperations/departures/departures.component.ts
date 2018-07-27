import { Component, OnInit } from '@angular/core';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Departure } from '../../../models/departure';

@Component({
  selector: 'app-departures',
  templateUrl: './departures.component.html',
  styleUrls: ['./departures.component.less'],
  providers: [ FlightsOperationsService ]
})
export class DeparturesComponent implements OnInit {

  departure: Departure[];

  selectedDeparture: Departure;
  details: boolean = true;

  constructor(private flightOpService: FlightsOperationsService) { }

  ngOnInit() {
    this.loadDepartures();
  }

  loadDepartures(){
    this.flightOpService.getDepartures()
        .subscribe((data: Departure[]) => this.departure = data);
  }

  delete(d: Departure){
    this.flightOpService.deleteDeparture(d.id)
        .subscribe(data => this.loadDepartures());
  }

  editDeparture(departure: Departure){
    debugger;
    this.details = false;
    this.selectedDeparture = departure;
  }

  onSelect(departure: Departure){
    debugger;
    this.details = true;
    this.selectedDeparture = departure;
  }

  add(){
    this.details = false;
    this.selectedDeparture = null;
  }

}
