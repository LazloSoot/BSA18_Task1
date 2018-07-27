import { Component, OnInit } from '@angular/core';
import { AircraftService } from '../../../services/aircraft.service';
import { Plane } from '../../../models/plane';

@Component({
  selector: 'app-planes',
  templateUrl: './planes.component.html',
  styleUrls: ['./planes.component.less'],
  providers: [ AircraftService ]
})
export class PlanesComponent implements OnInit {

  planes: Plane[];

  selectedPlane: Plane;
  details: boolean = true;

  constructor(private aircraftService: AircraftService) { }

  ngOnInit() {
    this.loadPlanes();
  }

  loadPlanes(){
    this.aircraftService.getPlanes()
        .subscribe((data: Plane[]) => this.planes = data);
  }

  delete(p: Plane){
    this.aircraftService.deletePlane(p.id)
        .subscribe(data => this.loadPlanes());
  }

  editPlane(plane: Plane){
    debugger;
    this.details = false;
    this.selectedPlane = plane;
  }

  onSelect(plane: Plane){
    debugger;
    this.details = true;
    this.selectedPlane = plane;
  }

  add(){
    this.details = false;
    this.selectedPlane = null;
  }
}
