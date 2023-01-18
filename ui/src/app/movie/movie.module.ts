import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {
  MovieDetailsContainerComponent
} from './components/containers/movie-details-container/movie-details-container.component';
import {MovieDetailsPageComponent} from './components/presentational/movie-detais-page/movie-details-page.component';
import {RouterModule} from "@angular/router";
import {routes} from "./routes";
import {MatDividerModule} from "@angular/material/divider";
import {FormsModule} from "@angular/forms";
import {SafePipe} from "../shared/pipes/safe.pipe";
import {SharedModule} from "../shared/shared.module";


@NgModule({
  declarations: [
    MovieDetailsContainerComponent,
    MovieDetailsPageComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatDividerModule,
    FormsModule,
    SharedModule
  ]
})
export class MovieModule {
}
