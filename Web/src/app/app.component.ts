import { Component, OnInit } from '@angular/core';
import { CookieBoxService } from './services/cookie-box.service';
import { LoggingService } from './services/logging.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public title = 'Randomizer';

  constructor(private cookieBox: CookieBoxService,
    private logger: LoggingService) { }

  ngOnInit(): void {
    this.logger.debug('Initializing AppComponent');
    this.cookieBox.checkAndShow();
  }
}
