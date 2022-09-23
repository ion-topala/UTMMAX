import { Injectable } from '@angular/core';
import { EntityState, EntityStore, StoreConfig } from '@datorama/akita';
import {createInitialState, LoginPage} from './login-page.model';

export interface LoginPageState extends EntityState<LoginPage> {}

@Injectable()
@StoreConfig({ name: 'login-page' })
export class LoginPageStore extends EntityStore<LoginPageState> {

  constructor() {
    super(createInitialState);
  }

}
