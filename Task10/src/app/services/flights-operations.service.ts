import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Flight } from '../models/flight'
import { Departure } from '../models/departure';
import { Ticket } from '../models/ticket';

@Injectable()
export class FlightsOperationsService {

  private url = '/api/flights';

  constructor(private http: HttpClient) { }

  getFlights(){
    return this.http.get(this.url);
  }

  getDepartures(){
    return this.http.get(this.url + '/departures');
  }

  getTickets(){
    return this.http.get(this.url + '/tickets');
  }

  getFlightTickets(id: number){
    return this.http.get(this.url + '/' + id + '/tickets');
  }

  createFlight(flight: Flight){
    return this.http.post(this.url, flight);
  }

  createTicket(ticket: Ticket){
    return this.http.post(this.url + '/tickets', ticket);
  }

  updateFlight(flight: Flight){
    return this.http.put(this.url, flight);
  }

  updateDeparture(departure: Departure){
    return this.http.put(this.url + '/departures', departure);
  }

  updateTicket(ticket: Ticket){
    return this.http.put(this.url + '/tickets', ticket);
  }

  deleteFlight(id: number){
    return this.http.delete(this.url + '/' + id);
  }

  deleteDeparture(id: number){
    return this.http.delete(this.url + '/departures' + '/' + id)
  }

  deleteTicket(id: number){
    return this.http.delete(this.url + '/tickets' + '/' + id)
  }
}
