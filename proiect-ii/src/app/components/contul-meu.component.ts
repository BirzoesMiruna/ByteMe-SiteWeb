import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-contul-meu',
  standalone: true,
  template: `
    <div style="text-align:center; margin-top: 40px;">
      <h2>Contul meu</h2>
      <p><strong>Nume:</strong> {{ userName }}</p>
      <p><strong>Email:</strong> {{ userEmail }}</p>
    </div>
  `
})
export class ContulMeuComponent implements OnInit {
  userName: string | null = null;
  userEmail: string | null = null;
  constructor(private router: Router) {}
ngOnInit(): void {
    this.userName = localStorage.getItem('userName');
    this.userEmail = localStorage.getItem('userEmail');
  }

  logout(): void {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
}
