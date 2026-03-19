import { Component } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService, ResetPasswordRequest } from '../services/auth.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-reset-password',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './reset-password.component.html'
})
export class ResetPasswordComponent {
  resetPasswordForm: any;  // Declarare fără inițializare

  message = '';
  error = '';

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.resetPasswordForm = this.fb.group({  // Inițializare AICI
      email: ['', [Validators.required, Validators.email]],
      token: ['', Validators.required],
      newPassword: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.resetPasswordForm.invalid) return;

    const formValue = this.resetPasswordForm.value;

    const request: ResetPasswordRequest = {
      email: formValue.email!,
      token: formValue.token!,
      newPassword: formValue.newPassword!
    };

    this.authService.resetPassword(request).subscribe({
      next: () => {
        this.message = 'Parola a fost resetată cu succes.';
        this.error = '';
        this.resetPasswordForm.reset();
      },
      error: () => {
        this.error = 'A apărut o eroare la resetarea parolei.';
        this.message = '';
      }
    });
  }
}
