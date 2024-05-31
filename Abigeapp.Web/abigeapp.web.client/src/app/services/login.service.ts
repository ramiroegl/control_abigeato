import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private tokenKey = 'auth_token';
  constructor(private http: HttpClient) {
  }

  login(login: Login): Observable<LoginResult> {
    return this.http.post<LoginResult>(`/api/users/login`, login);
  }

  saveToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  logout(): void {
    localStorage.removeItem(this.tokenKey);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  isLoggedIn(): boolean {
    return this.getToken() !== null;
  }
}

export interface Login {
  email: string;
  password: string;
}

export interface LoginResult {
  user: AuthedUser;
  token: string;
}

export interface AuthedUser {
  id: string;
  name: string;
  lastName: string;
  email: string;
}
