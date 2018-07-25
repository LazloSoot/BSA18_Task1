import { Component, OnInit } from '@angular/core';
import { CrewingService } from '../../../services/crewing.service';
import { Crew } from '../../../models/crew';

@Component({
  selector: 'app-crew',
  templateUrl: './crew.component.html',
  styleUrls: ['./crew.component.less'],
  providers: [CrewingService]
})
export class CrewComponent implements OnInit {

  crew: Crew = new Crew();
  crews: Crew[];
  tableMode: boolean = true; 

  constructor(private crewingService: CrewingService) { }

  ngOnInit() {
    this.loadCrews();
  }

  loadCrews(){
    this.crewingService.getCrews()
        .subscribe((data: Crew[]) => this.crews = data);
  }

  save(){
    if(this.crew.id == null){
      this.crewingService.createCrew(this.crew)
          .subscribe((data: Crew) => this.crews.push(data));
    }else{
      this.crewingService.updateCrew(this.crew)
          .subscribe(data => this.loadCrews());
    }
    this.cancel();
  }

  editCrew(c: Crew){
    this.crew = c;
  }

  cancel(){
    this.crew = new Crew();
    this.tableMode = true;
  }

  delete(c: Crew){
    this.crewingService.deleteCrew(c.id)
        .subscribe(data => this.loadCrews());
  }
  
  add(){
    this.cancel();
    this.tableMode = false;
  }
}
