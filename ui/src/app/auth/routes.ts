import {Routes} from "@angular/router";
import {LoginPageContainerComponent} from "./components/containers/login-page-container/login-page-container.component";

export const routes: Routes = [
  {
    path: 'login',
    component: LoginPageContainerComponent
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'login'
  }
];
