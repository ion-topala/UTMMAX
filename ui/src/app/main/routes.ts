import {Routes} from "@angular/router";
import {MainContainerComponent} from "./components/containers/main-container/main-container.component";

export const routes: Routes = [
  {
    path: '',
    component: MainContainerComponent,
    children: []
  }
];
