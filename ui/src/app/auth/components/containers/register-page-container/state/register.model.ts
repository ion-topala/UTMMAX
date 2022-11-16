import {ApiErrorModel} from "../../../../../models/error.models";

export interface RegisterState {
  loading: boolean;
  error: ApiErrorModel | null;
}

export function createInitialState() {
  return {
    loading: false,
    error: null
  } as RegisterState;
}
