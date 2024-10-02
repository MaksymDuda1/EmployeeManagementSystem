import { Component, OnDestroy, OnInit } from '@angular/core';
import { AppSignalrService } from '../../services/app-signalR.service';
import { AdminService } from '../../services/admin.service';
import { StatisticModel } from '../../models/statistic.model';
import { error } from 'console';
import { StatisticService } from '../../services/statistic.service';

@Component({
  selector: 'app-statistics',
  standalone: true,
  imports: [],
  templateUrl: './statistics.component.html',
  styleUrl: './statistics.component.scss'
})
export class StatisticsComponent implements OnInit, OnDestroy {
  activeAdmins = 0;
  errorMessage = '';
  static = new StatisticModel();

  constructor(private signalRService: AppSignalrService,
    private statisticService: StatisticService
  ) { }

  ngOnDestroy(): void {
    this.signalRService.activeAdmins$.unsubscribe();
  }

  ngOnInit(): void {
    this.statisticService.getStatistics().subscribe(data =>
      this.static = data,
      errorResponse => this.errorMessage = errorResponse.error);
    this.signalRService.activeAdmins$.subscribe(data => this.activeAdmins = data);
  }

  
}
