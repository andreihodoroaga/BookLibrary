import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login } from 'src/app/shared/models/login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  apiUrl = '/api/authenticate';

  constructor(private readonly httpClient: HttpClient) { }

  authenticate(loginDetails: Login) {
    return this.httpClient.post<Login>(this.apiUrl + '/authenticate', loginDetails)
  }

}
