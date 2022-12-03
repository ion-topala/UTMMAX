import {Injectable} from '@angular/core';
import {AppStateStore} from './app-state.store';
import {IdentityService} from "../../shared/identity.service";

@Injectable()
export class AppStateService {

  constructor(private store: AppStateStore, private identityService: IdentityService) {
  }

  public reset(): void {
    this.store.reset();

    this.init();
  }

  public init(): void {
    this.store.reset();
    this.identityService.getUser().subscribe({
        next: (it) =>
          this.store.update({
            user: it,
            sessionReady: true,
          }),
        error: () => this.store.update({user: null})
      }
    );
  }
}
