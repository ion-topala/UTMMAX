import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { LoginPageStore, LoginPageState } from './login-page.store';

@Injectable()
export class LoginPageQuery extends QueryEntity<LoginPageState> {

  constructor(protected override store: LoginPageStore) {
    super(store);
  }

}
