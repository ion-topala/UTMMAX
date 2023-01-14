import {Routes} from "@angular/router";
import {MainContainerComponent} from "./components/containers/main-container/main-container.component";

export const routes: Routes = [
  {
    path: '',
    component: MainContainerComponent,
    children: [
      {
        path: 'movie',
        loadChildren: () => import('src/app/movie/movie.module')
          .then(m => m.MovieModule),
      },
      {
        path: 'auth',
        loadChildren: () => import('src/app/auth/auth.module')
          .then(m => m.AuthModule),
      },
      {
        path: 'dashboard',
        loadChildren: () =>
          import('src/app/dashboard/dashboard.module').then((m) => m.DashboardModule),
      },
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      },
    ]
  }
];
