import {Routes} from "@angular/router";
import {AppComponent} from "./app.component";

export const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('src/app/auth/auth.module')
      .then(m => m.AuthModule),
  },
  {
    path: '',
    component: AppComponent,
    loadChildren: () => import('src/app/main/main.module').then((m) => m.MainModule),
    // canLoad: [LoadMainGuard],
  },
];
