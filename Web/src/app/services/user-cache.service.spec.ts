import { TestBed, inject } from '@angular/core/testing';

import { UserCacheService } from './user-cache.service';

describe('UserCacheService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UserCacheService]
    });
  });

  it('should be created', inject([UserCacheService], (service: UserCacheService) => {
    expect(service).toBeTruthy();
  }));
});
