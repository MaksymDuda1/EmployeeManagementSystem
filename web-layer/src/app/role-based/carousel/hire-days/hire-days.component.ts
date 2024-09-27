import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { EmployeeModel } from '../../../../models/employee.model';
import { EmployeeService } from '../../../../services/employee.service';

@Component({
  selector: 'app-hire-days',
  standalone: true,
  imports: [MatTableModule, CommonModule],
  templateUrl: './hire-days.component.html',
  styleUrl: './hire-days.component.scss'
})
export class HireDaysComponent {
  displayedColumns: string[] = ['firstName', 'secondName', 'birthday'];

  employees: EmployeeModel[] = [];
  errorMessage: string = '';

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.getAll().subscribe(
      data =>
        this.employees = this.sortEmployeesByHireDate(data),
      errorResponse => this.errorMessage = errorResponse
    );
  }

  private sortEmployeesByHireDate(employees: EmployeeModel[]): EmployeeModel[] {
    const today = new Date();
    const currentMonth = today.getMonth();
    const currentDay = today.getDate();

    return employees.sort((a, b) => {
      const dateA = new Date(a.hireDate);
      const dateB = new Date(b.hireDate);

      const monthA = dateA.getMonth();
      const dayA = dateA.getDate();
      const monthB = dateB.getMonth();
      const dayB = dateB.getDate();

      const diffA = this.getDayDifference(currentMonth, currentDay, monthA, dayA);
      const diffB = this.getDayDifference(currentMonth, currentDay, monthB, dayB);

      return diffA - diffB;
    });
  }

  private getDayDifference(currentMonth: number, currentDay: number, month: number, day: number): number {
    const currentDate = new Date(2000, currentMonth, currentDay);
    let comparisonDate = new Date(2000, month, day);

    if (comparisonDate < currentDate) {
      comparisonDate = new Date(2001, month, day);
    }

    const timeDiff = comparisonDate.getTime() - currentDate.getTime();
    return Math.ceil(timeDiff / (1000 * 3600 * 24));
  }

}
