import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { LoginPageStore } from './login-page.store';
import {LoginPageState} from "./login-page.model";

@Injectable()
export class LoginPageQuery extends QueryEntity<LoginPageState> {

  constructor(protected override store: LoginPageStore) {
    super(store);
  }

}
