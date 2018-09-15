import { Component, OnInit } from '@angular/core';
import { LoggingService } from '../services/logging.service';
import { AuthService } from '../services/auth.service';
import { NavigationService } from '../services/navigation.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public email: string;
  public password: string;
  public confirmPassword: string;
  public longOperation = false;

  constructor(private logger: LoggingService,
    private auth: AuthService,
    private navigation: NavigationService) { }

  ngOnInit() {
    this.logger.debug('Initializing LoginComponent');
  }

  public async login() {
    try {
      this.longOperation = true;
      await this.auth.login(this.email, this.password);
      await this.navigation.navigateHome();
    }
    finally {
      this.longOperation = false;
    }
  }
}
