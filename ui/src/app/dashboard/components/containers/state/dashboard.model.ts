import {ApiErrorModel} from "../../../../../models/error.models";
import {MovieFilterModel, MovieResultModel, MovieType} from "../../../../models/movie-models";

export interface DashboardState {
  loading: boolean;
  error: ApiErrorModel | null;
  filter: MovieFilterModel;
  movies: MovieResultModel[];
}

export function createDashboard(): DashboardState {
  return {
    loading: false,
    error: null,
    filter: {
      limit: 14,
      type: MovieType.Movie
    },
    movies: []
  } as DashboardState;
}
