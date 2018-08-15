import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FastRandomComponent } from './fast-random/fast-random.component';
import { RandomService } from './services/random.service';
import { AppMaterialsModule } from './app-materials.module';
import { ItemsGroupComponent } from './items-group/items-group.component';

@NgModule({
  declarations: [
    AppComponent,
    FastRandomComponent,
    ItemsGroupComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    AppMaterialsModule,
  ],
  providers: [
    RandomService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
