import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reteta-detalii',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reteta-detalii.component.html',
  styleUrls: ['./reteta-detalii.component.css']
})
export class RetetaDetaliiComponent {
  retetaId: string | null = null; // <- AICI e definită
  reteta: any;

  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  ngOnInit(): void {
    this.retetaId = this.route.snapshot.paramMap.get('id');
    if (this.retetaId) {
      this.http.get(`https://localhost:7133/api/Retete/${this.retetaId}`)
        .subscribe(data => {
          this.reteta = data;
          console.log('Reteta primită:', data);
        });
    }
  }
}
