import {Injectable} from '@angular/core';
import {LoginPageStore} from './login-page.store';
import {Observable} from "rxjs";
import {LoginModel, LoginResultModel} from "../../../../../models/user.models";
import {setLoading} from "@datorama/akita";
import {setError} from "../../../../../extensions/akita/functions/setError";
import {AuthService} from "../../../../../auth.service";

@Injectable()
export class LoginPageService {

  constructor(
    private authService: AuthService,
    private store: LoginPageStore) {
  }

  public login(data: LoginModel): Observable<LoginResultModel> {
    return this.authService.login(data).pipe(
      setLoading(this.store),
      setError(this.store));
  }
}
