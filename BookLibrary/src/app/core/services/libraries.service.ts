import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, throwError } from 'rxjs';
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

  getById(libraryId: string) {
    return this.httpClient.get<Library>(this.apiUrl + `/byid/${libraryId}`);
  }

  deleteLibrary(id: string): Observable<any> {
    return this.httpClient.delete(`${this.apiUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
