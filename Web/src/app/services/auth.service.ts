import { Injectable } from '@angular/core';
import { Require } from '../../utils/require';
import { LoggingService } from './logging.service';
import { UserInfo } from '../model/userInfo';
import { NamedNavigation } from '../model/navigation';
import { TokenData } from '../model/tokenData';
import { UserCacheService } from './user-cache.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private logger: LoggingService,
    private userCache: UserCacheService) { }

  public async register(email: string, password: string): Promise<UserInfo> {
    Require.notEmptyString(email, 'email');
    Require.notEmptyString(password, 'password');

    this.logger.debug(`Registering ${email}`);
    const mock = this.getMock(email);

    this.userCache.save(mock);
    this.logger.debug(`Registered ${email}`);
    return mock;
  }

  private getMock(email: string): UserInfo {
    const mock = new UserInfo();
    mock.user = new NamedNavigation<number>();
    mock.user.name = email;
    mock.user.id = 1;
    mock.tokenData = new TokenData();

    const expires = new Date();
    expires.setMonth(expires.getMonth() + 1);
    mock.tokenData.expires = expires.toString();
    return mock;
  }

  public get isLogged(): boolean {
    return this.userCache.isStored;
  }

  public async logOut(): Promise<void> {
    this.logger.debug('Logging out');
    this.userCache.invalidate();
    this.logger.debug('Logged out');
  }

  public async login(email: string, password: string): Promise<UserInfo> {
    Require.notEmptyString(email, 'email');
    Require.notEmptyString(password, 'password');

    this.logger.debug(`Logging in ${email}`);
    const mock = this.getMock(email);

    this.userCache.save(mock);
    this.logger.debug(`Logged in ${email}`);
    return mock;
  }
}
