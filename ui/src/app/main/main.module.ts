import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {RouterModule} from "@angular/router";
import {routes} from "./routes";
import {MainContainerComponent} from './components/containers/main-container/main-container.component';
import {MainPageComponent} from './components/presentational/main-page/main-page.component';
import {NavBarComponent} from "./components/presentational/nav-bar/nav-bar.component";
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonModule} from "@angular/material/button";


@NgModule({
  declarations: [
    MainContainerComponent,
    MainPageComponent,
    NavBarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    MatToolbarModule,
    MatIconModule,
    MatButtonModule
  ]
})
export class MainModule {
}
