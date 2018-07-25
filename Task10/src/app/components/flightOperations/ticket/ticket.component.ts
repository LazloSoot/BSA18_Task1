import { Component, OnInit } from '@angular/core';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Ticket } from '../../../models/ticket';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.less'],
  providers: [FlightsOperationsService]
})
export class TicketComponent implements OnInit {

  ticket: Ticket = new Ticket();
  tickets: Ticket[];
  tableMode: boolean = true; 

  constructor(private flightsService: FlightsOperationsService) { }

  ngOnInit() {
    this.loadTickets();
  }

  loadTickets(){
    this.flightsService.getTickets()
        .subscribe((data: Ticket[]) => this.tickets = data);
  }

  save(){
    if(this.ticket.id == null){
      this.flightsService.createTicket(this.ticket)
          .subscribe((data: Ticket) => this.tickets.push(data));
    }else{
      this.flightsService.updateTicket(this.ticket)
          .subscribe(data => this.loadTickets());
    }
    this.cancel();
  }

  editFlight(t: Ticket){
    this.ticket = t;
  }

  cancel(){
    this.ticket = new Ticket();
    this.tableMode = true;
  }

  delete(t: Ticket){
    this.flightsService.deleteTicket(t.id)
        .subscribe(data => this.loadTickets());
  }
  
  add(){
    this.cancel();
    this.tableMode = false;
  }

}
