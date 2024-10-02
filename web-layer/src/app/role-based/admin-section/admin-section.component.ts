import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {RouterModule} from "@angular/router"

@Component({
  selector: 'app-admin-section',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './admin-section.component.html',
  styleUrl: './admin-section.component.scss'
})
export class AdminSectionComponent {

}
