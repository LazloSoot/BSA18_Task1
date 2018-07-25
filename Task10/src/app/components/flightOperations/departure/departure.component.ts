import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
//import { Observable } from 'rxjs/Observable';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Departure } from '../../../models/departure';

@Component({
  selector: 'app-departure',
  templateUrl: './departure.component.html',
  styleUrls: ['./departure.component.less'],
  providers: [FlightsOperationsService]
})
export class DepartureComponent implements OnInit {

  departure: Departure = new Departure();
  departures: Departure[];
  tableMode: boolean = true; 

  constructor(private flightsService: FlightsOperationsService) { }

  ngOnInit() {
    this.loadDepartures();
  }

  loadDepartures(){
    this.flightsService.getFlights()
        .subscribe((data: Departure[]) => this.departures = data);
  }

  save(){
    
      this.flightsService.updateDeparture(this.departure)
          .subscribe(data => this.loadDepartures());
    this.cancel();
  }

  editFlight(d: Departure){
    this.departure = d;
  }

  cancel(){
    this.departure = new Departure();
    this.tableMode = true;
  }

  delete(d: Departure){
    this.flightsService.deleteDeparture(d.id)
        .subscribe(data => this.loadDepartures());
  }
  
  add(){
    this.cancel();
    this.tableMode = false;
  }

}
