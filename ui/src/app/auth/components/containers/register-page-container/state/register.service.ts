import {HttpClient} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {RegisterStore} from './register.store';

@Injectable()
export class RegisterService {

  constructor(private registerStore: RegisterStore, private http: HttpClient) {
  }
}

