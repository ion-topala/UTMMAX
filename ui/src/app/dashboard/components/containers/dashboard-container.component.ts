import {Component, OnInit} from '@angular/core';
import {DashboardStore} from "./state/dashboard.store";
import {DashboardQuery} from "./state/dashboard.query";
import {DashboardService} from "./state/dashboard.service";

@Component({
  template: `
    <app-dashboard-page></app-dashboard-page>`,
  providers:[DashboardStore, DashboardQuery, DashboardService]
})
export class DashboardContainerComponent implements OnInit {
  public ngOnInit(): void {
  }
}
