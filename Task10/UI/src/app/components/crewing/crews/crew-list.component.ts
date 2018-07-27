import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CrewingService } from '../../../services/crewing.service';
import { Crew } from '../../../models/crew';

@Component({
  selector: 'app-crew-list',
  templateUrl: './crew-list.component.html',
  styleUrls: ['./crew-list.component.less'],
  providers: [CrewingService]
})
export class CrewListComponent implements OnInit {

  crews: Crew[];

  selectedCrew: Crew;
  details: boolean = true;

  constructor(private crewingService: CrewingService) { }

  ngOnInit() {
    this.loadCrews();
  }

  loadCrews(){
    this.crewingService.getCrews()
        .subscribe((data: Crew[]) => this.crews = data);
  }

  delete(c: Crew){
    this.crewingService.deleteCrew(c.id)
        .subscribe(data => this.loadCrews());
  }

  editCrew(crew: Crew){
    debugger;
    this.details = false;
    this.selectedCrew = crew;
  }

  onSelect(crew: Crew){
    debugger;
    this.details = true;
    this.selectedCrew = crew;
  }

  add(){
    this.details = false;
    this.selectedCrew = null;
  }

}
