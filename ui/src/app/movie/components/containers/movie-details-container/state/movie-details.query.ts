import {Injectable} from "@angular/core";
import {Query, QueryEntity} from "@datorama/akita";
import {MovieDetailsState, MovieDetailsStore} from "./movie-details.store";

@Injectable()
export class MovieDetailsQuery extends QueryEntity<MovieDetailsState> {
  constructor(protected override store: MovieDetailsStore) {
    super(store);
  }
}
