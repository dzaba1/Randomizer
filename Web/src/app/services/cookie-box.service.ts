import { Injectable } from '@angular/core';
import { CookieCache } from './cookieCache';
import { environment } from '../../environments/environment';
import { CookieService } from 'ngx-cookie-service';
import { LoggingService } from './logging.service';
import { NotificationService, NotificationType } from './notification.service';

@Injectable({
  providedIn: 'root'
})
export class CookieBoxService {

  private cookieCache: CookieCache<boolean>;

  constructor(cookies: CookieService,
    private logger: LoggingService,
    private notificationService: NotificationService) {
    this.cookieCache = new CookieCache<boolean>(environment.cookieBoxName, cookies);
  }

  public checkAndShow() {
    this.logger.debug('Checking the cookie box.');
    this.cookieCache.invalidate();
    if (!this.cookieCache.isStored) {
      this.logger.debug('Displaying the cookie box.');
      this.notificationService.show('Cookies', NotificationType.Default);
      this.cookieCache.save(true);
    }
  }
}
