import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LocalService } from '../../services/local.service';

@Component({
  selector: 'app-top-menu',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './top-menu.component.html',
  styleUrl: './top-menu.component.scss'
})
export class TopMenuComponent {
  constructor(private localService: LocalService){}
}
