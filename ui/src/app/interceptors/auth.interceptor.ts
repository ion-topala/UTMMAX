import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {Injectable} from "@angular/core";
import {catchError, Observable, Subject, switchMap, take, tap, throwError} from "rxjs";
import {Router} from "@angular/router";
import {StorageService} from "../shared/storage.service";
import {LoginByRefreshTokenModel, LoginResultModel} from "../models/user.models";
import {AuthService} from "../auth.service";
import {ApiErrorCodes, ApiErrorModel} from "../models/error.models";
import {hasCode} from "../ui-core/functions/error.functions";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  private isAuthenticationLocked = false;
  private lockEnd = new Subject();

  constructor(
    private storageService: StorageService,
    private authService: AuthService,
    private router: Router
  ) {}

  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (req.headers.has('X-Ignore-Refresh-Interceptor')) {
      const nextReq = req.clone({
        headers: req.headers.delete('X-Ignore-Refresh-Interceptor'),
      });
      console.log('handle X-Ignore');
      return next.handle(nextReq);
    }

    return this.interceptWithAuth(req, next);
  }

  private handleWithRenewal(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.isAuthenticationLocked) {
      console.log('renewal started, Auth is locked.');
      return this.lockEnd.pipe(
        take(1),
        switchMap(() => this.interceptWithAuth(req, next))
      );
    }

    console.log('handle renew access token');
    return this.renewAccessToken().pipe(
      switchMap(() => this.interceptWithAuth(req, next)),
      catchError((error) => {
        // this.router.navigateByUrl('/auth/logout');
        return throwError(() => error);
      })
    );
  }

  private renewAccessToken(): Observable<any> {
    this.isAuthenticationLocked = true;
    return this.authService
      .loginByRefreshToken({
        refreshToken: this.storageService.getRefreshToken(),
      } as LoginByRefreshTokenModel)
      .pipe(
        tap({
          next: (result: LoginResultModel) => {
            this.storageService.setRefreshToken(result.refreshToken);
            this.storageService.setAccessToken(result.accessToken);
            this.notifyLockEnd();
          },
          error: () => {
            this.notifyLockEnd();
          },
          complete: () => {
            this.notifyLockEnd();
          },
        })
      );
  }

  private interceptWithAuth(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const accessToken = this.storageService.getAccessToken();
    const authReq = !!accessToken
      ? req.clone({
          setHeaders: { Authorization: 'Bearer ' + accessToken },
        })
      : req;

    console.log('start handling with auth.');
    return next.handle(authReq).pipe(
      catchError((error: ApiErrorModel) => {
        if (hasCode(error.code, ApiErrorCodes.Unauthorized)) {
          console.log('401 caught.');
          return this.handleWithRenewal(req, next);
        }

        console.log(error.code + ' caught.');
        return throwError(() => error);
      })
    );
  }

  private notifyLockEnd(): void {
    this.isAuthenticationLocked = false;
    this.lockEnd.next(true);
  }
}
