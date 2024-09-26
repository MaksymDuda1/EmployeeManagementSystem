import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RegistrationModel } from '../../models/registration.model';
import { LocalService } from '../../services/local.service';
import { CommonModule } from '@angular/common';
import { ApiTokenModel } from '../../models/api-token.model';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent {
  constructor(
    private authService: AuthService,
    private localService: LocalService) { }

  registrationModel: RegistrationModel = new RegistrationModel();
  errorMessage: string = "";

  fb = inject(NonNullableFormBuilder);
  registrationForm = this.fb.group({
    firstName: this.fb.control('', { validators: [Validators.required] }),
    secondName: this.fb.control('', { validators: [Validators.required] }),
    username: this.fb.control('', { validators: [Validators.required] }),
    email: this.fb.control('', { validators: [Validators.required, Validators.email] }),
    password: this.fb.control('', { validators: [Validators.required, Validators.minLength(8)] }),
  });

  onRegistration() {
    if (this.registrationForm.valid) {
      this.authService.registration(this.registrationForm.value).subscribe((tokenModel: ApiTokenModel) => {
        if (tokenModel.accessToken != null) {
          this.localService.put(LocalService.AuthTokenName, tokenModel.accessToken);
          window.location.href = '/waiting-room';
        }
      })
    }
    else {
      this.registrationForm.markAllAsTouched();
    }
  }

  // onRegistration() {
  //   this.authService.registration(this.registrationModel).subscribe((tokenModel: ApiTokenModel) => {
  //     if (tokenModel.accessToken != null) {
  //       this.localService.put(LocalService.AuthTokenName, tokenModel.accessToken);
  //       window.location.href = '/waiting-room';
  //     }
  //   },
  //     (errorResponse: any) => this.errorMessage = errorResponse)
  // }
}