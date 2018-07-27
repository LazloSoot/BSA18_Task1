import { TestBed, inject } from '@angular/core/testing';

import { CrewingService } from './crewing.service';

describe('CrewingService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CrewingService]
    });
  });

  it('should be created', inject([CrewingService], (service: CrewingService) => {
    expect(service).toBeTruthy();
  }));
});
