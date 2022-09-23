import {Component, OnInit} from '@angular/core';
import {RegisterStore} from "./state/register.store";
import {RegisterQuery} from "./state/register.query";
import {RegisterService} from "./state/register.service";
import {Observable} from "rxjs";
import {ApiErrorModel} from "../../../../../models/error.models";

@Component({
  template: `
    <app-register-page
      [loading]="loading$ | async"
      [error]="error$ | async">
    </app-register-page>`,
  providers: [RegisterStore, RegisterQuery, RegisterService]
})
export class RegisterPageContainerComponent implements OnInit {

  public loading$: Observable<boolean> = this.query.selectLoading();
  public error$: Observable<ApiErrorModel> = this.query.selectError<ApiErrorModel>();

  constructor(private query: RegisterQuery) {
  }

  ngOnInit(): void {
  }

}
