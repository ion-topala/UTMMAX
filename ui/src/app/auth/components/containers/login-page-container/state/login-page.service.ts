import {Injectable} from '@angular/core';
import {LoginPageStore} from './login-page.store';

@Injectable()
export class LoginPageService {

  constructor(private loginPageStore: LoginPageStore) {
  }
}
