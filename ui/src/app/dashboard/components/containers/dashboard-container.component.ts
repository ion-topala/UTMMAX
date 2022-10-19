import {Component, OnInit} from '@angular/core';

@Component({
  template: `
    <app-dashboard-page></app-dashboard-page>`,
})
export class DashboardContainerComponent implements OnInit{
  ngOnInit(): void {
    console.log("check");
  }
}
