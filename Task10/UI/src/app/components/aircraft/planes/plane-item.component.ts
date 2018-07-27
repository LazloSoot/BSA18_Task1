import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AircraftService } from '../../../services/aircraft.service';
import { Plane } from '../../../models/plane';

@Component({
  selector: 'app-plane-item',
  templateUrl: './plane-item.component.html',
  styleUrls: ['./plane-item.component.less'],
  providers: [AircraftService]
})
export class PlaneItemComponent{
  id: number;
  @Input() plane:  Plane;
  @Input() details: boolean;
  originPlane: Plane;

  constructor(private aircraftService: AircraftService) 
  { 
    if(this.plane)
      this.originPlane = this.plane;
  }

   loadPlane(id: number){
     this.aircraftService.getPlane(id)
         .subscribe((data: Plane) => {
           this.plane = data;
           this.originPlane = data;
          });
       }

     save(){
       debugger;
       if(this.plane.id)
         {
            this.aircraftService.updatePlane(this.plane)
                .subscribe(data => this.loadPlane(this.plane.id));
            this.details = true;
         }
       else
       {
         debugger;
          this.aircraftService.createPlane(this.plane);
          close();
       }
         
     }
    
      close(){
        this.plane = this.originPlane = null;
        this.details = true;
      }
    
      cancel(){
        this.plane = this.originPlane;
      }
}
