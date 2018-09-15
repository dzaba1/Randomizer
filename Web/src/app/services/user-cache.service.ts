import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { LoggingService } from './logging.service';
import { UserInfo } from '../model/userInfo';
import { environment } from '../../environments/environment';
import { Require } from '../../utils/require';
import { CookieCache } from './cookieCache';

@Injectable({
  providedIn: 'root'
})
export class UserCacheService {

  private cache: CookieCache<UserInfo>;

  constructor(cookies: CookieService,
    private logger: LoggingService) {
      this.cache = new CookieCache<UserInfo>(environment.userCacheName, cookies);
    }

  public save(data: UserInfo) {
    Require.notNull(data, 'data');
    Require.notNull(data.tokenData, 'data.tokenData');
    Require.notEmptyString(data.tokenData.expires, 'data.tokenData.expires');

    this.logger.debug(`Saving info for user ${data.user.name}`);

    const expires = new Date(data.tokenData.expires);

    this.cache.save(data, expires);
  }

  public get isStored(): boolean {
    return this.cache.isStored;
  }

  public get(): UserInfo {
    this.logger.debug('Getting user info from cookies.');
    return this.cache.get();
  }

  public invalidate() {
    this.logger.debug('Deleting user info from cookies.');
    this.cache.invalidate();
  }
}
