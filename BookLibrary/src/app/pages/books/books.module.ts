import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BooksRoutingModule } from './books-routing.module';
import { AddBookComponent } from './add-book/add-book.component';
import { BooksComponent } from './books.component';
import { BookComponent } from 'src/app/core/components/book/book.component';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ReactiveFormsModule } from '@angular/forms';
import { FilterByGenrePipe } from 'src/app/shared/pipes/filter-by-genre.pipe';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AddBookComponent,
    BooksComponent,
    BookComponent,
    FilterByGenrePipe
  ],
  imports: [
    CommonModule,
    BooksRoutingModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class BooksModule { }
