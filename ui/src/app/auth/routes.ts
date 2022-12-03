import {Routes} from "@angular/router";
import {LoginPageContainerComponent} from "./components/containers/login-page-container/login-page-container.component";
import {
  RegisterPageContainerComponent
} from "./components/containers/register-page-container/register-page-container.component";
import {LogoutContainerComponent} from "./components/containers/logout-container/logout-container.component";

export const routes: Routes = [
  {
    path: 'login',
    component: LoginPageContainerComponent
  },
  {
    path: 'register',
    component: RegisterPageContainerComponent
  },
  {
    path: 'logout',
    component: LogoutContainerComponent
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'login'
  }
];
