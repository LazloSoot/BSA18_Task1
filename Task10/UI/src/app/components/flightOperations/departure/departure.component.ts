import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Departure } from '../../../models/departure';

@Component({
  selector: 'app-departure',
  templateUrl: './departure.component.html',
  styleUrls: ['./departure.component.less'],
  providers: [FlightsOperationsService]
})
export class DepartureComponent implements OnInit {

  id: number;
  departure: Departure;
  newDeparture: Departure;
  loaded: boolean = false; 

  constructor(private flightsOpService: FlightsOperationsService, public route: ActivatedRoute) 
  {
    this.id = Number.parseInt(this.route.snapshot.params['id']);
  }

  ngOnInit() {
    if(this.id)
      this.loadDeparture(this.id);
  }

  loadDeparture(id: number){
    this.flightsOpService.getDeparture(id)
        .subscribe((data: Departure) => {
          this.departure = data;
          this.newDeparture = data;
          this.loaded = true;
        });
  }

  save(){
    this.flightsOpService.updateDeparture(this.newDeparture)
          .subscribe(data => this.loadDeparture(this.departure.id));
  }

  editDeparture(d: Departure){
    this.newDeparture = d;
  }

  cancel(){
    this.newDeparture = this.departure;
  }

}
