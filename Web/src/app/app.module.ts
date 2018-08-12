import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FastRandomComponent } from './fast-random/fast-random.component';
import { RandomService } from './services/random.service';
import { AppMaterialsModule } from './app-materials.module';

@NgModule({
  declarations: [
    AppComponent,
    FastRandomComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AppMaterialsModule
  ],
  providers: [
    RandomService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
