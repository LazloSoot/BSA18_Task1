import { Component, OnInit } from '@angular/core';
import { AircraftService } from '../../../services/aircraft.service';
import { PlaneType } from '../../../models/planeType';

@Component({
  selector: 'app-plane-type',
  templateUrl: './plane-type.component.html',
  styleUrls: ['./plane-type.component.less'],
  providers: [AircraftService]
})
export class PlaneTypeComponent implements OnInit {

  planeType:  PlaneType = new PlaneType();
  planeTypes: PlaneType[];
  tableMode: boolean = true; 

  constructor(private aircraftService: AircraftService) { }

  ngOnInit() {
    this.loadPlaneTypes();
  }

  loadPlaneTypes(){
    this.aircraftService.getPlaneTypes()
        .subscribe((data: PlaneType[]) => this.planeTypes = data);
  }

  save(){
    if(this.planeType.id == null){
      this.aircraftService.createPlaneType(this.planeType)
          .subscribe((data: PlaneType) => this.planeTypes.push(data));
    }else{
      this.aircraftService.updatePlaneType(this.planeType)
          .subscribe(data => this.loadPlaneTypes());
    }
    this.cancel();
  }

  editPlaneType(p : PlaneType){
    this.planeType = p;
  }

  cancel(){
    this.planeType = new PlaneType();
    this.tableMode = true;
  }

  delete(p: PlaneType){
    this.aircraftService.deletePlaneType(p.id)
        .subscribe(data => this.loadPlaneTypes());
  }
  
  add(){
    this.cancel();
    this.tableMode = false;
  }


}
