import {Component, OnInit} from '@angular/core';
import {LoginPageStore} from "./state/login-page.store";
import {LoginPageQuery} from "./state/login-page.query";
import {LoginPageService} from "./state/login-page.service";
import {ApiErrorModel} from "../../../../../models/error.models";
import {Observable} from "rxjs";

@Component({
  template: `
    <app-login-page
      [loading]="loading$ | async"
      [error]="error$ | async"
    ></app-login-page>`,
  providers: [LoginPageStore, LoginPageQuery, LoginPageService]
})
export class LoginPageContainerComponent implements OnInit {

  public loading$: Observable<boolean> = this.query.selectLoading();
  public error$: Observable<ApiErrorModel> = this.query.selectError<ApiErrorModel>();

  constructor(
    private query: LoginPageQuery
  ) {
  }

  ngOnInit(): void {
  }

}
