
import { Component, inject, OnInit, ViewEncapsulation } from '@angular/core';
import { Table, TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { DropdownModule } from 'primeng/dropdown';
import { CommonModule, DatePipe } from '@angular/common';
import { UserService } from '../../../../services/user.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PAGE_SIZE_OPTIONS, UserModel } from '../../../../models/user.model';
import { GetUsersModel } from '../../../../models/get-users.model';
import { Role } from '../../../../enums/role.enum';
import { UserStatus } from '../../../../enums/user-status';
import { CalendarModule } from 'primeng/calendar';
import { LocalService } from '../../../../services/local.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { StatisticService } from '../../../../services/statistic.service';
import { Paginator, PaginatorModule } from 'primeng/paginator';
import { UpdateRoleModalComponent } from './update-role-modal/update-role-modal.component';
import { MatFormField, MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatSelect, MatSelectModule } from '@angular/material/select';
import { MatOptionModule } from '@angular/material/core';
import { ExportService } from '../../../../services/export.service';
import { ExportModel } from '../../../../models/export.model';


@Component({
  selector: 'app-users-table',
  standalone: true,
  imports: [FormsModule,
    DatePipe,
    ReactiveFormsModule,
    CalendarModule,
    TableModule, TagModule, DropdownModule,
    CommonModule,
    PaginatorModule,
    FormsModule,
    MatFormFieldModule,
    MatLabel,
    MatSelectModule,
    MatOptionModule,
    UpdateRoleModalComponent],
  templateUrl: './users-table.component.html',
  styleUrl: './users-table.component.scss',
})
export class UsersTableComponent implements OnInit {
  errorMessage = '';
  filterModel: GetUsersModel = new GetUsersModel();
  roles: Role[] = [Role.Employee, Role.Manager, Role.Admin, Role.Initial];
  status: string[] = [UserStatus.Blocked, UserStatus.Unblocked]
  users: UserModel[] = [];
  currentUserId = '';
  pageSizeOptions = PAGE_SIZE_OPTIONS;
  isChangingRole: boolean = false;
  selectedUser = new UserModel();
  exportModel = new ExportModel();

  constructor(
    private userService: UserService,
    private datePipe: DatePipe,
    private statisticSerivice: StatisticService,
    private exportService: ExportService,
    private localService: LocalService,
    private jwtHelperService: JwtHelperService) { }

  setIsLocked(value: string) {
    if (value == UserStatus.Blocked)
      this.filterModel.isLocked = true;
    if(value == UserStatus.Unblocked)
      this.filterModel.isLocked = false;
    else{
      this.filterModel.isLocked = null;
    }

    this.getUsers();
  }

  onExport(exportType: string) {
    if (exportType === 'excel') {
      this.exportAsExcel();
    } else if (exportType === 'csv') {
      this.exportAsCsv();
    }
  }


  exportAsCsv() {
    this.exportModel.users = this.users;
    this.exportService.downloadCsv(this.exportModel);
  }

  exportAsExcel() {
    this.exportModel.users = this.users;
    this.exportService.downloadExcel(this.exportModel);
  }

  onChangeRole(id: string) {
    this.userService.getById(id).subscribe(
      data => {
        this.selectedUser = data;
        this.isChangingRole = true;
      },
      errorResponse => {
        this.errorMessage = errorResponse.error;
      }
    );
  }

  closeModal() {
    this.isChangingRole = false;
    this.selectedUser = new UserModel();
  }

  onMinDateSelect(event: Date) {
    const formattedDate = this.datePipe.transform(event, 'yyyy-MM-dd');
    this.filterModel.minRegistrationDate = formattedDate;
    this.getUsers();
  }

  onMaxDateSelect(event: Date) {
    const formattedDate = this.datePipe.transform(event, 'yyyy-MM-dd');

    this.filterModel.maxRegistrationDate = formattedDate;
    this.getUsers();
  }

  onUserLock(id: string) {
    this.userService.lock(id).subscribe(() => {
      this.getUsers()
    },
      errorResponse => this.errorMessage = errorResponse.error
    );
  }

  onUserUnlock(id: string) {
    this.userService.unlock(id).subscribe(() =>
      this.getUsers(),
      errorResponse => this.errorMessage = errorResponse.error
    );
  }

  onUserDelete(id: string) {
    this.userService.delete(id).subscribe(() =>
      this.users = this.users.filter(u => u.id != id));
  }

  onPageSizeChange(event: any) {
    this.filterModel.pageSize = event.value;
    this.filterModel.page = 1;
    this.getUsers();
  }

  getUsers(event?: any) {
    if (event) {
      this.filterModel.page = event.first / event.rows + 1;
      this.filterModel.pageSize = event.rows;
    }
    this.userService.getAll(this.filterModel).subscribe(data => {
      this.users = data.items
    },
      errorResponse => this.errorMessage = errorResponse);
  }

  ngOnInit() {
    this.getUsers();
    var token = this.localService.get(LocalService.AuthTokenName);
    if (token) {
      var decodedData = this.jwtHelperService.decodeToken(token);
      this.currentUserId = decodedData.nameid;
    }
  };


  clear(table: Table) {
    table.clear();
  }
}
