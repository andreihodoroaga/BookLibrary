import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LibrariesComponent } from './libraries.component';
import { LibraryComponent } from 'src/app/shared/components/library/library.component';

const routes: Routes = [
  { path: '', component: LibrariesComponent},
  { path: ':id', component: LibraryComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LibrariesRoutingModule { }
