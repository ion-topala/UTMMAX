import {Injectable} from '@angular/core';
import {QueryEntity} from '@datorama/akita';
import {RegisterStore} from './register.store';
import {RegisterState} from "./register.model";

@Injectable()
export class RegisterQuery extends QueryEntity<RegisterState> {

  constructor(protected override store: RegisterStore) {
    super(store);
  }

}
