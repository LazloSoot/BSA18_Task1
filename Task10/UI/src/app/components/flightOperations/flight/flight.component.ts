import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Flight } from '../../../models/flight';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.less'],
  providers: [FlightsOperationsService]
})
export class FlightComponent implements OnInit {

  id: number;
  flight: Flight;
  newFlight: Flight;
  loaded: boolean = false; 

  constructor(private flightsService: FlightsOperationsService, public route: ActivatedRoute) 
    {
      this.id = Number.parseInt(this.route.snapshot.params['id']);
    }

    ngOnInit() {
      if(this.id)
        this.loadFlight(this.id);
    }
  
    loadFlight(id: number){
      this.flightsService.getFlight(id)
          .subscribe((data: Flight) => {
            this.flight = data;
            this.newFlight = data;
            this.loaded = true;
          });
    }
  
    save(){
      this.flightsService.updateFlight(this.newFlight)
            .subscribe(data => this.loadFlight(this.flight.id));
    }
  
    editFlight(f: Flight){
      this.newFlight = f;
    }
  
    cancel(){
      this.newFlight = this.flight;
    }
}
