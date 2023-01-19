import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Author } from 'src/app/shared/models/author.model';

@Injectable({
  providedIn: 'root'
})
export class AuthorsService {
  apiUrl = '/api/authors';

  constructor(private readonly httpClient: HttpClient) { }

  getAuthors() {
    return this.httpClient.get<Author[]>(this.apiUrl).pipe(map(authors => authors.map(
      author => ({
        name: author.name,
        id: author.id
      })
    )));
  }
}
