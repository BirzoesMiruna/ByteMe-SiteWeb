import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent {
  nume: string = '';
  email: string = '';
  subiect: string = '';
  mesaj: string = '';

  trimiteMesaj() {
    console.log('Formular trimis:', {
      nume: this.nume,
      email: this.email,
      subiect: this.subiect,
      mesaj: this.mesaj
    });
    alert('Mesajul a fost trimis cu succes!');
    this.nume = '';
    this.email = '';
    this.subiect = '';
    this.mesaj = '';
  }
}
