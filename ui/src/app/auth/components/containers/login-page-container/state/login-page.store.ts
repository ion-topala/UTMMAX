import { Injectable } from '@angular/core';
import { EntityStore, StoreConfig } from '@datorama/akita';
import {createInitialState, LoginPageState} from './login-page.model';

@Injectable()
@StoreConfig({ name: 'login-page' })
export class LoginPageStore extends EntityStore<LoginPageState> {

  constructor() {
    super(createInitialState());
  }

}
