import {Routes} from "@angular/router";
import {LoginPageContainerComponent} from "./components/containers/login-page-container/login-page-container.component";
import {
  RegisterPageContainerComponent
} from "./components/containers/register-page-container/register-page-container.component";

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
    path: '',
    pathMatch: 'full',
    redirectTo: 'login'
  }
];
