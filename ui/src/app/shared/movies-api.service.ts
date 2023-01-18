import {Injectable} from "@angular/core";
import {ApiService} from "./api.service";
import {MovieDetailsModel, MovieFilterModel, MovieResultModel} from "../models/movie-models";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class MoviesApiService {
  public apiUrl = '/movie';

  constructor(private apiService: ApiService) {
  }

  public getTopMovies(movieFilter: MovieFilterModel): Observable<MovieResultModel[]> {
    return this.apiService.get(this.apiUrl, movieFilter);
  }

  public getById(movieId: number): Observable<MovieDetailsModel> {
    return this.apiService.get(`${this.apiUrl}/${movieId}`);
  }
}
