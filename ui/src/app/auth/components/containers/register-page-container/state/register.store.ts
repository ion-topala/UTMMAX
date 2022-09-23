import {Injectable} from '@angular/core';
import {EntityStore, StoreConfig} from '@datorama/akita';
import {createInitialState, RegisterState} from './register.model';


@Injectable()
@StoreConfig({name: 'register'})
export class RegisterStore extends EntityStore<RegisterState> {

  constructor() {
    super(createInitialState());
  }

}
