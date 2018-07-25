import { Component, OnInit } from '@angular/core';
import { AircraftService } from '../../../services/aircraft.service';
import { Plane } from '../../../models/plane';

@Component({
  selector: 'app-plane',
  templateUrl: './plane.component.html',
  styleUrls: ['./plane.component.less'],
  providers: [AircraftService]
})
export class PlaneComponent implements OnInit {

  plane:  Plane = new Plane();
  planes: Plane[];
  tableMode: boolean = true; 

  constructor(private aircraftService: AircraftService) { }

  ngOnInit() {
    this.loadPlanes();
  }

  loadPlanes(){
    this.aircraftService.getPlanes()
        .subscribe((data: Plane[]) => this.planes = data);
  }

  save(){
    if(this.plane.id == null){
      this.aircraftService.createPlane(this.plane)
          .subscribe((data: Plane) => this.planes.push(data));
    }else{
      this.aircraftService.updatePlane(this.plane)
          .subscribe(data => this.loadPlanes());
    }
    this.cancel();
  }

  editPlane(p : Plane){
    this.plane = p;
  }

  cancel(){
    this.plane = new Plane();
    this.tableMode = true;
  }

  delete(p: Plane){
    this.aircraftService.deletePlane(p.id)
        .subscribe(data => this.loadPlanes());
  }
  
  add(){
    this.cancel();
    this.tableMode = false;
  }

}
