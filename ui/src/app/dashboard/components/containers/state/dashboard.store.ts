import {Injectable} from '@angular/core';
import {EntityState, EntityStore, StoreConfig} from '@datorama/akita';
import {createDashboard, DashboardState} from './dashboard.model';

@Injectable()
@StoreConfig({name: 'dashboard'})
export class DashboardStore extends EntityStore<DashboardState> {

  constructor() {
    super(createDashboard());
  }

}
