import { Component, Input } from '@angular/core';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Flight } from '../../../models/flight';

@Component({
  selector: 'app-flight-item',
  templateUrl: './flight-item.component.html',
  styleUrls: ['./flight-item.component.less'],
  providers: [ FlightsOperationsService ]
})
export class FlightItemComponent {

  id: number;
  @Input() flight:  Flight;
  @Input() details: boolean;
  originFlight: Flight;

  constructor(private flightOpService: FlightsOperationsService ) 
  { 
    if(this.flight)
      this.originFlight = this.flight;
  }

   loadFlight(id: number){
     this.flightOpService.getFlight(id)
         .subscribe((data: Flight) => {
           this.flight = data;
           this.originFlight = data;
          });
       }

     save(){
       debugger;
       if(this.flight.id)
         {
            this.flightOpService.updateFlight(this.flight)
                .subscribe(data => this.loadFlight(this.flight.id));
            this.details = true;
         }
       else
       {
         debugger;
          this.flightOpService.createFlight(this.flight);
          close();
       }
         
     }
    
      close(){
        this.flight = this.originFlight = null;
        this.details = true;
      }
    
      cancel(){
        this.flight = this.originFlight;
      }
}
