import { Component, OnInit } from '@angular/core';
import { CrewingService } from '../../../services/crewing.service';
import { Pilot } from '../../../models/pilot';

@Component({
  selector: 'app-pilot',
  templateUrl: './pilot.component.html',
  styleUrls: ['./pilot.component.less'],
  providers: [CrewingService]
})
export class PilotComponent implements OnInit {

  pilot: Pilot = new Pilot();
  pilots: Pilot[];
  tableMode: boolean = true; 

  constructor(private crewingService: CrewingService) { }

  ngOnInit() {
    this.loadPilots();
  }

  loadPilots(){
    this.crewingService.getPilots()
        .subscribe((data: Pilot[]) => this.pilots = data);
  }

  save(){
    if(this.pilot.id == null){
      this.crewingService.createPilot(this.pilot)
          .subscribe((data: Pilot) => this.pilots.push(data));
    }else{
      this.crewingService.updatePilot(this.pilot)
          .subscribe(data => this.loadPilots());
    }
    this.cancel();
  }

  editPilot(p: Pilot){
    this.pilot = p;
  }

  cancel(){
    this.pilot = new Pilot();
    this.tableMode = true;
  }

  delete(p: Pilot){
    this.crewingService.deletePilot(p.id)
        .subscribe(data => this.loadPilots());
  }
  
  add(){
    this.cancel();
    this.tableMode = false;
  }
}
