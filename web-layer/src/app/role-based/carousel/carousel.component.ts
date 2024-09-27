import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatTableModule } from "@angular/material/table";
import { HireDaysComponent } from "./hire-days/hire-days.component";
import { EventsComponent } from "./events/events.component";
import { ProjectsComponent } from "./projects/projects.component";

@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [MatTableModule, CommonModule, HireDaysComponent, EventsComponent, ProjectsComponent],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.scss'
})
export class CarouselComponent {

}
