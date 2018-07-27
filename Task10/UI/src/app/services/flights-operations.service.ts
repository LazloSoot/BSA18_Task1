import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient} from '@angular/common/http';
import { Flight } from '../models/flight'
import { Departure } from '../models/departure';
import { Ticket } from '../models/ticket';

@Injectable()
export class FlightsOperationsService {

  private url = '/api/flights';

  constructor(private http: HttpClient) { }

  getFlights() : Observable<Flight[]> {
    return this.http.get(this.url)
        .pipe(map<Flight[],any>(data => {
          return data.map(function(flight: any) {
            return {
              id: flight.id,
              DeparturePoint: flight.From,
              DepartureTime: flight.Date,
              Destination: flight.To,
              ArrivalTime: flight.Arrival,
              TicketsIds: flight.TicketsIds
            };
          });
        }));
  }

  getFlight(id: number) : Observable<Flight> {
    return this.http.get(this.url + '/' + id)
        .pipe(map<Flight,any>(function(flight: any){
          return {
            id: flight.id,
            DeparturePoint: flight.From,
            DepartureTime: flight.Date,
            Destination: flight.To,
            ArrivalTime: flight.Arrival,
            TicketsIds: flight.TicketsIds
          };
        }));
  }

  getDepartures() : Observable<Departure[]> {
    return this.http.get(this.url + '/departures')
        .pipe(map<Departure[],any>(data => {
          return data.map(function(departure: any) {
            return {
              id: departure.id,
              FlightId: departure.Flight,
              DepartureTime: departure.Time,
              CrewId: departure.Crew,
              PlaneId: departure.Plane
            };
          });
        }));
  }

  getDeparture(id: number) : Observable<Departure> {
    return this.http.get(this.url + '/departures/' + id)
        .pipe(map<Departure,any>(function(departure: any){
          return {
            id: departure.id,
            FlightId: departure.Flight,
            DepartureTime: departure.Time,
            CrewId: departure.Crew,
            PlaneId: departure.Plane
          };
        }));
  }

  getTickets() : Observable<Ticket[]> {
    return this.http.get(this.url + '/tickets')
        .pipe(map<Ticket[],any>(data => {
          return data.map(function(ticket: any) {
            return {
              id: ticket.id,
              Price: ticket.Price,
              Seat: ticket.Seat
            };
          });
        }));
  }

  getTicket(id: number) : Observable<Ticket> {
    return this.http.get(this.url + '/tickets/' + id)
        .pipe(map<Ticket, any>(function(ticket: any){
          return {
            id: ticket.id,
            Price: ticket.Price,
            Seat: ticket.Seat
          };
        }));
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
