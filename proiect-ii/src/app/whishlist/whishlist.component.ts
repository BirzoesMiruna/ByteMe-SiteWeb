import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { WhishlistService, Reteta } from '../services/whishlist.service';

@Component({
  selector: 'app-whishlist',
  standalone: true,
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule
  ],
  templateUrl: './whishlist.component.html',
  styleUrls: ['./whishlist.component.css']
})
export class WhishlistComponent implements OnInit {
  whishlist: Reteta[] = [];
  // Aici ar trebui să fie tipul corect pentru whishlist
  constructor(private whishlistService: WhishlistService) {}

  ngOnInit(): void {
    const UtilizatorId = localStorage.getItem('userId'); // Înlocuiește cu ID-ul utilizatorului curent
    if (UtilizatorId) {
      this.whishlistService.getReteteFavorite(UtilizatorId).subscribe({
        next: (data: Reteta[]) => {
          this.whishlist = data;
          console.log("Wishlist primite:", data); // Verifică aici în consola din browser
        },
        error: (err) => {
          console.error("Eroare la API:", err);
        }
      });
    } else {
      console.error("UtilizatorId nu a fost găsit în localStorage.");
    }
  }

   stergeDinWishlist(reteta: Reteta): void {
    const UtilizatorId = localStorage.getItem('userId');
    if (UtilizatorId) {
      this.whishlistService.removeRetetaFavorite(UtilizatorId, reteta.id).subscribe({
        next: () => {
          this.whishlist = this.whishlist.filter(r => r.id !== reteta.id);
          console.log("Rețeta a fost ștearsă din wishlist:", reteta);
        },
        error: (err:any) => {
          console.error("Eroare la ștergerea rețetei din wishlist:", err);
        }
      });
    } else {
      console.error("UtilizatorId nu a fost găsit în localStorage.");
    }
  }
}
