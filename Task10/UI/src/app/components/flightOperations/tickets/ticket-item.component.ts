import { Component, OnInit, Input } from '@angular/core';
import { FlightsOperationsService } from '../../../services/flights-operations.service';
import { Ticket } from '../../../models/ticket';

@Component({
  selector: 'app-ticket-item',
  templateUrl: './ticket-item.component.html',
  styleUrls: ['./ticket-item.component.less'],
  providers: [ FlightsOperationsService ]
})
export class TicketItemComponent {

  id: number;
  @Input() ticket:  Ticket;
  @Input() details: boolean;
  originTicket: Ticket;

  constructor(private flightOpService: FlightsOperationsService) 
  { 
    if(this.ticket)
      this.originTicket = this.ticket;
  }

   loadTicket(id: number){
     this.flightOpService.getTicket(id)
         .subscribe((data: Ticket) => {
           this.ticket = data;
           this.originTicket = data;
          });
       }

     save(){
       debugger;
       if(this.ticket.id)
         {
            this.flightOpService.updateTicket(this.ticket)
                .subscribe(data => this.loadTicket(this.ticket.id));
            this.details = true;
         }
       else
       {
         debugger;
          this.flightOpService.createTicket(this.ticket);
          close();
       }
         
     }
    
      close(){
        this.ticket = this.originTicket = null;
        this.details = true;
      }
    
      cancel(){
        this.ticket = this.originTicket;
      }
    }