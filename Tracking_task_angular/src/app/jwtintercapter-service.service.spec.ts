import { TestBed } from '@angular/core/testing';

import { JwtintercapterServiceService } from './jwtintercapter-service.service';

describe('JwtintercapterServiceService', () => {
  let service: JwtintercapterServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtintercapterServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
