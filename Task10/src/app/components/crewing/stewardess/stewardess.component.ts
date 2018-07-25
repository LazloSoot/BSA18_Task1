import { Component, OnInit } from '@angular/core';
import { CrewingService } from '../../../services/crewing.service';
import { Stewardess } from '../../../models/stewardess';

@Component({
  selector: 'app-stewardess',
  templateUrl: './stewardess.component.html',
  styleUrls: ['./stewardess.component.less'],
  providers: [CrewingService]
})
export class StewardessComponent implements OnInit {

  stewardess: Stewardess = new Stewardess();
  stewardesses: Stewardess[];
  tableMode: boolean = true; 

  constructor(private crewingService: CrewingService) { }

  ngOnInit() {
    this.loadStewardesses();
  }

  loadStewardesses(){
    this.crewingService.getStewardesses()
        .subscribe((data: Stewardess[]) => this.stewardesses = data);
  }

  save(){
    if(this.stewardess.id == null){
      this.crewingService.createStewardess(this.stewardess)
          .subscribe((data: Stewardess) => this.stewardesses.push(data));
    }else{
      this.crewingService.updateStewardess(this.stewardess)
          .subscribe(data => this.loadStewardesses());
    }
    this.cancel();
  }

  editCrew(s: Stewardess){
    this.stewardess = s;
  }

  cancel(){
    this.stewardess = new Stewardess();
    this.tableMode = true;
  }

  delete(s: Stewardess){
    this.crewingService.deleteStewardess(s.id)
        .subscribe(data => this.loadStewardesses());
  }
  
  add(){
    this.cancel();
    this.tableMode = false;
  }
}
