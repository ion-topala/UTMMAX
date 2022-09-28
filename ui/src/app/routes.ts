import {Routes} from "@angular/router";
import {AppComponent} from "./app.component";

export const routes: Routes = [
  {
    path: '',
    component: AppComponent,
    loadChildren: () => import('src/app/main/main.module').then((m) => m.MainModule),
    // canLoad: [LoadMainGuard],
  },
];
