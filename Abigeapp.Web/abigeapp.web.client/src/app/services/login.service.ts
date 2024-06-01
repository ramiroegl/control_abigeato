import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Login } from '../models/login';
import { LoginResult } from '../models/loginResult';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private tokenKey = 'session_data';
  constructor(private http: HttpClient) {
  }

  login(login: Login): Observable<LoginResult> {
    return this.http.post<LoginResult>(`/api/usuarios/login`, login);
  }

  saveSession(sessionData: LoginResult): void {
    localStorage.setItem(this.tokenKey, JSON.stringify(sessionData));
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  getSession(): LoginResult | null {
    var sessionDataString = localStorage.getItem(this.tokenKey);
    if (sessionDataString == null) {
      return null;
    }

    return JSON.parse(sessionDataString);
  }

  isLoggedIn(): boolean {
    return this.getSession() !== null;
  }
}

