import {Component, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {StorageService} from "../../../../shared/storage.service";

@Component({
  template: '',
})
export class LogoutContainerComponent implements OnInit {
  constructor(private router: Router, private storageService: StorageService) {
  }

  public ngOnInit(): void {
    this.storageService.clear();
    this.router.navigate(['/dashboard']);
  }
}
