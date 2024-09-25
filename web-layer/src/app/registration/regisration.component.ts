import { Component } from '@angular/core';
import { RegistrationModel } from '../../models/registration.model';
import { LocalService } from '../../services/local.service';
import { AuthService } from '../../services/auth.service';
import { ApiTokenModel } from '../../models/api-token.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-regisration',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './regisration.component.html',
  styleUrl: './regisration.component.scss'
})

export class RegistrationComponent {
  constructor(
    private authService: AuthService,
    private localService: LocalService) { }

  registrationModel: RegistrationModel = new RegistrationModel();
  errorMessage: string = "";

  onRegistration() {
    this.authService.registration(this.registrationModel).subscribe((tokenModel: ApiTokenModel) => {
      if(tokenModel.accessToken != null){
        this.localService.put(LocalService.AuthTokenName, tokenModel.accessToken);
        window.location.href = '/waiting-room'; 
      }
    },
      (errorResponse: any) => this.errorMessage = errorResponse)
  }
}