import {Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {ApiService} from "./api.service";
import {UserModel} from "../models/user.models";

@Injectable({
  providedIn: 'root',
})
export class IdentityService {
  private apiUrl = '/identity';

  constructor(private apiService: ApiService) {
  }

  public getUser(): Observable<UserModel> {
    return this.apiService.get<UserModel>(`${this.apiUrl}/me`);
  }

  public getById(id: number): Observable<UserModel> {
    return this.apiService.get(`${this.apiUrl}/${id}`);
  }
}
