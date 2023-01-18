import {Routes} from "@angular/router";
import {
  MovieDetailsContainerComponent
} from "./components/containers/movie-details-container/movie-details-container.component";

export const routes: Routes = [
  {
    path: ':id',
    component: MovieDetailsContainerComponent
  }
];
