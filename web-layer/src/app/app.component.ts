import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TopMenuComponent } from "./top-menu/top-menu.component";
import { AppSignalrService } from '../services/app-signalR.service';
import { Subscription } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LocalService } from '../services/local.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, TopMenuComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'web-layer';

  isAdminActive: boolean = false;
  activeUsers: number = 0;

  constructor(
    private signalRService: AppSignalrService,
    private jwtHElperService: JwtHelperService,
    private localService: LocalService
  ) { }

  ngOnInit() {
    this.signalRService.activeAdmins$.subscribe(data => this.activeUsers = data);

    var token = this.localService.get(LocalService.AuthTokenName);
    if (token != null) {
      var decodedData = this.jwtHElperService.decodeToken(token);
      if (decodedData.role == "Admin") {
        this.signalRService.join(decodedData.nameid);
      }
    }
  }

  ngOnDestroy() {
    this.signalRService.leave();
  }
}
