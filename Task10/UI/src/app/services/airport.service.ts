import { Injectable } from '@angular/core';

import {
  Observable, of, 
} from 'rxjs';
import { 
  map, catchError, retry 
} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AirportService {

  constructor() { }
}
