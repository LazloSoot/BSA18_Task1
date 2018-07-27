import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AirportService } from '../../services/airport.service';
@Component({
  selector: 'app-airport',
  templateUrl: './airport.component.html',
  styleUrls: ['./airport.component.less'],
  providers: [AirportService]
})
export class AirportComponent implements OnInit {

  constructor(
    public router: Router, 
    public airportService: AirportService
  ) { }

  ngOnInit() {
  }

  onClick(direction: string){
    this.router.navigate(['/' + direction]);
  }
}
