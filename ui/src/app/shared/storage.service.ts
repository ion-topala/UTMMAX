import {Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StorageService {
  public static accessTokenKey = 'access-token';
  public static refreshTokenKey = 'refresh-token';

  public anyTokens(): boolean {
    return (this.getAccessToken() || this.getRefreshToken()) != null;
  }

  public setAccessToken(token: string): void {
    localStorage.setItem(StorageService.accessTokenKey, token);
  }

  public getAccessToken(): string | null {
    return localStorage.getItem(StorageService.accessTokenKey);
  }

  public setRefreshToken(token: string): void {
    localStorage.setItem(StorageService.refreshTokenKey, token);
  }

  public getRefreshToken(): string | null {
    return localStorage.getItem(StorageService.refreshTokenKey);
  }

  public clear(): void {
    localStorage.removeItem(StorageService.accessTokenKey);
    localStorage.removeItem(StorageService.refreshTokenKey);
  }
}
