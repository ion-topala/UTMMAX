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
import {MatMenuModule} from "@angular/material/menu";
import {MatDividerModule} from "@angular/material/divider";
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatSelectModule} from "@angular/material/select";
import {MatListModule} from "@angular/material/list";
import {SharedModule} from "../shared/shared.module";


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
    MatButtonModule,
    MatMenuModule,
    MatDividerModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatSelectModule,
    MatListModule,
    SharedModule,
  ]
})
export class MainModule {
}
