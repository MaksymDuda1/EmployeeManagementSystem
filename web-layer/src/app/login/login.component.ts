import { Component, inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { LocalService } from '../../services/local.service';
import { LoginModel } from '../../models/login.model';
import { ApiTokenModel } from '../../models/api-token.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Role } from '../../enums/role.enum';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, NonNullableFormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  loginModel = new LoginModel();
  errorMessage = "";

  constructor(private authService: AuthService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService) { }

  fb = inject(NonNullableFormBuilder);
  loginForm = this.fb.group({
    username: this.fb.control('', { validators: [Validators.required] }),
    email: this.fb.control('', { validators: [Validators.required, Validators.email] }),
    password: this.fb.control('', { validators: [Validators.required, Validators.minLength(8)] }),
  });

  onLogin() {
    if(this.loginForm.valid)
    this.authService.login(this.loginForm.value).subscribe((tokenModel: ApiTokenModel) => {
      if (tokenModel.accessToken != null) {
        this.localService.put(LocalService.AuthTokenName, tokenModel.accessToken);
        var decodedData = this.jwtHelperService.decodeToken(tokenModel.accessToken);


        if (decodedData.role == Role.Initial) {
          window.location.href = 'waiting-room';
          return;
        }

        window.location.href = 'role-based';

        // if(decodedData.role = Role.Admin)
        //   window.location.href = 'admin';
        // if(decodedData = Role.Manager)
        //   window.location.href = 'manager'
        // if(decodedData.role = Role.Employee)
        //   window.location.href = 'employee'
      }
    },
  errorResponse => this.errorMessage = errorResponse.error)
    else{
      this.loginForm.markAllAsTouched();
    }
  }
}
