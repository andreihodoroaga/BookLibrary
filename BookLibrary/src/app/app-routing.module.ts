import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'books', loadChildren: () => import('./pages/books/books.module').then(m => m.BooksModule) },
  { path: 'libraries', loadChildren: () => import('./pages/libraries/libraries.module').then(m => m.LibrariesModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }