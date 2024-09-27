import { Component, Input, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ProjectModel } from '../../../../models/project.model';
import { LocalService } from '../../../../services/local.service';
import { ManagerService } from '../../../../services/manager.service';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { ProjectService } from '../../../../services/project.service';
import { EmployeeService } from '../../../../services/employee.service';

@Component({
  selector: 'app-projects',
  standalone: true,
  imports: [CommonModule, MatTableModule],
  templateUrl: './projects.component.html',
  styleUrl: './projects.component.scss'
})
export class ProjectsComponent implements OnInit {
  
  constructor(private managerService: ManagerService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService,
    private projectService: ProjectService,
    private employeeService: EmployeeService) { }
  projects: ProjectModel[] = [];
  errorMessage: string = '';

  displayedColumns: string[] = ['name', 'customer', 'deadline'];

  ngOnInit(): void {
    var token = this.localService.get(LocalService.AuthTokenName);
    if (token) {
      var decodedData = this.jwtHelperService.decodeToken(token);
      if (decodedData.role == 'Manager') {
        this.managerService.getByUserId(decodedData.nameid).subscribe(data => {
          this.projects = data.projects
        });
      }

      if (decodedData.role == 'Admin') {
        this.projectService.getAll().subscribe(data => {
          this.projects = data
        },
          errorResponse => this.errorMessage = errorResponse.error);
      }

      // if(decodedData.role = "Employee"){
      //   this.employeeService.
      // }
    }
  }
}