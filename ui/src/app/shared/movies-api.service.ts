import {Injectable} from "@angular/core";
import {ApiService} from "./api.service";
import {MovieFilterModel, MovieResultModel} from "../models/movie-models";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class MoviesApiService {
  public apiUrl = '/movie';

  constructor(private apiService: ApiService) {
  }

  public getTopMovies(movieFilter: MovieFilterModel): Observable<MovieResultModel[]>{
    return this.apiService.get(this.apiUrl, movieFilter);
  }
}
