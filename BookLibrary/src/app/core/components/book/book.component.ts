import { Component, Input, OnInit } from '@angular/core';
import { Book } from './book.model';
import { genres } from 'src/app/shared/models/genre.model';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss']
})
export class BookComponent implements OnInit {
  /**
   * The object containing book info.
   */
  @Input() book!: Book;

  /**
   * The array containing the different possible genres.
   */
  bookGenre = genres[this.book?.genre ? this.book.genre : 0];

  constructor() { }

  ngOnInit(): void {
  }

}
