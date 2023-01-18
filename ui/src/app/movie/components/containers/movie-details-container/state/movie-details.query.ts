import {Injectable} from "@angular/core";
import {Query, QueryEntity} from "@datorama/akita";
import {MovieDetailsState, MovieDetailsStore} from "./movie-details.store";
import {Observable} from "rxjs";
import {MovieDetailsModel} from "../../../../../models/movie-models";

@Injectable()
export class MovieDetailsQuery extends QueryEntity<MovieDetailsState> {
  constructor(protected override store: MovieDetailsStore) {
    super(store);
  }

  public selectData(): Observable<MovieDetailsModel> {
    return this.select((it) => it.data);
  }
}
