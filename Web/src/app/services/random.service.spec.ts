import { TestBed, inject } from '@angular/core/testing';

import { RandomService } from './random.service';

describe('RandomService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RandomService]
    });
  });

  it('should be created', inject([RandomService], (service: RandomService) => {
    expect(service).toBeTruthy();
  }));

  it('#shuffle shouldn\'t modify the collection', () => {
    const service = TestBed.get(RandomService);
    const array = [1, 2, 3];
    service.shuffle(array);
    expect(array.length).toBe(3);
  });

  it ('#next should return correct value on max value provided', () => {
    const service = TestBed.get(RandomService);
    const result = service.next(2, 3);
    expect(result).toBe(2);
  });
});
