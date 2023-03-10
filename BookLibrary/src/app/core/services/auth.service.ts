import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, throwError } from 'rxjs';
import { Login } from 'src/app/shared/models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl = '/api/users';

  constructor(private readonly httpClient: HttpClient) { }

  isLoggedIn() {
    const token = localStorage.getItem('token');
    return token != null;
  }

  logout() {
    localStorage.removeItem('token');
  }

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
      map((response: any) => {
        localStorage.setItem('token', response.token);
      }),
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
