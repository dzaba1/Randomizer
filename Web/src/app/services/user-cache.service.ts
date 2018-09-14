import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { LoggingService } from './logging.service';
import { UserInfo } from '../model/userInfo';
import { environment } from '../../environments/environment';
import { Require } from '../../utils/require';

@Injectable({
  providedIn: 'root'
})
export class UserCacheService {

  constructor(private cookies: CookieService,
    private logger: LoggingService) { }

  public save(data: UserInfo) {
    Require.notNull(data, 'data');
    Require.notNull(data.tokenData, 'data.tokenData');
    Require.notEmptyString(data.tokenData.expires, 'data.tokenData.expires');

    this.logger.debug(`Saving info for user ${data.user.name}`);

    const expires = new Date(data.tokenData.expires);
    const json = JSON.stringify(data);

    this.cookies.set(environment.userCacheName, json, expires);
  }

  public get isStored(): boolean {
    return this.cookies.check(environment.userCacheName);
  }

  public get(): UserInfo {
    if (!this.isStored) {
      return null;
    }

    this.logger.debug('Getting user info from cookies.');
    const json = this.cookies.get(environment.userCacheName);
    return JSON.parse(json);
  }

  public invalidate() {
    this.logger.debug('Deleting user info from cookies.');
    this.cookies.delete(environment.userCacheName);
  }
}
