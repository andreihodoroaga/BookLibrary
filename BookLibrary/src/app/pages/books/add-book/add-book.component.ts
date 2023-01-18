import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { genres } from 'src/app/shared/models/genre.model';

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
    author: new FormControl(''),
    pageCount: new FormControl(0, [Validators.required, Validators.pattern(/^\d+$/)]),
    genre: new FormControl(''),
    rating: new FormControl(0, [Validators.required, Validators.pattern(/^(?:[1-4](?:\.[0-9]{1,2})?|5(?:\.0{1,2})?)$/)]),
    publishedDate: new FormControl<Date | null>(null),
    authorId: new FormControl('')
  })

  constructor() { }

  ngOnInit(): void {
  }

  onSubmit() {
    if (this.addBookForm.invalid)
      return;

    console.log(this.addBookForm.value.title)
  }

}
