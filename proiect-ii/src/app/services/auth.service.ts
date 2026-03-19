import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable ,BehaviorSubject} from 'rxjs';

export interface ResetPasswordRequest {
  email: string;
  token: string;
  newPassword: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7133/api';

  constructor(private http: HttpClient) {}
 private loggedIn = new BehaviorSubject<boolean>(false); // 🟢 inițial false
  loggedIn$ = this.loggedIn.asObservable();
  login(email: string, parola: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/Login`, {
      email: email,
      parola: parola
    });
  }

   resetPassword(request: ResetPasswordRequest): Observable<any> {
    return this.http.post(`${this.apiUrl}/Login/reset-password`, request);
  }

  
    isLoggedIn(): boolean {
    return !!localStorage.getItem('userId');
  }
  setLoggedIn(value: boolean): void {
    this.loggedIn.next(value);
  }
}
