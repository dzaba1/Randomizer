import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FastRandomComponent } from './fast-random/fast-random.component';
import { RandomService } from './services/random.service';
import { AppMaterialsModule } from './app-materials.module';
import { ItemsGroupComponent } from './items-group/items-group.component';
import { DateTimeService } from './services/date-time.service';
import { NavComponent } from './nav/nav.component';
import { LoggingService } from './services/logging.service';
import { RegisterComponent } from './register/register.component';
import { ConfirmValidatorDirective } from './validators/confirm-validator.directive';
import { AuthService } from './services/auth.service';
import { NavigationService } from './services/navigation.service';
import { CookieService } from 'ngx-cookie-service';
import { UserCacheService } from './services/user-cache.service';
import { LoginComponent } from './login/login.component';
import { NotificationService } from './services/notification.service';
import { NotifierModule } from 'angular-notifier';

@NgModule({
  declarations: [
    AppComponent,
    FastRandomComponent,
    ItemsGroupComponent,
    NavComponent,
    RegisterComponent,
    ConfirmValidatorDirective,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    AppMaterialsModule,
    NotifierModule
  ],
  providers: [
    RandomService,
    DateTimeService,
    LoggingService,
    AuthService,
    NavigationService,
    CookieService,
    UserCacheService,
    NotificationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
