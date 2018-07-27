import { Component, OnInit } from '@angular/core';
import { AircraftService } from '../../../services/aircraft.service';
import { PlaneType } from '../../../models/planeType';

@Component({
  selector: 'app-plane-types',
  templateUrl: './plane-types.component.html',
  styleUrls: ['./plane-types.component.less'],
  providers: [ AircraftService ]
})
export class PlaneTypesComponent implements OnInit {

  planeTypes: PlaneType[];

  selectedPlaneType: PlaneType;
  details: boolean = true;

  constructor(private aircraftService: AircraftService) { }

  ngOnInit() {
    this.loadPlaneTypes();
  }

  loadPlaneTypes(){
    this.aircraftService.getPlaneTypes()
        .subscribe((data: PlaneType[]) => this.planeTypes = data);
  }

  delete(p: PlaneType){
    this.aircraftService.deletePlaneType(p.id)
        .subscribe(data => this.loadPlaneTypes());
  }

  editPlaneType(planeType: PlaneType){
    debugger;
    this.details = false;
    this.selectedPlaneType = planeType;
  }

  onSelect(planeType: PlaneType){
    debugger;
    this.details = true;
    this.selectedPlaneType = planeType;
  }

  add(){
    this.details = false;
    this.selectedPlaneType = null;
  }

}
