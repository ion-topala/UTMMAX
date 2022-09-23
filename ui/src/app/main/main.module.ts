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
import {SideNavComponent} from './components/presentational/side-nav/side-nav.component';
import {MatSidenavModule} from "@angular/material/sidenav";
import {MatSelectModule} from "@angular/material/select";


@NgModule({
  declarations: [
    MainContainerComponent,
    MainPageComponent,
    NavBarComponent,
    SideNavComponent,
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
    MatSelectModule
  ]
})
export class MainModule {
}
