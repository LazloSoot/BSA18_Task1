import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Pilot } from '../models/pilot'
import { Stewardess } from '../models/stewardess';
import { Crew } from '../models/crew';

@Injectable()
export class CrewingService {

  private url = '/api/crews';

  constructor(private http: HttpClient) { }

  getCrews(){
    return this.http.get(this.url);
  }

  getPilots(){
    return this.http.get(this.url + '/pilots');
  }

  getStewardesses(){
    return this.http.get(this.url + '/stewardesses');
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
    return this.http.put(this.url, crew);
  }

  updatePilot(pilot: Pilot){
    return this.http.put(this.url + '/pilots', pilot);
  }

  updateStewardess(stewardess: Stewardess){
    return this.http.put(this.url + '/stewardesses', stewardess);
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
