import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { LocalService } from '../../services/local.service';
import { LoginModel } from '../../models/login.model';
import { ApiTokenModel } from '../../models/api-token.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Role } from '../../enums/role.enum';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  loginModel = new LoginModel();
  errorMessage = "";

  constructor(private authService: AuthService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService) { }

  onLogin(){
    this.authService.login(this.loginModel).subscribe((tokenModel: ApiTokenModel) => {
      if(tokenModel.accessToken != null){
        this.localService.put(LocalService.AuthTokenName, tokenModel.accessToken);

        var decodedData = this.jwtHelperService.decodeToken(tokenModel.accessToken);

        if(decodedData.role = Role.Admin)
          window.location.href = 'admin';
        if(decodedData = Role.Manager)
          window.location.href = 'manager'
        if(decodedData.role = Role.Employee)
          window.location.href = 'employee'
        if(decodedData.role = Role.Initial)
          window.location.href = 'intital'
      }     
    },
  errorResponse => {
    this.errorMessage = errorResponse;
  })
  }
}
