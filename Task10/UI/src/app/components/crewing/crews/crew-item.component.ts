import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CrewingService } from '../../../services/crewing.service';
import { Crew } from '../../../models/crew';

@Component({
  selector: 'app-crew-item',
  templateUrl: './crew-item.component.html',
  styleUrls: ['./crew-item.component.less'],
  providers: [CrewingService]
})
export class CrewItemComponent {

  id: number;
  @Input() crew:  Crew;
  @Input() details: boolean;
  originCrew: Crew;

  constructor(private crewingService: CrewingService) 
  { 
    if(this.crew)
      this.originCrew = this.crew;
  }

   loadCrew(id: number){
     this.crewingService.getCrew(id)
         .subscribe((data: Crew) => {
           this.crew = data;
           this.originCrew = data;
          });
       }

     save(){
       debugger;
       if(this.crew.id)
         {
            this.crewingService.updateCrew(this.crew)
                .subscribe(data => this.loadCrew(this.crew.id));
            this.details = true;
         }
       else
       {
         debugger;
          this.crewingService.createCrew(this.crew);
          close();
       }
         
     }
    
      close(){
        this.crew = this.originCrew = null;
        this.details = true;
      }
    
      cancel(){
        this.crew = this.originCrew;
      }
}
