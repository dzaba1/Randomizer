import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatCardModule} from '@angular/material/card';
import {MatListModule} from '@angular/material/list';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';

const MaterialModules = [
  BrowserAnimationsModule,
  MatCardModule,
  MatListModule,
  MatInputModule,
  MatButtonModule
];

@NgModule({
  imports: MaterialModules,
  exports: MaterialModules
})
export class AppMaterialsModule { }
