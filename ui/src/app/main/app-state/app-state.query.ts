import { Injectable } from '@angular/core';
import { QueryEntity } from '@datorama/akita';
import { AppStateStore } from './app-state.store';
import {Observable} from "rxjs";
import {UserModel} from "../../../models/user.models";
import {AppState} from "./app-state.model";

@Injectable()
export class AppStateQuery extends QueryEntity<AppState> {

  constructor(protected override store: AppStateStore) {
    super(store);
  }

  public selectUser(): Observable<UserModel | null> {
    return this.select((it) => it.user);
  }

  public sessionIsReady(): Observable<boolean> {
    return this.select((it) => it.sessionReady);
  }

  public getUser(): UserModel | null {
    return this.getValue()?.user;
  }

}
