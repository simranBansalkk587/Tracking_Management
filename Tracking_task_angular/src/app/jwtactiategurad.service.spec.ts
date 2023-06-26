import { TestBed } from '@angular/core/testing';

import { JwtactiateguradService } from './jwtactiategurad.service';

describe('JwtactiateguradService', () => {
  let service: JwtactiateguradService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JwtactiateguradService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
