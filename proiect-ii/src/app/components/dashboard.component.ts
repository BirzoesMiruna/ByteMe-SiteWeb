import { Component } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  template: `
    <div style="text-align:center; margin-top: 30px;">
      <h2>Bine ai venit în Dashboard!</h2>
      <p>Aici poți vedea conținut doar după login.</p>
    </div>
  `,
  styleUrls: []
})
export class DashboardComponent {}
