import {Component, OnInit} from '@angular/core';
import {ActivationStart, ChildActivationStart, Router} from "@angular/router";
import {AppStateService} from "./main/app-state/app-state.service";
import {MatDialog} from "@angular/material/dialog";
import {takeUntil} from "rxjs";
import {BaseComponent} from "./ui-core/base.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent extends BaseComponent implements OnInit{
  title = 'UTMMAX';

  constructor(
    private service: AppStateService,
    private router: Router,
    private dialog: MatDialog,
  ) {
    super();
    this.router.events
      .pipe(
        takeUntil(this.onDestroy$),
      )
      .subscribe((event) => {
        if (event instanceof ActivationStart || event instanceof ChildActivationStart) {
          this.dialog.openDialogs.forEach(it => it.close());
        }
      });
  }

  public ngOnInit(): void {
    this.service.init();
  }
}
