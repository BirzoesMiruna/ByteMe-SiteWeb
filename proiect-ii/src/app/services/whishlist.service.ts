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
export class WhishlistService {
  private apiUrl = 'https://localhost:7133/api/Favorite';

  constructor(private http: HttpClient) {}

  // Noul endpoint care returnează direct rețetele favorite
  getReteteFavorite(UtilizatorId: string): Observable<Reteta[]> {
    return this.http.get<Reteta[]>(`${this.apiUrl}/retete-favorite/${UtilizatorId}`);
  }
  removeRetetaFavorite(UtilizatorId: string, retetaId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/remove-retete-favorite/${UtilizatorId}/${retetaId}`);
  }
}
