import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CrewingService } from '../../../services/crewing.service';
import { Pilot } from '../../../models/pilot';

@Component({
  selector: 'app-pilots',
  templateUrl: './pilots.component.html',
  styleUrls: ['./pilots.component.less'],
  providers: [CrewingService]
})
export class PilotsComponent implements OnInit {

  pilots: Pilot[];

  selectedPilot: Pilot;
  details: boolean = true;

  constructor(private crewingService: CrewingService, public route: ActivatedRoute) { 
    debugger;
  }

  ngOnInit() {
    debugger;
    this.loadPilots();
  }

  loadPilots(){
    this.crewingService.getPilots()
        .subscribe((data: Pilot[]) => this.pilots = data);
  }

  delete(p: Pilot){
    this.crewingService.deletePilot(p.id)
        .subscribe(data => this.loadPilots());
  }

  editPilot(pilot: Pilot){
    debugger;
    this.details = false;
    this.selectedPilot = pilot;
  }

  onSelect(pilot: Pilot){
    debugger;
    this.details = true;
    this.selectedPilot = pilot;
  }

  add(){
    this.details = false;
    this.selectedPilot = null;
  }
}
