import { TestBed, inject } from '@angular/core/testing';

import { FlightsOperationsService } from './flights-operations.service';

describe('FlightsOperationsService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FlightsOperationsService]
    });
  });

  it('should be created', inject([FlightsOperationsService], (service: FlightsOperationsService) => {
    expect(service).toBeTruthy();
  }));
});
