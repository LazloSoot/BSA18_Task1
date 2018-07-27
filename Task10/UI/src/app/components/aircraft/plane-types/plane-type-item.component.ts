import { Component, Input } from '@angular/core';
import { AircraftService } from '../../../services/aircraft.service';
import { PlaneType } from '../../../models/planeType';

@Component({
  selector: 'app-plane-type-item',
  templateUrl: './plane-type-item.component.html',
  styleUrls: ['./plane-type-item.component.less'],
  providers: [AircraftService]
})
export class PlaneTypeItemComponent {

  id: number;
  @Input() planeType:  PlaneType;
  @Input() details: boolean;
  originPlaneType: PlaneType;

  constructor(private aircraftService: AircraftService) 
  { 
    if(this.planeType)
      this.originPlaneType = this.planeType;
  }

   loadPlaneType(id: number){
     this.aircraftService.getPlaneType(id)
         .subscribe((data: PlaneType) => {
           this.planeType = data;
           this.originPlaneType = data;
          });
       }

     save(){
       debugger;
       if(this.planeType.id)
         {
            this.aircraftService.updatePlaneType(this.planeType)
                .subscribe(data => this.loadPlaneType(this.planeType.id));
            this.details = true;
         }
       else
       {
         debugger;
          this.aircraftService.createPlaneType(this.planeType);
          close();
       }
         
     }
    
      close(){
        this.planeType = this.originPlaneType = null;
        this.details = true;
      }
    
      cancel(){
        this.planeType = this.originPlaneType;
      }
}
