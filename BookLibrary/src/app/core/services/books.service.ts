import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../components/book/book.model';
import { map } from 'rxjs';
import { genres } from 'src/app/shared/models/genre.model';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private httpClient: HttpClient) {

  }

  getAllBooks() {
    return this.httpClient.get<Book[]>('/api/books').pipe(
      map(booksData => booksData.map(
        book => ({
          title: book.title,
          author: book.author ? book.author : "Autor necunoscut",
          description: book.description,
          genre: book.genre,
          rating: book.rating,
          pageCount: book.pageCount,
          publishedDate: book.publishedDate
        })
      ))
    );
  }
}
