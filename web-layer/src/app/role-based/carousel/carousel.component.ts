import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatTableModule} from "@angular/material/table";

export interface PeriodicElement {
  firstName: string;
  secondName: string;
  birthday: Date;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},
  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},
  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},
  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},
  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},
  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},
  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},
  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},

  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},

  {firstName: 'Employee1', secondName: 'Employee1', birthday: new Date(2004,9,16)},

];

@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [MatTableModule, CommonModule],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.scss'
})
export class CarouselComponent {
  displayedColumns: string[] = ['firstName', 'secondName', 'birthday'];
  dataSource = ELEMENT_DATA;
}
