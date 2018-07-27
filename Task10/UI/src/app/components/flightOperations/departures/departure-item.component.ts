import { Component, Input } from '@angular/core';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Departure } from '../../../models/departure';

@Component({
  selector: 'app-departure-item',
  templateUrl: './departure-item.component.html',
  styleUrls: ['./departure-item.component.less'],
  providers: [ FlightsOperationsService ]
})
export class DepartureItemComponent {

  id: number;
  @Input() departure:  Departure;
  @Input() details: boolean;
  originDeparture: Departure;

  constructor(private flightOpService: FlightsOperationsService) 
  { 
    if(this.departure)
      this.originDeparture = this.departure;
  }

   loadDeparture(id: number){
     this.flightOpService.getDeparture(id)
         .subscribe((data: Departure) => {
           this.departure = data;
           this.originDeparture = data;
          });
       }

     save(){
       debugger;
       if(this.departure.id)
         {
            this.flightOpService.updateDeparture(this.departure)
                .subscribe(data => this.loadDeparture(this.departure.id));
            this.details = true;
         }
         
     }
    
      close(){
        this.departure = this.originDeparture = null;
        this.details = true;
      }
    
      cancel(){
        this.departure = this.originDeparture;
      }

}
