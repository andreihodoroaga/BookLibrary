import { Pipe, PipeTransform } from '@angular/core';
import { Book } from 'src/app/core/components/book/book.model';
import { genres } from '../models/genre.model';

@Pipe({
  name: 'filterByGenre',
})
export class FilterByGenrePipe implements PipeTransform {

  /**
   * Returns an array of books filtered by genre.
   * If genre is not provided, the entire array is returned.
   */
  transform(books: Book[], genre: string): Book[] {
    if (!genre) {
      return books;
    }

    return books.filter((book) => genres[book.genre] === genre);
  }
}
