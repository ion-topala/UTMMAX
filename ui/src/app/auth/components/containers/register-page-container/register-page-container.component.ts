import {Component, OnInit} from '@angular/core';
import {RegisterStore} from "./state/register.store";
import {RegisterQuery} from "./state/register.query";
import {RegisterService} from "./state/register.service";
import {Observable} from "rxjs";
import {ApiErrorModel} from "../../../../models/error.models";
import {RegisterUserModel} from "../../../../models/user.models";
import {Router} from "@angular/router";
import {StorageService} from "../../../../shared/storage.service";

@Component({
  template: `
    <app-register-page
      [loading]="loading$ | async"
      [error]="error$ | async"
      (onSubmit)="register($event)"
    >
    </app-register-page>`,
  providers: [RegisterStore, RegisterQuery, RegisterService]
})
export class RegisterPageContainerComponent implements OnInit {

  public loading$: Observable<boolean> = this.query.selectLoading();
  public error$: Observable<ApiErrorModel> = this.query.selectError<ApiErrorModel>();

  constructor(
    private query: RegisterQuery,
    private service: RegisterService,
    private router: Router,
    private storageService: StorageService,
  ) {
  }

  ngOnInit(): void {
    this.storageService.clear();
  }

  register(event: RegisterUserModel) {
    this.service.register(event).subscribe(() => {
      this.router.navigate(['/auth/login']);
    });
  }
}
