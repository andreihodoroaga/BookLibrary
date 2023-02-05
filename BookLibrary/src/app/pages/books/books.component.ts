import { Component, OnInit, OnDestroy } from '@angular/core';
import { BooksService } from 'src/app/core/services/books.service';
import { Book } from 'src/app/core/components/book/book.model';
import { genres } from 'src/app/shared/models/genre.model';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
  books: Book[] = [];

  genres = genres;

  selectedGenre: string = '';

  constructor(private booksService: BooksService) { }

  ngOnInit(): void {
    this.getBooks();
  }
  
  getBooks() {
    this.booksService.getAllBooks().subscribe(responseBooks => {
      this.books = responseBooks;
    })
  }

}
