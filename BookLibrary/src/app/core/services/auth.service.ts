import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
}
