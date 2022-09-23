import {Injectable} from '@angular/core';
import {EntityStore, StoreConfig} from '@datorama/akita';
import {AppState, createInitialState} from './app-state.model';


@Injectable()
@StoreConfig({name: 'app-app-state'})
export class AppStateStore extends EntityStore<AppState> {

  constructor() {
    super(createInitialState());
  }

}
