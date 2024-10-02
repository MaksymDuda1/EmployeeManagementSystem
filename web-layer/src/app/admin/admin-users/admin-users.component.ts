import { Component, OnInit } from '@angular/core';
import { TableModule } from "primeng/table"
import { UsersTableComponent } from "./users-table/users-table.component";
import { StatisticsComponent } from "../../statistics/statistics.component";
import { ToolbarComponent } from "./toolbar/toolbar.component";

@Component({
  selector: 'app-admin-users',
  standalone: true,
  imports: [TableModule, UsersTableComponent, StatisticsComponent, ToolbarComponent],
  templateUrl: './admin-users.component.html',
  styleUrl: './admin-users.component.scss'
})
export class AdminUsersComponent {
};