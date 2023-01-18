import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {filter, map, Observable, takeUntil} from "rxjs";
import {BaseComponent} from "../../../../ui-core/base.component";
import {MovieDetailsStore} from "./state/movie-details.store";
import {MovieDetailsQuery} from "./state/movie-details.query";
import {MovieDetailsService} from "./state/movie-details.service";
import {MovieDetailsModel} from "../../../../models/movie-models";

@Component({
  template: `
    <app-movie-details-page
      [data]="data$ | async">
    </app-movie-details-page>`,
  providers: [MovieDetailsStore, MovieDetailsQuery, MovieDetailsService]
})
export class MovieDetailsContainerComponent extends BaseComponent implements OnInit {
  public data$: Observable<MovieDetailsModel> = this.query.selectData();

  constructor(
    private route: ActivatedRoute,
    private service: MovieDetailsService,
    private query: MovieDetailsQuery,
  ) {
    super();
  }

  public ngOnInit(): void {
    this.route.paramMap
      .pipe(
        map((it) => Number(it?.get('id'))),
        takeUntil(this.onDestroy$),
        filter((it) => it != null),
      )
      .subscribe((movieId) => {
        this.init(movieId);
      });
  }

  public init(movieId: number): void {
    this.service.init(movieId);
  }

}
