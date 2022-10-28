import {Injectable} from '@angular/core';
import {DashboardStore} from './dashboard.store';
import {MovieType} from "../../../../models/movie-models";
import {MoviesApiService} from "../../../../shared/movies-api.service";

@Injectable()
export class DashboardService {

  constructor(private store: DashboardStore, private moviesService: MoviesApiService) {
  }

  public getMovies() {
    let filter = {...this.store.getValue().filter};
    filter.type = MovieType.Movie;

    this.moviesService.getTopMovies(filter)
      .subscribe((it) =>
        this.store.update({
          movies: it,
        })
      );
  }

  public getCartoons() {
    let filter = {...this.store.getValue().filter};
    filter.type = MovieType.Cartoons;

    this.moviesService.getTopMovies(filter)
      .subscribe((it) =>
        this.store.update({
          cartoons: it,
        })
      );
  }
}
