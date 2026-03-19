import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../services/auth.service'; // ← ajustează calea dacă e nevoie
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule], // 👈 Aici e cheia!
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  parola: string = '';
  mesaj: string = '';

constructor(private authService: AuthService, private router: Router) {}

goToResetPassword(event: Event) {
  event.preventDefault();  // previne trimiterea formularului
  this.router.navigate(['/reset-password']);
}
onLogin() {
  this.authService.login(this.email, this.parola).subscribe({
    next: (res: any) => {
      this.mesaj = `Login reușit! Bine ai venit, ${res.nume}`;
      localStorage.setItem('userId', res.id);
      localStorage.setItem('userName', res.nume);
      localStorage.setItem('userEmail', res.email);

//  Notifică aplicația că utilizatorul s-a logat
    
      this.authService.setLoggedIn(true);
      //Redirecționează către dashboard după login
      this.router.navigate(['/contul-meu']);
    },
    error: () => {
      this.mesaj = 'Email sau parolă greșite!';
    }
  });
}

}
