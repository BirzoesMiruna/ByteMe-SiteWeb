import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterLink, RouterOutlet, RouterLinkActive } from '@angular/router';
import { AuthService } from './services/auth.service';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    RouterLink,
    RouterOutlet,
    RouterLinkActive
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  userName: string | null = null;

 constructor(private router: Router, private authService: AuthService) {}


  ngOnInit() {
  this.userName = localStorage.getItem('userName');

  // Ascultă schimbări de login
  this.authService.loggedIn$.subscribe(isLogged => {
    if (isLogged) {
      this.userName = localStorage.getItem('userName');
    } else {
      this.userName = null;
    }
  });
}


  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
    this.userName = null;
    this.authService.setLoggedIn(false);
  }

  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }

  openInNewTab(url: string) {
    window.open(url, '_blank');
  }
}
