import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BooksService } from 'src/app/core/services/books.service';
import { genres } from 'src/app/shared/models/genre.model';
import { Book } from 'src/app/core/components/book/book.model';

@Component({
  selector: 'app-add-book',
  templateUrl: './add-book.component.html',
  styleUrls: ['./add-book.component.scss']
})
export class AddBookComponent implements OnInit {
  /**
   * The array containing the different possible genres.
   */
  genres = genres;

  addBookForm = new FormGroup({
    title: new FormControl(''),
    description: new FormControl(''),
    authorName: new FormControl(''),
    pageCount: new FormControl(0, [Validators.required, Validators.pattern(/^\d+$/)]),
    genre: new FormControl(),
    rating: new FormControl(0, [Validators.required, Validators.pattern(/^(?:[1-4](?:\.[0-9]{1,2})?|5(?:\.0{1,2})?)$/)]),
    publishedDate: new FormControl<Date | null>(null),
  })

  constructor(private readonly booksService: BooksService) { }

  ngOnInit(): void {
  }

  addBook(book: Book) {
    this.booksService.addBook(book).subscribe(response => {
      console.log(response)
    })
  }

  onSubmit() {
    if (this.addBookForm.invalid)
      return;
    
    const newBook: Book = {
      title: this.addBookForm.value.title!,
      description: this.addBookForm.value.description!,
      pageCount: this.addBookForm.value.pageCount!,
      rating: this.addBookForm.value.rating!,
      genre: this.getGenre(this.addBookForm.value.genre!),
      publishedDate: this.addBookForm.value.publishedDate!,
      authorName: this.addBookForm.value.authorName!,
    }
    
    this.addBook(newBook);
  }

  getGenre(genreName: string) {
    return genres.indexOf(genreName);
  }
}
