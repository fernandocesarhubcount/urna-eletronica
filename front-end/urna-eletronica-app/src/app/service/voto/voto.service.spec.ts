import { TestBed } from '@angular/core/testing';

import { VotoService } from './voto.service';

describe('VotoService', () => {
  let service: VotoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VotoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
