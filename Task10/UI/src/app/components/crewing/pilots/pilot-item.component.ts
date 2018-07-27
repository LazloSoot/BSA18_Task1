import { Component, OnInit, Input } from '@angular/core';
import { Pilot } from '../../../models/pilot';
import { CrewingService } from '../../../services/crewing.service';

@Component({
  selector: 'app-pilot-item',
  templateUrl: './pilot-item.component.html',
  styleUrls: ['./pilot-item.component.less'],
  providers: [ CrewingService ]
})
export class PilotItemComponent {

  id: number;
  @Input() pilot:  Pilot;
  @Input() details: boolean;
  originPilot: Pilot;

  constructor(private crewingService: CrewingService) 
  { 
    if(this.pilot)
      this.originPilot = this.pilot;
  }

   loadPilot(id: number){
     this.crewingService.getPilot(id)
         .subscribe((data: Pilot) => {
           this.pilot = data;
           this.originPilot = data;
          });
       }

     save(){
       debugger;
       if(this.pilot.id)
         {
            this.crewingService.updatePilot(this.pilot)
                .subscribe(data => this.loadPilot(this.pilot.id));
            this.details = true;
         }
       else
       {
         debugger;
          this.crewingService.createPilot(this.pilot);
          close();
       }
         
     }
    
      close(){
        this.pilot = this.originPilot = null;
        this.details = true;
      }
    
      cancel(){
        this.pilot = this.originPilot;
      }
}
