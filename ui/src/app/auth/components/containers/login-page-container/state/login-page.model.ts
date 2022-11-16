import {ApiErrorModel} from "../../../../../models/error.models";

export interface LoginPageState {
  loading: boolean;
  error: ApiErrorModel | null;
}

export function createInitialState(): LoginPageState {
  return {
    loading: false,
    error: null,
  } as LoginPageState;
}
