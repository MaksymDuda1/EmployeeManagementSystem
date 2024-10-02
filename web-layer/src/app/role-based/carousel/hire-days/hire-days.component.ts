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
  displayedColumns: string[] = ['firstName', 'secondName', 'hireDate'];

  employees: EmployeeModel[] = [];
  errorMessage: string = '';

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.employeeService.getAll().subscribe(
      data => this.employees = this.sortEmployeesByUpcomingHireDate(data),
      errorResponse => this.errorMessage = errorResponse
    );
  }

  private sortEmployeesByUpcomingHireDate(employees: EmployeeModel[]): EmployeeModel[] {
    const today = new Date();
    const currentYear = today.getFullYear();

    return employees.sort((a, b) => {
      const hireDateA = new Date(a.hireDate);
      const hireDateB = new Date(b.hireDate);

      const nextAnniversaryA = new Date(currentYear, hireDateA.getMonth(), hireDateA.getDate());
      const nextAnniversaryB = new Date(currentYear, hireDateB.getMonth(), hireDateB.getDate());

      if (nextAnniversaryA < today) nextAnniversaryA.setFullYear(currentYear + 1);
      if (nextAnniversaryB < today) nextAnniversaryB.setFullYear(currentYear + 1);

      return nextAnniversaryA.getTime() - nextAnniversaryB.getTime();
    }).map(employee => ({
      ...employee,
      daysUntilAnniversary: this.getDaysUntilAnniversary(employee.hireDate)
    }));
  }

  private getDaysUntilAnniversary(hireDate: Date): number {
    const today = new Date();
    const currentYear = today.getFullYear();
    const hireDay = new Date(hireDate);
    
    const nextAnniversary = new Date(currentYear, hireDay.getMonth(), hireDay.getDate());
    
    if (nextAnniversary < today) {
      nextAnniversary.setFullYear(currentYear + 1);
    }
    
    const timeDiff = nextAnniversary.getTime() - today.getTime();
    return Math.ceil(timeDiff / (1000 * 3600 * 24));
  }

}
