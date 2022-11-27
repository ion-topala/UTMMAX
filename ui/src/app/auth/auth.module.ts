import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from "@angular/router";
import {routes} from "./routes";
import { LoginPageContainerComponent } from './components/containers/login-page-container/login-page-container.component';
import { LoginPageComponent } from './presentational/login-page/login-page.component';
import {MatButtonModule} from "@angular/material/button";
import { RegisterPageContainerComponent } from './components/containers/register-page-container/register-page-container.component';
import { RegisterPageComponent } from './presentational/register-page/register-page.component';
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatSelectModule} from "@angular/material/select";
import {ReactiveFormsModule} from "@angular/forms";
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MatNativeDateModule} from "@angular/material/core";
import {MatInputModule} from "@angular/material/input";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatIconModule} from "@angular/material/icon";
import {LogoutContainerComponent} from "./components/containers/logout-container/logout-container.component";


@NgModule({
  declarations: [
    LoginPageContainerComponent,
    LogoutContainerComponent,
    LoginPageComponent,
    RegisterPageContainerComponent,
    RegisterPageComponent
  ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        MatButtonModule,
        MatSidenavModule,
        MatSelectModule,
        ReactiveFormsModule,
        MatDatepickerModule,
        MatNativeDateModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule
    ]
})
export class AuthModule {
}
