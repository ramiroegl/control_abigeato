import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

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

export interface Login {
  email: string;
  password: string;
}

export interface LoginResult {
  id: string;
  fincaId: string;
  email: string;
}