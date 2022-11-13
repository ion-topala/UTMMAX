import {Injectable} from "@angular/core";
import {ApiService} from "./api.service";
import {MovieFilterModel, MovieResultModel} from "../models/movie-models";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root',
})
export class AuthApiService {
  public apiUrl = '/identity';

  constructor(private apiService: ApiService) {
  }

  public login(movieFilter: MovieFilterModel): Observable<MovieResultModel[]>{
    return this.apiService.get(this.apiUrl, movieFilter);
  }
}
