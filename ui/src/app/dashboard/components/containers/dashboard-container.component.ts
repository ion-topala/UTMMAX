import {Component, OnInit} from '@angular/core';
import {DashboardStore} from "./state/dashboard.store";
import {DashboardQuery} from "./state/dashboard.query";
import {DashboardService} from "./state/dashboard.service";
import {Observable} from "rxjs";
import {ApiErrorModel} from "../../../../models/error.models";
import {MovieResultModel} from "../../../models/movie-models";

@Component({
  template: `
    <app-dashboard-page
    [movies]="movies$ | async"
    [cartoons]="cartoons$ | async"
    ></app-dashboard-page>`,
  providers:[DashboardStore, DashboardQuery, DashboardService]
})
export class DashboardContainerComponent implements OnInit {

  constructor(
    private service: DashboardService,
    private query: DashboardQuery
  ) {
  }

  public error$: Observable<ApiErrorModel> = this.query.selectError<ApiErrorModel>();
  public movies$: Observable<MovieResultModel[]> = this.query.selectMovies();
  public cartoons$: Observable<MovieResultModel[]> = this.query.selectCartoons();

  public ngOnInit(): void {
    this.service.getMovies()
    this.service.getCartoons()
  }
}
