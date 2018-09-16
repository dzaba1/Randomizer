import { TestBed, inject } from '@angular/core/testing';

import { CookieBoxService } from './cookie-box.service';

describe('CookieBoxService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CookieBoxService]
    });
  });

  it('should be created', inject([CookieBoxService], (service: CookieBoxService) => {
    expect(service).toBeTruthy();
  }));
});
