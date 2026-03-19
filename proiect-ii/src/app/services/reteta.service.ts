import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Reteta {
  id: string;
  titlu: string;
  descriere: string;
  imagineUrl: string;
  ingrediente: string;
}

@Injectable({
  providedIn: 'root'
})
export class RetetaService {
  private apiUrl = 'https://localhost:7133/api/retete';

  constructor(private http: HttpClient) {}

   getRetete(): Observable<Reteta[]> {
    return this.http.get<Reteta[]>(this.apiUrl);
  }

  getRandomRetete(): Observable<Reteta[]> {
  return this.http.get<Reteta[]>('https://localhost:7133/api/Retete/random');
}

}
