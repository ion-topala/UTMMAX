import {MovieDetailsModel, MovieResultModel} from "../../../../../models/movie-models";
import {Injectable} from "@angular/core";
import {EntityStore, Store, StoreConfig} from "@datorama/akita";
import {ApiErrorModel} from "../../../../../models/error.models";

export interface MovieDetailsState {
  loading: boolean;
  error: ApiErrorModel | null;
  data: MovieDetailsModel;
}

export function createInitialState(): MovieDetailsState {
  return {
    data: null,
    loading: false,
    error: null,
  } as MovieDetailsState;
}

@Injectable()
@StoreConfig({name: 'movie-details-store'})
export class MovieDetailsStore extends EntityStore<MovieDetailsState> {
  constructor() {
    super(createInitialState());
  }
}
