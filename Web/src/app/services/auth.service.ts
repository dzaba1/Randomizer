import { Injectable } from '@angular/core';
import { Require } from '../../utils/require';
import { LoggingService } from './logging.service';
import { UserInfo } from '../model/userInfo';
import { NamedNavigation } from '../model/navigation';
import { TokenData } from '../model/tokenData';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _isLogged = false;

  constructor(private logger: LoggingService) { }

  public async register(email: string, password: string): Promise<UserInfo> {
    Require.notEmptyString(email, 'email');
    Require.notEmptyString(password, 'password');

    this.logger.debug(`Registering ${email}`);
    this._isLogged = true;

    const mock = new UserInfo();
    mock.user = new NamedNavigation<number>();
    mock.user.name = email;
    mock.user.id = 1;
    mock.tokenData = new TokenData();

    this.logger.debug(`Registered ${email}`);
    return mock;
  }

  public get isLogged(): boolean {
    return this._isLogged;
  }

  public async logOut(): Promise<void> {
    this.logger.debug('Logging out');
    this._isLogged = false;
    this.logger.debug('Logged out');
  }
}
