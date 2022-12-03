import {Injectable} from '@angular/core';
import {Observable, tap} from 'rxjs';
import {ApiService} from "./shared/api.service";
import {StorageService} from "./shared/storage.service";
import * as moment from 'moment';
import {
  LoginByRefreshTokenModel,
  LoginModel,
  LoginResultModel,
  RegisterUserModel,
  UserModel
} from "./models/user.models";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = '/authentication';

  constructor(private apiService: ApiService, private storageService: StorageService) {
  }

  public login(data: LoginModel): Observable<LoginResultModel> {
    return this.apiService.post<LoginResultModel>(`${this.apiUrl}/login`, data).pipe(
      tap((it) => {
        this.setSession(it);
      })
    );
  }

  public register(data: RegisterUserModel): Observable<UserModel> {
    return this.apiService.post<UserModel>(`${this.apiUrl}/register`, data);
  }

  public loginByRefreshToken(data: LoginByRefreshTokenModel): Observable<LoginResultModel> {
    return this.apiService.post<LoginResultModel>(`${this.apiUrl}/login-by-refresh-token`, data,
      {
        headers: {
          'X-Ignore-Refresh-Interceptor': 'true'
        }
      }).pipe(
      tap((it) => {
        this.setSession(it);
      })
    );
  }

  private setSession(authResult: LoginResultModel) {
    this.storageService.setAccessToken(authResult.accessToken);
    this.storageService.setRefreshToken(authResult.refreshToken);
  }

  public isLoggedIn() {
    return moment().isBefore(this.getExpiration());
  }

  getExpiration() {
    const expiration = localStorage.getItem('expires_at');
    // @ts-ignore
    const expiresAt = JSON.parse(expiration);
    return moment(expiresAt);
  }
}
