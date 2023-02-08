import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../components/book/book.model';
import { Observable, catchError, map, throwError } from 'rxjs';
import { genres } from 'src/app/shared/models/genre.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {
  apiUrl = '/api/books';

  constructor(private httpClient: HttpClient) {

  }

  getAllBooks() {
    return this.httpClient.get<Book[]>(this.apiUrl).pipe(
      map(booksData => booksData.map(
        book => ({
          title: book.title,
          description: book.description,
          genre: book.genre,
          rating: book.rating,
          pageCount: book.pageCount,
          publishedDate: book.publishedDate,
          authorName: book.authorName
        })
      ))
    );
  }

  addBook(book: Book): Observable<Book> {
    return this.httpClient.post<Book>(this.apiUrl + '/add', book)
      .pipe(
        catchError(this.handleError)
      );
  }

  deleteBook(id: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
