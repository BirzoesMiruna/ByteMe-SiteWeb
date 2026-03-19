import { TestBed } from '@angular/core/testing';

import { RetetaService } from './reteta.service';

describe('RetetaService', () => {
  let service: RetetaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RetetaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
