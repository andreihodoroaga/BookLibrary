import { Component, OnInit, OnDestroy } from '@angular/core';
import { BooksService } from 'src/app/core/services/books.service';
import { Book } from 'src/app/core/components/book/book.model';
import { genres } from 'src/app/shared/models/genre.model';
import { fromEvent, map, pairwise, switchMap } from 'rxjs';

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

    // Get the click event from the books list
    const bookClick$ = fromEvent(document.querySelectorAll('.book-container'), 'click');

    const selectedBook$ = bookClick$.pipe(
      pairwise(),
      map(([previous, current]) => {
        const previousBook = (previous.target as HTMLElement).dataset['book'];
        const currentBook = (current.target as HTMLElement).dataset['book'];
        return { previous: previousBook, current: currentBook };
      })
    );

    // Subscribe to the selected book stream to log the 
    // previous book and the current book that was clicked
    selectedBook$.subscribe(bookPair => {
      console.log(`Previous book: ${bookPair.previous} Current book: ${bookPair.current}`);
    });
  }
  
  getBooks() {
    this.booksService.getAllBooks().subscribe(responseBooks => {
      this.books = responseBooks;
    })
  }

  // I am using switchMap to ensure that the latest list of books
  // is retrieved from BE after a book is deleted
  deleteBook(bookId: string) {
    this.booksService.deleteBook(bookId)
      .pipe(
        switchMap(() => this.booksService.getAllBooks())
      )
      .subscribe(books => {
        this.books = books;
      });
  }
}
