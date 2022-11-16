import {Injectable} from '@angular/core';
import {AppStateStore} from './app-state.store';
import {IdentityService} from "../../shared/identity.service";

@Injectable()
export class AppStateService {

  constructor(private store: AppStateStore, private identityService: IdentityService) {
  }

  public reset(): void {
    this.store.reset();
  }

  public init(): void {
    this.store.reset();
    this.identityService.getUser().subscribe((it) =>
      this.store.update({
        user: it,
        sessionReady: true,
      })
    );
  }
}
