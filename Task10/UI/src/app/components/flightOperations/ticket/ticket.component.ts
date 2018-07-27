import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Ticket } from '../../../models/ticket';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.less'],
  providers: [FlightsOperationsService]
})
export class TicketComponent implements OnInit {

  id: number;
  ticket: Ticket;
  newTicket: Ticket;
  loaded: boolean = false; 

  constructor(private flightsService: FlightsOperationsService, public route: ActivatedRoute) 
  {
    this.id = Number.parseInt(this.route.snapshot.params['id']);
  }

  ngOnInit() {
    if(this.id)
      this.loadTicket(this.id);
  }

  loadTicket(id: number){
    this.flightsService.getTicket(id)
        .subscribe((data: Ticket) => {
          this.ticket = data;
          this.newTicket = data;
          this.loaded = true;
        });
  }

  save(){
    this.flightsService.updateTicket(this.newTicket)
          .subscribe(data => this.loadTicket(this.ticket.id));
  }

  editTicket(t: Ticket){
    this.newTicket = t;
  }

  cancel(){
    this.newTicket = this.ticket;
  }

}
