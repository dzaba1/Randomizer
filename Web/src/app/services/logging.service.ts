import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoggingService {

  constructor() { }

  public get debugEnabled(): boolean {
    return !environment.production;
  }

  public debug(message: string): void {
    if (this.debugEnabled) {
      console.log(message);
    }
  }
}
