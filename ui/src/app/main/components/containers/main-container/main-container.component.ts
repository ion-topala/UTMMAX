import {Component, OnInit} from '@angular/core';
import {AppStateQuery} from "../../../app-state/app-state.query";
import {UserModel} from "../../../../models/user.models";
import {filter, Observable, Subscription, take, takeUntil} from "rxjs";
import {BaseComponent} from "../../../../ui-core/base.component";
import {AppStateService} from "../../../app-state/app-state.service";
import {AppStateStore} from "../../../app-state/app-state.store";
import {MatDialog} from "@angular/material/dialog";
import {
  SearchContainerComponent
} from "../../../../shared/components/containers/search-container/search-container.component";

@Component({
  template: `
    <app-main-page
      [user]="user$ | async"
      (onSearchBarClick)="tryOpenSmartSearch()"
    >
    </app-main-page>`
})
export class MainContainerComponent extends BaseComponent implements OnInit {

  public user$: Observable<UserModel | null> = this.query.selectUser();
  public smartSearchSubscription: Subscription | null = null;

  constructor(
    private query: AppStateQuery,
    private appStateStore: AppStateStore,
    private dialog: MatDialog,
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
        }
      )
  }

  public tryOpenSmartSearch(): void {
    if (this.smartSearchSubscription != null && !this.smartSearchSubscription.closed) {
      return;
    }

    this.smartSearchSubscription = this.dialog.open(SearchContainerComponent, {
      data: null,
      hasBackdrop: true,
      closeOnNavigation: true,
      panelClass: 'mat-dialog-container-override',
      disableClose: false,
    })
      .afterClosed()
      .subscribe();
  }
}
