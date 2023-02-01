import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { Library } from 'src/app/shared/models/library.model';

@Injectable({
  providedIn: 'root'
})
export class LibrariesService {
  apiUrl = '/api/libraries';

  constructor(private readonly httpClient: HttpClient) { }

  getLibraries() {
    return this.httpClient.get<Library[]>(this.apiUrl).pipe(map(libraries => libraries.map(
      library => ({
        name: library.name,
        id: library.id
      })
    )));
  }
}
