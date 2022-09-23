import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from "@angular/router";
import {routes} from "./routes";
import { LoginPageContainerComponent } from './components/containers/login-page-container/login-page-container.component';
import { LoginPageComponent } from './presentational/login-page/login-page.component';
import {MatButtonModule} from "@angular/material/button";
import { RegisterPageContainerComponent } from './components/containers/register-page-container/register-page-container.component';
import { RegisterPageComponent } from './presentational/register-page/register-page.component';


@NgModule({
  declarations: [
    LoginPageContainerComponent,
    LoginPageComponent,
    RegisterPageContainerComponent,
    RegisterPageComponent
  ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        MatButtonModule
    ]
})
export class AuthModule {
}
