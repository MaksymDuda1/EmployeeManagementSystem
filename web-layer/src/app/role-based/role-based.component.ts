import { Component, OnInit } from '@angular/core';
import { LocalService } from '../../services/local.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Role } from '../../enums/role.enum';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-role-based',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './role-based.component.html',
  styleUrl: './role-based.component.scss'
})
export class RoleBasedComponent implements OnInit {
  constructor(private localService: LocalService,private jwtHelperService: JwtHelperService){}

  role: string = '';
  userName: string = '';

  ngOnInit(): void {
    var token = this.localService.get(LocalService.AuthTokenName);
    if(token){
      var decodedData = this.jwtHelperService.decodeToken(token);
        this.userName = decodedData.unique_name;
        this.role = decodedData.role;
      if(this.role === Role.Initial.toString())
        window.location.href = '/waiting-room';
    }
  }
}
