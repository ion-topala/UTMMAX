import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {
  MovieDetailsContainerComponent
} from './components/containers/movie-details-container/movie-details-container.component';
import {MovieDetailsPageComponent} from './components/presentational/movie-detais-page/movie-details-page.component';
import {RouterModule} from "@angular/router";
import {routes} from "./routes";


@NgModule({
  declarations: [
    MovieDetailsContainerComponent,
    MovieDetailsPageComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ]
})
export class MovieModule {
}
