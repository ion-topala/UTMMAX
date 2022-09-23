import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule} from "@angular/router";
import {routes} from "./routes";
import { MainContainerComponent } from './components/containers/main-container/main-container.component';
import { MainPageComponent } from './components/presentational/main-page/main-page.component';



@NgModule({
  declarations: [
    MainContainerComponent,
    MainPageComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ]
})
export class MainModule { }
