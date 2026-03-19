import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router'; // AICI e esential

interface Tara {
  id: string; // GUID
  nume: string;
}

interface Reteta {
  id: string;
  titlu: string;
  descriere: string;
  ingrediente: string;
  imagineUrl: string;
}

@Component({
  selector: 'app-retete',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './retete.component.html',
  styleUrls: ['./retete.component.css']
})
export class ReteteComponent implements OnInit {
  tari: Tara[] = [];
  retete: Reteta[] = [];
  taraSelectata: boolean = false;

  constructor(private http: HttpClient) {}
  

  ngOnInit(): void {
    this.loadTari(); // aici începem cu țările
  }

  loadTari() {
    this.http.get<Tara[]>('https://localhost:7133/api/Tari').subscribe(data => {
      console.log(" Tari primite:", data);
      this.tari = data;
    });
  }

  onSelectTara(taraId: string) {
    this.http.get<Reteta[]>(`https://localhost:7133/api/Retete/tara/${taraId}`).subscribe(data => {
      console.log(" Retete pentru tara:", data);
      this.retete = data;
      this.taraSelectata = true;
    });
  }

  backToTari() {
    this.taraSelectata = false;
    this.retete = [];
  }

  getSteagUrl(numeTara: string): string {
    return 'assets/Flags/flags/' + numeTara.toLowerCase().replace(/\s/g, '') + '.png';
  }
}