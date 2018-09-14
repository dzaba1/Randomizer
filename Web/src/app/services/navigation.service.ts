import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { LoggingService } from './logging.service';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {

  constructor(private router: Router,
    private logger: LoggingService) { }

  public navigateHome(): Promise<boolean> {
    this.logger.debug('Navigating home.');
    return this.router.navigate(['']);
  }
}
