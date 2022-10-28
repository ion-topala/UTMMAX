import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {DashboardContainerComponent} from "./components/containers/dashboard-container.component";
import { DashboardPageComponent } from './components/presentational/dashboard-page/dashboard-page.component';
import {SliderCardsComponent} from "./components/presentational/slider-cards/slider-cards.component";
import {RouterModule} from "@angular/router";
import {routes} from "./routes";
import {IvyCarouselModule} from "angular-responsive-carousel";



@NgModule({
  declarations: [
    DashboardContainerComponent,
    DashboardPageComponent,
    SliderCardsComponent
  ],
  exports:[
    DashboardContainerComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    IvyCarouselModule,
  ]
})
export class DashboardModule { }
