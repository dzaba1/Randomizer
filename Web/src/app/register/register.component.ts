import { Component, OnInit } from '@angular/core';
import { LoggingService } from '../services/logging.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public email: string;
  public password: string;
  public confirmPassword: string;
  public longOperation = false;

  constructor(private logger: LoggingService) { }

  ngOnInit() {
    this.logger.debug('Initializing RegisterComponent');
  }

  public async register() {
    this.longOperation = true;
  }
}
