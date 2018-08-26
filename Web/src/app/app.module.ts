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

@NgModule({
  declarations: [
    AppComponent,
    FastRandomComponent,
    ItemsGroupComponent,
    NavComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    AppMaterialsModule,
  ],
  providers: [
    RandomService,
    DateTimeService,
    LoggingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
