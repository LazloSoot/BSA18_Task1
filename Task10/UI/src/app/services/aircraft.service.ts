import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import { Plane } from '../models/plane';
import { PlaneType } from '../models/planeType';

@Injectable()
export class AircraftService {

  private url = '/api/planes';

  constructor(private http: HttpClient) { }

  getPlanes() : Observable<Plane[]> {
    return this.http.get(this.url)
        .pipe(map<Plane[],any>(data => {
          return data.map(function(plane: any){
            return {
              id: plane.id,
              Name: plane.name,
              Release: plane.releaseDate,
              LifeTime: plane.lifetime,
              HeavyMaintenceDate: plane.lastHeavyMaintenance,
              FlightHours: plane.flightHours,
              PlaneTypeId: plane.planeTypeId
            };
          });
        }));
  }

  getPlane(id: number) : Observable<Plane> {
    return this.http.get(this.url + '/' + id)
        .pipe(map<Plane,any>(function(plane: any){
          return {
            id: plane.id,
            Name: plane.name,
            Release: plane.releaseDate,
            LifeTime: plane.lifetime,
            HeavyMaintenceDate: plane.lastHeavyMaintenance,
            FlightHours: plane.flightHours,
            PlaneTypeId: plane.planeTypeId
          };
        }));
  }


  getPlaneTypes() : Observable<PlaneType[]> {
    return this.http.get(this.url + '/planeTypes')
        .pipe(map<PlaneType[],any>(data => {
          return data.map(function(planeType: any){
            return {
              id: planeType.id,
              Model: planeType.model,
              Capacity: planeType.capacity,
              CargoCapacity: planeType.cargoCapacity
            };
          });
        }));
  }

  getPlaneType(id: number) : Observable<PlaneType> {
    return this.http.get(this.url + '/planeTypes/' + id)
      .pipe(map<PlaneType,any>(function(planeType: any){
          return {
            id: planeType.id,
            Model: planeType.model,
            Capacity: planeType.capacity,
            CargoCapacity: planeType.cargoCapacity
          };
      }));
  }


  updatePlane(plane: Plane){
    return this.http.put(this.url + '/' + plane.id , plane);
  }
  createPlane(plane: Plane){
    return this.http.post(this.url, plane);
  }

  createPlaneType(planeType: PlaneType){
    return this.http.post(this.url + '/planeTypes', planeType);
  }

  updatePlaneType(planeType: PlaneType){
    return this.http.put(this.url + '/planeTypes/' + planeType.id , planeType);
  }

  deletePlane(id: number){
    return this.http.delete(this.url + '/' + id);
  }

  deletePlaneType(id: number){
    return this.http.delete(this.url + '/planeTypes' + '/' + id)
  }
}
