import {ApiErrorModel} from "../../../../../../models/error.models";

export interface LoginPage {
  loading: boolean;
  error: ApiErrorModel | null;
}

export function createInitialState(): LoginPage {
  return {
    loading: false,
    error: null,
  } as LoginPage;
}
