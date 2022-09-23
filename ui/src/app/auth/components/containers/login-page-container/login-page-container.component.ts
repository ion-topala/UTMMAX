import { Component, OnInit } from '@angular/core';
import {LoginPageStore} from "./state/login-page.store";
import {LoginPageQuery} from "./state/login-page.query";
import {LoginPageService} from "./state/login-page.service";

@Component({
  selector: 'app-login-page-container',
  templateUrl: './login-page-container.component.html',
  styleUrls: ['./login-page-container.component.css'],
  providers: [LoginPageStore, LoginPageQuery, LoginPageService]
})
export class LoginPageContainerComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
