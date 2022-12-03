import {Component} from '@angular/core';
import {LoginPageStore} from "./state/login-page.store";
import {LoginPageQuery} from "./state/login-page.query";
import {LoginPageService} from "./state/login-page.service";
import {ApiErrorModel} from "../../../../models/error.models";
import {Observable} from "rxjs";
import {LoginModel} from "../../../../models/user.models";
import {Router} from "@angular/router";
import {StorageService} from "../../../../shared/storage.service";
import {AppStateService} from "../../../../main/app-state/app-state.service";

@Component({
  template: `
    <app-login-page
      [loading]="loading$ | async"
      [error]="error$ | async"
      (onLogin)="login($event)"
    ></app-login-page>`,
  providers: [LoginPageStore, LoginPageQuery, LoginPageService]
})
export class LoginPageContainerComponent {

  public loading$: Observable<boolean> = this.query.selectLoading();
  public error$: Observable<ApiErrorModel> = this.query.selectError<ApiErrorModel>();

  constructor(
    private query: LoginPageQuery,
    private service: LoginPageService,
    private router: Router,
    private appService: AppStateService,
    private storageService: StorageService,
  ) {
  }

  public ngOnInit(): void {
    this.appService.reset();
    this.storageService.clear();
  }

  public login(event: LoginModel): void {
    this.service.login(event)
      .subscribe(_ => {
        this.router.navigateByUrl('/')
        this.appService.init();
      });
  }
}
