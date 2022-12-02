import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {StorageService} from "../../../../shared/storage.service";
import {AppStateService} from "../../../../main/app-state/app-state.service";

@Component({
  template: '',
})
export class LogoutContainerComponent implements OnInit {
  constructor(private router: Router, private storageService: StorageService,     private appService: AppStateService,
  ) {
  }

  public ngOnInit(): void {
    this.storageService.clear();
    this.router.navigateByUrl('/')
    this.appService.reset();
  }
}
