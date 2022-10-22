import {Injectable} from '@angular/core';
import {DashboardStore} from './dashboard.store';
import {MovieFilterModel} from "../../../../models/movie-models";
import {MoviesApiService} from "../../../../shared/movies-api.service";

@Injectable()
export class DashboardService {

  constructor(private store: DashboardStore, private moviesService: MoviesApiService) {
  }

  public getMovies(filter: MovieFilterModel) {
    this.moviesService.getTopMovies(filter)
      .subscribe((it) =>
        this.store.update({
          movies: it,
        })
      );
  }
}
