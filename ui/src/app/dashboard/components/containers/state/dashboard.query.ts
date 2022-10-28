import {Injectable} from '@angular/core';
import {QueryEntity} from '@datorama/akita';
import {MovieResultModel} from "../../../../models/movie-models";
import {DashboardStore} from "./dashboard.store";
import {DashboardState} from "./dashboard.model";
import {Observable} from "rxjs";

@Injectable()
export class DashboardQuery extends QueryEntity<DashboardState> {

  constructor(protected override store: DashboardStore) {
    super(store);
  }

  public selectMovies(): Observable<MovieResultModel[]> {
    return this.select(store => store.movies)
  }

  public selectCartoons(): Observable<MovieResultModel[]> {
    return this.select(store => store.cartoons)
  }
}
