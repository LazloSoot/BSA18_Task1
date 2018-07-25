import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Plane } from '../models/plane';
import { PlaneType } from '../models/planeType';

@Injectable()
export class AircraftService {

  private url = '/api/planes';

  constructor(private http: HttpClient) { }

  getPlanes(){
    return this.http.get(this.url);
  }

  getPlaneTypes(){
    return this.http.get(this.url + '/planeTypes');
  }

  createPlane(plane: Plane){
    return this.http.post(this.url, plane);
  }

  createPlaneType(planeType: PlaneType){
    return this.http.post(this.url + '/planeTypes', planeType);
  }

  updatePlane(plane: Plane){
    return this.http.put(this.url, plane);
  }

  updatePlaneType(planeType: PlaneType){
    return this.http.put(this.url + '/planeTypes', planeType);
  }

  deletePlane(id: number){
    return this.http.delete(this.url + '/' + id);
  }

  deletePlaneType(id: number){
    return this.http.delete(this.url + '/planeTypes' + '/' + id)
  }
}
