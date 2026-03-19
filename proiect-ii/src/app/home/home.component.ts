import { Component,inject, OnInit } from '@angular/core';
import { RetetaService,Reteta } from '../services/reteta.service';
//import { Reteta } from '../models/reteta.model';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router'; // ✅ Adaugă asta


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  reteteRecomandate: Reteta[] = [];

  //constructor(private retetaService: RetetaService) {}
  private retetaService = inject(RetetaService);

  ngOnInit(): void {
    this.retetaService.getRandomRetete().subscribe(data => {
      this.reteteRecomandate = data;
    });
  }
}
