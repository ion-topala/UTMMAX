import {UserModel} from "../../models/user.models";

export interface AppState {
  user: UserModel | null;
  sessionReady: boolean;
}

export function createInitialState(): AppState {
  return {
    sessionReady: false,
    user: null,
  } as AppState;
}
