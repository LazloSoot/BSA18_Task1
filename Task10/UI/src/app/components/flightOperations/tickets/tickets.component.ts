import { Component, OnInit } from '@angular/core';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Ticket } from '../../../models/ticket';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.less'],
  providers: [ FlightsOperationsService ]
})
export class TicketsComponent implements OnInit {

  tickets: Ticket[];

  selectedTicket: Ticket;
  details: boolean = true;

  constructor(private flightOpService: FlightsOperationsService) { }

  ngOnInit() {
    this.loadTickets();
  }

  loadTickets(){
    this.flightOpService.getTickets()
        .subscribe((data: Ticket[]) => this.tickets = data);
  }

  delete(t: Ticket){
    this.flightOpService.deleteTicket(t.id)
        .subscribe(data => this.loadTickets());
  }

  editPlane(ticket: Ticket){
    debugger;
    this.details = false;
    this.selectedTicket = ticket;
  }

  onSelect(ticket: Ticket){
    debugger;
    this.details = true;
    this.selectedTicket = ticket;
  }

  add(){
    this.details = false;
    this.selectedTicket = null;
  }

}
