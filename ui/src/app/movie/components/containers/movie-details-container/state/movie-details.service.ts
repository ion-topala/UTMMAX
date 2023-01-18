import {Injectable} from "@angular/core";
import {setLoading} from "@datorama/akita";
import {setError} from "../../../../../extensions/akita/functions/setError";
import {MoviesApiService} from "../../../../../shared/movies-api.service";
import {MovieDetailsStore} from "./movie-details.store";

@Injectable()
export class MovieDetailsService {
  constructor(
    private store: MovieDetailsStore,
    private movieApiService: MoviesApiService,
  ) {
  }

  public init(movieId: number): void {
    this.movieApiService
      .getById(movieId)
      .pipe(
        setLoading(this.store),
        setError(this.store))
      .subscribe((it) =>
        this.store.update({
          data: it,
        })
      );
  }

  public reload(): void {
  }
}
