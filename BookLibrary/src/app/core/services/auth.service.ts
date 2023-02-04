import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { Login } from 'src/app/shared/models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl = '/api/users';

  constructor(private readonly httpClient: HttpClient) { }

  authenticate(loginDetails: Login) {
    return this.httpClient.post<Login>(this.apiUrl + '/authenticate', loginDetails)
  }

  signup(email: string, password: string) {
    return this.httpClient.post(this.apiUrl + '/create-user', {
      username: 'default',
      firstname: 'default',
      lastname: 'default',
      role: 1,
      email: email,
      password: password
    })
  }

  login(email: string, password: string) {
    return this.httpClient.post(this.apiUrl + '/authenticate', {
      username: 'default',
      firstname: 'default',
      lastname: 'default',
      role: 1,
      email: email,
      password: password
    })
    .pipe(
      catchError((errorRes: any) => {
        if (errorRes.status === 400) {
          // Handle bad request
          return throwError(() => new Error('Invalid email or password!'));
        } else {
          // Handle other errors
          return throwError(() => new Error('An error occured!'));
        }
      })
    )
  }
}
