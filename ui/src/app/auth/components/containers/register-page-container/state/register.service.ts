import {Injectable} from '@angular/core';
import {RegisterStore} from './register.store';
import {RegisterUserModel, UserModel} from "../../../../../models/user.models";
import {Observable} from "rxjs";
import {setLoading} from "@datorama/akita";
import {setError} from "../../../../../extensions/akita/functions/setError";
import {AuthService} from "../../../../../auth.service";

@Injectable()
export class RegisterService {

  constructor(private store: RegisterStore, private authService: AuthService) {
  }

  public register(data: RegisterUserModel): Observable<UserModel> {
    return this.authService
      .register(data)
      .pipe(setLoading(this.store), setError(this.store));
  }
}

