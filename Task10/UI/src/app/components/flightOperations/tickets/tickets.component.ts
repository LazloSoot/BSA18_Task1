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

}
