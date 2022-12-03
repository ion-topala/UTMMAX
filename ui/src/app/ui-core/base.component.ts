import {Component, OnDestroy} from '@angular/core';
import {Subject} from 'rxjs';

@Component({
  selector: 'base-component',
  template: '',
})
export class BaseComponent implements OnDestroy {
  protected onDestroy$ = new Subject<void>();

  public ngOnDestroy(): void {
    this.onDestroy$.next();
    this.onDestroy$.complete();
  }
}
