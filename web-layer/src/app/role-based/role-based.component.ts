import { Component, OnInit } from '@angular/core';
import { LocalService } from '../../services/local.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CommonModule } from '@angular/common';
import { CarouselComponent } from './carousel/carousel.component';
import { AdminSectionComponent } from './admin-section/admin-section.component';
import { RouterModule } from '@angular/router';
import { ManagerSectionComponent } from "./manager-section/manager-section.component";
import { EmployeeSectionComponent } from "./employee-section/employee-section.component";
import { StatisticsComponent } from "../statistics/statistics.component";

@Component({
  selector: 'app-role-based',
  standalone: true,
  imports: [CommonModule, CarouselComponent, AdminSectionComponent, RouterModule,
    ManagerSectionComponent, EmployeeSectionComponent, StatisticsComponent],
  templateUrl: './role-based.component.html',
  styleUrl: './role-based.component.scss'
})
export class RoleBasedComponent implements OnInit {
  constructor(private localService: LocalService, private jwtHelperService: JwtHelperService) { }

  role: string = '';
  userName: string = '';

  ngOnInit(): void {
    var token = this.localService.get(LocalService.AuthTokenName);
    if (token) {
      var decodedData = this.jwtHelperService.decodeToken(token);
      this.userName = decodedData.unique_name;
      this.role = decodedData.role;
    }
  }
}
