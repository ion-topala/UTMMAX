import {Component, OnInit} from '@angular/core';
import {AppStateQuery} from "../../../app-state/app-state.query";
import {UserModel} from "../../../../models/user.models";
import {filter, Observable, take, takeUntil} from "rxjs";
import {BaseComponent} from "../../../../ui-core/base.component";

@Component({
  template: `
    <app-main-page
      [user]="user$ | async">
    </app-main-page>`
})
export class MainContainerComponent extends BaseComponent implements OnInit {

  public user$: Observable<UserModel | null> = this.query.selectUser();
  constructor(
    private query: AppStateQuery,
  ) {
    super();
  }

  ngOnInit(): void {
    this.query.sessionIsReady()
      .pipe(
        takeUntil(this.onDestroy$),
        filter(it => it),
        take(1),
      )
      .subscribe(_ => {
        const user = this.query.getUser();
      });
  }

}
