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

  departures: Departure[];

  constructor(private flightOpService: FlightsOperationsService) { }

  ngOnInit() {
    this.loadDepartures();
  }

  loadDepartures(){
    this.flightOpService.getDepartures()
        .subscribe((data: Departure[]) => this.departures = data);
  }

  delete(d: Departure){
    this.flightOpService.deleteDeparture(d.id)
        .subscribe(data => this.loadDepartures());
  }

}
