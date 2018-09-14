import { Component, OnInit } from '@angular/core';
import { LoggingService } from '../services/logging.service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  constructor(private logger: LoggingService,
    private auth: AuthService) { }

  ngOnInit() {
    this.logger.debug('Initializing NavComponent');
  }

  public get isLogged(): boolean {
    return this.auth.isLogged;
  }

  public async logOut(): Promise<void> {
    return this.auth.logOut();
  }
}
