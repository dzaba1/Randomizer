import { Injectable } from '@angular/core';
import { Require } from '../utils/require';

@Injectable({
  providedIn: 'root'
})
export class RandomService {

  constructor() { }

  public next(from: number, to: number): number {
    Require.notNull(from, 'from');
    Require.notNull(to, 'to');

    if (from >= to) {
      throw new RangeError('\'To\' should be greater than \'from\'.');
    }

    return Math.floor(Math.random() * (to - from) + from);
  }

  public shuffle<T>(collection: T[]) {
    Require.notNull(collection, 'collection');

    for (let i = 0; i < collection.length; i++) {
      const index = this.next(i, collection.length);
      const element = collection[i];
      collection[i] = collection[index];
      collection[index] = element;
    }
  }
}
