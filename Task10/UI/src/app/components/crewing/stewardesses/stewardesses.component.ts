import { Component, OnInit } from '@angular/core';
import { CrewingService } from '../../../services/crewing.service';
import { Stewardess } from '../../../models/stewardess';

@Component({
  selector: 'app-stewardesses',
  templateUrl: './stewardesses.component.html',
  styleUrls: ['./stewardesses.component.less'],
  providers: [CrewingService]
})
export class StewardessesComponent implements OnInit {

  stewardesses: Stewardess[];

  selectedStewardess: Stewardess;
  details: boolean = true;

  constructor(private crewingService: CrewingService) { }

  ngOnInit() {
    this.loadStewardesses();
  }

  loadStewardesses(){
    this.crewingService.getStewardesses()
        .subscribe((data: Stewardess[]) => this.stewardesses = data);
  }

  delete(s: Stewardess){
    this.crewingService.deleteStewardess(s.id)
        .subscribe(data => this.loadStewardesses());
  }

  editStewardess(stewardess: Stewardess){
    debugger;
    this.details = false;
    this.selectedStewardess = stewardess;
  }

  onSelect(stewardess: Stewardess){
    debugger;
    this.details = true;
    this.selectedStewardess = stewardess;
  }

  add(){
    this.details = false;
    this.selectedStewardess = null;
  }
}
