import { TestBed } from '@angular/core/testing';

import { HomePetsService } from './home-pets.service';

describe('HomePetsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HomePetsService = TestBed.get(HomePetsService);
    expect(service).toBeTruthy();
  });
});
