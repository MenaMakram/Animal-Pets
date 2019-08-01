/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProfileClientService } from './ProfileClient.service';

describe('Service: ProfileClient', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProfileClientService]
    });
  });

  it('should ...', inject([ProfileClientService], (service: ProfileClientService) => {
    expect(service).toBeTruthy();
  }));
});
