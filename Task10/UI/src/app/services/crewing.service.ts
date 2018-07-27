import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient} from '@angular/common/http';
import { Pilot } from '../models/pilot'
import { Stewardess } from '../models/stewardess';
import { Crew } from '../models/crew';

@Injectable()
export class CrewingService {

  private url = '/api/crews';

  constructor(private http: HttpClient) { }

  getCrews() : Observable<Crew[]>{
    return this.http.get(this.url)
        .pipe(map<Crew[],any>(data => {
          return data.map(function(crew: any) {
            return {
              id: crew.id,
              PilotId: crew.Pilot,
              StewardessesIds: crew.Stewardesses
            };
          });
        }));
  }

  getCrew(id: number) : Observable<Crew> {
    return this.http.get(this.url + '/' + id)
        .pipe(map<Crew,any>(function(crew: any){
          return {
              id: crew.id,
              PilotId: crew.Pilot,
              StewardessesIds: crew.Stewardesses
          };
        }));
  }

  getPilots() : Observable<Pilot[]> {
    return this.http.get(this.url + '/pilots')
      .pipe(map<Pilot[],any>(data => {
          let pilots = data;
        //  debugger;
          return pilots.map(function(pilot: any){
            return {
              id: pilot.id, 
              Name: pilot.FirstName, 
              SurName: pilot.LastName, 
              Birth: pilot.BirthDate, 
              ExperienceYears: pilot.Exp 
            };
          });
    }));
  }

  getPilot(id: number) : Observable<Pilot> {
    return this.http.get(this.url + '/pilots/' + id)
      .pipe(map<Pilot, any>(function(pilot: any){
        return {
          id: pilot.id, 
          Name: pilot.FirstName, 
          SurName: pilot.LastName, 
          Birth: pilot.BirthDate, 
          ExperienceYears: pilot.Exp 
        };
      }));
        
  }

  getStewardesses() : Observable<Stewardess[]> {
    return this.http.get(this.url + '/stewardesses')
      .pipe(map<Stewardess[],any>(data => {
        return data.map(function(stewardess: any){
          return {
            id: stewardess.id, 
            Name: stewardess.FirstName, 
            SurName: stewardess.LastName, 
            Birth: stewardess.BirthDate
          };
        });
      }));
  }

  getStewardess(id: number) : Observable<Stewardess> {
    return this.http.get(this.url + '/stewardesses/' + id)
      .pipe(map<Stewardess[],any>(function(stewardess: any){
          return {
            id: stewardess.id, 
            Name: stewardess.FirstName, 
            SurName: stewardess.LastName, 
            Birth: stewardess.BirthDate
          };
      }));
  }

  createCrew(crew: Crew){
    return this.http.post(this.url, crew);
  }

  createPilot(pilot: Pilot){
    return this.http.post(this.url + '/pilots', pilot);
  }

  createStewardess(stewardess: Stewardess){
    return this.http.post(this.url + '/stewardesses', stewardess);
  }

  updateCrew(crew: Crew){
    return this.http.put(this.url + '/' + crew.id, crew);
  }

  updatePilot(pilot: Pilot){
    return this.http.put(this.url + '/pilots/' + pilot.id, pilot);
  }

  updateStewardess(stewardess: Stewardess){
    return this.http.put(this.url + '/stewardesses/' + stewardess.id, stewardess);
  }

  deleteCrew(id: number){
    return this.http.delete(this.url + '/' + id);
  }

  deletePilot(id: number){
    return this.http.delete(this.url + '/pilots' + '/' + id)
  }

  deleteStewardess(id: number){
    return this.http.delete(this.url + '/stewardesses' + '/' + id)
  }
}
