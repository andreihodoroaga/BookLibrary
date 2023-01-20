import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LibrariesRoutingModule } from './libraries-routing.module';
import { LibrariesComponent } from './libraries.component';
import { MatCardModule } from '@angular/material/card';


@NgModule({
  declarations: [LibrariesComponent],
  imports: [
    CommonModule,
    LibrariesRoutingModule,
    MatCardModule
  ]
})
export class LibrariesModule { }
