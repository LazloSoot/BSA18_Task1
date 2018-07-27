import { Component, OnInit, Input } from '@angular/core';
import { CrewingService } from '../../../services/crewing.service';
import { Stewardess } from '../../../models/stewardess';

@Component({
  selector: 'app-stewardess-item',
  templateUrl: './stewardess-item.component.html',
  styleUrls: ['./stewardess-item.component.less']
})
export class StewardessItemComponent {

  id: number;
  @Input() stewardess:  Stewardess;
  @Input() details: boolean;
  originStewardess: Stewardess;

  constructor(private crewingService: CrewingService) 
  { 
    if(this.stewardess)
      this.originStewardess = this.stewardess;
  }

   loadStewardess(id: number){
     this.crewingService.getStewardess(id)
         .subscribe((data: Stewardess) => {
           this.stewardess = data;
           this.originStewardess = data;
          });
       }

     save(){
       debugger;
       if(this.stewardess.id)
         {
            this.crewingService.updateStewardess(this.stewardess)
                .subscribe(data => this.loadStewardess(this.stewardess.id));
            this.details = true;
         }
       else
       {
         debugger;
          this.crewingService.createStewardess(this.stewardess);
          close();
       }
         
     }
    
      close(){
        this.stewardess = this.originStewardess = null;
        this.details = true;
      }
    
      cancel(){
        this.stewardess = this.originStewardess;
      }
}
