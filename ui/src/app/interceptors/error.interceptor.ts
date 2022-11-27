import {Injectable} from "@angular/core";
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {catchError, Observable, throwError} from "rxjs";
import {ApiErrorModel} from "../models/error.models";


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError(err => {
          if (err instanceof HttpErrorResponse) {
            return throwError(() => err.error as ApiErrorModel);
          }

          return throwError(() => err);
        })
      );
  }
}
